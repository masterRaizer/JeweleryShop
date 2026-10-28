namespace JewelryWorkshop
{
    partial class UserMainForm
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
            this.btnExit = new System.Windows.Forms.Button();
            this.btnMyOrders = new System.Windows.Forms.Button();
            this.btnCatalog = new System.Windows.Forms.Button();
            this.btnScrap = new System.Windows.Forms.Button();
            this.btnRepair = new System.Windows.Forms.Button();
            this.btnManufacturing = new System.Windows.Forms.Button();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain.SuspendLayout();
            this.panelCenterCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 825F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.panelCenterCard, 1, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 284F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(975, 569);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // panelCenterCard
            // 
            this.panelCenterCard.Controls.Add(this.btnExit);
            this.panelCenterCard.Controls.Add(this.btnMyOrders);
            this.panelCenterCard.Controls.Add(this.btnCatalog);
            this.panelCenterCard.Controls.Add(this.btnScrap);
            this.panelCenterCard.Controls.Add(this.btnRepair);
            this.panelCenterCard.Controls.Add(this.btnManufacturing);
            this.panelCenterCard.Controls.Add(this.lblSubTitle);
            this.panelCenterCard.Controls.Add(this.lblWelcome);
            this.panelCenterCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterCard.Location = new System.Drawing.Point(77, 144);
            this.panelCenterCard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelCenterCard.Name = "panelCenterCard";
            this.panelCenterCard.Size = new System.Drawing.Size(821, 280);
            this.panelCenterCard.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnExit.Location = new System.Drawing.Point(675, 16);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(112, 31);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Выйти";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMyOrders
            // 
            this.btnMyOrders.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnMyOrders.Location = new System.Drawing.Point(645, 114);
            this.btnMyOrders.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMyOrders.Name = "btnMyOrders";
            this.btnMyOrders.Size = new System.Drawing.Size(142, 106);
            this.btnMyOrders.TabIndex = 6;
            this.btnMyOrders.Text = "История\nзаказов";
            this.btnMyOrders.UseVisualStyleBackColor = true;
            this.btnMyOrders.Click += new System.EventHandler(this.btnMyOrders_Click);
            // 
            // btnCatalog
            // 
            this.btnCatalog.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCatalog.Location = new System.Drawing.Point(491, 114);
            this.btnCatalog.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCatalog.Name = "btnCatalog";
            this.btnCatalog.Size = new System.Drawing.Size(142, 106);
            this.btnCatalog.TabIndex = 5;
            this.btnCatalog.Text = "Товары\nв наличии";
            this.btnCatalog.UseVisualStyleBackColor = true;
            this.btnCatalog.Click += new System.EventHandler(this.btnCatalog_Click);
            // 
            // btnScrap
            // 
            this.btnScrap.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnScrap.Location = new System.Drawing.Point(338, 114);
            this.btnScrap.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnScrap.Name = "btnScrap";
            this.btnScrap.Size = new System.Drawing.Size(142, 106);
            this.btnScrap.TabIndex = 4;
            this.btnScrap.Text = "Сдать лом\n(Заявка)";
            this.btnScrap.UseVisualStyleBackColor = true;
            this.btnScrap.Click += new System.EventHandler(this.btnScrap_Click);
            // 
            // btnRepair
            // 
            this.btnRepair.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRepair.Location = new System.Drawing.Point(184, 114);
            this.btnRepair.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnRepair.Name = "btnRepair";
            this.btnRepair.Size = new System.Drawing.Size(142, 106);
            this.btnRepair.TabIndex = 3;
            this.btnRepair.Text = "Ремонт\nизделий";
            this.btnRepair.UseVisualStyleBackColor = true;
            this.btnRepair.Click += new System.EventHandler(this.btnRepair_Click);
            // 
            // btnManufacturing
            // 
            this.btnManufacturing.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnManufacturing.Location = new System.Drawing.Point(30, 114);
            this.btnManufacturing.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnManufacturing.Name = "btnManufacturing";
            this.btnManufacturing.Size = new System.Drawing.Size(142, 106);
            this.btnManufacturing.TabIndex = 2;
            this.btnManufacturing.Text = "Изготовление\nукрашений";
            this.btnManufacturing.UseVisualStyleBackColor = true;
            this.btnManufacturing.Click += new System.EventHandler(this.btnManufacturing_Click);
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubTitle.Location = new System.Drawing.Point(28, 57);
            this.lblSubTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(401, 20);
            this.lblSubTitle.TabIndex = 1;
            this.lblSubTitle.Text = "Выберите необходимую услугу ювелирной мастерской ниже:";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(26, 16);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(251, 32);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Добро пожаловать!";
            // 
            // UserMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 569);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UserMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Личный кабинет клиента";
            this.Load += new System.EventHandler(this.UserMainForm_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.panelCenterCard.ResumeLayout(false);
            this.panelCenterCard.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Panel panelCenterCard;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.Button btnManufacturing;
        private System.Windows.Forms.Button btnRepair;
        private System.Windows.Forms.Button btnScrap;
        private System.Windows.Forms.Button btnCatalog;
        private System.Windows.Forms.Button btnMyOrders;
        private System.Windows.Forms.Button btnExit;
    }
}