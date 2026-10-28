namespace JewelryWorkshop
{
    partial class ScrapForm
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
            this.btnSendScrap = new System.Windows.Forms.Button();
            this.lblTotalPayout = new System.Windows.Forms.Label();
            this.lblPayoutText = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.MaskedTextBox();
            this.lblContactText = new System.Windows.Forms.Label();
            this.txtWeight = new System.Windows.Forms.TextBox();
            this.lblWeightText = new System.Windows.Forms.Label();
            this.cmbScrapMetal = new System.Windows.Forms.ComboBox();
            this.lblMetalText = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain.SuspendLayout();
            this.panelCenterCard.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 600F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.panelCenterCard, 1, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 422F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1050, 650);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // panelCenterCard
            // 
            this.panelCenterCard.Controls.Add(this.btnBack);
            this.panelCenterCard.Controls.Add(this.btnSendScrap);
            this.panelCenterCard.Controls.Add(this.lblTotalPayout);
            this.panelCenterCard.Controls.Add(this.lblPayoutText);
            this.panelCenterCard.Controls.Add(this.txtContact);
            this.panelCenterCard.Controls.Add(this.lblContactText);
            this.panelCenterCard.Controls.Add(this.txtWeight);
            this.panelCenterCard.Controls.Add(this.lblWeightText);
            this.panelCenterCard.Controls.Add(this.cmbScrapMetal);
            this.panelCenterCard.Controls.Add(this.lblMetalText);
            this.panelCenterCard.Controls.Add(this.lblTitle);
            this.panelCenterCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterCard.Location = new System.Drawing.Point(227, 116);
            this.panelCenterCard.Margin = new System.Windows.Forms.Padding(2);
            this.panelCenterCard.Name = "panelCenterCard";
            this.panelCenterCard.Size = new System.Drawing.Size(596, 418);
            this.panelCenterCard.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnBack.Location = new System.Drawing.Point(382, 321);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(180, 45);
            this.btnBack.TabIndex = 10;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSendScrap
            // 
            this.btnSendScrap.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnSendScrap.Location = new System.Drawing.Point(195, 321);
            this.btnSendScrap.Margin = new System.Windows.Forms.Padding(2);
            this.btnSendScrap.Name = "btnSendScrap";
            this.btnSendScrap.Size = new System.Drawing.Size(180, 45);
            this.btnSendScrap.TabIndex = 9;
            this.btnSendScrap.Text = "Оставить заявку";
            this.btnSendScrap.UseVisualStyleBackColor = true;
            this.btnSendScrap.Click += new System.EventHandler(this.btnSendScrap_Click);
            // 
            // lblTotalPayout
            // 
            this.lblTotalPayout.AutoSize = true;
            this.lblTotalPayout.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTotalPayout.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblTotalPayout.Location = new System.Drawing.Point(322, 254);
            this.lblTotalPayout.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalPayout.Name = "lblTotalPayout";
            this.lblTotalPayout.Size = new System.Drawing.Size(109, 30);
            this.lblTotalPayout.TabIndex = 8;
            this.lblTotalPayout.Text = "0.00 руб.";
            // 
            // lblPayoutText
            // 
            this.lblPayoutText.AutoSize = true;
            this.lblPayoutText.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold);
            this.lblPayoutText.Location = new System.Drawing.Point(30, 256);
            this.lblPayoutText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPayoutText.Name = "lblPayoutText";
            this.lblPayoutText.Size = new System.Drawing.Size(279, 25);
            this.lblPayoutText.TabIndex = 7;
            this.lblPayoutText.Text = "Ориентировочно к выплате:";
            // 
            // txtContact
            // 
            this.txtContact.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtContact.Location = new System.Drawing.Point(195, 195);
            this.txtContact.Margin = new System.Windows.Forms.Padding(2);
            this.txtContact.Mask = "8 (000) 000-00-00";
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(368, 34);
            this.txtContact.TabIndex = 6;
            // 
            // lblContactText
            // 
            this.lblContactText.AutoSize = true;
            this.lblContactText.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.lblContactText.Location = new System.Drawing.Point(30, 199);
            this.lblContactText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContactText.Name = "lblContactText";
            this.lblContactText.Size = new System.Drawing.Size(130, 25);
            this.lblContactText.TabIndex = 5;
            this.lblContactText.Text = "Ваш телефон:";
            // 
            // txtWeight
            // 
            this.txtWeight.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtWeight.Location = new System.Drawing.Point(195, 138);
            this.txtWeight.Margin = new System.Windows.Forms.Padding(2);
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Size = new System.Drawing.Size(368, 34);
            this.txtWeight.TabIndex = 4;
            this.txtWeight.TextChanged += new System.EventHandler(this.txtWeight_TextChanged);
            // 
            // lblWeightText
            // 
            this.lblWeightText.AutoSize = true;
            this.lblWeightText.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.lblWeightText.Location = new System.Drawing.Point(30, 142);
            this.lblWeightText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWeightText.Name = "lblWeightText";
            this.lblWeightText.Size = new System.Drawing.Size(126, 25);
            this.lblWeightText.TabIndex = 3;
            this.lblWeightText.Text = "Ввод веса (г):";
            // 
            // cmbScrapMetal
            // 
            this.cmbScrapMetal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScrapMetal.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.cmbScrapMetal.Location = new System.Drawing.Point(195, 81);
            this.cmbScrapMetal.Margin = new System.Windows.Forms.Padding(2);
            this.cmbScrapMetal.Name = "cmbScrapMetal";
            this.cmbScrapMetal.Size = new System.Drawing.Size(368, 36);
            this.cmbScrapMetal.TabIndex = 2;
            this.cmbScrapMetal.SelectedIndexChanged += new System.EventHandler(this.cmbScrapMetal_SelectedIndexChanged);
            // 
            // lblMetalText
            // 
            this.lblMetalText.AutoSize = true;
            this.lblMetalText.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.lblMetalText.Location = new System.Drawing.Point(30, 85);
            this.lblMetalText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMetalText.Name = "lblMetalText";
            this.lblMetalText.Size = new System.Drawing.Size(149, 25);
            this.lblMetalText.TabIndex = 1;
            this.lblMetalText.Text = "Выбор металла:";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(99, 20);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(402, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Заявка на сдачу драгоценного лома";
            // 
            // ScrapForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 650);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ScrapForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Заявка на сдачу лома";
            this.Load += new System.EventHandler(this.ScrapForm_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.panelCenterCard.ResumeLayout(false);
            this.panelCenterCard.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Panel panelCenterCard;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblMetalText;
        private System.Windows.Forms.ComboBox cmbScrapMetal;
        private System.Windows.Forms.Label lblWeightText;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Label lblContactText;
        private System.Windows.Forms.MaskedTextBox txtContact;
        private System.Windows.Forms.Label lblPayoutText;
        private System.Windows.Forms.Label lblTotalPayout;
        private System.Windows.Forms.Button btnSendScrap;
        private System.Windows.Forms.Button btnBack;
    }
}