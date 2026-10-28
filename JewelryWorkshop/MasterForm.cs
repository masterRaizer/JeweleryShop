using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace JewelryWorkshop
{
    public partial class MasterForm : Form
    {
        public MasterForm()
        {
            InitializeComponent();
        }

        // Загрузка формы: заполняем статусы, металлы с ценами и выводим заявки
        private void MasterForm_Load(object sender, EventArgs e)
        {
            // 1. Наполняем первый список (Фильтр типов заявок)
            cmbRequestFilter.Items.Clear();
            cmbRequestFilter.Items.Add("Изготовление");
            cmbRequestFilter.Items.Add("Ремонт");
            cmbRequestFilter.Items.Add("Скупка");
            cmbRequestFilter.Items.Add("Бронь товаров");
            cmbRequestFilter.SelectedIndex = 0; // По умолчанию показываем Изготовление

            // 2. Наполнили ВТОРОЙ список (Новые статусы для изменения)
            cmbStatuses.Items.Clear();
            using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                connection.Open();
                string query = "SELECT status_name FROM OrderStatuses";
                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cmbStatuses.Items.Add(reader["status_name"].ToString());
                    }
                }
            }
            if (cmbStatuses.Items.Count > 0) cmbStatuses.SelectedIndex = 0;

            // 3. Загружаем таблицу на экран
            LoadRequestsTable();

            // 4. Наполняем список металлов для редактирования цен
            LoadMetalsWithCurrentPrices();

            // 5. ЦВЕТОВАЯ ПАЛИТРА «ШАМПАНЬ» ДЛЯ РАБОЧЕГО МЕСТА МАСТЕРА
            this.BackColor = Color.FromArgb(253, 251, 247); // Нежный кремово-молочный фон формы
            panelCenterCard.BackColor = Color.White;         // Белоснежная центральная карточка

            // Стилизация текстовых меток и заголовков под гамму сепии и золота
            lblTableTitle.ForeColor = Color.FromArgb(184, 134, 11); // Глубокое золото
            lblFilterText.ForeColor = Color.FromArgb(70, 65, 55);
            lblStatusText.ForeColor = Color.FromArgb(70, 65, 55);
            lblCourseText.ForeColor = Color.FromArgb(70, 65, 55);
            lblNewPriceText.ForeColor = Color.FromArgb(70, 65, 55);

            // Текстовое поле ввода цены (делаем пастельным)
            txtNewMetalPrice.BackColor = Color.FromArgb(253, 251, 247);
            txtNewMetalPrice.ForeColor = Color.FromArgb(70, 65, 55);

            // 6. ЮВЕЛИРНАЯ СТИЛИЗАЦИЯ ТАБЛИЦЫ ЗАЯВОК (DataGridView)
            dgvRequests.BackgroundColor = Color.White;
            dgvRequests.BorderStyle = BorderStyle.None;
            dgvRequests.GridColor = Color.FromArgb(240, 235, 225); // Мягкая пастельная сетка

            // Настройка шапки таблицы
            dgvRequests.EnableHeadersVisualStyles = false;
            dgvRequests.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 240, 230); // Цвет шампань
            dgvRequests.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(70, 65, 55);    // Сепия
            dgvRequests.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvRequests.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 240, 230);

            // Настройка ячеек данных
            dgvRequests.DefaultCellStyle.BackColor = Color.White;
            dgvRequests.DefaultCellStyle.ForeColor = Color.FromArgb(70, 65, 55);
            dgvRequests.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            // Цвет выделения строки мастером (мягкий нюдово-бежевый оттенок)
            dgvRequests.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 225, 210);
            dgvRequests.DefaultCellStyle.SelectionForeColor = Color.FromArgb(60, 55, 45);
            dgvRequests.RowHeadersVisible = false; // Убираем левый технический столбец

            // 7. ПРЕМИАЛЬНЫЙ СТИЛЬ И СКРУГЛЕНИЕ КНОПОК ИНТЕРФЕЙСА
            foreach (Control control in this.panelCenterCard.Controls)
            {
                if (control is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Cursor = Cursors.Hand;
                    btn.FlatAppearance.BorderSize = 0; // Полностью убираем дефолтные черные границы

                    // Дифференцированное окрашивание кнопок мастера
                    if (btn.Name == "btnViewImage")
                    {
                        // Просмотр эскиза — изящный кофейно-нюдовый тон с акцентом
                        btn.BackColor = Color.FromArgb(235, 225, 212);
                        btn.ForeColor = Color.FromArgb(120, 90, 40);
                        btn.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
                    }
                    else if (btn.Name == "btnUpdateStatus" || btn.Name == "btnUpdateMetalPrice")
                    {
                        // Кнопки выполнения действий — матовое золото с белым текстом
                        btn.BackColor = Color.FromArgb(184, 134, 11);
                        btn.ForeColor = Color.White;
                        btn.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
                    }
                    else
                    {
                        // Кнопки «В архив», «Открыть архив» и «Выход» — нейтральный благородный нюд
                        btn.BackColor = Color.FromArgb(225, 215, 198);
                        btn.ForeColor = Color.FromArgb(60, 55, 45);
                        btn.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
                    }

                    // Аппаратное скругление углов (Радиус 12)
                    System.Drawing.Drawing2D.GraphicsPath p = new System.Drawing.Drawing2D.GraphicsPath();
                    int r = 12;
                    p.StartFigure();
                    p.AddArc(new Rectangle(0, 0, r, r), 180, 90);
                    p.AddArc(new Rectangle(btn.Width - r, 0, r, r), 270, 90);
                    p.AddArc(new Rectangle(btn.Width - r, btn.Height - r, r, r), 0, 90);
                    p.AddArc(new Rectangle(0, btn.Height - r, r, r), 90, 90);
                    p.CloseFigure();
                    btn.Region = new Region(p);
                }
            }
        }

        // Вспомогательный метод для наполнения комбобокса металлов актуальными курсами
        private void LoadMetalsWithCurrentPrices()
        {
            cmbPriceMetalSelect.Items.Clear();
            using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                connection.Open();
                string query = "SELECT metal_name, price_scrap FROM Metals";
                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string metalName = reader["metal_name"].ToString();
                        double currentPrice = reader["price_scrap"] != DBNull.Value ? Convert.ToDouble(reader["price_scrap"]) : 0;

                        // Формируем красивую строку: Металл (текущая: ХХХ руб/г)
                        cmbPriceMetalSelect.Items.Add($"{metalName} (текущая: {currentPrice:N0} руб/г)");
                    }
                }
            }
            if (cmbPriceMetalSelect.Items.Count > 0) cmbPriceMetalSelect.SelectedIndex = 0;
        }

        // Метод для загрузки данных из SQLite в DataGridView
        private void LoadRequestsTable()
        {
            if (cmbRequestFilter.SelectedItem == null) return;

            dgvRequests.ReadOnly = true;
            dgvRequests.AllowUserToAddRows = false;
            dgvRequests.AllowUserToDeleteRows = false;

            string filter = cmbRequestFilter.SelectedItem.ToString();
            string query = "";

            if (filter == "Изготовление")
            {
                query = @"SELECT 
            MO.id AS [ID], 
            U.login AS [Клиент], 
            MO.contact_data AS [Контакты], 
            MO.date_created AS [Дата], 
            IFNULL(S.status_name, 'Новая') AS [Статус], 
            MO.jewelry_type AS [Изделие], 
            M.metal_name AS [Металл], 
            MO.comments AS [Пожелания/Камни],
            
            CASE 
                WHEN MO.image_path IS NULL OR MO.image_path = '' THEN '❌ Нет эскиза'
                ELSE '📷 Есть эскиз'
            END AS [Наличие эскиза],
            
            IFNULL(MO.image_path, '') AS [image_path]
          FROM ManufacturingOrders MO
          LEFT JOIN Users U ON MO.user_id = U.id
          LEFT JOIN Metals M ON MO.metal_id = M.id
          LEFT JOIN OrderStatuses S ON MO.status_id = S.id
          LEFT JOIN ClientDashboard CD ON CD.order_type = 'Изготовление' AND CD.order_ref_id = MO.id
          WHERE IFNULL(CD.current_status, 'Новая') != 'В архиве'";
            }
            else if (filter == "Ремонт")
            {
                query = @"SELECT 
            RO.id AS [ID], 
            U.login AS [Клиент], 
            RO.contact_data AS [Контакты], 
            RO.date_created AS [Дата], 
            IFNULL(S.status_name, 'Новая') AS [Статус], 
            PL.damage_name AS [Поломка], 
            RO.final_cost AS [Цена, руб]
          FROM RepairOrders RO
          LEFT JOIN Users U ON RO.user_id = U.id
          LEFT JOIN RepairPriceList PL ON RO.repair_price_id = PL.id
          LEFT JOIN OrderStatuses S ON RO.status_id = S.id
          LEFT JOIN ClientDashboard CD ON CD.order_type = 'Ремонт' AND CD.order_ref_id = RO.id
          WHERE IFNULL(CD.current_status, 'Новая') != 'В архиве'";
            }
            else if (filter == "Скупка")
            {
                query = @"SELECT
SD.id AS [ID],
U.login AS [Клиент],
SD.contact_data AS [Контакты],
SD.date_created AS [Дата],
'Выплачено' AS [Статус],
M.metal_name AS [Металл лома],
SD.weight AS [Вес, г],
SD.total_payout AS [Выплата, руб]
FROM ScrapDeals SD
LEFT JOIN Users U ON SD.user_id = U.id
LEFT JOIN Metals M ON SD.metal_id = M.id
LEFT JOIN ClientDashboard CD ON CD.order_type = 'Скупка' AND CD.order_ref_id = SD.id
WHERE IFNULL(CD.current_status, 'Выплачено') != 'В архиве'";
            }
            else if (filter == "Бронь товаров")
            {
                query = @"SELECT
CD.id AS [ID],
U.login AS [Клиент],
CD.contact_data AS [Контакты],
CD.date_added AS [Дата бронирования],
CASE CAST(CD.order_ref_id AS TEXT)
WHEN '1' THEN 'Браслет с топазами и бриллиантами'
WHEN '2' THEN 'Обручальное кольцо переплетенное'
WHEN '3' THEN 'Кулон с розовым топазом'
WHEN '4' THEN 'Кольцо с большим аквамарином'
WHEN '5' THEN 'Длинные серьги Аристократ'
WHEN '6' THEN 'Кольцо-солитер Розовое сияние'
WHEN '7' THEN 'Брошь-булавка Колибри'
WHEN '8' THEN 'Классический солитер Минимализм'
ELSE 'Товар из каталога'
END AS [Забронированное изделие],
CASE CAST(CD.order_ref_id AS TEXT)
WHEN '1' THEN '195 000 руб.'
WHEN '2' THEN '68 900 руб.'
WHEN '3' THEN '42 000 руб.'
WHEN '4' THEN '125 000 руб.'
WHEN '5' THEN '275 000 руб.'
WHEN '6' THEN '160 000 руб.'
WHEN '7' THEN '420 000 руб.'
WHEN '8' THEN '95 000 руб.'
ELSE 'Цена в каталоге'
END AS [Стоимость товара],
CD.current_status AS [Статус]
FROM ClientDashboard CD
LEFT JOIN Users U ON CD.user_id = U.id
WHERE CD.order_type = 'Бронь' AND CD.current_status != 'В архиве'";
            }
            using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                connection.Open();
                using (var adapter = new SQLiteDataAdapter(query, connection))
                {
                    System.Data.DataTable dataTable = new System.Data.DataTable();
                    adapter.Fill(dataTable);
                    dgvRequests.DataSource = dataTable;
                    dgvRequests.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dgvRequests.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            if (dgvRequests.Columns.Contains("image_path"))
            {
                dgvRequests.Columns["image_path"].Visible = false;
            }
        }
        // КНОПКА: ОТКРЫТИЕ ЭСКИЗА В ОТДЕЛЬНОМ ОКНЕ С ВАЛИДАЦИЕЙ ОТСУТСТВИЯ
        private void btnViewImage_Click(object sender, EventArgs e)
        {
            if (dgvRequests.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите заявку в таблице!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!dgvRequests.Columns.Contains("image_path"))
            {
                MessageBox.Show("Просмотр эскизов доступен исключительно для заявок на Изготовление украшений!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            object pathObj = dgvRequests.CurrentRow.Cells["image_path"].Value;
            if (pathObj == null || string.IsNullOrEmpty(pathObj.ToString().Trim()))
            {
                MessageBox.Show("Данный клиент оформил заказ без прикрепления фотографии.\n\nЭскиз отсутствует (не приложен)!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string imgPath = pathObj.ToString();
            try
            {
                Form imageForm = new Form();
                imageForm.Size = new Size(700, 700);
                imageForm.Text = $"Просмотр эскиза к заказу №{dgvRequests.CurrentRow.Cells["ID"].Value}";
                imageForm.StartPosition = FormStartPosition.CenterParent;
                imageForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                imageForm.MaximizeBox = false;
                PictureBox picBox = new PictureBox();
                picBox.Dock = DockStyle.Fill;
                // Копируем картинку в память, чтобы не блокировать файл эскиза на диске
                using (Image img = Image.FromFile(imgPath))
                {
                    picBox.Image = new Bitmap(img);
                }
                picBox.SizeMode = PictureBoxSizeMode.Zoom;
                imageForm.Controls.Add(picBox);
                imageForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось прочитать или найти файл эскиза по указанному пути:\n{imgPath}\n\nВозможно, файл был перемещен или удален. Ошибка: {ex.Message}",
                "Ошибка открытия файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // Кнопка "Обновить статус" С СКВОЗНОЙ ПОДДЕРЖКОЙ ИСПРАВЛЕНИЯ БРОНИ
        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (dgvRequests.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите заявку в таблице мышкой!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbStatuses.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите новый статус из списка!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string filter = cmbRequestFilter.SelectedItem.ToString();
            if (filter == "Скупка")
            {
                MessageBox.Show("Сделки по скупке лома проводятся мгновенно, их статус нельзя изменить!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string requestId = dgvRequests.CurrentRow.Cells["ID"].Value.ToString();
            string newStatus = cmbStatuses.SelectedItem.ToString();
            if (filter == "Бронь товаров")
            {
                using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
                {
                    connection.Open();
                    string updateDashboardQuery = "UPDATE ClientDashboard SET current_status = @statusName WHERE id = @id";
                    using (var cmd = new SQLiteCommand(updateDashboardQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@statusName", newStatus);
                        cmd.Parameters.AddWithValue("@id", requestId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show($"Статус брони №{requestId} успешно изменен на '{newStatus}'!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRequestsTable();
                return;
            }
            using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int statusId = 1;
                        string statusQuery = "SELECT id FROM OrderStatuses WHERE status_name = @name";
                        using (var cmd = new SQLiteCommand(statusQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@name", newStatus);
                            object res = cmd.ExecuteScalar();
                            if (res != null) statusId = Convert.ToInt32(res);
                        }
                        string targetTable = "";
                        if (filter == "Изготовление") targetTable = "ManufacturingOrders";
                        else if (filter == "Ремонт") targetTable = "RepairOrders";
                        string updateOrderQuery = $"UPDATE {targetTable} SET status_id = @statusId WHERE id = @id";
                        using (var cmd = new SQLiteCommand(updateOrderQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@statusId", statusId);
                            cmd.Parameters.AddWithValue("@id", requestId);
                            cmd.ExecuteNonQuery();
                        }
                        string updateDashboardQuery = @"UPDATE ClientDashboard
SET current_status = @statusName
WHERE order_type = @orderType AND order_ref_id = @refId";
                        using (var cmd = new SQLiteCommand(updateDashboardQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@statusName", newStatus);
                            cmd.Parameters.AddWithValue("@orderType", filter);
                            cmd.Parameters.AddWithValue("@refId", requestId);
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        MessageBox.Show($"Статус заявки №{requestId} успешно изменен на '{newStatus}'!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadRequestsTable();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Ошибка при обновлении статуса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        // Кнопка "Выйти из аккаунта"
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmbRequestFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRequestsTable();
        }
        // Кнопка "Перенести в архив" С СКВОЗНОЙ ПОДДЕРЖКОЙ ИСПРАВЛЕНИЯ БРОНИ
        private void btnArchiveOrder_Click(object sender, EventArgs e)
        {
            if (dgvRequests.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите заявку в таблице для архивации!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string filter = cmbRequestFilter.SelectedItem.ToString();
            string requestId = dgvRequests.CurrentRow.Cells["ID"].Value.ToString();
            if (filter != "Бронь товаров")
            {
                string currentStatus = dgvRequests.CurrentRow.Cells["Статус"].Value.ToString();
                if (currentStatus == "Новая" || currentStatus == "В_Работе")
                {
                    MessageBox.Show("Нельзя архивировать активные заказы! Сначала завершите работу или отклоните заявку.",
                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            DialogResult dialogResult = MessageBox.Show($"Вы точно хотите перенести заявку №{requestId} в архив?",
            "Подтверждение архивации", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
                {
                    connection.Open();
                    string archiveQuery = "";
                    if (filter == "Бронь товаров")
                    {
                        archiveQuery = "UPDATE ClientDashboard SET current_status = 'В архиве' WHERE id = @refId";
                    }
                    else
                    {
                        archiveQuery = "UPDATE ClientDashboard SET current_status = 'В архиве' WHERE order_type = @orderType AND order_ref_id = @refId";
                    }
                    using (var cmd = new SQLiteCommand(archiveQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@orderType", filter == "Бронь товаров" ? "Бронь" : filter);
                        cmd.Parameters.AddWithValue("@refId", requestId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show($"Заявка №{requestId} успешно заархивирована!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRequestsTable();
            }
        }
        // Кнопка открытия Архива
        private void btnOpenArchive_Click(object sender, EventArgs e)
        {
            ArchiveForm archiveForm = new ArchiveForm();
            archiveForm.ShowDialog();
            LoadRequestsTable();
        }
        // Кнопка "Обновить курс металлов"
        private void btnUpdateMetalPrice_Click(object sender, EventArgs e)
        {
            if (cmbPriceMetalSelect.SelectedItem == null) return;
            string selectedText = cmbPriceMetalSelect.SelectedItem.ToString();
            string selectedMetal = selectedText.Split('(')[0].Trim();
            string priceText = txtNewMetalPrice.Text.Trim().Replace(",", ".");
            if (!double.TryParse(priceText, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double newPrice) || newPrice <= 0)
            {
                MessageBox.Show("Пожалуйста, введите корректную цену за грамм (положительное число)!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE Metals SET price_scrap = @newPrice WHERE metal_name = @metalName";
                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@newPrice", newPrice);
                    command.Parameters.AddWithValue("@metalName", selectedMetal);
                    command.ExecuteNonQuery();
                }
            }
            MessageBox.Show($"Курс скупки для '{selectedMetal}' успешно обновлен до {newPrice} руб/г!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNewMetalPrice.Text = "";
            LoadMetalsWithCurrentPrices();
            LoadRequestsTable();
        }
        private void MasterForm_Load_1(object sender, EventArgs e)
        {
        }
    }
}