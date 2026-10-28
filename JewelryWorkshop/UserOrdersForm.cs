using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace JewelryWorkshop
{
    public partial class UserOrdersForm : Form
    {
        public string ClientLogin { get; set; }

        public UserOrdersForm()
        {
            InitializeComponent();
        }

        private void UserOrdersForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            RefreshOrdersTable();

            // ЦВЕТОВАЯ ПАЛИТРА «ШАМПАНЬ» ДЛЯ ЭКРАНА ИСТОРИИ ЗАКАЗОВ
            this.BackColor = Color.FromArgb(253, 251, 247); // Нежный кремово-молочный фон приложения
            panelCenterCard.BackColor = Color.White;         // Белоснежная подложка центральной карточки

            // Стилизация заголовка формы
            lblClientTitle.ForeColor = Color.FromArgb(184, 134, 11); // Глубокое премиальное золото

            // ЮВЕЛИРНАЯ СТИЛИЗАЦИЯ ТАБЛИЦЫ ЗАКАЗОВ (DataGridView)
            dgvMyOrders.BackgroundColor = Color.White;
            dgvMyOrders.BorderStyle = BorderStyle.None;
            dgvMyOrders.GridColor = Color.FromArgb(240, 235, 225); // Мягкая пастельная сетка

            // Настройка шапки таблицы
            dgvMyOrders.EnableHeadersVisualStyles = false;
            dgvMyOrders.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(245, 240, 230); // Цвет шампань
            dgvMyOrders.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(70, 65, 55);    // Сепия для текста
            dgvMyOrders.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvMyOrders.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 240, 230);

            // Настройка ячеек данных
            dgvMyOrders.DefaultCellStyle.BackColor = Color.White;
            dgvMyOrders.DefaultCellStyle.ForeColor = Color.FromArgb(70, 65, 55);
            dgvMyOrders.DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            // Цвет выделения строки пользователем (сдержанный бежево-нюдовый вместо синего)
            dgvMyOrders.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 225, 210);
            dgvMyOrders.DefaultCellStyle.SelectionForeColor = Color.FromArgb(60, 55, 45);
            dgvMyOrders.RowHeadersVisible = false; // Скрываем левую техническую колонку

            // Применяем аппаратное скругление и цвета к кнопкам
            StyleButton(btnBack);
            StyleButton(btnCancelOrder);
            StyleButton(btnEditOrder);
        }

        private void RefreshOrdersTable()
        {
            dgvMyOrders.ReadOnly = true;
            dgvMyOrders.AllowUserToAddRows = false;
            dgvMyOrders.AllowUserToDeleteRows = false;
            dgvMyOrders.DataSource = null;

            if (string.IsNullOrEmpty(ClientLogin)) ClientLogin = "client1";

            using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                connection.Open();

                int userId = 0;
                string userQuery = "SELECT id FROM Users WHERE login = @login";
                using (var cmd = new SQLiteCommand(userQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@login", ClientLogin);
                    object res = cmd.ExecuteScalar();
                    if (res != null) userId = Convert.ToInt32(res);
                }

                // УСОВЕРШЕНСТВОВАННЫЙ SQL-ЗАПРОС С ПОДДЕРЖКОЙ КАТАЛОЖНОЙ БРОНИ
                string dashboardQuery = @"
            SELECT 
                CD.id AS [№ Записи],
                CD.order_type AS [Тип услуги],
                CD.order_ref_id AS [ID Заказа],
                
                -- Умное определение названия изделия
                CASE 
                    WHEN CD.order_type = 'Изготовление' THEN (SELECT jewelry_type FROM ManufacturingOrders WHERE id = CD.order_ref_id)
                    WHEN CD.order_type = 'Ремонт' THEN (SELECT PL.damage_name FROM RepairOrders RO LEFT JOIN RepairPriceList PL ON RO.repair_price_id = PL.id WHERE RO.id = CD.order_ref_id)
                    WHEN CD.order_type = 'Скупка' THEN (SELECT M.metal_name FROM ScrapDeals SD LEFT JOIN Metals M ON SD.metal_id = M.id WHERE SD.id = CD.order_ref_id)
                    WHEN CD.order_type = 'Бронь' THEN 
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
                        END
                    ELSE 'Не указано'
                END AS [Наименование / Детали],

                -- Умное определение цены товара
                CASE 
                    WHEN CD.order_type = 'Изготовление' THEN 'По согласованию'
                    WHEN CD.order_type = 'Ремонт' THEN (SELECT CAST(final_cost AS TEXT) || ' руб.' FROM RepairOrders WHERE id = CD.order_ref_id)
                    WHEN CD.order_type = 'Скупка' THEN (SELECT CAST(total_payout AS TEXT) || ' руб.' FROM ScrapDeals WHERE id = CD.order_ref_id)
                    WHEN CD.order_type = 'Бронь' THEN 
                        CASE CAST(CD.order_ref_id AS TEXT)
                            WHEN '1' THEN '195 000 руб.'
                            WHEN '2' THEN '68 900 руб.'
                            WHEN '3' THEN '42 000 руб.'
                            WHEN '4' THEN '125 000 руб.'
                            WHEN '5' THEN '275 000 руб.'
                            WHEN '6' THEN '160 000 руб.'
                            WHEN '7' THEN '420 000 руб.'
                            WHEN '8' THEN '95 000 руб.'
                            ELSE 'Цена по каталогу'
                        END
                    ELSE '0 руб.'
                END AS [Сумма],

                strftime('%d.%m.%Y %H:%M', CD.date_added) AS [Дата оформления],
                CD.current_status AS [Текущий статус]
            FROM ClientDashboard CD
            WHERE CD.user_id = @userId
            ORDER BY CD.id DESC";

                using (var adapter = new SQLiteDataAdapter(dashboardQuery, connection))
                {
                    adapter.SelectCommand.Parameters.AddWithValue("@userId", userId);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dgvMyOrders.DataSource = dataTable;
                    dgvMyOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }

            if (dgvMyOrders.Columns.Contains("ID Заказа")) dgvMyOrders.Columns["ID Заказа"].Visible = false;

            if (dgvMyOrders.Rows.Count == 0)
            {
                lblClientTitle.Text = "История моих заказов: (У вас пока нет оформленных заявок)";
                btnCancelOrder.Enabled = false;
                btnEditOrder.Enabled = false;
            }
            else
            {
                lblClientTitle.Text = "История моих заказов";
                btnCancelOrder.Enabled = true;
                btnEditOrder.Enabled = true;
            }
        }

        // КНОПКА БЕЗОПАСНОЙ ОТМЕНЫ ЗАКАЗА (ТОЛЬКО ДЛЯ СТАТУСА "НОВАЯ")
        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (dgvMyOrders.CurrentRow == null) return;

            string status = dgvMyOrders.CurrentRow.Cells["Текущий статус"].Value.ToString().Trim();
            string orderType = dgvMyOrders.CurrentRow.Cells["Тип услуги"].Value.ToString();
            long orderRefId = Convert.ToInt64(dgvMyOrders.CurrentRow.Cells["ID Заказа"].Value);
            long dashboardId = Convert.ToInt64(dgvMyOrders.CurrentRow.Cells["№ Записи"].Value);

            if (status != "Новая")
            {
                MessageBox.Show("Отмена невозможна! Данный заказ уже взят мастером в работу или выполнен.",
                                "Доступ отклонен", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show("Вы уверены, что хотите полностью отменить этот заказ и удалить его из базы?",
                                          "Подтверждение отмены", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string deleteQuery = "";
                        if (orderType == "Изготовление") deleteQuery = "DELETE FROM ManufacturingOrders WHERE id = @id";
                        else if (orderType == "Ремонт") deleteQuery = "DELETE FROM RepairOrders WHERE id = @id";
                        else if (orderType == "Скупка") deleteQuery = "DELETE FROM ScrapDeals WHERE id = @id";

                        // У брони нет отдельной таблицы заказа — она хранится только в журнале
                        if (deleteQuery != "")
                        {
                            using (var cmd = new SQLiteCommand(deleteQuery, connection))
                            {
                                cmd.Parameters.AddWithValue("@id", orderRefId);
                                cmd.ExecuteNonQuery();
                            }
                        }

                        // Удаляем запись журнала по её собственному id. Раньше удаление шло по order_ref_id,
                        // и для брони (где order_ref_id = id товара) стирались брони этого товара у ВСЕХ клиентов
                        string deleteDash = "DELETE FROM ClientDashboard WHERE id = @id";
                        using (var cmd = new SQLiteCommand(deleteDash, connection))
                        {
                            cmd.Parameters.AddWithValue("@id", dashboardId);
                            cmd.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        MessageBox.Show("Заказ успешно аннулирован!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshOrdersTable();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Ошибка при удалении: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        // КНОПКА РЕДАКТИРОВАНИЯ КОНТАКТНЫХ ДАННЫХ ЗАКАЗА
        private void btnEditOrder_Click(object sender, EventArgs e)
        {
            if (dgvMyOrders.CurrentRow == null) return;
            string status = dgvMyOrders.CurrentRow.Cells["Текущий статус"].Value.ToString().Trim();
            string orderType = dgvMyOrders.CurrentRow.Cells["Тип услуги"].Value.ToString();
            long orderRefId = Convert.ToInt64(dgvMyOrders.CurrentRow.Cells["ID Заказа"].Value);
            long dashboardId = Convert.ToInt64(dgvMyOrders.CurrentRow.Cells["№ Записи"].Value);
            if (status != "Новая")
            {
                MessageBox.Show("Изменение данных невозможно! Заказ уже обрабатывается мастером.",
                "Доступ отклонен", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Form phoneForm = new Form();
            phoneForm.Size = new Size(350, 180);
            phoneForm.Text = "Редактирование контактов";
            phoneForm.StartPosition = FormStartPosition.CenterParent;
            phoneForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            phoneForm.MaximizeBox = false;
            phoneForm.MinimizeBox = false;
            Label lblPrompt = new Label() { Left = 20, Top = 15, Width = 300, Text = "Введите новый номер телефона:" };
            MaskedTextBox mtbPhone = new MaskedTextBox();
            mtbPhone.Left = 20;
            mtbPhone.Top = 40;
            mtbPhone.Width = 290;
            mtbPhone.Font = new Font("Segoe UI", 11F);
            mtbPhone.Mask = "8 (000) 000-00-00";
            Button btnOk = new Button() { Text = "Сохранить", Left = 110, Top = 85, Width = 100, Height = 32, DialogResult = DialogResult.OK };
            Button btnCancel = new Button() { Text = "Отмена", Left = 215, Top = 85, Width = 95, Height = 32, DialogResult = DialogResult.Cancel };
            phoneForm.Controls.AddRange(new Control[] { lblPrompt, mtbPhone, btnOk, btnCancel });
            phoneForm.AcceptButton = btnOk;
            phoneForm.CancelButton = btnCancel;
            StyleButton(btnOk);
            StyleButton(btnCancel);
            if (phoneForm.ShowDialog() == DialogResult.OK)
            {
                if (!mtbPhone.MaskCompleted)
                {
                    MessageBox.Show("Ошибка! Номер телефона введен не полностью. Заполните все 11 цифр шаблона.",
                    "Некорректный ввод", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Сохраняем номер в том же формате, что и при оформлении заказа: 8 (XXX) XXX-XX-XX
                string resultPhone = mtbPhone.Text.Trim();
                using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
                {
                    connection.Open();
                    string updateQuery = "";
                    long targetId = orderRefId;
                    if (orderType == "Изготовление") updateQuery = "UPDATE ManufacturingOrders SET contact_data = @contact WHERE id = @id";
                    else if (orderType == "Ремонт") updateQuery = "UPDATE RepairOrders SET contact_data = @contact WHERE id = @id";
                    else if (orderType == "Скупка") updateQuery = "UPDATE ScrapDeals SET contact_data = @contact WHERE id = @id";
                    else if (orderType == "Бронь")
                    {
                        // Телефон брони хранится прямо в журнале
                        updateQuery = "UPDATE ClientDashboard SET contact_data = @contact WHERE id = @id";
                        targetId = dashboardId;
                    }
                    using (var cmd = new SQLiteCommand(updateQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@contact", resultPhone);
                        cmd.Parameters.AddWithValue("@id", targetId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show($"Контактный телефон успешно изменен на:\n{resultPhone}",
                "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshOrdersTable();
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void StyleButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.Cursor = Cursors.Hand;
            btn.FlatAppearance.BorderSize = 0; // Полностью убираем дефолтные черные границы WinForms
                                               // Цветовые решения для кнопок истории заказов
            if (btn.Name == "btnCancelOrder")
            {
                // Кнопка отмены заказа — приглушенный матовый бордово-нюдовый цвет с белым текстом
                btn.BackColor = Color.FromArgb(210, 145, 145);
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            }
            else if (btn.Name == "btnEditOrder")
            {
                // Кнопка изменения контактов — матовое золото с белым текстом
                btn.BackColor = Color.FromArgb(184, 134, 11);
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            }
            else
            {
                // Все остальные кнопки (Назад, Отмена во всплывающем окне) — мягкий благородный нюд
                btn.BackColor = Color.FromArgb(225, 215, 198);
                btn.ForeColor = Color.FromArgb(60, 55, 45);
                btn.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            }
            GraphicsPath p = new GraphicsPath();
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