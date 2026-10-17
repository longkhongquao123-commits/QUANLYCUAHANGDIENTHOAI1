namespace QuanLyCuaHangDienThoai
{
    partial class frmChiTietChungTu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.lblSanPham = new System.Windows.Forms.Label();
            this.dgvChungTu = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChungTu)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSanPham
            // 
            this.lblSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSanPham.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSanPham.Location = new System.Drawing.Point(12, 14);
            this.lblSanPham.Name = "lblSanPham";
            this.lblSanPham.Size = new System.Drawing.Size(887, 112);
            this.lblSanPham.TabIndex = 0;
            this.lblSanPham.Text = "Chứng từ của sản phẩm: ";
            // 
            // dgvChungTu
            // 
            this.dgvChungTu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChungTu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChungTu.Location = new System.Drawing.Point(17, 145);
            this.dgvChungTu.Name = "dgvChungTu";
            this.dgvChungTu.RowHeadersWidth = 62;
            this.dgvChungTu.Size = new System.Drawing.Size(887, 424);
            this.dgvChungTu.TabIndex = 1;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(799, 597);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 32);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // frmChiTietChungTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 643);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgvChungTu);
            this.Controls.Add(this.lblSanPham);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.Name = "frmChiTietChungTu";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chứng từ nguồn";
            ((System.ComponentModel.ISupportInitialize)(this.dgvChungTu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSanPham;
        private System.Windows.Forms.DataGridView dgvChungTu;
        private System.Windows.Forms.Button btnDong;
    }
}