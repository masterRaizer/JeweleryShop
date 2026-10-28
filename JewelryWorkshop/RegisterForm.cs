using System;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace JewelryWorkshop
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            // 1. Автоматически наполняем роли
            cmbRole.Items.Clear();
            cmbRole.Items.Add("Пользователь");
            cmbRole.Items.Add("Мастер");
            cmbRole.SelectedIndex = 0;

            // 2. ЦВЕТОВАЯ ПАЛИТРА «ШАМПАНЬ» ДЛЯ ФОРМЫ РЕГИСТРАЦИИ
            this.BackColor = Color.FromArgb(253, 251, 247); // Нежный кремово-молочный фон формы
            panelCenterCard.BackColor = Color.White;         // Белоснежная центральная карточка

            // Принудительно перекрашиваем надписи под благородный стиль сепии
            lblLoginText.ForeColor = Color.FromArgb(70, 65, 55);
            lblPasswordText.ForeColor = Color.FromArgb(70, 65, 55);
            lblRoleText.ForeColor = Color.FromArgb(70, 65, 55);
            lblSecretCodeText.ForeColor = Color.FromArgb(184, 134, 11); // Золотой акцент для секретного кода
            chkShowPasswordReg.ForeColor = Color.FromArgb(90, 85, 75);

            // Пастельный стиль текстовых полей ввода
            txtNewLogin.BackColor = Color.White;
            txtNewPassword.BackColor = Color.White;
            txtSecretCode.BackColor = Color.White;

            // 3. ПРЕМИАЛЬНЫЙ СТИЛЬ И СКРУГЛЕНИЕ КНОПОК
            foreach (Control control in this.panelCenterCard.Controls)
            {
                if (control is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.Cursor = Cursors.Hand;
                    btn.FlatAppearance.BorderSize = 0; // Полностью убираем дефолтные черные границы

                    // Цветовые сценарии кнопок регистрации
                    if (btn.Name == "btnSave")
                    {
                        // Главное действие — насыщенное матовое золото и белый жирный текст
                        btn.BackColor = Color.FromArgb(184, 134, 11);
                        btn.ForeColor = Color.White;
                        btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                    }
                    else if (btn.Name == "btnBack")
                    {
                        // Второстепенная кнопка — мягкий благородный нюд
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

            lblSecretCodeText.Visible = false;
            txtSecretCode.Visible = false;
        }

        // ЛОГИКА ФЛАЖКА: ПОКАЗАТЬ / СКРЫТЬ ПАРОЛЬ ПРИ РЕГИСТРАЦИИ
        private void chkShowPasswordReg_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPasswordReg.Checked)
            {
                txtNewPassword.PasswordChar = '\0'; // Раскрываем символы пароля
            }
            else
            {
                txtNewPassword.PasswordChar = '•'; // Маскируем пароль обратно
            }
        }

        // Кнопка "Зарегистрироваться"
        private void btnSave_Click(object sender, EventArgs e)
        {
            string login = txtNewLogin.Text.Trim();
            string password = txtNewPassword.Text.Trim();
            string role = cmbRole.SelectedItem.ToString();
            string secretCode = txtSecretCode.Text.Trim();

            // Базовая проверка на пустые поля
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Заполните все обязательные поля (Логин и Пароль)!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ЗАЩИТА: Если регистрируется Мастер, проверяем секретный код
            if (role == "Мастер")
            {
                string correctSecretCode = "flomaster";

                if (secretCode != correctSecretCode)
                {
                    MessageBox.Show("Неверный секретный код сотрудника! Регистрация в роли Мастера отклонена.",
                                    "Ошибка доступа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            using (var connection = new SQLiteConnection(DatabaseManager.ConnectionString))
            {
                connection.Open();

                // Проверяем уникальность логина
                string checkUserQuery = "SELECT COUNT(*) FROM Users WHERE login = @login";
                using (var checkCmd = new SQLiteCommand(checkUserQuery, connection))
                {
                    checkCmd.Parameters.AddWithValue("@login", login);
                    long count = (long)checkCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Получаем ID роли из таблицы Roles
                int roleId = 2; // По умолчанию Пользователь
                string getRoleQuery = "SELECT id FROM Roles WHERE role_name = @roleName";
                using (var roleCmd = new SQLiteCommand(getRoleQuery, connection))
                {
                    roleCmd.Parameters.AddWithValue("@roleName", role);
                    object rId = roleCmd.ExecuteScalar();
                    if (rId != null) roleId = Convert.ToInt32(rId);
                }

                // Записываем пользователя в таблицу Users
                string insertQuery = "INSERT INTO Users (login, password, role_id) VALUES (@login, @password, @roleId)";
                using (var insertCmd = new SQLiteCommand(insertQuery, connection))
                {
                    insertCmd.Parameters.AddWithValue("@login", login);
                    insertCmd.Parameters.AddWithValue("@password", SecurityHelper.HashPassword(password));
                    insertCmd.Parameters.AddWithValue("@roleId", roleId);

                    insertCmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show($"Аккаунт с ролью '{role}' успешно зарегистрирован!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        // Кнопка "Назад"
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRole.SelectedItem != null && cmbRole.SelectedItem.ToString() == "Мастер")
            {
                lblSecretCodeText.Visible = true;
                txtSecretCode.Visible = true;
            }
            else
            {
                lblSecretCodeText.Visible = false;
                txtSecretCode.Visible = false;
                txtSecretCode.Text = "";
            }
        }
    }
}
