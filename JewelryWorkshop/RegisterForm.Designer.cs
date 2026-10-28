namespace JewelryWorkshop
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.panelCenterCard = new System.Windows.Forms.Panel();
            this.lblLoginText = new System.Windows.Forms.Label();
            this.txtNewLogin = new System.Windows.Forms.TextBox();
            this.lblPasswordText = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.chkShowPasswordReg = new System.Windows.Forms.CheckBox(); // НАШ НОВЫЙ ФЛАЖОК
            this.lblRoleText = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblSecretCodeText = new System.Windows.Forms.Label();
            this.txtSecretCode = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.tableLayoutPanelMain.SuspendLayout();
            this.panelCenterCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 650F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.panelCenterCard, 1, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 510F)); // Увеличили высоту карточки под новый элемент
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1200, 800);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // panelCenterCard
            // 
            this.panelCenterCard.Controls.Add(this.btnBack);
            this.panelCenterCard.Controls.Add(this.btnSave);
            this.panelCenterCard.Controls.Add(this.txtSecretCode);
            this.panelCenterCard.Controls.Add(this.lblSecretCodeText);
            this.panelCenterCard.Controls.Add(this.cmbRole);
            this.panelCenterCard.Controls.Add(this.lblRoleText);
            this.panelCenterCard.Controls.Add(this.chkShowPasswordReg); // Добавили на панель
            this.panelCenterCard.Controls.Add(this.txtNewPassword);
            this.panelCenterCard.Controls.Add(this.lblPasswordText);
            this.panelCenterCard.Controls.Add(this.txtNewLogin);
            this.panelCenterCard.Controls.Add(this.lblLoginText);
            this.panelCenterCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterCard.Location = new System.Drawing.Point(278, 148);
            this.panelCenterCard.Name = "panelCenterCard";
            this.panelCenterCard.Size = new System.Drawing.Size(644, 504);
            this.panelCenterCard.TabIndex = 0;
            // 
            // lblLoginText
            // 
            this.lblLoginText.AutoSize = true;
            this.lblLoginText.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblLoginText.Location = new System.Drawing.Point(40, 43);
            this.lblLoginText.Name = "lblLoginText";
            this.lblLoginText.Size = new System.Drawing.Size(133, 28);
            this.lblLoginText.TabIndex = 0;
            this.lblLoginText.Text = "Новый логин:";
            // 
            // txtNewLogin
            // 
            this.txtNewLogin.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtNewLogin.Location = new System.Drawing.Point(210, 38);
            this.txtNewLogin.Name = "txtNewLogin";
            this.txtNewLogin.Size = new System.Drawing.Size(380, 39);
            this.txtNewLogin.TabIndex = 1;
            // 
            // lblPasswordText
            // 
            this.lblPasswordText.AutoSize = true;
            this.lblPasswordText.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblPasswordText.Location = new System.Drawing.Point(40, 113);
            this.lblPasswordText.Name = "lblPasswordText";
            this.lblPasswordText.Size = new System.Drawing.Size(147, 28);
            this.lblPasswordText.TabIndex = 2;
            this.lblPasswordText.Text = "Новый пароль:";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtNewPassword.Location = new System.Drawing.Point(210, 108);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '•';
            this.txtNewPassword.Size = new System.Drawing.Size(380, 39);
            this.txtNewPassword.TabIndex = 3;
            // 
            // chkShowPasswordReg
            // 
            this.chkShowPasswordReg.AutoSize = true;
            this.chkShowPasswordReg.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkShowPasswordReg.Location = new System.Drawing.Point(210, 160); // Разместили строго под полем пароля
            this.chkShowPasswordReg.Name = "chkShowPasswordReg";
            this.chkShowPasswordReg.Size = new System.Drawing.Size(166, 27);
            this.chkShowPasswordReg.TabIndex = 4;
            this.chkShowPasswordReg.Text = "Показать пароль";
            this.chkShowPasswordReg.UseVisualStyleBackColor = true;
            this.chkShowPasswordReg.CheckedChanged += new System.EventHandler(this.chkShowPasswordReg_CheckedChanged); // Подписка на событие
            // 
            // lblRoleText
            // 
            this.lblRoleText.AutoSize = true;
            this.lblRoleText.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblRoleText.Location = new System.Drawing.Point(40, 213); // Сместили на 30 пикселей ниже
            this.lblRoleText.Name = "lblRoleText";
            this.lblRoleText.Size = new System.Drawing.Size(129, 28);
            this.lblRoleText.TabIndex = 5;
            this.lblRoleText.Text = "Выбор роли:";
            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.cmbRole.Location = new System.Drawing.Point(210, 208); // Сместили ниже
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(380, 39);
            this.cmbRole.TabIndex = 6;
            this.cmbRole.SelectedIndexChanged += new System.EventHandler(this.cmbRole_SelectedIndexChanged);
            // 
            // lblSecretCodeText
            // 
            this.lblSecretCodeText.AutoSize = true;
            this.lblSecretCodeText.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblSecretCodeText.Location = new System.Drawing.Point(40, 283); // Сместили ниже
            this.lblSecretCodeText.Name = "lblSecretCodeText";
            this.lblSecretCodeText.Size = new System.Drawing.Size(131, 28);
            this.lblSecretCodeText.TabIndex = 7;
            this.lblSecretCodeText.Text = "Код мастера:";
            // 
            // txtSecretCode
            // 
            this.txtSecretCode.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtSecretCode.Location = new System.Drawing.Point(210, 278); // Сместили ниже
            this.txtSecretCode.Name = "txtSecretCode";
            this.txtSecretCode.PasswordChar = '•';
            this.txtSecretCode.Size = new System.Drawing.Size(380, 39);
            this.txtSecretCode.TabIndex = 8;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.Location = new System.Drawing.Point(120, 375); // Сместили нижние кнопки
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(230, 48);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Зарегистрироваться";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnBack.Location = new System.Drawing.Point(365, 375); // Сместили нижние кнопки
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(225, 48);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Назад";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            this.btnBack.UseVisualStyleBackColor = true;
            //
            // RegisterForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Регистрация нового аккаунта";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.panelCenterCard.ResumeLayout(false);
            this.panelCenterCard.PerformLayout();
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Panel panelCenterCard;
        private System.Windows.Forms.Label lblLoginText;
        private System.Windows.Forms.TextBox txtNewLogin;
        private System.Windows.Forms.Label lblPasswordText;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.CheckBox chkShowPasswordReg; // Переменная флажка
        private System.Windows.Forms.Label lblRoleText;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblSecretCodeText;
        private System.Windows.Forms.TextBox txtSecretCode;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBack;
    }
}