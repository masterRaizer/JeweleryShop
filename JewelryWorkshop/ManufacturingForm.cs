using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace JewelryWorkshop
{
    public partial class ManufacturingForm : Form
    {
        public string ClientLogin { get; set; }
        private string selectedImagePath = ""; // Путь к прикрепленному эскизу

        public ManufacturingForm()
        {
            InitializeComponent();
        }

        private void ManufacturingForm_Load(object sender, EventArgs e)
        {
            // 1. Разворачиваем форму во весь экран
            this.WindowState = FormWindowState.Maximized;

            // 2. НАПОЛНЯЕМ СПИСКИ ТИПОВ УКРАШЕНИЙ (С ДОБАВЛЕНИЕМ ПУНКТА ДРУГОЕ)
            cmbJewelryType.Items.Clear();
            cmbJewelryType.Items.AddRange(new string[] { "Кольцо", "Серьги", "Браслет", "Цепочка", "Кулон", "Другое..." });
            if (cmbJewelryType.Items.Count > 0) cmbJewelryType.SelectedIndex = 0;

            // 3. Новые колонки и камни теперь добавляются при запуске в DatabaseManager.UpgradeDatabase()

            // 4. ДИНАМИЧЕСКАЯ ЗАГРУЗКА МЕТАЛЛОВ ИЗ БД В КОМБОБОКС
            using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                connection.Open();
                string metalQuery = "SELECT metal_name FROM Metals ORDER BY id ASC";
                using (var cmd = new SQLiteCommand(metalQuery, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    cmbMetalType.Items.Clear();
                    while (reader.Read())
                    {
                        cmbMetalType.Items.Add(reader["metal_name"].ToString());
                    }
                }
            }
            if (cmbMetalType.Items.Count > 0) cmbMetalType.SelectedIndex = 0;

            // 5. ДИНАМИЧЕСКАЯ ЗАГРУЗКА ОБНОВЛЕННОГО СПИСКА КАМНЕЙ ИЗ БД В КОМБОБОКС
            using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                connection.Open();
                string gemQuery = "SELECT gem_name FROM Gems ORDER BY id ASC";
                using (var cmd = new SQLiteCommand(gemQuery, connection))
                using (var reader = cmd.ExecuteReader())
                {
                    cmbGemType.Items.Clear();
                    while (reader.Read())
                    {
                        cmbGemType.Items.Add(reader["gem_name"].ToString());
                    }
                }
            }
            if (cmbGemType.Items.Count > 0) cmbGemType.SelectedIndex = 0;

            // 6. ЦВЕТОВАЯ ПАЛИТРА «ШАМПАНЬ» И СТИЛИЗАЦИЯ ФОРМЫ ЗАКАЗА
            this.BackColor = Color.FromArgb(253, 251, 247); // Кремово-молочный фон формы
            panelCenterCard.BackColor = Color.White;         // Белая подложка карты заказа

            // Настройка оттенков текстов и заголовка
            lblTitle.ForeColor = Color.FromArgb(184, 134, 11); // Благородный золотой заголовок
            lblJewelryText.ForeColor = Color.FromArgb(70, 65, 55);
            lblMetalText.ForeColor = Color.FromArgb(70, 65, 55);
            lblGemText.ForeColor = Color.FromArgb(70, 65, 55);
            lblCommentsText.ForeColor = Color.FromArgb(70, 65, 55);
            lblContactText.ForeColor = Color.FromArgb(70, 65, 55);

            // Настройка рамки предпросмотра картинки (делаем пастельной вместо черной)
            picPreview.BorderStyle = BorderStyle.None;
            picPreview.BackColor = Color.FromArgb(253, 251, 247);

            // Стилизация и скругление всех кнопок внутри карты заказа
            foreach (Control control in this.panelCenterCard.Controls)
            {
                if (control is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Cursor = Cursors.Hand;
                    btn.FlatAppearance.BorderSize = 0; // Полностью убираем дефолтные черные рамки

                    // Цветовые решения для кнопок в стиле "Шампань"
                    if (btn.Name == "btnSendOrder")
                    {
                        // Главное действие — насыщенное матовое золото и белый жирный текст
                        btn.BackColor = Color.FromArgb(184, 134, 11);
                        btn.ForeColor = Color.White;
                        btn.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                    }
                    else
                    {
                        // Дополнительные кнопки (Назад, Прикрепить эскиз) — мягкий благородный нюд
                        btn.BackColor = Color.FromArgb(225, 215, 198);
                        btn.ForeColor = Color.FromArgb(60, 55, 45);
                        btn.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
                    }

                    // Аппаратное скругление углов кнопок (Радиус 12)
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

        // ЛОГИКА ОТОБРАЖЕНИЯ СТРОКИ ДЛЯ СВОЕГО ТИПА ИЗДЕЛИЯ (БЕЗ СДВИГА ЭЛЕМЕНТОВ)
        private void cmbJewelryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbJewelryType.SelectedItem != null && cmbJewelryType.SelectedItem.ToString() == "Другое...")
            {
                // Просто делаем видимым поле в существующем пустом пространстве
                txtCustomJewelryType.Visible = true;
                txtCustomJewelryType.Focus();
            }
            else
            {
                // Скрываем и очищаем поле ввода
                txtCustomJewelryType.Visible = false;
                txtCustomJewelryType.Text = "";
            }
        }

        // МОДУЛЬ ПРИКРЕПЛЕНИЯ ФОТОГРАФИИ
        private void btnAttachPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Изображения (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                ofd.Title = "Выберите эскиз или фотографию украшения";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    selectedImagePath = ofd.FileName;
                    // Копируем картинку в память, чтобы файл на диске не оставался заблокированным
                    using (Image img = Image.FromFile(selectedImagePath))
                    {
                        picPreview.Image = new Bitmap(img);
                    }
                    btnAttachPhoto.Text = "✅ Фото эскиза прикреплено";
                }
            }
        }

        private void btnSendOrder_Click(object sender, EventArgs e)
        {
            if (cmbJewelryType.SelectedItem == null || cmbMetalType.SelectedItem == null || cmbGemType.SelectedItem == null) return;

            string jewelryType = cmbJewelryType.SelectedItem.ToString();
            string metalName = cmbMetalType.SelectedItem.ToString();
            string gemName = cmbGemType.SelectedItem.ToString();
            string comments = txtGems.Text.Trim();
            string contact = txtContact.Text.Trim();
            if (jewelryType == "Другое...")
            {
                jewelryType = txtCustomJewelryType.Text.Trim();
                if (string.IsNullOrEmpty(jewelryType))
                {
                    MessageBox.Show("Пожалуйста, укажите ваш собственный тип изделия в появившемся поле!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomJewelryType.Focus();
                    return;
                }
            }
            if (!txtContact.MaskCompleted)
            {
                MessageBox.Show("Ошибка! Номер телефона введен некорректно или не полностью. Заполните все 11 цифр шаблона!",
                "Некорректный формат", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(ClientLogin)) ClientLogin = "client1";
            using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int userId = 0;
                        string userQuery = "SELECT id FROM Users WHERE login = @login";
                        using (var cmd = new SQLiteCommand(userQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@login", ClientLogin);
                            object res = cmd.ExecuteScalar();
                            if (res != null) userId = Convert.ToInt32(res);
                        }
                        int metalId = 0;
                        string metalQuery = "SELECT id FROM Metals WHERE metal_name = @name";
                        using (var cmd = new SQLiteCommand(metalQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@name", metalName);
                            object res = cmd.ExecuteScalar();
                            if (res != null) metalId = Convert.ToInt32(res);
                        }
                        int gemId = 0;
                        string gemQuery = "SELECT id FROM Gems WHERE gem_name = @name";
                        using (var cmd = new SQLiteCommand(gemQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@name", gemName);
                            object res = cmd.ExecuteScalar();
                            if (res != null) gemId = Convert.ToInt32(res);
                        }
                        string dateStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        string insertOrderQuery = @"
INSERT INTO ManufacturingOrders (user_id, jewelry_type, metal_id, gem_id, comments, status_id, date_created, contact_data, image_path)
VALUES (@userId, @jType, @metalId, @gemId, @comments, 1, @date, @contact, @img);
SELECT last_insert_rowid();";
                        long newOrderId = 0;
                        using (var command = new SQLiteCommand(insertOrderQuery, connection))
                        {
                            command.Parameters.AddWithValue("@userId", userId);
                            command.Parameters.AddWithValue("@jType", jewelryType);
                            command.Parameters.AddWithValue("@metalId", metalId);
                            command.Parameters.AddWithValue("@gemId", gemId);
                            command.Parameters.AddWithValue("@comments", comments);
                            command.Parameters.AddWithValue("@date", dateStr);
                            command.Parameters.AddWithValue("@contact", contact);
                            command.Parameters.AddWithValue("@img", selectedImagePath);
                            newOrderId = (long)command.ExecuteScalar();
                        }
                        string insertDashboardQuery = @"
INSERT INTO ClientDashboard (user_id, order_type, order_ref_id, date_added, current_status)
VALUES (@userId, 'Изготовление', @orderId, @date, 'Новая')";
                        using (var command = new SQLiteCommand(insertDashboardQuery, connection))
                        {
                            command.Parameters.AddWithValue("@userId", userId);
                            command.Parameters.AddWithValue("@orderId", newOrderId);
                            command.Parameters.AddWithValue("@date", dateStr);
                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        MessageBox.Show("Заявка на изготовление ювелирного украшения успешно отправлена!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtGems.Text = "";
                        txtContact.Text = "";
                        txtCustomJewelryType.Text = "";
                        picPreview.Image = null;
                        selectedImagePath = "";
                        btnAttachPhoto.Text = "📎 Прикрепить фото эскиза";
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Ошибка при оформлении заказа: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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