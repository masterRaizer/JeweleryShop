namespace JewelryWorkshop
{
    partial class RepairForm
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
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSendRepair = new System.Windows.Forms.Button();
            this.lblEstimatedPrice = new System.Windows.Forms.Label();
            this.lblEstimatedPriceText = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.MaskedTextBox();
            this.lblContactText = new System.Windows.Forms.Label();
            this.dgvRepairPrice = new System.Windows.Forms.DataGridView();
            this.lblDamageText = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain.SuspendLayout();
            this.panelCenterCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepairPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 900F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.panelCenterCard, 1, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 552F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1125, 691);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // panelCenterCard
            // 
            this.panelCenterCard.Controls.Add(this.btnBack);
            this.panelCenterCard.Controls.Add(this.btnSendRepair);
            this.panelCenterCard.Controls.Add(this.lblEstimatedPrice);
            this.panelCenterCard.Controls.Add(this.lblEstimatedPriceText);
            this.panelCenterCard.Controls.Add(this.txtContact);
            this.panelCenterCard.Controls.Add(this.lblContactText);
            this.panelCenterCard.Controls.Add(this.dgvRepairPrice);
            this.panelCenterCard.Controls.Add(this.lblDamageText);
            this.panelCenterCard.Controls.Add(this.lblTitle);
            this.panelCenterCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterCard.Location = new System.Drawing.Point(114, 71);
            this.panelCenterCard.Margin = new System.Windows.Forms.Padding(2);
            this.panelCenterCard.Name = "panelCenterCard";
            this.panelCenterCard.Size = new System.Drawing.Size(896, 548);
            this.panelCenterCard.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnBack.Location = new System.Drawing.Point(435, 483);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(188, 45);
            this.btnBack.TabIndex = 8;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSendRepair
            // 
            this.btnSendRepair.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnSendRepair.Location = new System.Drawing.Point(225, 483);
            this.btnSendRepair.Margin = new System.Windows.Forms.Padding(2);
            this.btnSendRepair.Name = "btnSendRepair";
            this.btnSendRepair.Size = new System.Drawing.Size(195, 45);
            this.btnSendRepair.TabIndex = 7;
            this.btnSendRepair.Text = "Отправить заявку";
            this.btnSendRepair.UseVisualStyleBackColor = true;
            this.btnSendRepair.Click += new System.EventHandler(this.btnSendRepair_Click);
            // 
            // lblEstimatedPrice
            // 
            this.lblEstimatedPrice.AutoSize = true;
            this.lblEstimatedPrice.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblEstimatedPrice.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblEstimatedPrice.Location = new System.Drawing.Point(277, 428);
            this.lblEstimatedPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEstimatedPrice.Name = "lblEstimatedPrice";
            this.lblEstimatedPrice.Size = new System.Drawing.Size(109, 30);
            this.lblEstimatedPrice.TabIndex = 6;
            this.lblEstimatedPrice.Text = "0.00 руб.";
            // 
            // lblEstimatedPriceText
            // 
            this.lblEstimatedPriceText.AutoSize = true;
            this.lblEstimatedPriceText.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblEstimatedPriceText.Location = new System.Drawing.Point(22, 431);
            this.lblContactText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEstimatedPriceText.Name = "lblEstimatedPriceText";
            this.lblEstimatedPriceText.Size = new System.Drawing.Size(243, 25);
            this.lblEstimatedPriceText.TabIndex = 5;
            this.lblEstimatedPriceText.Text = "Итоговая сумма ремонта:";
            // 
            // txtContact
            // 
            this.txtContact.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtContact.Location = new System.Drawing.Point(225, 374);
            this.txtContact.Margin = new System.Windows.Forms.Padding(2);
            this.txtContact.Mask = "8 (000) 000-00-00";
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(301, 34);
            this.txtContact.TabIndex = 4;
            // 
            // lblContactText
            // 
            this.lblContactText.AutoSize = true;
            this.lblContactText.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.lblContactText.Location = new System.Drawing.Point(22, 378);
            this.lblContactText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContactText.Name = "lblContactText";
            this.lblContactText.Size = new System.Drawing.Size(130, 25);
            this.lblContactText.TabIndex = 3;
            this.lblContactText.Text = "Ваш телефон:";
            // 
            // dgvRepairPrice
            // 
            this.dgvRepairPrice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRepairPrice.Location = new System.Drawing.Point(26, 102);
            this.dgvRepairPrice.Margin = new System.Windows.Forms.Padding(2);
            this.dgvRepairPrice.Name = "dgvRepairPrice";
            this.dgvRepairPrice.RowHeadersWidth = 51;
            this.dgvRepairPrice.RowTemplate.Height = 32;
            this.dgvRepairPrice.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRepairPrice.MultiSelect = true; // ИСПРАВЛЕНИЕ: РАЗРЕШАЕМ МУЛЬТИВЫБОР ОПЦИЙ РАЗОМ
            this.dgvRepairPrice.Size = new System.Drawing.Size(840, 252);
            this.dgvRepairPrice.TabIndex = 2;
            this.dgvRepairPrice.SelectionChanged += new System.EventHandler(this.dgvRepairPrice_SelectionChanged);
            // 
            // lblDamageText
            // 
            this.lblDamageText.AutoSize = true;
            this.lblDamageText.Font = new System.Drawing.Font("Segoe UI", 13, System.Drawing.FontStyle.Bold);
            this.lblDamageText.Location = new System.Drawing.Point(22, 65);
            this.lblDamageText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDamageText.Name = "lblDamageText";
            this.lblDamageText.Size = new System.Drawing.Size(550, 25);
            this.lblDamageText.TabIndex = 1;
            this.lblDamageText.Text = "Зажмите Ctrl или Shift для выбора нескольких поломок:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(240, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(383, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Оформление заказа на ремонт";
            //
            // RepairForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 691);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RepairForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ремонт ювелирных изделий";
            this.Load += new System.EventHandler(this.RepairForm_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.panelCenterCard.ResumeLayout(false);
            this.panelCenterCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRepairPrice)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Panel panelCenterCard;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDamageText;
        private System.Windows.Forms.DataGridView dgvRepairPrice;
        private System.Windows.Forms.Label lblContactText;
        private System.Windows.Forms.MaskedTextBox txtContact;
        private System.Windows.Forms.Label lblEstimatedPriceText;
        private System.Windows.Forms.Label lblEstimatedPrice;
        private System.Windows.Forms.Button btnSendRepair;
        private System.Windows.Forms.Button btnBack;
    }
}