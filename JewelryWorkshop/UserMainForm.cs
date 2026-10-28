using System;
using System.Windows.Forms;
using System.Drawing;

namespace JewelryWorkshop
{
    public partial class UserMainForm : Form
    {
        // Переменная для хранения логина вошедшего пользователя
        public string CurrentUserLogin { get; set; }

        public UserMainForm()
        {
            InitializeComponent();
        }

        // Событие загрузки формы: вывод приветствия и наложение премиальной дизайн-системы
        private void UserMainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            // Как только форма загрузится, выводим имя пользователя на лейбл
            lblWelcome.Text = $"Вы вошли как: {CurrentUserLogin}";

            // ЦВЕТОВАЯ ПАЛИТРА «ШАМПАНЬ» ДЛЯ ГЛАВНОГО МЕНЮ ПОЛЬЗОВАТЕЛЯ
            this.BackColor = Color.FromArgb(253, 251, 247); // Нежный кремово-молочный фон приложения
            panelCenterCard.BackColor = Color.White;         // Белоснежная центральная карточка-подложка

            // Стилизация текстовых элементов
            lblWelcome.ForeColor = Color.FromArgb(184, 134, 11); // Глубокое премиальное золото (DarkGoldenrod)
            lblSubTitle.ForeColor = Color.FromArgb(140, 130, 115); // Мягкий кофейный оттенок

            // Автоматическое премиальное скругление углов у всех кнопок-плиток меню
            foreach (Control control in this.panelCenterCard.Controls)
            {
                if (control is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Cursor = Cursors.Hand;
                    btn.FlatAppearance.BorderSize = 0; // Полностью убираем дефолтные серые и черные границы WinForms

                    // Цветовое разделение кнопок меню под ювелирную концепцию
                    if (btn.Name == "btnExit")
                    {
                        // Маленькая кнопка выхода — аккуратный светлый нюд
                        btn.BackColor = Color.FromArgb(225, 215, 198);
                        btn.ForeColor = Color.FromArgb(60, 55, 45);
                        btn.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular);
                    }
                    else
                    {
                        // Плитки основных услуг (Изготовление, Ремонт, Скупка, Каталог, Заказы) — матовое золото с белым текстом
                        btn.BackColor = Color.FromArgb(212, 185, 145);
                        btn.ForeColor = Color.White;
                        btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    }

                    // Обрезаем острые системные углы до радиуса 12
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

        // Кнопка "Выйти из аккаунта"
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); // Просто закрывает эту форму
        }

        private void btnManufacturing_Click(object sender, EventArgs e)
        {
            ManufacturingForm mForm = new ManufacturingForm();

            // Передаем логин текущего пользователя, который мы сохранили при входе
            mForm.ClientLogin = this.CurrentUserLogin;

            this.Hide(); // Скрываем главное меню
            mForm.ShowDialog(); // Открываем форму заказа
            this.Show();
        }

        private void btnRepair_Click(object sender, EventArgs e)
        {
            RepairForm rForm = new RepairForm();
            rForm.ClientLogin = this.CurrentUserLogin; // Передаем логин клиента

            this.Hide();
            rForm.ShowDialog();
            this.Show();
        }

        private void btnScrap_Click(object sender, EventArgs e)
        {
            ScrapForm sForm = new ScrapForm();
            sForm.ClientLogin = this.CurrentUserLogin; // Передаем логин

            this.Hide();
            sForm.ShowDialog();
            this.Show();
        }

        private void btnCatalog_Click(object sender, EventArgs e)
        {
            CatalogForm cForm = new CatalogForm();

            cForm.ClientLogin = this.CurrentUserLogin;

            this.Hide();
            cForm.ShowDialog();
            this.Show();
        }

        private void btnMyOrders_Click(object sender, EventArgs e)
        {
            UserOrdersForm ordersForm = new UserOrdersForm();

            // Передаем логин текущего пользователя, чтобы форма знала, чьи заказы искать
            ordersForm.ClientLogin = this.CurrentUserLogin;

            this.Hide(); // Прячем главное меню
            ordersForm.ShowDialog(); // Открываем историю заказов
            this.Show();
        }
    }
}
