using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace JewelryWorkshop
{
    public partial class ScrapForm : Form
    {
        // Переменная для логина текущего клиента
        public string ClientLogin { get; set; }

        // Переменная для хранения итоговой суммы выплаты
        private double totalPayout = 0;

        public ScrapForm()
        {
            InitializeComponent();
        }

        // Загрузка формы: наполняем типы металла для скупки и накладываем ювелирную палитру
        private void ScrapForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            cmbScrapMetal.Items.Clear();

            using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                connection.Open();
                string query = "SELECT metal_name, price_scrap FROM Metals";
                using (var cmd = new SQLiteCommand(query, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string name = reader["metal_name"].ToString();
                        string price = reader["price_scrap"].ToString();
                        cmbScrapMetal.Items.Add($"{name} ({price} руб/г)");
                    }
                }
            }

            if (cmbScrapMetal.Items.Count > 0) cmbScrapMetal.SelectedIndex = 0;
            CalculatePayout();

            // ЦВЕТОВАЯ ПАЛИТРА «ШАМПАНЬ» ДЛЯ ЭКРАНА СКУПКИ ЛОМА
            this.BackColor = Color.FromArgb(253, 251, 247); // Нежный кремово-молочный фон приложения
            panelCenterCard.BackColor = Color.White;         // Белоснежная карточка контента

            // Красиво перекрашиваем надписи под благородный стиль бренда
            lblTitle.ForeColor = Color.FromArgb(184, 134, 11);       // Глубокое золото (DarkGoldenrod)
            lblMetalText.ForeColor = Color.FromArgb(70, 65, 55);       // Мягкая сепия для лучшей читаемости
            lblWeightText.ForeColor = Color.FromArgb(70, 65, 55);
            lblContactText.ForeColor = Color.FromArgb(70, 65, 55);
            lblPayoutText.ForeColor = Color.FromArgb(70, 65, 55);
            lblTotalPayout.ForeColor = Color.FromArgb(184, 134, 11);  // Итоговая выплата горит золотом вместо зеленого

            // ИСПРАВЛЕНО: Теперь скругляем кнопки внутри panelCenterCard, чтобы стили гарантированно применились
            foreach (Control control in this.panelCenterCard.Controls)
            {
                if (control is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Cursor = Cursors.Hand;
                    btn.FlatAppearance.BorderSize = 0; // Полностью убираем дефолтные серые границы WinForms

                    // Цветовые сценарии кнопок
                    if (btn.Name == "btnSendScrap")
                    {
                        // Оставить заявку — насыщенный золотой тон с белым жирным текстом
                        btn.BackColor = Color.FromArgb(184, 134, 11);
                        btn.ForeColor = Color.White;
                        btn.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
                    }
                    else if (btn.Name == "btnBack")
                    {
                        // Назад — мягкий и сдержанный нюдовый оттенок
                        btn.BackColor = Color.FromArgb(225, 215, 198);
                        btn.ForeColor = Color.FromArgb(60, 55, 45);
                        btn.Font = new Font("Segoe UI", 13F, FontStyle.Regular);
                    }

                    // Обрезаем углы до премиального радиуса 12
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

        // Пересчет при изменении текста в поле веса
        private void txtWeight_TextChanged(object sender, EventArgs e)
        {
            CalculatePayout();
        }

        // Пересчет при смене металла в выпадающем списке
        private void cmbScrapMetal_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculatePayout();
        }

        // Логика автоматического расчета стоимости скупки
        private void CalculatePayout()
        {
            if (cmbScrapMetal.SelectedItem == null) return;

            string selectedItem = cmbScrapMetal.SelectedItem.ToString();
            string metalName = selectedItem.Split('(')[0].Trim();
            double pricePerGram = 0;

            using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                connection.Open();
                string query = "SELECT price_scrap FROM Metals WHERE metal_name = @name";
                using (var cmd = new SQLiteCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@name", metalName);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        pricePerGram = Convert.ToDouble(result);
                    }
                }
            }

            string weightInput = txtWeight.Text.Trim().Replace(",", ".");

            if (double.TryParse(weightInput, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double weight) && weight > 0)
            {
                totalPayout = weight * pricePerGram;
                lblTotalPayout.Text = $"{totalPayout:N2} руб.";
            }
            else
            {
                totalPayout = 0;
                lblTotalPayout.Text = "0.00 руб.";
            }
        }

        // Кнопка "Оформить скупку"
        private void btnSendScrap_Click(object sender, EventArgs e)
        {
            if (cmbScrapMetal.SelectedItem == null) return;

            string selectedItem = cmbScrapMetal.SelectedItem.ToString();
            string metalName = selectedItem.Split('(')[0].Trim();
            string weightText = txtWeight.Text.Trim();
            string contact = txtContact.Text.Trim();

            string weightInput = weightText.Replace(",", ".");
            if (!double.TryParse(weightInput, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double parsedWeight) || parsedWeight < 0.1 || parsedWeight > 10000)
            {
                MessageBox.Show("Пожалуйста, введите корректный вес лома (от 0.1 до 10 000 г)!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!txtContact.MaskCompleted)
            {
                MessageBox.Show("Ошибка! Номер телефона введен некорректно или не полностью. Заполните все 11 цифр шаблона!",
                                "Некорректный формат", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(ClientLogin))
            {
                ClientLogin = "client1";
            }

            using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int userId = 0;
                        string userQuery = "SELECT id FROM Users WHERE login = @login";
                        using (var command = new SQLiteCommand(userQuery, connection))
                        {
                            command.Parameters.AddWithValue("@login", ClientLogin);
                            object res = command.ExecuteScalar();
                            if (res != null) userId = Convert.ToInt32(res);
                        }

                        int metalId = 0;
                        double scrapPrice = 0;
                        string metalQuery = "SELECT id, price_scrap FROM Metals WHERE metal_name = @name";
                        using (var command = new SQLiteCommand(metalQuery, connection))
                        {
                            command.Parameters.AddWithValue("@name", metalName);
                            using (var reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    metalId = Convert.ToInt32(reader["id"]);
                                    scrapPrice = Convert.ToDouble(reader["price_scrap"]);
                                }
                            }
                        }

                        double localPayout = parsedWeight * scrapPrice;
                        string dateStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                        string insertDealQuery = @"
                    INSERT INTO ScrapDeals (user_id, metal_id, weight, total_payout, date_created, contact_data) 
                    VALUES (@userId, @metalId, @weight, @payout, @date, @contact);
                    SELECT last_insert_rowid();";

                        long newDealId = 0;
                        using (var command = new SQLiteCommand(insertDealQuery, connection))
                        {
                            command.Parameters.AddWithValue("@userId", userId);
                            command.Parameters.AddWithValue("@metalId", metalId);
                            command.Parameters.AddWithValue("@weight", parsedWeight);
                            command.Parameters.AddWithValue("@payout", localPayout);
                            command.Parameters.AddWithValue("@date", dateStr);
                            command.Parameters.AddWithValue("@contact", contact);
                            newDealId = (long)command.ExecuteScalar();
                        }
                        string insertDashboardQuery = @"
INSERT INTO ClientDashboard (user_id, order_type, order_ref_id, date_added, current_status)
VALUES (@userId, 'Скупка', @dealId, @date, 'Выплачено')";
                        using (var command = new SQLiteCommand(insertDashboardQuery, connection))
                        {
                            command.Parameters.AddWithValue("@userId", userId);
                            command.Parameters.AddWithValue("@dealId", newDealId);
                            command.Parameters.AddWithValue("@date", dateStr);
                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        MessageBox.Show("Ваша заявка на сдачу лома успешно оформлена и отправлена мастеру!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtWeight.Text = "";
                        txtContact.Text = "";
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Ошибка при оформлении заявки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        // Кнопка "Назад"
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                return;
            }
            if (e.KeyChar == '.' || e.KeyChar == ',')
            {
                if (txtWeight.Text.Contains(".") || txtWeight.Text.Contains(","))
                {
                    e.Handled = true;
                }
                return;
            }
            e.Handled = true;
        }
        private void txtContact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            txtContact.TextChanged -= txtContact_TextChanged;
            string rawDigits = string.Empty;
            foreach (char c in txtContact.Text)
            {
                if (char.IsDigit(c)) rawDigits += c;
            }
            if (rawDigits.Length > 0 && (rawDigits[0] == '8' || rawDigits[0] == '7'))
            {
                rawDigits = rawDigits.Substring(1);
            }
            if (rawDigits.Length > 10)
            {
                rawDigits = rawDigits.Substring(0, 10);
            }
            string formatted = "+7";
            if (rawDigits.Length > 0)
            {
                string k = rawDigits.Length > 3 ? rawDigits.Substring(0, 3) : rawDigits;
                formatted += $" ({k}";
            }
            if (rawDigits.Length >= 4)
            {
                string k = rawDigits.Length > 6 ? rawDigits.Substring(3, 3) : rawDigits.Substring(3);
                formatted += $") {k}";
            }
            if (rawDigits.Length >= 7)
            {
                string k = rawDigits.Length > 8 ? rawDigits.Substring(6, 2) : rawDigits.Substring(6);
                formatted += $"-{k}";
            }
            if (rawDigits.Length >= 9)
            {
                string k = rawDigits.Substring(8);
                formatted += $"-{k}";
            }
            txtContact.Text = formatted;
            txtContact.SelectionStart = txtContact.Text.Length;
            txtContact.TextChanged += txtContact_TextChanged;
        }
    }
}