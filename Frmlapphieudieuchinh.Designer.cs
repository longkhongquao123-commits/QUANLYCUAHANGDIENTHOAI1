namespace QuanLyCuaHangDienThoai
{
    partial class frmLapPhieuDieuChinh
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
            this.grpPhieu = new System.Windows.Forms.GroupBox();
            this.txtLyDo = new System.Windows.Forms.TextBox();
            this.lblLyDo = new System.Windows.Forms.Label();
            this.txtNguoiLap = new System.Windows.Forms.TextBox();
            this.lblNguoiLap = new System.Windows.Forms.Label();
            this.txtTrangThai = new System.Windows.Forms.TextBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.dtpNgayLap = new System.Windows.Forms.DateTimePicker();
            this.lblNgayLap = new System.Windows.Forms.Label();
            this.txtMaPhieu = new System.Windows.Forms.TextBox();
            this.lblMaPhieu = new System.Windows.Forms.Label();
            this.grpDong = new System.Windows.Forms.GroupBox();
            this.btnXoaDong = new System.Windows.Forms.Button();
            this.btnSuaDong = new System.Windows.Forms.Button();
            this.btnThemDong = new System.Windows.Forms.Button();
            this.txtChenhLech = new System.Windows.Forms.TextBox();
            this.lblChenhLech = new System.Windows.Forms.Label();
            this.numTonTT = new System.Windows.Forms.NumericUpDown();
            this.lblTonTT = new System.Windows.Forms.Label();
            this.txtTonHT = new System.Windows.Forms.TextBox();
            this.lblTonHT = new System.Windows.Forms.Label();
            this.cboSanPham = new System.Windows.Forms.ComboBox();
            this.lblSanPham = new System.Windows.Forms.Label();
            this.dgvChiTiet = new System.Windows.Forms.DataGridView();
            this.lblThua = new System.Windows.Forms.Label();
            this.lblThieu = new System.Windows.Forms.Label();
            this.btnLuuNhap = new System.Windows.Forms.Button();
            this.btnGuiDuyet = new System.Windows.Forms.Button();
            this.btnDuyet = new System.Windows.Forms.Button();
            this.btnTuChoi = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.grpPhieu.SuspendLayout();
            this.grpDong.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTonTT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // grpPhieu
            // 
            this.grpPhieu.Controls.Add(this.txtLyDo);
            this.grpPhieu.Controls.Add(this.lblLyDo);
            this.grpPhieu.Controls.Add(this.txtNguoiLap);
            this.grpPhieu.Controls.Add(this.lblNguoiLap);
            this.grpPhieu.Controls.Add(this.txtTrangThai);
            this.grpPhieu.Controls.Add(this.lblTrangThai);
            this.grpPhieu.Controls.Add(this.dtpNgayLap);
            this.grpPhieu.Controls.Add(this.lblNgayLap);
            this.grpPhieu.Controls.Add(this.txtMaPhieu);
            this.grpPhieu.Controls.Add(this.lblMaPhieu);
            this.grpPhieu.Location = new System.Drawing.Point(12, 12);
            this.grpPhieu.Name = "grpPhieu";
            this.grpPhieu.Size = new System.Drawing.Size(991, 143);
            this.grpPhieu.TabIndex = 0;
            this.grpPhieu.TabStop = false;
            this.grpPhieu.Text = "Thông tin phiếu";
            // 
            // txtLyDo
            // 
            this.txtLyDo.Location = new System.Drawing.Point(100, 106);
            this.txtLyDo.Name = "txtLyDo";
            this.txtLyDo.Size = new System.Drawing.Size(871, 31);
            this.txtLyDo.TabIndex = 9;
            // 
            // lblLyDo
            // 
            this.lblLyDo.AutoSize = true;
            this.lblLyDo.Location = new System.Drawing.Point(15, 109);
            this.lblLyDo.Name = "lblLyDo";
            this.lblLyDo.Size = new System.Drawing.Size(55, 25);
            this.lblLyDo.TabIndex = 8;
            this.lblLyDo.Text = "Lý do";
           
            // 
            // txtNguoiLap
            // 
            this.txtNguoiLap.Location = new System.Drawing.Point(100, 69);
            this.txtNguoiLap.Name = "txtNguoiLap";
            this.txtNguoiLap.Size = new System.Drawing.Size(200, 31);
            this.txtNguoiLap.TabIndex = 7;
            // 
            // lblNguoiLap
            // 
            this.lblNguoiLap.AutoSize = true;
            this.lblNguoiLap.Location = new System.Drawing.Point(6, 72);
            this.lblNguoiLap.Name = "lblNguoiLap";
            this.lblNguoiLap.Size = new System.Drawing.Size(91, 25);
            this.lblNguoiLap.TabIndex = 6;
            this.lblNguoiLap.Text = "Người lập";
            // 
            // txtTrangThai
            // 
            this.txtTrangThai.Location = new System.Drawing.Point(685, 28);
            this.txtTrangThai.Name = "txtTrangThai";
            this.txtTrangThai.Size = new System.Drawing.Size(286, 31);
            this.txtTrangThai.TabIndex = 5;
           
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Location = new System.Drawing.Point(590, 31);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(89, 25);
            this.lblTrangThai.TabIndex = 4;
            this.lblTrangThai.Text = "Trạng thái";
            // 
            // dtpNgayLap
            // 
            this.dtpNgayLap.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgayLap.Location = new System.Drawing.Point(424, 29);
            this.dtpNgayLap.Name = "dtpNgayLap";
            this.dtpNgayLap.Size = new System.Drawing.Size(160, 31);
            this.dtpNgayLap.TabIndex = 3;
            // 
            // lblNgayLap
            // 
            this.lblNgayLap.AutoSize = true;
            this.lblNgayLap.Location = new System.Drawing.Point(335, 31);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Size = new System.Drawing.Size(83, 25);
            this.lblNgayLap.TabIndex = 2;
            this.lblNgayLap.Text = "Ngày lập";
            // 
            // txtMaPhieu
            // 
            this.txtMaPhieu.Location = new System.Drawing.Point(100, 31);
            this.txtMaPhieu.Name = "txtMaPhieu";
            this.txtMaPhieu.Size = new System.Drawing.Size(200, 31);
            this.txtMaPhieu.TabIndex = 1;
            // 
            // lblMaPhieu
            // 
            this.lblMaPhieu.AutoSize = true;
            this.lblMaPhieu.Location = new System.Drawing.Point(8, 34);
            this.lblMaPhieu.Name = "lblMaPhieu";
            this.lblMaPhieu.Size = new System.Drawing.Size(86, 25);
            this.lblMaPhieu.TabIndex = 0;
            this.lblMaPhieu.Text = "Mã phiếu";
            // 
            // grpDong
            // 
            this.grpDong.Controls.Add(this.btnXoaDong);
            this.grpDong.Controls.Add(this.btnSuaDong);
            this.grpDong.Controls.Add(this.btnThemDong);
            this.grpDong.Controls.Add(this.txtChenhLech);
            this.grpDong.Controls.Add(this.lblChenhLech);
            this.grpDong.Controls.Add(this.numTonTT);
            this.grpDong.Controls.Add(this.lblTonTT);
            this.grpDong.Controls.Add(this.txtTonHT);
            this.grpDong.Controls.Add(this.lblTonHT);
            this.grpDong.Controls.Add(this.cboSanPham);
            this.grpDong.Controls.Add(this.lblSanPham);
            this.grpDong.Location = new System.Drawing.Point(12, 161);
            this.grpDong.Name = "grpDong";
            this.grpDong.Size = new System.Drawing.Size(991, 111);
            this.grpDong.TabIndex = 1;
            this.grpDong.TabStop = false;
            this.grpDong.Text = "Dòng kiểm kê";
            // 
            // btnXoaDong
            // 
            this.btnXoaDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.btnXoaDong.Location = new System.Drawing.Point(891, 40);
            this.btnXoaDong.Name = "btnXoaDong";
            this.btnXoaDong.Size = new System.Drawing.Size(80, 30);
            this.btnXoaDong.TabIndex = 10;
            this.btnXoaDong.Text = "Xóa dòng";
            this.btnXoaDong.UseVisualStyleBackColor = false;
            // 
            // btnSuaDong
            // 
            this.btnSuaDong.Location = new System.Drawing.Point(792, 40);
            this.btnSuaDong.Name = "btnSuaDong";
            this.btnSuaDong.Size = new System.Drawing.Size(80, 30);
            this.btnSuaDong.TabIndex = 9;
            this.btnSuaDong.Text = "Sửa dòng";
            this.btnSuaDong.UseVisualStyleBackColor = true;
            // 
            // btnThemDong
            // 
            this.btnThemDong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btnThemDong.Location = new System.Drawing.Point(691, 40);
            this.btnThemDong.Name = "btnThemDong";
            this.btnThemDong.Size = new System.Drawing.Size(80, 30);
            this.btnThemDong.TabIndex = 8;
            this.btnThemDong.Text = "Thêm dòng";
            this.btnThemDong.UseVisualStyleBackColor = false;
            // 
            // txtChenhLech
            // 
            this.txtChenhLech.Location = new System.Drawing.Point(561, 65);
            this.txtChenhLech.Name = "txtChenhLech";
            this.txtChenhLech.Size = new System.Drawing.Size(100, 31);
            this.txtChenhLech.TabIndex = 7;
            // 
            // lblChenhLech
            // 
            this.lblChenhLech.AutoSize = true;
            this.lblChenhLech.Location = new System.Drawing.Point(421, 71);
            this.lblChenhLech.Name = "lblChenhLech";
            this.lblChenhLech.Size = new System.Drawing.Size(98, 25);
            this.lblChenhLech.TabIndex = 6;
            this.lblChenhLech.Text = "Chênh lệch";
            // 
            // numTonTT
            // 
            this.numTonTT.Location = new System.Drawing.Point(123, 63);
            this.numTonTT.Name = "numTonTT";
            this.numTonTT.Size = new System.Drawing.Size(110, 31);
            this.numTonTT.TabIndex = 5;
            // 
            // lblTonTT
            // 
            this.lblTonTT.AutoSize = true;
            this.lblTonTT.Location = new System.Drawing.Point(15, 65);
            this.lblTonTT.Name = "lblTonTT";
            this.lblTonTT.Size = new System.Drawing.Size(102, 25);
            this.lblTonTT.TabIndex = 4;
            this.lblTonTT.Text = "Tồn thực tế";
            // 
            // txtTonHT
            // 
            this.txtTonHT.Location = new System.Drawing.Point(561, 31);
            this.txtTonHT.Name = "txtTonHT";
            this.txtTonHT.Size = new System.Drawing.Size(100, 31);
            this.txtTonHT.TabIndex = 3;
            // 
            // lblTonHT
            // 
            this.lblTonHT.AutoSize = true;
            this.lblTonHT.Location = new System.Drawing.Point(421, 31);
            this.lblTonHT.Name = "lblTonHT";
            this.lblTonHT.Size = new System.Drawing.Size(119, 25);
            this.lblTonHT.TabIndex = 2;
            this.lblTonHT.Text = "Tồn hệ thống";
            // 
            // cboSanPham
            // 
            this.cboSanPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSanPham.FormattingEnabled = true;
            this.cboSanPham.Location = new System.Drawing.Point(123, 28);
            this.cboSanPham.Name = "cboSanPham";
            this.cboSanPham.Size = new System.Drawing.Size(260, 33);
            this.cboSanPham.TabIndex = 1;
            // 
            // lblSanPham
            // 
            this.lblSanPham.AutoSize = true;
            this.lblSanPham.Location = new System.Drawing.Point(15, 31);
            this.lblSanPham.Name = "lblSanPham";
            this.lblSanPham.Size = new System.Drawing.Size(92, 25);
            this.lblSanPham.TabIndex = 0;
            this.lblSanPham.Text = "Sản phẩm";
            // 
            // dgvChiTiet
            // 
            this.dgvChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTiet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTiet.Location = new System.Drawing.Point(12, 278);
            this.dgvChiTiet.Name = "dgvChiTiet";
            this.dgvChiTiet.RowHeadersWidth = 62;
            this.dgvChiTiet.Size = new System.Drawing.Size(991, 296);
            this.dgvChiTiet.TabIndex = 2;
            // 
            // lblThua
            // 
            this.lblThua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblThua.AutoSize = true;
            this.lblThua.ForeColor = System.Drawing.Color.Green;
            this.lblThua.Location = new System.Drawing.Point(7, 590);
            this.lblThua.Name = "lblThua";
            this.lblThua.Size = new System.Drawing.Size(113, 25);
            this.lblThua.TabIndex = 3;
            this.lblThua.Text = "Tổng thừa: 0";
            // 
            // lblThieu
            // 
            this.lblThieu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblThieu.AutoSize = true;
            this.lblThieu.ForeColor = System.Drawing.Color.Red;
            this.lblThieu.Location = new System.Drawing.Point(176, 590);
            this.lblThieu.Name = "lblThieu";
            this.lblThieu.Size = new System.Drawing.Size(116, 25);
            this.lblThieu.TabIndex = 4;
            this.lblThieu.Text = "Tổng thiếu: 0";
            // 
            // btnLuuNhap
            // 
            this.btnLuuNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuNhap.Location = new System.Drawing.Point(463, 610);
            this.btnLuuNhap.Name = "btnLuuNhap";
            this.btnLuuNhap.Size = new System.Drawing.Size(100, 34);
            this.btnLuuNhap.TabIndex = 5;
            this.btnLuuNhap.Text = "Lưu nháp";
            this.btnLuuNhap.UseVisualStyleBackColor = true;
            // 
            // btnGuiDuyet
            // 
            this.btnGuiDuyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuiDuyet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(242)))), ((int)(((byte)(204)))));
            this.btnGuiDuyet.Location = new System.Drawing.Point(573, 610);
            this.btnGuiDuyet.Name = "btnGuiDuyet";
            this.btnGuiDuyet.Size = new System.Drawing.Size(100, 34);
            this.btnGuiDuyet.TabIndex = 6;
            this.btnGuiDuyet.Text = "Gửi duyệt";
            this.btnGuiDuyet.UseVisualStyleBackColor = false;
            // 
            // btnDuyet
            // 
            this.btnDuyet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDuyet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(239)))), ((int)(((byte)(206)))));
            this.btnDuyet.Location = new System.Drawing.Point(683, 610);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(100, 34);
            this.btnDuyet.TabIndex = 7;
            this.btnDuyet.Text = "Duyệt";
            this.btnDuyet.UseVisualStyleBackColor = false;
            // 
            // btnTuChoi
            // 
            this.btnTuChoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTuChoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(199)))), ((int)(((byte)(206)))));
            this.btnTuChoi.Location = new System.Drawing.Point(793, 610);
            this.btnTuChoi.Name = "btnTuChoi";
            this.btnTuChoi.Size = new System.Drawing.Size(100, 34);
            this.btnTuChoi.TabIndex = 8;
            this.btnTuChoi.Text = "Từ chối";
            this.btnTuChoi.UseVisualStyleBackColor = false;
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(903, 610);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 34);
            this.btnDong.TabIndex = 9;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // Frmlapphieudieuchinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 660);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnTuChoi);
            this.Controls.Add(this.btnDuyet);
            this.Controls.Add(this.btnGuiDuyet);
            this.Controls.Add(this.btnLuuNhap);
            this.Controls.Add(this.lblThieu);
            this.Controls.Add(this.lblThua);
            this.Controls.Add(this.dgvChiTiet);
            this.Controls.Add(this.grpDong);
            this.Controls.Add(this.grpPhieu);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frmlapphieudieuchinh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Lập phiếu điều chỉnh tồn";
            this.grpPhieu.ResumeLayout(false);
            this.grpPhieu.PerformLayout();
            this.grpDong.ResumeLayout(false);
            this.grpDong.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTonTT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTiet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpPhieu;
        private System.Windows.Forms.TextBox txtLyDo;
        private System.Windows.Forms.Label lblLyDo;
        private System.Windows.Forms.TextBox txtNguoiLap;
        private System.Windows.Forms.Label lblNguoiLap;
        private System.Windows.Forms.TextBox txtTrangThai;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.DateTimePicker dtpNgayLap;
        private System.Windows.Forms.Label lblNgayLap;
        private System.Windows.Forms.TextBox txtMaPhieu;
        private System.Windows.Forms.Label lblMaPhieu;
        private System.Windows.Forms.GroupBox grpDong;
        private System.Windows.Forms.Button btnXoaDong;
        private System.Windows.Forms.Button btnSuaDong;
        private System.Windows.Forms.Button btnThemDong;
        private System.Windows.Forms.TextBox txtChenhLech;
        private System.Windows.Forms.Label lblChenhLech;
        private System.Windows.Forms.NumericUpDown numTonTT;
        private System.Windows.Forms.Label lblTonTT;
        private System.Windows.Forms.TextBox txtTonHT;
        private System.Windows.Forms.Label lblTonHT;
        private System.Windows.Forms.ComboBox cboSanPham;
        private System.Windows.Forms.Label lblSanPham;
        private System.Windows.Forms.DataGridView dgvChiTiet;
        private System.Windows.Forms.Label lblThua;
        private System.Windows.Forms.Label lblThieu;
        private System.Windows.Forms.Button btnLuuNhap;
        private System.Windows.Forms.Button btnGuiDuyet;
        private System.Windows.Forms.Button btnDuyet;
        private System.Windows.Forms.Button btnTuChoi;
        private System.Windows.Forms.Button btnDong;
    }
}