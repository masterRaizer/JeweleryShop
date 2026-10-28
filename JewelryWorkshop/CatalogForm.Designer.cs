namespace JewelryWorkshop
{
    partial class CatalogForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelGrid = new System.Windows.Forms.FlowLayoutPanel();
            this.panelDetails = new System.Windows.Forms.Panel();
            this.btnBackToGrid = new System.Windows.Forms.Button();
            this.btnReserve = new System.Windows.Forms.Button();
            this.lblDetailedPrice = new System.Windows.Forms.Label();
            this.txtFullDesc = new System.Windows.Forms.TextBox();
            this.picLarge = new System.Windows.Forms.PictureBox();
            this.btnFormClose = new System.Windows.Forms.Button();
            this.panelDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLarge)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(505, 19);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(390, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Эксклюзивные изделия в наличии";
            // 
            // panelGrid
            // 
            this.panelGrid.Location = new System.Drawing.Point(34, 69);
            this.panelGrid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelGrid.Name = "panelGrid";
            this.panelGrid.Size = new System.Drawing.Size(1372, 691);
            this.panelGrid.TabIndex = 1;
            // 
            // panelDetails
            // 
            this.panelDetails.Controls.Add(this.btnBackToGrid);
            this.panelDetails.Controls.Add(this.btnReserve);
            this.panelDetails.Controls.Add(this.lblDetailedPrice);
            this.panelDetails.Controls.Add(this.txtFullDesc);
            this.panelDetails.Controls.Add(this.picLarge);
            this.panelDetails.Location = new System.Drawing.Point(34, 69);
            this.panelDetails.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(1372, 691);
            this.panelDetails.TabIndex = 2;
            this.panelDetails.Visible = false;
            // 
            // btnBackToGrid
            // 
            this.btnBackToGrid.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.btnBackToGrid.Location = new System.Drawing.Point(720, 609);
            this.btnBackToGrid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBackToGrid.Name = "btnBackToGrid";
            this.btnBackToGrid.Size = new System.Drawing.Size(225, 41);
            this.btnBackToGrid.TabIndex = 4;
            this.btnBackToGrid.Text = "Назад к витрине";
            this.btnBackToGrid.UseVisualStyleBackColor = true;
            this.btnBackToGrid.Click += new System.EventHandler(this.btnBackToGrid_Click);
            // 
            // btnReserve
            // 
            this.btnReserve.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnReserve.Location = new System.Drawing.Point(465, 609);
            this.btnReserve.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReserve.Name = "btnReserve";
            this.btnReserve.Size = new System.Drawing.Size(225, 41);
            this.btnReserve.TabIndex = 3;
            this.btnReserve.Text = "Забронировать изделие";
            this.btnReserve.UseVisualStyleBackColor = true;
            this.btnReserve.Click += new System.EventHandler(this.btnReserve_Click);
            // 
            // lblDetailedPrice
            // 
            this.lblDetailedPrice.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblDetailedPrice.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblDetailedPrice.Location = new System.Drawing.Point(720, 528);
            this.lblDetailedPrice.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDetailedPrice.Name = "lblDetailedPrice";
            this.lblDetailedPrice.Size = new System.Drawing.Size(622, 41);
            this.lblDetailedPrice.TabIndex = 2;
            this.lblDetailedPrice.Text = "0 руб.";
            this.lblDetailedPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFullDesc
            // 
            this.txtFullDesc.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.txtFullDesc.Location = new System.Drawing.Point(720, 16);
            this.txtFullDesc.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtFullDesc.Multiline = true;
            this.txtFullDesc.Name = "txtFullDesc";
            this.txtFullDesc.ReadOnly = true;
            this.txtFullDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFullDesc.Size = new System.Drawing.Size(624, 488);
            this.txtFullDesc.TabIndex = 1;
            // 
            // picLarge
            // 
            this.picLarge.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picLarge.Location = new System.Drawing.Point(15, 16);
            this.picLarge.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.picLarge.Name = "picLarge";
            this.picLarge.Size = new System.Drawing.Size(676, 553);
            this.picLarge.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLarge.TabIndex = 0;
            this.picLarge.TabStop = false;
            // 
            // btnFormClose
            // 
            this.btnFormClose.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnFormClose.Location = new System.Drawing.Point(1256, 20);
            this.btnFormClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnFormClose.Name = "btnFormClose";
            this.btnFormClose.Size = new System.Drawing.Size(150, 34);
            this.btnFormClose.TabIndex = 3;
            this.btnFormClose.Text = "Выход в меню";
            this.btnFormClose.UseVisualStyleBackColor = true;
            this.btnFormClose.Click += new System.EventHandler(this.btnFormClose_Click);
            // 
            // CatalogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1440, 878);
            this.Controls.Add(this.btnFormClose);
            this.Controls.Add(this.panelDetails);
            this.Controls.Add(this.panelGrid);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CatalogForm";
            this.Text = "Премиальный каталог готовых изделий";
            this.Load += new System.EventHandler(this.CatalogForm_Load);
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLarge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel panelGrid;
        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.PictureBox picLarge;
        private System.Windows.Forms.TextBox txtFullDesc;
        private System.Windows.Forms.Label lblDetailedPrice;
        private System.Windows.Forms.Button btnReserve;
        private System.Windows.Forms.Button btnBackToGrid;
        private System.Windows.Forms.Button btnFormClose;
    }
}