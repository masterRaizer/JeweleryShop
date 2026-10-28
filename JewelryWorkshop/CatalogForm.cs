using System;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace JewelryWorkshop
{
    public partial class CatalogForm : Form
    {
        public string ClientLogin { get; set; } // ПРИЕМ ТЕКУЩЕГО СЕССИОННОГО ЛОГИНА ПОЛЬЗОВАТЕЛЯ
        private int selectedProductId = -1;
        private string currentProductName = "";
        private double currentProductPrice = 0;

        public CatalogForm()
        {
            InitializeComponent();
        }

        private void CatalogForm_Load(object sender, System.EventArgs e)
        {
            // 1. РАЗВЕРТЫВАНИЕ ВО ВЕСЬ ЭКРАН ПРИ ЗАПУСКЕ
            this.WindowState = FormWindowState.Maximized;

            // ПРИМЕНЕНИЕ ЮВЕЛИРНОЙ ПАЛИТРЫ К ОСНОВНЫМ КОНТЕНТ-ПАНЕЛЯМ
            this.BackColor = Color.FromArgb(253, 251, 247);     // Кремово-молочный фон каталога
            panelGrid.BackColor = Color.FromArgb(253, 251, 247); // Фон сетки плиток
            panelDetails.BackColor = Color.White;                // Белый чистый фон детальной карточки

            // Стилизация статических текстовых элементов
            lblTitle.ForeColor = Color.FromArgb(184, 134, 11);    // Глубокое золото для заголовка витрины
            lblDetailedPrice.ForeColor = Color.FromArgb(184, 134, 11); // Золотой цвет цены в карточке

            // Современный текстовый бокс описания товара
            txtFullDesc.BackColor = Color.FromArgb(253, 251, 247);
            txtFullDesc.ForeColor = Color.FromArgb(70, 65, 55);
            txtFullDesc.BorderStyle = BorderStyle.None;

            // Выравниваем кнопку закрытия строго в верхнем правом углу монитора
            btnFormClose.Location = new Point(this.Width - 240, 25);

            // 2. ИДЕАЛЬНОЕ ЦЕНТРИРОВАНИЕ ГЛАВНОЙ СЕТКИ (4 плитки в ряд)
            int gridWidth = 1700;
            int gridHeight = 770;
            int gridLeft = (this.Width - gridWidth) / 2;

            panelGrid.Location = new Point(gridLeft, 110);
            panelGrid.Size = new Size(gridWidth, gridHeight);
            panelGrid.Visible = true;

            // 3. ИДЕАЛЬНОЕ ЦЕНТРИРОВАНИЕ ДЕТАЛЬНОЙ КАРТОЧКИ (Экран №2)
            int detailsWidth = 1420;
            int detailsHeight = 750;
            int detailsLeft = (this.Width - detailsWidth) / 2;

            panelDetails.Location = new Point(detailsLeft, 110);
            panelDetails.Size = new Size(detailsWidth, detailsHeight);
            panelDetails.Visible = false;

            // Перестраиваем размеры элементов детального просмотра внутри панели
            picLarge.Size = new Size(540, 540);
            picLarge.Location = new Point(0, 0);
            picLarge.BorderStyle = BorderStyle.None; // Убираем черную рамку

            txtFullDesc.Size = new Size(860, 460);
            txtFullDesc.Location = new Point(560, 0);

            lblDetailedPrice.Size = new Size(860, 50);
            lblDetailedPrice.Location = new Point(560, 480);
            lblDetailedPrice.TextAlign = ContentAlignment.MiddleRight;

            // Центрируем нижние кнопки
            btnReserve.Size = new Size(260, 46);
            btnReserve.Location = new Point(440, 620);

            btnBackToGrid.Size = new Size(260, 46);
            btnBackToGrid.Location = new Point(720, 620);

            // Применяем аппаратное скругление и палитру к кнопкам экрана деталей
            StyleButton(btnReserve);
            StyleButton(btnBackToGrid);
            StyleButton(btnFormClose);

            // Очищаем и заново генерируем 8 товаров
            panelGrid.Controls.Clear();

            // 4. ГЕНЕРИРУЕМ НАШИ 8 РОСКОШНЫХ ТОВАРОВ
            CreateLargeProductTile(1, "Браслет с топазами и бриллиантами", 195000, Properties.Resources.item1,
                "Белое золото 585, 15 топазов, 30 бриллиантов.",
                "Роскошный браслет из белого золота 585 пробы. Уникальная ювелирная композиция гармонично сочетает в себе дорожку из 15 небесно-голубых топазов огранки 'Овал' и деликатную инкрустацию из 30 мелких сверкающих бриллиантов классической огранки. Полная ручная закрепка камней.");

            CreateLargeProductTile(2, "Обручальное кольцо переплетенное", 68900, Properties.Resources.item2,
                "Сочетание белого и розового золота 750 пробы.",
                "Эксклюзивное обручальное кольцо со сложным переплетенным дизайном. Выполнено из благородного сочетания белого и розового золота 750 пробы. Символизирует неразрывный союз двух сердец. Превосходная ювелирная классика высшего качества.");

            CreateLargeProductTile(3, "Кулон с розовым топазом", 42000, Properties.Resources.item3,
                "Розовое золото 585 пробы. Фирменная коробочка.",
                "Элегантный подвес из розового золота 585 пробы с натуральным розовым топазом безупречной чистоты. Изделие поставляется в комплекте с фирменной премиальной розовой коробочкой. Полностью готовый роскошный подарок.");

            CreateLargeProductTile(4, "Кольцо с большим аквамарином", 125000, Properties.Resources.item4,
                "Платина 950, крупный аквамарин 'Изумруд', фианиты.",
                "Великолепное платиновое кольцо 950 пробы, украшенное крупным чистейшим голубым аквамарином в центре. По бокам центральный камень изысканно подчеркнут аккуратными дорожками из мелких полупрозрачных фианитов. Изумительная ручная работа.");

            CreateLargeProductTile(5, "Длинные серьги 'Аристократ'", 275000, Properties.Resources.item5,
                "Платина 950, крупные каплевидные бриллианты, маркизы.",
                "Эксклюзивные висячие серьги царственного дизайна. Выполнены из платины высшей 950 пробы. Композиция увенчана ажурными цветочными элементами, переходящими в крупные каплевидные бриллианты чистейшей огранки в окружении плотной бриллиантовой инкрустации. Настоящая фамильная драгоценность.");

            CreateLargeProductTile(6, "Кольцо-солитер 'Розовое сияние'", 160000, Properties.Resources.item6,
                "Розовое золото 750, крупный муассанит, ореол.",
                "Роскошное помолвочное кольцо из благородного розового золота 750 пробы. В центре внимания — великолепный крупный муассанит идеальной круглой огранки, сияние которого многократно усиливается за счет двойного сверкающего ореола и инкрустированной камнями шинки. Символ вечной любви.");

            CreateLargeProductTile(7, "Брошь-булавка 'Колибри'", 420000, Properties.Resources.item7,
                "Желтое золото 585, saрфиры, изумруды, опалы.",
                "Ювелирный шедевр ручной сборки. Коллекционная брошь в виде экзотической птицы колибри выполнена из yellow золота 585 пробы. Тончайшая закрепка сотен цветных камней: натуральные синие сапфиры, яркие уральские изумруды, переливчатые благородные опалы и рубины создают неповторимую игру цвета.");

            CreateLargeProductTile(8, "Классический солитер 'Минимализм'", 95000, Properties.Resources.item8,
                "Розовое золото 585, чистейший бриллиант 0.5 карат.",
                "Изящное и лаконичное кольцо, выполненное в стиле утонченного минимализма из розового золота 585 пробы. Классический каст на 6 крапанах надежно удерживает крупный природный бриллиант весом 0.5 карат с безупречными оптическими характеристиками. Идеальный выбор для предложения.");
        }

        private void CreateLargeProductTile(int id, string name, double price, Image img, string shortDesc, string fullDesc)
        {
            Panel tile = new Panel();
            tile.Size = new Size(405, 360);
            tile.Margin = new Padding(10);
            tile.BorderStyle = BorderStyle.None; // Убираем черную рамку плитки
            tile.Cursor = Cursors.Hand;
            tile.BackColor = Color.White;        // Белая премиальная подложка товара

            // Динамическое скругление углов у самой плитки товара
            tile.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = new GraphicsPath())
                {
                    int r = 16; // Чуть больший радиус для плиток
                    path.AddArc(new Rectangle(0, 0, r, r), 180, 90);
                    path.AddArc(new Rectangle(tile.Width - r - 1, 0, r, r), 270, 90);
                    path.AddArc(new Rectangle(tile.Width - r - 1, tile.Height - r - 1, r, r), 0, 90);
                    path.AddArc(new Rectangle(0, tile.Height - r - 1, r, r), 90, 90);
                    path.CloseFigure();
                    tile.Region = new Region(path);

                    // Тонкая аккуратная пастельная кайма вокруг плитки
                    using (Pen pen = new Pen(Color.FromArgb(235, 228, 215), 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };

            PictureBox pic = new PictureBox();
            pic.Size = new Size(385, 210);
            pic.Location = new Point(10, 10);
            pic.Image = img;
            pic.SizeMode = PictureBoxSizeMode.Zoom;

            Label lblName = new Label();
            lblName.Size = new Size(385, 30);
            lblName.Location = new Point(10, 230);
            lblName.Text = name;
            lblName.ForeColor = Color.FromArgb(70, 65, 55); // Темная сепия вместо черного
            lblName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);

            Label lblShort = new Label();
            lblShort.Size = new Size(385, 45);
            lblShort.Location = new Point(10, 265);
            lblShort.Text = shortDesc;
            lblShort.ForeColor = Color.FromArgb(140, 130, 115); // Кофейный оттенок текста
            lblShort.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);

            Label lblCost = new Label();
            lblCost.Size = new Size(385, 30);
            lblCost.Location = new Point(10, 315);
            lblCost.Text = $"{price:N0} руб.";
            lblCost.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCost.ForeColor = Color.FromArgb(184, 134, 11); // Фирменное золото бренда вместо стандартного зеленого
            lblCost.TextAlign = ContentAlignment.MiddleRight;

            Action openDetailsAction = () =>
            {
                selectedProductId = id;
                currentProductName = name;
                currentProductPrice = price;
                picLarge.Image = img;
                txtFullDesc.Text = fullDesc;
                lblDetailedPrice.Text = $"{price:N0} руб.";

                panelGrid.Visible = false;
                panelDetails.Visible = true;
                lblTitle.Text = "Детальный просмотр изделия";
            };

            tile.Click += (s, a) => openDetailsAction();
            pic.Click += (s, a) => openDetailsAction();
            lblName.Click += (s, a) => openDetailsAction();
            lblShort.Click += (s, a) => openDetailsAction();
            lblCost.Click += (s, a) => openDetailsAction();

            tile.Controls.Add(pic);
            tile.Controls.Add(lblName);
            tile.Controls.Add(lblShort);
            tile.Controls.Add(lblCost);

            panelGrid.Controls.Add(tile);
        }

        private void StyleButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.Cursor = Cursors.Hand;
            btn.FlatAppearance.BorderSize = 0; // Полностью убираем черную рамку WinForms

            // Цветовые сценарии кнопок каталога
            if (btn.Name == "btnReserve")
            {
                // Кнопка бронирования — матовое золото с белым жирным текстом
                btn.BackColor = Color.FromArgb(184, 134, 11);
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            }
            else
            {
                // Кнопки возврата и закрытия каталога — благородный светлый нюд
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

        

        // ИСПРАВЛЕНИЕ: ЛОГИКА ОФОРМЛЕНИЯ БРОНИРОВАНИЯ КАК ПОЛНОЦЕННОЙ ЗАЯВКИ В ЖУРНАЛ СУБД
        private void btnReserve_Click(object sender, EventArgs e)
        {
            if (selectedProductId == -1) return;

            // 1. Запрашиваем номер телефона через модальное окно с маской
            Form phoneForm = new Form();
            phoneForm.Size = new Size(350, 180);
            phoneForm.Text = "Контакты для брони";
            phoneForm.StartPosition = FormStartPosition.CenterParent;
            phoneForm.FormBorderStyle = FormBorderStyle.FixedDialog;
            phoneForm.MaximizeBox = false;

            Label lblPrompt = new Label() { Left = 20, Top = 15, Width = 300, Text = "Введите ваш номер телефона для бронирования:" };
            MaskedTextBox mtbPhone = new MaskedTextBox() { Left = 20, Top = 40, Width = 290, Mask = "8 (000) 000-00-00", Font = new Font("Segoe UI", 11F) };
            Button btnOk = new Button() { Text = "Оформить", Left = 110, Top = 85, Width = 100, Height = 32, DialogResult = DialogResult.OK };
            Button btnCancel = new Button() { Text = "Отмена", Left = 215, Top = 85, Width = 95, Height = 32, DialogResult = DialogResult.Cancel };
            phoneForm.Controls.AddRange(new Control[] { lblPrompt, mtbPhone, btnOk, btnCancel });
            if (phoneForm.ShowDialog() != DialogResult.OK || !mtbPhone.MaskCompleted)
            {
                if (mtbPhone.Text != "8 (   )   -  -")
                {
                    MessageBox.Show("Бронирование отклонено! Номер телефона введен некорректно или не полностью.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }
            string contactPhone = mtbPhone.Text.Trim();
            if (string.IsNullOrEmpty(ClientLogin)) ClientLogin = "client1";
            // 2. ЗАПИСЬ СДЕЛКИ В БАЗУ ДАННЫХ В ЕДИНУЮ СИСТЕМУ СИНХРОНИЗАЦИИ ЖУРНАЛА
            using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Получаем ID вошедшего пользователя
                        int userId = 0;
                        string userQuery = "SELECT id FROM Users WHERE login = @login";
                        using (var cmd = new SQLiteCommand(userQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@login", ClientLogin);
                            object res = cmd.ExecuteScalar();
                            if (res != null) userId = Convert.ToInt32(res);
                        }
                        string dateStr = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                        // Помещаем запись в ClientDashboard со статусом брони!
                        // Поле order_ref_id привязываем к внутреннему ID товара
                        string insertDashboardQuery = @"
INSERT INTO ClientDashboard (user_id, order_type, order_ref_id, date_added, current_status, contact_data)
VALUES (@userId, 'Бронь', @refId, @date, 'Новая', @contact)";
                        using (var command = new SQLiteCommand(insertDashboardQuery, connection))
                        {
                            command.Parameters.AddWithValue("@userId", userId);
                            command.Parameters.AddWithValue("@refId", selectedProductId); // ID товара
                            command.Parameters.AddWithValue("@date", dateStr);
                            command.Parameters.AddWithValue("@contact", contactPhone); // Раньше телефон спрашивали, но никуда не сохраняли
                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                        MessageBox.Show($"Изделие '{currentProductName}' успешно забронировано за вашим аккаунтом!\n\nЗаявка отправлена в мастерскую. Отслеживайте её в Истории заказов.",
                        "Успех бронирования", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnBackToGrid_Click(null, null);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Ошибка бронирования: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void btnBackToGrid_Click(object sender, EventArgs e)
        {
            panelDetails.Visible = false;
            panelGrid.Visible = true;
            lblTitle.Text = "Эксклюзивные изделия в наличии";
            selectedProductId = -1;
        }
        private void btnFormClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}