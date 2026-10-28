using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace JewelryWorkshop
{
    public partial class RepairForm : Form
    {
        public string ClientLogin { get; set; }

        public RepairForm()
        {
            InitializeComponent();
        }

        private void RepairForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            // Колонка repair_time теперь добавляется при запуске в DatabaseManager.UpgradeDatabase()
            LoadRepairPriceTable();

            // ЦВЕТОВАЯ ПАЛИТРА «ШАМПАНЬ» ДЛЯ ФОРМЫ РЕМОНТА
            this.BackColor = Color.FromArgb(253, 251, 247); // Нежный кремово-молочный фон приложения
            panelCenterCard.BackColor = Color.White;         // Белоснежная центральная карточка

            // Красиво перекрашиваем надписи под благородный стиль
            lblTitle.ForeColor = Color.FromArgb(184, 134, 11); // Глубокое золото (DarkGoldenrod)
            lblDamageText.ForeColor = Color.FromArgb(140, 130, 115); // Мягкий кофейный цвет для подсказки
            lblContactText.ForeColor = Color.FromArgb(70, 65, 55);   // Темно-сепия для полей
            lblEstimatedPriceText.ForeColor = Color.FromArgb(70, 65, 55);
            lblEstimatedPrice.ForeColor = Color.FromArgb(184, 134, 11); // Итоговая сумма горит золотом бренда

            // ЮВЕЛИРНАЯ СТИЛИЗАЦИЯ ТАБЛИЦЫ ПРАЙС-ЛИСТА (DataGridView)
            dgvRepairPrice.BackgroundColor = Color.White;
            dgvRepairPrice.BorderStyle = BorderStyle.None;
            dgvRepairPrice.GridColor = Color.FromArgb(240, 235, 225); // Нежная пастельная сетка

            // Настройка заголовков таблицы
            dgvRepairPrice.EnableHeadersVisualStyles = false;
            dgvRepairPrice.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 240, 230); // Шампань
            dgvRepairPrice.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(70, 65, 55);    // Сепия
            dgvRepairPrice.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvRepairPrice.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 240, 230);

            // Настройка ячеек данных
            dgvRepairPrice.DefaultCellStyle.BackColor = Color.White;
            dgvRepairPrice.DefaultCellStyle.ForeColor = Color.FromArgb(70, 65, 55);
            dgvRepairPrice.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            // Цвет выделения выбранных поломок (сдержанный бежево-нюдовый вместо синего)
            dgvRepairPrice.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 225, 210);
            dgvRepairPrice.DefaultCellStyle.SelectionForeColor = Color.FromArgb(60, 55, 45);
            dgvRepairPrice.RowHeadersVisible = false; // Прячем пустую техническую колонку слева

            // Программно стилизуем и скругляем углы у кнопок (Радиус 12)
            foreach (Control control in this.panelCenterCard.Controls)
            {
                if (control is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Cursor = Cursors.Hand;
                    btn.FlatAppearance.BorderSize = 0; // Полностью убираем дефолтные черные границы

                    // Цветовые решения для кнопок формы ремонта
                    if (btn.Name == "btnSendRepair")
                    {
                        // Главное действие — насыщенное матовое золото и белый жирный текст
                        btn.BackColor = Color.FromArgb(184, 134, 11);
                        btn.ForeColor = Color.White;
                        btn.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
                    }
                    else if (btn.Name == "btnBack")
                    {
                        // Второстепенная кнопка — мягкий благородный нюд
                        btn.BackColor = Color.FromArgb(225, 215, 198);
                        btn.ForeColor = Color.FromArgb(60, 55, 45);
                        btn.Font = new Font("Segoe UI", 13F, FontStyle.Regular);
                    }

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

        private void LoadRepairPriceTable()
        {
            dgvRepairPrice.ReadOnly = true;
            dgvRepairPrice.AllowUserToAddRows = false;
            dgvRepairPrice.AllowUserToDeleteRows = false;

            using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                connection.Open();
                string query = "SELECT id AS [ID], damage_name AS [Тип неисправности], cost AS [Цена, руб], repair_time AS [Время выполнения] FROM RepairPriceList";

                using (var adapter = new SQLiteDataAdapter(query, connection))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvRepairPrice.DataSource = dt;

                    if (dgvRepairPrice.Columns.Contains("ID")) dgvRepairPrice.Columns["ID"].Visible = false;
                    dgvRepairPrice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
        }

        // ИСПРАВЛЕНИЕ: ДИНАМИЧЕСКИЙ СУММАРНЫЙ ПЕРЕСЧЕТ ВСЕХ ВЫДЕЛЕННЫХ СТРОК
        private void dgvRepairPrice_SelectionChanged(object sender, EventArgs e)
        {
            double totalSum = 0;

            foreach (DataGridViewRow row in dgvRepairPrice.SelectedRows)
            {
                if (row.Cells["Цена, руб"].Value != null)
                {
                    totalSum += Convert.ToDouble(row.Cells["Цена, руб"].Value);
                }
            }

            lblEstimatedPrice.Text = $"{totalSum:N0} руб.";
        }

        // ИСПРАВЛЕНИЕ: ЦИКЛИЧЕСКАЯ ОТПРАВКА ВСЕХ ВЫБРАННЫХ ОПЦИЙ В ЕДИНОЙ ТРАНЗАКЦИИ
        private void btnSendRepair_Click(object sender, EventArgs e)
        {
            if (dgvRepairPrice.SelectedRows.Count == 0)
            {
                MessageBox.Show("Пожалуйста, выберите хотя бы одну услугу из таблицы прайс-листа!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!txtContact.MaskCompleted)
            {
                MessageBox.Show("Ошибка! Номер телефона введен некорректно или не полностью. Заполните все 11 цифр шаблона!",
                                "Некорректный формат", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string contact = txtContact.Text.Trim();
            if (string.IsNullOrEmpty(ClientLogin)) ClientLogin = "client1";

            using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // 1. Получаем ID текущего пользователя
                        int userId = 0;
                        string userQuery = "SELECT id FROM Users WHERE login = @login";
                        using (var cmd = new SQLiteCommand(userQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@login", ClientLogin);
                            object res = cmd.ExecuteScalar();
                            if (res != null) userId = Convert.ToInt32(res);
                        }
                        string dateStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        // 2. В ЦИКЛЕ ПРОБЕГАЕМ ПО ВСЕМ ВЫДЕЛЕННЫМ СТРОКАМ И ОТПРАВЛЯЕМ ИХ В БД
                        foreach (DataGridViewRow row in dgvRepairPrice.SelectedRows)
                        {
                            long repairPriceId = Convert.ToInt64(row.Cells["ID"].Value);
                            double cost = Convert.ToDouble(row.Cells["Цена, руб"].Value);
                            string insertOrderQuery = @"
INSERT INTO RepairOrders (user_id, repair_price_id, status_id, date_created, contact_data, final_cost)
VALUES (@userId, @repPriceId, 1, @date, @contact, @cost);
SELECT last_insert_rowid();";
                            long newOrderId = 0;
                            using (var command = new SQLiteCommand(insertOrderQuery, connection))
                            {
                                command.Parameters.AddWithValue("@userId", userId);
                                command.Parameters.AddWithValue("@repPriceId", repairPriceId);
                                command.Parameters.AddWithValue("@date", dateStr);
                                command.Parameters.AddWithValue("@contact", contact);
                                command.Parameters.AddWithValue("@cost", cost);
                                newOrderId = (long)command.ExecuteScalar();
                            }
                            string insertDashboardQuery = @"
INSERT INTO ClientDashboard (user_id, order_type, order_ref_id, date_added, current_status)
VALUES (@userId, 'Ремонт', @orderId, @date, 'Новая')";
                            using (var command = new SQLiteCommand(insertDashboardQuery, connection))
                            {
                                command.Parameters.AddWithValue("@userId", userId);
                                command.Parameters.AddWithValue("@orderId", newOrderId);
                                command.Parameters.AddWithValue("@date", dateStr);
                                command.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                        MessageBox.Show($"Успех! Оформлено решение по ремонту в количестве {dgvRepairPrice.SelectedRows.Count} опций!",
                        "Заявка оформлена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtContact.Text = "";
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Ошибка оформления ремонта: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}