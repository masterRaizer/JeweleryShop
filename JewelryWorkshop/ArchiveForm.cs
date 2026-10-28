using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace JewelryWorkshop
{
    public partial class ArchiveForm : Form
    {
        public ArchiveForm()
        {
            InitializeComponent();
        }

        private void ArchiveForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            // 1. Запускаем метод загрузки заархивированных строк
            LoadArchiveTable();

            // 2. ЦВЕТОВАЯ ПАЛИТРА «ШАМПАНЬ» ДЛЯ ВСЕЙ ФОРМЫ АРХИВА
            this.BackColor = Color.FromArgb(253, 251, 247); // Нежный кремово-молочный фон приложения
            panelCenterCard.BackColor = Color.White;         // Белоснежная центральная карточка

            // Стилизация главного заголовка
            lblTitle.ForeColor = Color.FromArgb(184, 134, 11); // Глубокое премиальное золото

            // 3. ПРЕМИАЛЬНЫЙ СТИЛЬ И СКРУГЛЕНИЕ КНОПОК
            // ИСПРАВЛЕНО: ищем кнопки внутри panelCenterCard, так как они лежат на ней
            foreach (Control control in this.panelCenterCard.Controls)
            {
                if (control is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Cursor = Cursors.Hand;
                    btn.FlatAppearance.BorderSize = 0; // Убираем стандартные рамки

                    // Цветовые решения для кнопок
                    if (btn.Name == "btnUnarchive")
                    {
                        // Главная кнопка восстановления — матовый бежево-золотой с белым текстом
                        btn.BackColor = Color.FromArgb(212, 185, 145);
                        btn.ForeColor = Color.White;
                        btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    }
                    else if (btn.Name == "btnBack")
                    {
                        // Кнопка возврата назад — мягкий нюд
                        btn.BackColor = Color.FromArgb(225, 215, 198);
                        btn.ForeColor = Color.FromArgb(60, 55, 45);
                        btn.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
                    }

                    // Вычисляем траекторию скругления углов (Радиус 12)
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

            // 4. ЮВЕЛИРНАЯ СТИЛИЗАЦИЯ ТАБЛИЦЫ (DataGridView)
            dgvArchive.BackgroundColor = Color.White;
            dgvArchive.BorderStyle = BorderStyle.None;
            dgvArchive.GridColor = Color.FromArgb(240, 235, 225); // Очень нежная пастельная сетка

            // Настройка шапки таблицы
            dgvArchive.EnableHeadersVisualStyles = false;
            dgvArchive.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 240, 230); // Шампань для шапки
            dgvArchive.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(70, 65, 55);    // Сепия для букв
            dgvArchive.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvArchive.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 240, 230);

            // Настройка ячеек данных
            dgvArchive.DefaultCellStyle.BackColor = Color.White;
            dgvArchive.DefaultCellStyle.ForeColor = Color.FromArgb(70, 65, 55);
            dgvArchive.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            // Цвет выделения строки пользователем (сдержанный бежевый вместо ядовито-синего)
            dgvArchive.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 225, 210);
            dgvArchive.DefaultCellStyle.SelectionForeColor = Color.FromArgb(60, 55, 45);

            // Скрываем левый пустой технический столбец
            dgvArchive.RowHeadersVisible = false;
        }




        // Метод для вывода всех заархивированных строк
        private void LoadArchiveTable()
        {
            dgvArchive.ReadOnly = true;
            dgvArchive.AllowUserToAddRows = false;
            dgvArchive.AllowUserToDeleteRows = false;

            // ИСПРАВЛЕНО: Добавлено форматирование strftime для системной даты ISO 8601
            string query = @"
        SELECT 
            id AS [№ Записи],
            order_type AS [Тип услуги],
            order_ref_id AS [ID Заказа],
            strftime('%d.%m.%Y %H:%M', date_added) AS [Дата добавления]
        FROM ClientDashboard
        WHERE current_status = 'В архиве'
        ORDER BY id DESC";

            using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                connection.Open();
                using (var adapter = new SQLiteDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    dgvArchive.DataSource = dataTable;

                    dgvArchive.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                    dgvArchive.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    dgvArchive.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }


        // Кнопка "Восстановить из архива"
        private void btnUnarchive_Click(object sender, EventArgs e)
        {
            if (dgvArchive.CurrentRow == null)
            {
                MessageBox.Show("Выберите строку для восстановления!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string dashboardId = dgvArchive.CurrentRow.Cells["№ Записи"].Value.ToString();
            string orderType = dgvArchive.CurrentRow.Cells["Тип услуги"].Value.ToString();

            // Статус по умолчанию в зависимости от типа
            string restoreStatus = (orderType == "Скупка") ? "Выплачено" : "Готова_к_выдаче";

            using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                connection.Open();

                // Для изготовления и ремонта возвращаем настоящий статус заявки из её таблицы.
                // Раньше всегда ставилось "Готова_к_выдаче", даже если заявка была "Отклонена"
                string statusQuery = "";
                if (orderType == "Изготовление")
                    statusQuery = "SELECT S.status_name FROM ManufacturingOrders MO JOIN OrderStatuses S ON MO.status_id = S.id JOIN ClientDashboard CD ON CD.order_ref_id = MO.id WHERE CD.id = @id";
                else if (orderType == "Ремонт")
                    statusQuery = "SELECT S.status_name FROM RepairOrders RO JOIN OrderStatuses S ON RO.status_id = S.id JOIN ClientDashboard CD ON CD.order_ref_id = RO.id WHERE CD.id = @id";

                if (statusQuery != "")
                {
                    using (var cmd = new SQLiteCommand(statusQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@id", dashboardId);
                        object res = cmd.ExecuteScalar();
                        if (res != null) restoreStatus = res.ToString();
                    }
                }

                // Меняем маркер "В архиве" обратно на прежний статус
                string restoreQuery = "UPDATE ClientDashboard SET current_status = @status WHERE id = @id";
                using (var cmd = new SQLiteCommand(restoreQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@status", restoreStatus);
                    cmd.Parameters.AddWithValue("@id", dashboardId);
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Заявка успешно восстановлена из архива!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadArchiveTable(); // Обновляем экран архива
        }

        // Кнопка Назад
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
