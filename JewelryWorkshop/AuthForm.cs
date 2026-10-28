using JewelryWorkshop.Models;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace JewelryWorkshop
{
    public partial class AuthForm : Form
    {
        public AuthForm()
        {
            InitializeComponent();
        }

        // Кнопка "Регистрация"
        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm regForm = new RegisterForm();

            this.Hide(); // Прячем окно входа
            regForm.ShowDialog(); // Показываем окно регистрации как модальное (код замрет тут, пока его не закроют)
            this.Show(); // Когда окно регистрации закроется (через Назад или Успех), логин снова покажется
        }

        // Кнопка "Войти"
        private void btnEnter_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Проверка на пустые поля ввода
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, введите логин и пароль!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                connection.Open();

                // Безопасный параметризованный запрос с JOIN для определения роли
                string query = @"SELECT Roles.role_name 
                         FROM Users 
                         INNER JOIN Roles ON Users.role_id = Roles.id 
                         WHERE Users.login = @login AND Users.password = @password";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", SecurityHelper.HashPassword(password));

                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        string userRole = result.ToString();

                        // --- ВОТ ОНО! ВСПЛЫВАЮЩЕЕ ОКНО ОБ УСПЕШНОМ ВХОДЕ ---
                        // Выводим логин, текст роли и ставим красивую синюю иконку Информации
                        MessageBox.Show($"Авторизация успешно пройдена!\n\nДобро пожаловать, {login}.\nВаша роль в системе: {userRole}",
                                        "Успешный вход",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                        // Очищаем поля ввода, чтобы при выходе из аккаунта форма была чистой
                        txtLogin.Text = "";
                        txtPassword.Text = "";

                        // В зависимости от роли открываем нужное окно
                        if (userRole == "Мастер")
                        {
                            MasterForm mForm = new MasterForm();
                            this.Hide();
                            mForm.ShowDialog();
                            this.Show();
                        }
                        else
                        {
                            UserMainForm userMenu = new UserMainForm();
                            userMenu.CurrentUserLogin = login;
                            this.Hide();
                            userMenu.ShowDialog();
                            this.Show();
                        }
                    }
                    else
                    {
                        // Если логин или пароль не подошли
                        MessageBox.Show("Неверный логин или пароль! Доступ отклонен.", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }



        private void AuthForm_Load(object sender, EventArgs e)
        {
            // 1. Принудительно разворачиваем окно на весь экран при старте
            this.WindowState = FormWindowState.Maximized;

            // 2. ЦВЕТОВАЯ ПАЛИТРА «ШАМПАНЬ» ДЛЯ ВСЕЙ ФОРМЫ
            this.BackColor = Color.FromArgb(253, 251, 247); // Нежный кремово-молочный фон приложения
            panelCenterCard.BackColor = Color.White;         // Белоснежная центральная карточка

            // Принудительно перекрашиваем надписи под благородный стиль
            lblMainTitle.ForeColor = Color.FromArgb(184, 134, 11); // Глубокое золото (DarkGoldenrod)
            lblSubTitle.ForeColor = Color.FromArgb(140, 130, 115);  // Мягкий кофейный оттенок
            lblLogin.ForeColor = Color.FromArgb(70, 65, 55);       // Темно-сепия для читаемости
            lblPassword.ForeColor = Color.FromArgb(70, 65, 55);
            chkShowPassword.ForeColor = Color.FromArgb(90, 85, 75);

            // 3. ПРЕМИАЛЬНЫЙ СТИЛЬ И СКРУГЛЕНИЕ КНОПОК
            foreach (Control control in this.panelCenterCard.Controls)
            {
                if (control is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Cursor = Cursors.Hand;

                    // Дизайн кнопок: матовый бежево-золотой с белым текстом
                    btn.BackColor = Color.FromArgb(212, 185, 145);
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    btn.FlatAppearance.BorderSize = 0; // Убираем жесткую черную рамку

                    // Скругление радиусом 12
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




        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
            {
                // Отключаем скрытие: пароль становится полностью видимым
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                // Включаем скрытие: заменяем все символы на жирные точки
                txtPassword.PasswordChar = '\u2022';
            }
        }

        // Срабатывает при нажатии клавиш в поле ЛОГИНА
        private void txtLogin_KeyDown(object sender, KeyEventArgs e)
        {
            // Если нажата клавиша Enter
            if (e.KeyCode == Keys.Enter)
            {
                // Подавляем стандартный системный звуковой сигнал ("писк")
                e.SuppressKeyPress = true;

                // Переносим фокус (курсор клавиатуры) на поле пароля
                txtPassword.Focus();
            }
        }

        // Срабатывает при нажатии клавиш в поле ПАРОЛЯ
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            // Если нажата клавиша Enter
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                // Автоматически "кликаем" по кнопке Войти, запуская наш метод авторизации
                btnEnter_Click(this, new EventArgs());
            }
        }

    }
}
