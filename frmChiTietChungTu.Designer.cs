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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTieuDe = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblSanPham = new System.Windows.Forms.Label();
            this.dgvChungTu = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.pnlTieuDe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChungTu)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTieuDe
            // 
            this.pnlTieuDe.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.pnlTieuDe.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.pnlTieuDe.Controls.Add(this.lblTieuDe);
            this.pnlTieuDe.Location = new System.Drawing.Point(0, 0);
            this.pnlTieuDe.Name = "pnlTieuDe";
            this.pnlTieuDe.Size = new System.Drawing.Size(911, 56);
            this.pnlTieuDe.TabIndex = 3;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(18, 12);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(230, 41);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "CHỨNG TỪ NGUỒN";
            // 
            // lblSanPham
            // 
            this.lblSanPham.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.lblSanPham.AutoEllipsis = true;
            this.lblSanPham.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblSanPham.ForeColor = System.Drawing.Color.FromArgb(31, 78, 121);
            this.lblSanPham.Location = new System.Drawing.Point(16, 68);
            this.lblSanPham.Name = "lblSanPham";
            this.lblSanPham.Size = new System.Drawing.Size(879, 32);
            this.lblSanPham.TabIndex = 0;
            this.lblSanPham.Text = "Chứng từ của sản phẩm: ";
            this.lblSanPham.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvChungTu
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(242, 246, 250);
            this.dgvChungTu.AllowUserToAddRows = false;
            this.dgvChungTu.AllowUserToDeleteRows = false;
            this.dgvChungTu.AllowUserToResizeRows = false;
            this.dgvChungTu.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvChungTu.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.dgvChungTu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChungTu.BackgroundColor = System.Drawing.Color.White;
            this.dgvChungTu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvChungTu.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvChungTu.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(31, 78, 121);
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvChungTu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvChungTu.ColumnHeadersHeight = 38;
            this.dgvChungTu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(51, 51, 51);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(204, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvChungTu.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvChungTu.EnableHeadersVisualStyles = false;
            this.dgvChungTu.GridColor = System.Drawing.Color.FromArgb(217, 226, 236);
            this.dgvChungTu.Location = new System.Drawing.Point(16, 108);
            this.dgvChungTu.MultiSelect = false;
            this.dgvChungTu.Name = "dgvChungTu";
            this.dgvChungTu.ReadOnly = true;
            this.dgvChungTu.RowHeadersVisible = false;
            this.dgvChungTu.RowHeadersWidth = 62;
            this.dgvChungTu.RowTemplate.Height = 30;
            this.dgvChungTu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChungTu.Size = new System.Drawing.Size(879, 482);
            this.dgvChungTu.TabIndex = 1;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(785, 602);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(110, 38);
            this.btnDong.TabIndex = 2;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            // 
            // frmChiTietChungTu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(240, 243, 247);
            this.ClientSize = new System.Drawing.Size(911, 654);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.dgvChungTu);
            this.Controls.Add(this.lblSanPham);
            this.Controls.Add(this.pnlTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(500, 300);
            this.ShowInTaskbar = false;
            this.Name = "frmChiTietChungTu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chứng từ nguồn";
            this.pnlTieuDe.ResumeLayout(false);
            this.pnlTieuDe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChungTu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTieuDe;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblSanPham;
        private System.Windows.Forms.DataGridView dgvChungTu;
        private System.Windows.Forms.Button btnDong;
    }
}