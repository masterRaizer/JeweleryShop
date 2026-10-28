using System;
using System.Data.SQLite;
using System.IO;

namespace JewelryWorkshop
{
    public static class DatabaseManager
    {
        private static readonly string DbFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "workshop.db");

        // Foreign Keys=True — включаем проверку внешних ключей (в SQLite по умолчанию она выключена,
        // из-за чего ON DELETE CASCADE и ссылочная целостность не работали)
        public static string ConnectionString = $"Data Source={DbFilePath};Version=3;Foreign Keys=True;";

        public static void InitializeDatabase()
        {
            // Проверяем наличие файла по абсолютному пути
            if (!File.Exists(DbFilePath))
            {
                SQLiteConnection.CreateFile(DbFilePath);

                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();

                    // Создаем справочные таблицы
                    ExecuteNonQuery("CREATE TABLE Roles (id INTEGER PRIMARY KEY AUTOINCREMENT, role_name TEXT NOT NULL UNIQUE);", connection);
                    ExecuteNonQuery("CREATE TABLE OrderStatuses (id INTEGER PRIMARY KEY AUTOINCREMENT, status_name TEXT NOT NULL UNIQUE);", connection);
                    ExecuteNonQuery("CREATE TABLE Metals (id INTEGER PRIMARY KEY AUTOINCREMENT, metal_name TEXT NOT NULL UNIQUE, price_scrap REAL, price_work REAL);", connection);
                    ExecuteNonQuery("CREATE TABLE Gems (id INTEGER PRIMARY KEY AUTOINCREMENT, gem_name TEXT NOT NULL UNIQUE, price_unit REAL);", connection);
                    ExecuteNonQuery("CREATE TABLE RepairPriceList (id INTEGER PRIMARY KEY AUTOINCREMENT, damage_name TEXT NOT NULL UNIQUE, cost REAL, repair_time TEXT);", connection);

                    // 1. Таблица пользователей
                    ExecuteNonQuery(@"CREATE TABLE Users (
                                id INTEGER PRIMARY KEY AUTOINCREMENT,
                                login TEXT NOT NULL UNIQUE,
                                password TEXT NOT NULL,
                                role_id INTEGER,
                                FOREIGN KEY(role_id) REFERENCES Roles(id) ON DELETE CASCADE);", connection);

                    // 2. Усовершенствованная таблица Изготовления (добавлен ON DELETE CASCADE)
                    ExecuteNonQuery(@"CREATE TABLE ManufacturingOrders (
                                id INTEGER PRIMARY KEY AUTOINCREMENT, user_id INTEGER, jewelry_type TEXT,
                                metal_id INTEGER, gem_id INTEGER, comments TEXT, status_id INTEGER,
                                date_created TEXT, contact_data TEXT, image_path TEXT,
                                FOREIGN KEY(user_id) REFERENCES Users(id) ON DELETE CASCADE,
                                FOREIGN KEY(metal_id) REFERENCES Metals(id),
                                FOREIGN KEY(gem_id) REFERENCES Gems(id),
                                FOREIGN KEY(status_id) REFERENCES OrderStatuses(id));", connection);

                    // 3. Усовершенствованная таблица Ремонта (добавлен ON DELETE CASCADE)
                    ExecuteNonQuery(@"CREATE TABLE RepairOrders (
                                id INTEGER PRIMARY KEY AUTOINCREMENT, user_id INTEGER, repair_price_id INTEGER,
                                status_id INTEGER, date_created TEXT, contact_data TEXT, final_cost REAL,
                                FOREIGN KEY(user_id) REFERENCES Users(id) ON DELETE CASCADE,
                                FOREIGN KEY(repair_price_id) REFERENCES RepairPriceList(id),
                                FOREIGN KEY(status_id) REFERENCES OrderStatuses(id));", connection);

                    // 4. Усовершенствованная таблица Скупки (добавлен ON DELETE CASCADE)
                    ExecuteNonQuery(@"CREATE TABLE ScrapDeals (
                                id INTEGER PRIMARY KEY AUTOINCREMENT, user_id INTEGER, metal_id INTEGER,
                                weight REAL, total_payout REAL, date_created TEXT, contact_data TEXT,
                                FOREIGN KEY(user_id) REFERENCES Users(id) ON DELETE CASCADE,
                                FOREIGN KEY(metal_id) REFERENCES Metals(id));", connection);

                    // 5. Усовершенствованная таблица Журнала/Dashboard (добавлен ON DELETE CASCADE)
                    ExecuteNonQuery(@"CREATE TABLE ClientDashboard (
                                id INTEGER PRIMARY KEY AUTOINCREMENT, user_id INTEGER, order_type TEXT,
                                order_ref_id INTEGER, date_added TEXT, current_status TEXT, contact_data TEXT,
                                FOREIGN KEY(user_id) REFERENCES Users(id) ON DELETE CASCADE);", connection);

                    // Создание индексов для оптимизации (Пункт №2)
                    ExecuteNonQuery("CREATE INDEX IF NOT EXISTS idx_users_login ON Users(login);", connection);
                    ExecuteNonQuery("CREATE INDEX IF NOT EXISTS idx_dashboard_user ON ClientDashboard(user_id);", connection);
                    ExecuteNonQuery("CREATE INDEX IF NOT EXISTS idx_manufacturing_user ON ManufacturingOrders(user_id);", connection);
                    ExecuteNonQuery("CREATE INDEX IF NOT EXISTS idx_repair_user ON RepairOrders(user_id);", connection);
                    ExecuteNonQuery("CREATE INDEX IF NOT EXISTS idx_manufacturing_status ON ManufacturingOrders(status_id);", connection);
                    ExecuteNonQuery("CREATE INDEX IF NOT EXISTS idx_repair_status ON RepairOrders(status_id);", connection);

                    // Первичное заполнение справочников
                    ExecuteNonQuery("INSERT INTO Roles (role_name) VALUES ('Мастер'), ('Пользователь');", connection);
                    ExecuteNonQuery("INSERT INTO OrderStatuses (status_name) VALUES ('Новая'), ('В_Работе'), ('Готова_к_выдаче'), ('Отклонена');", connection);
                    ExecuteNonQuery("INSERT INTO Metals (metal_name, price_scrap, price_work) VALUES ('Золото 585', 3500, 5000), ('Золото 750', 4500, 6500), ('Серебро 925', 80, 200), ('Платина 950', 5000, 8000);", connection);
                    ExecuteNonQuery("INSERT INTO Gems (gem_name, price_unit) VALUES ('Без камней', 0), ('Фианит', 300), ('Топаз', 2500), ('Бриллиант', 15000);", connection);
                    ExecuteNonQuery("INSERT INTO RepairPriceList (damage_name, cost, repair_time) VALUES ('Пайка цепи/браслета', 1500, '1-2 дня'), ('Закрепка/вставка камня', 3000, '2-3 дня'), ('Увеличение/уменьшение кольца', 2000, 'от 3 часов'), ('Ультразвуковая чистка и полировка', 1000, '3-5 дней');", connection);

                    // Мастер по умолчанию (пароль 1234 захеширован)
                    ExecuteNonQuery("INSERT INTO Users (login, password, role_id) VALUES ('master', '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4', 1);", connection);
                }
            }

