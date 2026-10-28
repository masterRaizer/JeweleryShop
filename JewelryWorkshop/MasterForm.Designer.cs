namespace JewelryWorkshop
{
    partial class MasterForm
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
            this.btnViewImage = new System.Windows.Forms.Button();
            this.btnUpdateMetalPrice = new System.Windows.Forms.Button();
            this.txtNewMetalPrice = new System.Windows.Forms.TextBox();
            this.lblNewPriceText = new System.Windows.Forms.Label();
            this.cmbPriceMetalSelect = new System.Windows.Forms.ComboBox();
            this.lblCourseText = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnOpenArchive = new System.Windows.Forms.Button();
            this.btnArchiveOrder = new System.Windows.Forms.Button();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.cmbStatuses = new System.Windows.Forms.ComboBox();
            this.lblStatusText = new System.Windows.Forms.Label();
            this.dgvRequests = new System.Windows.Forms.DataGridView();
            this.cmbRequestFilter = new System.Windows.Forms.ComboBox();
            this.lblFilterText = new System.Windows.Forms.Label();
            this.lblTableTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain.SuspendLayout();
            this.panelCenterCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 720F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.panelCenterCard, 1, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 504F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(975, 650);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // panelCenterCard
            // 
            this.panelCenterCard.Controls.Add(this.btnViewImage);
            this.panelCenterCard.Controls.Add(this.btnUpdateMetalPrice);
            this.panelCenterCard.Controls.Add(this.txtNewMetalPrice);
            this.panelCenterCard.Controls.Add(this.lblNewPriceText);
            this.panelCenterCard.Controls.Add(this.cmbPriceMetalSelect);
            this.panelCenterCard.Controls.Add(this.lblCourseText);
            this.panelCenterCard.Controls.Add(this.btnExit);
            this.panelCenterCard.Controls.Add(this.btnOpenArchive);
            this.panelCenterCard.Controls.Add(this.btnArchiveOrder);
            this.panelCenterCard.Controls.Add(this.btnUpdateStatus);
            this.panelCenterCard.Controls.Add(this.cmbStatuses);
            this.panelCenterCard.Controls.Add(this.lblStatusText);
            this.panelCenterCard.Controls.Add(this.dgvRequests);
            this.panelCenterCard.Controls.Add(this.cmbRequestFilter);
            this.panelCenterCard.Controls.Add(this.lblFilterText);
            this.panelCenterCard.Controls.Add(this.lblTableTitle);
            this.panelCenterCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterCard.Location = new System.Drawing.Point(129, 75);
            this.panelCenterCard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelCenterCard.Name = "panelCenterCard";
            this.panelCenterCard.Size = new System.Drawing.Size(716, 500);
            this.panelCenterCard.TabIndex = 0;
            // 
            // btnViewImage
            // 
            this.btnViewImage.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnViewImage.ForeColor = System.Drawing.Color.DarkBlue;
            this.btnViewImage.Location = new System.Drawing.Point(15, 297);
            this.btnViewImage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnViewImage.Name = "btnViewImage";
            this.btnViewImage.Size = new System.Drawing.Size(195, 31);
            this.btnViewImage.TabIndex = 16;
            this.btnViewImage.Text = "🖼️ Посмотреть эскиз изделия";
            this.btnViewImage.UseVisualStyleBackColor = true;
            this.btnViewImage.Click += new System.EventHandler(this.btnViewImage_Click);
            // 
            // btnUpdateMetalPrice
            // 
            this.btnUpdateMetalPrice.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnUpdateMetalPrice.Location = new System.Drawing.Point(611, 387);
            this.btnUpdateMetalPrice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUpdateMetalPrice.Name = "btnUpdateMetalPrice";
            this.btnUpdateMetalPrice.Size = new System.Drawing.Size(90, 31);
            this.btnUpdateMetalPrice.TabIndex = 15;
            this.btnUpdateMetalPrice.Text = "Обновить";
            this.btnUpdateMetalPrice.UseVisualStyleBackColor = true;
            this.btnUpdateMetalPrice.Click += new System.EventHandler(this.btnUpdateMetalPrice_Click);
            // 
            // txtNewMetalPrice
            // 
            this.txtNewMetalPrice.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtNewMetalPrice.Location = new System.Drawing.Point(529, 397);
            this.txtNewMetalPrice.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNewMetalPrice.Name = "txtNewMetalPrice";
            this.txtNewMetalPrice.Size = new System.Drawing.Size(76, 27);
            this.txtNewMetalPrice.TabIndex = 14;
            // 
            // lblNewPriceText
            // 
            this.lblNewPriceText.AutoSize = true;
            this.lblNewPriceText.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblNewPriceText.Location = new System.Drawing.Point(435, 401);
            this.lblNewPriceText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNewPriceText.Name = "lblNewPriceText";
            this.lblNewPriceText.Size = new System.Drawing.Size(94, 20);
            this.lblNewPriceText.TabIndex = 13;
            this.lblNewPriceText.Text = "Новая цена:";
            // 
            // cmbPriceMetalSelect
            // 
            this.cmbPriceMetalSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPriceMetalSelect.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbPriceMetalSelect.Location = new System.Drawing.Point(128, 397);
            this.cmbPriceMetalSelect.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbPriceMetalSelect.Name = "cmbPriceMetalSelect";
            this.cmbPriceMetalSelect.Size = new System.Drawing.Size(297, 28);
            this.cmbPriceMetalSelect.TabIndex = 12;
            // 
            // lblCourseText
            // 
            this.lblCourseText.AutoSize = true;
            this.lblCourseText.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblCourseText.Location = new System.Drawing.Point(15, 401);
            this.lblCourseText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCourseText.Name = "lblCourseText";
            this.lblCourseText.Size = new System.Drawing.Size(113, 20);
            this.lblCourseText.TabIndex = 11;
            this.lblCourseText.Text = "Металл скупки:";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnExit.Location = new System.Drawing.Point(15, 451);
            this.btnExit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(165, 37);
            this.btnExit.TabIndex = 10;
            this.btnExit.Text = "Выход из системы";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnOpenArchive
            // 
            this.btnOpenArchive.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnOpenArchive.Location = new System.Drawing.Point(566, 342);
            this.btnOpenArchive.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOpenArchive.Name = "btnOpenArchive";
            this.btnOpenArchive.Size = new System.Drawing.Size(135, 31);
            this.btnOpenArchive.TabIndex = 8;
            this.btnOpenArchive.Text = "Открыть архив";
            this.btnOpenArchive.UseVisualStyleBackColor = true;
            this.btnOpenArchive.Click += new System.EventHandler(this.btnOpenArchive_Click);
            // 
            // btnArchiveOrder
            // 
            this.btnArchiveOrder.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnArchiveOrder.Location = new System.Drawing.Point(431, 342);
            this.btnArchiveOrder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnArchiveOrder.Name = "btnArchiveOrder";
            this.btnArchiveOrder.Size = new System.Drawing.Size(128, 31);
            this.btnArchiveOrder.TabIndex = 7;
            this.btnArchiveOrder.Text = "В архив";
            this.btnArchiveOrder.UseVisualStyleBackColor = true;
            this.btnArchiveOrder.Click += new System.EventHandler(this.btnArchiveOrder_Click);
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.btnUpdateStatus.Location = new System.Drawing.Point(296, 342);
            this.btnUpdateStatus.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(128, 31);
            this.btnUpdateStatus.TabIndex = 6;
            this.btnUpdateStatus.Text = "Изменить статус";
            this.btnUpdateStatus.UseVisualStyleBackColor = true;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // cmbStatuses
            // 
            this.cmbStatuses.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatuses.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbStatuses.Location = new System.Drawing.Point(128, 344);
            this.cmbStatuses.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbStatuses.Name = "cmbStatuses";
            this.cmbStatuses.Size = new System.Drawing.Size(158, 28);
            this.cmbStatuses.TabIndex = 5;
            // 
            // lblStatusText
            // 
            this.lblStatusText.AutoSize = true;
            this.lblStatusText.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblStatusText.Location = new System.Drawing.Point(15, 348);
            this.lblStatusText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatusText.Name = "lblStatusText";
            this.lblStatusText.Size = new System.Drawing.Size(111, 20);
            this.lblStatusText.TabIndex = 4;
            this.lblStatusText.Text = "Новый статус:";
            // 
            // dgvRequests
            // 
            this.dgvRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRequests.Location = new System.Drawing.Point(0, 98);
            this.dgvRequests.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvRequests.Name = "dgvRequests";
            this.dgvRequests.RowHeadersWidth = 51;
            this.dgvRequests.RowTemplate.Height = 24;
            this.dgvRequests.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRequests.Size = new System.Drawing.Size(716, 187);
            this.dgvRequests.TabIndex = 3;
            // 
            // cmbRequestFilter
            // 
            this.cmbRequestFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRequestFilter.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbRequestFilter.Location = new System.Drawing.Point(308, 52);
            this.cmbRequestFilter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cmbRequestFilter.Name = "cmbRequestFilter";
            this.cmbRequestFilter.Size = new System.Drawing.Size(181, 29);
            this.cmbRequestFilter.TabIndex = 2;
            this.cmbRequestFilter.SelectedIndexChanged += new System.EventHandler(this.cmbRequestFilter_SelectedIndexChanged);
            // 
            // lblFilterText
            // 
            this.lblFilterText.AutoSize = true;
            this.lblFilterText.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblFilterText.Location = new System.Drawing.Point(240, 55);
            this.lblFilterText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFilterText.Name = "lblFilterText";
            this.lblFilterText.Size = new System.Drawing.Size(59, 21);
            this.lblFilterText.TabIndex = 1;
            this.lblFilterText.Text = "Услуга:";
            // 
            // lblTableTitle
            // 
            this.lblTableTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTableTitle.Location = new System.Drawing.Point(0, 8);
            this.lblTableTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTableTitle.Name = "lblTableTitle";
            this.lblTableTitle.Size = new System.Drawing.Size(716, 30);
            this.lblTableTitle.TabIndex = 0;
            this.lblTableTitle.Text = "Список заявок в мастерской";
            this.lblTableTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 650);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MasterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Рабочее место Мастера Ювелира";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MasterForm_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.panelCenterCard.ResumeLayout(false);
            this.panelCenterCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRequests)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Panel panelCenterCard;
        private System.Windows.Forms.Label lblTableTitle;
        private System.Windows.Forms.Label lblFilterText;
        private System.Windows.Forms.ComboBox cmbRequestFilter;
        private System.Windows.Forms.DataGridView dgvRequests;
        private System.Windows.Forms.Button btnViewImage;
        private System.Windows.Forms.Label lblStatusText;
        private System.Windows.Forms.ComboBox cmbStatuses;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Button btnArchiveOrder;
        private System.Windows.Forms.Button btnOpenArchive;
        private System.Windows.Forms.Label lblCourseText;
        private System.Windows.Forms.ComboBox cmbPriceMetalSelect;
        private System.Windows.Forms.Label lblNewPriceText;
        private System.Windows.Forms.TextBox txtNewMetalPrice;
        private System.Windows.Forms.Button btnUpdateMetalPrice;
        private System.Windows.Forms.Button btnExit;
    }
}