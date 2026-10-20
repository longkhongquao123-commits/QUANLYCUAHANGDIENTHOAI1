namespace QUANLYCUAHANGDIENTHOAI
{
    partial class FormThongKeDoanhThu
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
            System.Windows.Forms.DataGridViewCellStyle styleHeader1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleCell1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleAlt1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleHeader2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleCell2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleAlt2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTieuDe = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblPhuDe = new System.Windows.Forms.Label();
            this.pnlLoc = new System.Windows.Forms.Panel();
            this.pnlTong = new System.Windows.Forms.Panel();
            this.lblTuNgay = new System.Windows.Forms.Label();
            this.dtpTuNgay = new System.Windows.Forms.DateTimePicker();
            this.lblDenNgay = new System.Windows.Forms.Label();
            this.dtpDenNgay = new System.Windows.Forms.DateTimePicker();
            this.lblKieuXem = new System.Windows.Forms.Label();
            this.cboKieuXem = new System.Windows.Forms.ComboBox();
            this.btnXem = new System.Windows.Forms.Button();
            this.btnXuat = new System.Windows.Forms.Button();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.lblPhieu = new System.Windows.Forms.Label();
            this.dgvPhieu = new System.Windows.Forms.DataGridView();
            this.lblTong = new System.Windows.Forms.Label();
            this.txtTongDoanhThu = new System.Windows.Forms.TextBox();
            this.pnlTieuDe.SuspendLayout();
            this.pnlLoc.SuspendLayout();
            this.pnlTong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieu)).BeginInit();
            this.SuspendLayout();
            //
            // pnlTieuDe
            //
            this.pnlTieuDe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTieuDe.BackColor = System.Drawing.Color.FromArgb(30, 64, 124);
            this.pnlTieuDe.Controls.Add(this.lblPhuDe);
            this.pnlTieuDe.Controls.Add(this.lblTieuDe);
            this.pnlTieuDe.Location = new System.Drawing.Point(0, 0);
            this.pnlTieuDe.Name = "pnlTieuDe";
            this.pnlTieuDe.Size = new System.Drawing.Size(1000, 58);
            this.pnlTieuDe.TabIndex = 20;
            //
            // lblTieuDe
            //
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(18, 5);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(250, 28);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "THỐNG KÊ DOANH THU";
            //
            // lblPhuDe
            //
            this.lblPhuDe.AutoSize = true;
            this.lblPhuDe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhuDe.ForeColor = System.Drawing.Color.FromArgb(200, 215, 240);
            this.lblPhuDe.Location = new System.Drawing.Point(21, 35);
            this.lblPhuDe.Name = "lblPhuDe";
            this.lblPhuDe.Size = new System.Drawing.Size(300, 17);
            this.lblPhuDe.TabIndex = 1;
            this.lblPhuDe.Text = "Chỉ tính các phiếu đã hoàn tất";
            //
            // pnlLoc
            //
            this.pnlLoc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlLoc.BackColor = System.Drawing.Color.White;
            this.pnlLoc.Controls.Add(this.lblTuNgay);
            this.pnlLoc.Controls.Add(this.dtpTuNgay);
            this.pnlLoc.Controls.Add(this.lblDenNgay);
            this.pnlLoc.Controls.Add(this.dtpDenNgay);
            this.pnlLoc.Controls.Add(this.lblKieuXem);
            this.pnlLoc.Controls.Add(this.cboKieuXem);
            this.pnlLoc.Controls.Add(this.btnXem);
            this.pnlLoc.Controls.Add(this.btnXuat);
            this.pnlLoc.Location = new System.Drawing.Point(16, 70);
            this.pnlLoc.Name = "pnlLoc";
            this.pnlLoc.Size = new System.Drawing.Size(968, 62);
            this.pnlLoc.TabIndex = 21;
            //
            // lblTuNgay
            //
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.ForeColor = System.Drawing.Color.FromArgb(30, 64, 124);
            this.lblTuNgay.Location = new System.Drawing.Point(16, 23);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(50, 17);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày";
            //
            // dtpTuNgay
            //
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(80, 19);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(130, 25);
            this.dtpTuNgay.TabIndex = 1;
            //
            // lblDenNgay
            //
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.ForeColor = System.Drawing.Color.FromArgb(30, 64, 124);
            this.lblDenNgay.Location = new System.Drawing.Point(235, 23);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(58, 17);
            this.lblDenNgay.TabIndex = 2;
            this.lblDenNgay.Text = "Đến ngày";
            //
            // dtpDenNgay
            //
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(305, 19);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(130, 25);
            this.dtpDenNgay.TabIndex = 3;
            //
            // lblKieuXem
            //
            this.lblKieuXem.AutoSize = true;
            this.lblKieuXem.ForeColor = System.Drawing.Color.FromArgb(30, 64, 124);
            this.lblKieuXem.Location = new System.Drawing.Point(460, 23);
            this.lblKieuXem.Name = "lblKieuXem";
            this.lblKieuXem.Size = new System.Drawing.Size(55, 17);
            this.lblKieuXem.TabIndex = 4;
            this.lblKieuXem.Text = "Xem theo";
            //
            // cboKieuXem
            //
            this.cboKieuXem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKieuXem.FormattingEnabled = true;
            this.cboKieuXem.Location = new System.Drawing.Point(535, 19);
            this.cboKieuXem.Name = "cboKieuXem";
            this.cboKieuXem.Size = new System.Drawing.Size(160, 25);
            this.cboKieuXem.TabIndex = 5;
            //
            // btnXem
            //
            this.btnXem.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnXem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXem.FlatAppearance.BorderSize = 0;
            this.btnXem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXem.ForeColor = System.Drawing.Color.White;
            this.btnXem.Location = new System.Drawing.Point(715, 14);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(110, 34);
            this.btnXem.TabIndex = 6;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = false;
            //
            // btnXuat
            //
            this.btnXuat.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnXuat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXuat.FlatAppearance.BorderSize = 0;
            this.btnXuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuat.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXuat.ForeColor = System.Drawing.Color.White;
            this.btnXuat.Location = new System.Drawing.Point(835, 14);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(120, 34);
            this.btnXuat.TabIndex = 7;
            this.btnXuat.Text = "Xuất CSV";
            this.btnXuat.UseVisualStyleBackColor = false;
            //
            // dgvThongKe
            //
            this.dgvThongKe.AllowUserToAddRows = false;
            this.dgvThongKe.AllowUserToDeleteRows = false;
            this.dgvThongKe.AllowUserToResizeRows = false;
            styleAlt1.BackColor = System.Drawing.Color.FromArgb(244, 247, 252);
            this.dgvThongKe.AlternatingRowsDefaultCellStyle = styleAlt1;
            this.dgvThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKe.BackgroundColor = System.Drawing.Color.White;
            this.dgvThongKe.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvThongKe.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvThongKe.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            styleHeader1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            styleHeader1.BackColor = System.Drawing.Color.FromArgb(30, 64, 124);
            styleHeader1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            styleHeader1.ForeColor = System.Drawing.Color.White;
            styleHeader1.SelectionBackColor = System.Drawing.Color.FromArgb(30, 64, 124);
            styleHeader1.SelectionForeColor = System.Drawing.Color.White;
            styleHeader1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvThongKe.ColumnHeadersDefaultCellStyle = styleHeader1;
            this.dgvThongKe.ColumnHeadersHeight = 34;
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            styleCell1.BackColor = System.Drawing.Color.White;
            styleCell1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            styleCell1.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            styleCell1.SelectionBackColor = System.Drawing.Color.FromArgb(189, 215, 238);
            styleCell1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvThongKe.DefaultCellStyle = styleCell1;
            this.dgvThongKe.EnableHeadersVisualStyles = false;
            this.dgvThongKe.GridColor = System.Drawing.Color.FromArgb(221, 227, 236);
            this.dgvThongKe.Location = new System.Drawing.Point(16, 144);
            this.dgvThongKe.MultiSelect = false;
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.ReadOnly = true;
            this.dgvThongKe.RowHeadersVisible = false;
            this.dgvThongKe.RowHeadersWidth = 51;
            this.dgvThongKe.RowTemplate.Height = 28;
            this.dgvThongKe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongKe.Size = new System.Drawing.Size(968, 180);
            this.dgvThongKe.TabIndex = 8;
            //
            // lblPhieu
            //
            this.lblPhieu.AutoSize = true;
            this.lblPhieu.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhieu.ForeColor = System.Drawing.Color.FromArgb(30, 64, 124);
            this.lblPhieu.Location = new System.Drawing.Point(16, 336);
            this.lblPhieu.Name = "lblPhieu";
            this.lblPhieu.Size = new System.Drawing.Size(300, 17);
            this.lblPhieu.TabIndex = 9;
            this.lblPhieu.Text = "Phiếu nguồn của dòng đang chọn (bấm đúp 1 phiếu để xem chi tiết)";
            //
            // dgvPhieu
            //
            this.dgvPhieu.AllowUserToAddRows = false;
            this.dgvPhieu.AllowUserToDeleteRows = false;
            this.dgvPhieu.AllowUserToResizeRows = false;
            styleAlt2.BackColor = System.Drawing.Color.FromArgb(244, 247, 252);
            this.dgvPhieu.AlternatingRowsDefaultCellStyle = styleAlt2;
            this.dgvPhieu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPhieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieu.BackgroundColor = System.Drawing.Color.White;
            this.dgvPhieu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPhieu.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvPhieu.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            styleHeader2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            styleHeader2.BackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            styleHeader2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            styleHeader2.ForeColor = System.Drawing.Color.White;
            styleHeader2.SelectionBackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            styleHeader2.SelectionForeColor = System.Drawing.Color.White;
            styleHeader2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhieu.ColumnHeadersDefaultCellStyle = styleHeader2;
            this.dgvPhieu.ColumnHeadersHeight = 34;
            this.dgvPhieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            styleCell2.BackColor = System.Drawing.Color.White;
            styleCell2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            styleCell2.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            styleCell2.SelectionBackColor = System.Drawing.Color.FromArgb(189, 215, 238);
            styleCell2.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvPhieu.DefaultCellStyle = styleCell2;
            this.dgvPhieu.EnableHeadersVisualStyles = false;
            this.dgvPhieu.GridColor = System.Drawing.Color.FromArgb(221, 227, 236);
            this.dgvPhieu.Location = new System.Drawing.Point(16, 360);
            this.dgvPhieu.MultiSelect = false;
            this.dgvPhieu.Name = "dgvPhieu";
            this.dgvPhieu.ReadOnly = true;
            this.dgvPhieu.RowHeadersVisible = false;
            this.dgvPhieu.RowHeadersWidth = 51;
            this.dgvPhieu.RowTemplate.Height = 28;
            this.dgvPhieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieu.Size = new System.Drawing.Size(968, 150);
            this.dgvPhieu.TabIndex = 10;
            //
            // pnlTong
            //
            this.pnlTong.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTong.BackColor = System.Drawing.Color.White;
            this.pnlTong.Controls.Add(this.lblTong);
            this.pnlTong.Controls.Add(this.txtTongDoanhThu);
            this.pnlTong.Location = new System.Drawing.Point(16, 522);
            this.pnlTong.Name = "pnlTong";
            this.pnlTong.Size = new System.Drawing.Size(968, 56);
            this.pnlTong.TabIndex = 22;
            //
            // lblTong
            //
            this.lblTong.AutoSize = true;
            this.lblTong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTong.ForeColor = System.Drawing.Color.FromArgb(30, 64, 124);
            this.lblTong.Location = new System.Drawing.Point(20, 17);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(130, 21);
            this.lblTong.TabIndex = 11;
            this.lblTong.Text = "Tổng doanh thu";
            //
            // txtTongDoanhThu
            //
            this.txtTongDoanhThu.BackColor = System.Drawing.Color.White;
            this.txtTongDoanhThu.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongDoanhThu.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.txtTongDoanhThu.Location = new System.Drawing.Point(180, 12);
            this.txtTongDoanhThu.Name = "txtTongDoanhThu";
            this.txtTongDoanhThu.ReadOnly = true;
            this.txtTongDoanhThu.Size = new System.Drawing.Size(260, 32);
            this.txtTongDoanhThu.TabIndex = 12;
            this.txtTongDoanhThu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // Form3
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(240, 243, 248);
            this.ClientSize = new System.Drawing.Size(1000, 596);
            this.Controls.Add(this.pnlTong);
            this.Controls.Add(this.dgvPhieu);
            this.Controls.Add(this.lblPhieu);
            this.Controls.Add(this.dgvThongKe);
            this.Controls.Add(this.pnlLoc);
            this.Controls.Add(this.pnlTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(900, 560);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê doanh thu";
            this.pnlTieuDe.ResumeLayout(false);
            this.pnlTieuDe.PerformLayout();
            this.pnlLoc.ResumeLayout(false);
            this.pnlLoc.PerformLayout();
            this.pnlTong.ResumeLayout(false);
            this.pnlTong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlTieuDe;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblPhuDe;
        private System.Windows.Forms.Panel pnlLoc;
        private System.Windows.Forms.Panel pnlTong;
        private System.Windows.Forms.Label lblTuNgay;
        private System.Windows.Forms.DateTimePicker dtpTuNgay;
        private System.Windows.Forms.Label lblDenNgay;
        private System.Windows.Forms.DateTimePicker dtpDenNgay;
        private System.Windows.Forms.Label lblKieuXem;
        private System.Windows.Forms.ComboBox cboKieuXem;
        private System.Windows.Forms.Button btnXem;
        private System.Windows.Forms.Button btnXuat;
        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.Label lblPhieu;
        private System.Windows.Forms.DataGridView dgvPhieu;
        private System.Windows.Forms.Label lblTong;
        private System.Windows.Forms.TextBox txtTongDoanhThu;
    }
}