            // Доводим структуру уже существующей базы до актуальной версии.
            // Раньше эти колонки добавлялись только при открытии форм клиента, и если мастер
            // заходил первым, запрос к ManufacturingOrders.image_path падал с ошибкой.
            UpgradeDatabase();
        }

        private static void UpgradeDatabase()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                // А. Колонка с путём к эскизу в заявках на изготовление
                AddColumnIfMissing("ManufacturingOrders", "image_path", "TEXT", connection);

                // Б. Колонка со сроком выполнения в прайс-листе ремонта
                if (AddColumnIfMissing("RepairPriceList", "repair_time", "TEXT", connection))
                {
                    ExecuteNonQuery("UPDATE RepairPriceList SET repair_time = '1-2 дня' WHERE id = 1", connection);
                    ExecuteNonQuery("UPDATE RepairPriceList SET repair_time = '2-3 дня' WHERE id = 2", connection);
                    ExecuteNonQuery("UPDATE RepairPriceList SET repair_time = 'от 3 часов' WHERE id = 3", connection);
                    ExecuteNonQuery("UPDATE RepairPriceList SET repair_time = '3-5 дней' WHERE id = 4", connection);
                    ExecuteNonQuery("UPDATE RepairPriceList SET repair_time = '2-4 дня' WHERE repair_time IS NULL", connection);
                }

                // В. Колонка с телефоном в журнале (нужна для брони товаров из каталога)
                AddColumnIfMissing("ClientDashboard", "contact_data", "TEXT", connection);

                // Г. Дополнительные камни для заявок на изготовление (без дублей)
                string[] newGems = { "Изумруд", "Гранат", "Рубин", "Сапфир", "Янтарь", "Аметист", "Цитрин", "Жемчуг" };
                foreach (string gem in newGems)
                {
                    using (var cmd = new SQLiteCommand("INSERT OR IGNORE INTO Gems (gem_name) VALUES (@gemName)", connection))
                    {
                        cmd.Parameters.AddWithValue("@gemName", gem);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        // Добавляет колонку, если её ещё нет. Возвращает true, если колонка была добавлена
        private static bool AddColumnIfMissing(string table, string column, string type, SQLiteConnection conn)
        {
            using (var cmd = new SQLiteCommand($"PRAGMA table_info({table})", conn))
            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader["name"].ToString() == column) return false;
                }
            }

            ExecuteNonQuery($"ALTER TABLE {table} ADD COLUMN {column} {type}", conn);
            return true;
        }

        private static void ExecuteNonQuery(string sql, SQLiteConnection conn)
        {
            using (var cmd = new SQLiteCommand(sql, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
