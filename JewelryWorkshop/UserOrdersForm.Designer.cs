namespace JewelryWorkshop
{
    partial class UserOrdersForm
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
            this.btnEditOrder = new System.Windows.Forms.Button();
            this.btnCancelOrder = new System.Windows.Forms.Button();
            this.dgvMyOrders = new System.Windows.Forms.DataGridView();
            this.lblClientTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanelMain.SuspendLayout();
            this.panelCenterCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyOrders)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 675F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Controls.Add(this.panelCenterCard, 1, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 3;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 447F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(900, 609);
            this.tableLayoutPanelMain.TabIndex = 0;
            // 
            // panelCenterCard
            // 
            this.panelCenterCard.Controls.Add(this.btnBack);
            this.panelCenterCard.Controls.Add(this.btnEditOrder);
            this.panelCenterCard.Controls.Add(this.btnCancelOrder);
            this.panelCenterCard.Controls.Add(this.dgvMyOrders);
            this.panelCenterCard.Controls.Add(this.lblClientTitle);
            this.panelCenterCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCenterCard.Location = new System.Drawing.Point(114, 83);
            this.panelCenterCard.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelCenterCard.Name = "panelCenterCard";
            this.panelCenterCard.Size = new System.Drawing.Size(671, 443);
            this.panelCenterCard.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnBack.Location = new System.Drawing.Point(499, 378);
            this.btnBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(150, 37);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Назад в меню";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnEditOrder
            // 
            this.btnEditOrder.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnEditOrder.Location = new System.Drawing.Point(184, 378);
            this.btnEditOrder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEditOrder.Name = "btnEditOrder";
            this.btnEditOrder.Size = new System.Drawing.Size(165, 37);
            this.btnEditOrder.TabIndex = 4;
            this.btnEditOrder.Text = "Изменить контакты";
            this.btnEditOrder.UseVisualStyleBackColor = true;
            this.btnEditOrder.Click += new System.EventHandler(this.btnEditOrder_Click);
            // 
            // btnCancelOrder
            // 
            this.btnCancelOrder.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancelOrder.ForeColor = System.Drawing.Color.DarkRed;
            this.btnCancelOrder.Location = new System.Drawing.Point(22, 378);
            this.btnCancelOrder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCancelOrder.Name = "btnCancelOrder";
            this.btnCancelOrder.Size = new System.Drawing.Size(150, 37);
            this.btnCancelOrder.TabIndex = 3;
            this.btnCancelOrder.Text = "Отменить заказ";
            this.btnCancelOrder.UseVisualStyleBackColor = true;
            this.btnCancelOrder.Click += new System.EventHandler(this.btnCancelOrder_Click);
            // 
            // dgvMyOrders
            // 
            this.dgvMyOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyOrders.Location = new System.Drawing.Point(22, 61);
            this.dgvMyOrders.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvMyOrders.Name = "dgvMyOrders";
            this.dgvMyOrders.RowHeadersWidth = 51;
            this.dgvMyOrders.RowTemplate.Height = 24;
            this.dgvMyOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMyOrders.Size = new System.Drawing.Size(626, 292);
            this.dgvMyOrders.TabIndex = 1;
            // 
            // lblClientTitle
            // 
            this.lblClientTitle.AutoSize = true;
            this.lblClientTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblClientTitle.Location = new System.Drawing.Point(218, 15);
            this.lblClientTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClientTitle.Name = "lblClientTitle";
            this.lblClientTitle.Size = new System.Drawing.Size(224, 25);
            this.lblClientTitle.TabIndex = 0;
            this.lblClientTitle.Text = "История моих заказов";
            // 
            // UserOrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 609);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UserOrdersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Личный кабинет — Мои заказы";
            this.Load += new System.EventHandler(this.UserOrdersForm_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.panelCenterCard.ResumeLayout(false);
            this.panelCenterCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyOrders)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.Panel panelCenterCard;
        private System.Windows.Forms.Label lblClientTitle;
        private System.Windows.Forms.DataGridView dgvMyOrders;
        private System.Windows.Forms.Button btnCancelOrder;
        private System.Windows.Forms.Button btnEditOrder;
        private System.Windows.Forms.Button btnBack;
    }
}