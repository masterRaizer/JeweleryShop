namespace JewelryWorkshop
{
    partial class ManufacturingForm
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
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.btnAttachPhoto = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnSendOrder = new System.Windows.Forms.Button();
            this.txtContact = new System.Windows.Forms.MaskedTextBox();
            this.lblContactText = new System.Windows.Forms.Label();
            this.txtGems = new System.Windows.Forms.TextBox();
            this.lblCommentsText = new System.Windows.Forms.Label();
            this.cmbGemType = new System.Windows.Forms.ComboBox();
            this.lblGemText = new System.Windows.Forms.Label();
            this.cmbMetalType = new System.Windows.Forms.ComboBox();
            this.lblMetalText = new System.Windows.Forms.Label();
            this.txtCustomJewelryType = new System.Windows.Forms.TextBox(); // НАШЕ НОВОЕ ПОЛЕ РУЧНОГО ВВОДА
            this.cmbJewelryType = new System.Windows.Forms.ComboBox();
            this.lblJewelryText = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain.SuspendLayout();
            this.panelCenterCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 938F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.panelCenterCard, 1, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 528F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(1200, 731);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // panelCenterCard
            // 
            this.panelCenterCard.Controls.Add(this.picPreview);
            this.panelCenterCard.Controls.Add(this.btnAttachPhoto);
            this.panelCenterCard.Controls.Add(this.btnBack);
            this.panelCenterCard.Controls.Add(this.btnSendOrder);
            this.panelCenterCard.Controls.Add(this.txtContact);
            this.panelCenterCard.Controls.Add(this.lblContactText);
            this.panelCenterCard.Controls.Add(this.txtGems);
            this.panelCenterCard.Controls.Add(this.lblCommentsText);
            this.panelCenterCard.Controls.Add(this.cmbGemType);
            this.panelCenterCard.Controls.Add(this.lblGemText);
            this.panelCenterCard.Controls.Add(this.cmbMetalType);
            this.panelCenterCard.Controls.Add(this.lblMetalText);
            this.panelCenterCard.Controls.Add(this.txtCustomJewelryType); // Добавили на панель
            this.panelCenterCard.Controls.Add(this.cmbJewelryType);
            this.panelCenterCard.Controls.Add(this.lblJewelryText);
            this.panelCenterCard.Controls.Add(this.lblTitle);
            this.panelCenterCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterCard.Location = new System.Drawing.Point(133, 103);
            this.panelCenterCard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelCenterCard.Name = "panelCenterCard";
            this.panelCenterCard.Size = new System.Drawing.Size(934, 524);
            this.panelCenterCard.TabIndex = 0;
            // 
            // picPreview
            // 
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(518, 73);
            this.picPreview.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(383, 375); // Немного увеличили высоту
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picPreview.TabIndex = 12;
            this.picPreview.TabStop = false;
            // 
            // btnAttachPhoto
            // 
            this.btnAttachPhoto.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnAttachPhoto.Location = new System.Drawing.Point(172, 410); // Сместили ниже
            this.btnAttachPhoto.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAttachPhoto.Name = "btnAttachPhoto";
            this.btnAttachPhoto.Size = new System.Drawing.Size(324, 37);
            this.btnAttachPhoto.TabIndex = 11;
            this.btnAttachPhoto.Text = "📎 Прикрепить фото эскиза";
            this.btnAttachPhoto.UseVisualStyleBackColor = true;
            this.btnAttachPhoto.Click += new System.EventHandler(this.btnAttachPhoto_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 13F);
            this.btnBack.Location = new System.Drawing.Point(382, 465); // Сместили ниже
            this.btnBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(188, 45);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnSendOrder
            // 
            this.btnSendOrder.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnSendOrder.Location = new System.Drawing.Point(172, 465); // Сместили ниже
            this.btnSendOrder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSendOrder.Name = "btnSendOrder";
            this.btnSendOrder.Size = new System.Drawing.Size(195, 45);
            this.btnSendOrder.TabIndex = 13;
            this.btnSendOrder.Text = "Отправить заявку";
            this.btnSendOrder.UseVisualStyleBackColor = true;
            this.btnSendOrder.Click += new System.EventHandler(this.btnSendOrder_Click);
            // 
            // txtContact
            // 
            this.txtContact.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtContact.Location = new System.Drawing.Point(172, 355); // Сместили ниже
            this.txtContact.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtContact.Mask = "8 (000) 000-00-00";
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(324, 34);
            this.txtContact.TabIndex = 10;
            // 
            // lblContactText
            // 
            this.lblContactText.AutoSize = true;
            this.lblContactText.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.lblContactText.Location = new System.Drawing.Point(30, 359); // Сместили ниже
            this.lblContactText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContactText.Name = "lblContactText";
            this.lblContactText.Size = new System.Drawing.Size(130, 25);
            this.lblContactText.TabIndex = 9;
            this.lblContactText.Text = "Ваш телефон:";
            // 
            // txtGems
            // 
            this.txtGems.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.txtGems.Location = new System.Drawing.Point(172, 298); // Сместили ниже
            this.txtGems.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtGems.Name = "txtGems";
            this.txtGems.Size = new System.Drawing.Size(324, 34);
            this.txtGems.TabIndex = 8;
            // 
            // lblCommentsText
            // 
            this.lblCommentsText.AutoSize = true;
            this.lblCommentsText.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.lblCommentsText.Location = new System.Drawing.Point(30, 302); // Сместили ниже
            this.lblCommentsText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCommentsText.Name = "lblCommentsText";
            this.lblCommentsText.Size = new System.Drawing.Size(117, 25);
            this.lblCommentsText.TabIndex = 7;
            this.lblCommentsText.Text = "Пожелания:";
            //
            // cmbGemType
            //
            this.cmbGemType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGemType.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.cmbGemType.Location = new System.Drawing.Point(172, 241); // Сместили ниже
            this.cmbGemType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbGemType.Name = "cmbGemType";
            this.cmbGemType.Size = new System.Drawing.Size(324, 36);
            this.cmbGemType.TabIndex = 6;
            //
            // lblGemText
            //
            this.lblGemText.AutoSize = true;
            this.lblGemText.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.lblGemText.Location = new System.Drawing.Point(30, 245); // Сместили ниже
            this.lblGemText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGemText.Name = "lblGemText";
            this.lblGemText.Size = new System.Drawing.Size(120, 25);
            this.lblGemText.TabIndex = 5;
            this.lblGemText.Text = "Драг. камни:";
            //
            // cmbMetalType
            //
            this.cmbMetalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetalType.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.cmbMetalType.Location = new System.Drawing.Point(172, 184); // Сместили ниже
            this.cmbMetalType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbMetalType.Name = "cmbMetalType";
            this.cmbMetalType.Size = new System.Drawing.Size(324, 36);
            this.cmbMetalType.TabIndex = 4;
            //
            // lblMetalText
            //
            this.lblMetalText.AutoSize = true;
            this.lblMetalText.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.lblMetalText.Location = new System.Drawing.Point(30, 188); // Сместили ниже
            this.lblMetalText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMetalText.Name = "lblMetalText";
            this.lblMetalText.Size = new System.Drawing.Size(138, 25);
            this.lblMetalText.TabIndex = 3;
            this.lblMetalText.Text = "Выбор сплава:";
            //
            // txtCustomJewelryType
            //
            this.txtCustomJewelryType.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtCustomJewelryType.Location = new System.Drawing.Point(172, 127); // Размещено ровно между списком изделий и сплавом
            this.txtCustomJewelryType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCustomJewelryType.Name = "txtCustomJewelryType";
            this.txtCustomJewelryType.Size = new System.Drawing.Size(324, 32);
            this.txtCustomJewelryType.TabIndex = 15;
            this.txtCustomJewelryType.Visible = false; // ПО УМОЛЧАНИЮ СКРЫТО
                                                       //
                                                       // cmbJewelryType
                                                       //
            this.cmbJewelryType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJewelryType.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.cmbJewelryType.Location = new System.Drawing.Point(172, 73);
            this.cmbJewelryType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbJewelryType.Name = "cmbJewelryType";
            this.cmbJewelryType.Size = new System.Drawing.Size(324, 36);
            this.cmbJewelryType.TabIndex = 2;
            this.cmbJewelryType.SelectedIndexChanged += new System.EventHandler(this.cmbJewelryType_SelectedIndexChanged); // ПОДПИСКА НА СОБЫТИЕ
                                                                                                                           //
                                                                                                                           // lblJewelryText
                                                                                                                           //
            this.lblJewelryText.AutoSize = true;
            this.lblJewelryText.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.lblJewelryText.Location = new System.Drawing.Point(30, 77);
            this.lblJewelryText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblJewelryText.Name = "lblJewelryText";
            this.lblJewelryText.Size = new System.Drawing.Size(123, 25);
            this.lblJewelryText.TabIndex = 1;
            this.lblJewelryText.Text = "Тип изделия:";
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(259, 16);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(437, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Заявка на изготовление украшения";
            //
            // ManufacturingForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 731);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ManufacturingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Изготовление ювелирных изделий";
            this.Load += new System.EventHandler(this.ManufacturingForm_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.panelCenterCard.ResumeLayout(false);
            this.panelCenterCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Panel panelCenterCard;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblJewelryText;
        private System.Windows.Forms.ComboBox cmbJewelryType;
        private System.Windows.Forms.TextBox txtCustomJewelryType; // Переменная нового текстового поля
        private System.Windows.Forms.Label lblMetalText;
        private System.Windows.Forms.ComboBox cmbMetalType;
        private System.Windows.Forms.Label lblGemText;
        private System.Windows.Forms.ComboBox cmbGemType;
        private System.Windows.Forms.Label lblCommentsText;
        private System.Windows.Forms.TextBox txtGems;
        private System.Windows.Forms.Label lblContactText;
        private System.Windows.Forms.MaskedTextBox txtContact;
        private System.Windows.Forms.Button btnAttachPhoto;
        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnSendOrder;
        private System.Windows.Forms.Button btnBack;
    }
}