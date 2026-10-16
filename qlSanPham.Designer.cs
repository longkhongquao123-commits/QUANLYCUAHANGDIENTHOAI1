namespace qlySanPham
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtMaSanPham = new TextBox();
            txtTenSP = new TextBox();
            txtMaDanhMuc = new TextBox();
            dtpThongTinBaoHanh = new DateTimePicker();
            txtSoLuongTon = new TextBox();
            txtGiaBanHienTai = new TextBox();
            cboTrangThai = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            dgvSanPham = new DataGridView();
            MaSP = new DataGridViewTextBoxColumn();
            TenSP = new DataGridViewTextBoxColumn();
            MaDanhMuc = new DataGridViewTextBoxColumn();
            MoTa = new DataGridViewTextBoxColumn();
            SoLuongTon = new DataGridViewTextBoxColumn();
            GiaBanHienTai = new DataGridViewTextBoxColumn();
            MaThuongHieu = new DataGridViewTextBoxColumn();
            NguongTonToiThieu = new DataGridViewTextBoxColumn();
            HinhAnh = new DataGridViewTextBoxColumn();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnGhi = new Button();
            btnTimKiem = new Button();
            btnTim = new Button();
            btnLamMoi = new Button();
            label9 = new Label();
            label10 = new Label();
            txtMoTa = new TextBox();
            txtNguongTonToiThieu = new TextBox();
            txtMaThuongHieu = new TextBox();
            txtHinhAnh = new TextBox();
            label11 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).BeginInit();
            SuspendLayout();
            // 
            // txtMaSanPham
            // 
            txtMaSanPham.Enabled = false;
            txtMaSanPham.Location = new Point(171, 12);
            txtMaSanPham.Name = "txtMaSanPham";
            txtMaSanPham.Size = new Size(250, 27);
            txtMaSanPham.TabIndex = 0;
            // 
            // txtTenSP
            // 
            txtTenSP.Enabled = false;
            txtTenSP.Location = new Point(171, 48);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(250, 27);
            txtTenSP.TabIndex = 1;
            // 
            // txtMaDanhMuc
            // 
            txtMaDanhMuc.Enabled = false;
            txtMaDanhMuc.Location = new Point(171, 81);
            txtMaDanhMuc.Name = "txtMaDanhMuc";
            txtMaDanhMuc.Size = new Size(250, 27);
            txtMaDanhMuc.TabIndex = 2;
            // 
            // dtpThongTinBaoHanh
            // 
            dtpThongTinBaoHanh.Enabled = false;
            dtpThongTinBaoHanh.Location = new Point(171, 111);
            dtpThongTinBaoHanh.Name = "dtpThongTinBaoHanh";
            dtpThongTinBaoHanh.Size = new Size(250, 27);
            dtpThongTinBaoHanh.TabIndex = 3;
            // 
            // txtSoLuongTon
            // 
            txtSoLuongTon.Enabled = false;
            txtSoLuongTon.Location = new Point(655, 83);
            txtSoLuongTon.Name = "txtSoLuongTon";
            txtSoLuongTon.Size = new Size(151, 27);
            txtSoLuongTon.TabIndex = 5;
            // 
            // txtGiaBanHienTai
            // 
            txtGiaBanHienTai.Enabled = false;
            txtGiaBanHienTai.Location = new Point(655, 12);
            txtGiaBanHienTai.Name = "txtGiaBanHienTai";
            txtGiaBanHienTai.Size = new Size(151, 27);
            txtGiaBanHienTai.TabIndex = 6;
            // 
            // cboTrangThai
            // 
            cboTrangThai.Enabled = false;
            cboTrangThai.FormattingEnabled = true;
            cboTrangThai.Items.AddRange(new object[] { "Đang kinh doanh", "Hết hàng" });
            cboTrangThai.Location = new Point(655, 45);
            cboTrangThai.Name = "cboTrangThai";
            cboTrangThai.Size = new Size(151, 28);
            cboTrangThai.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 12);
            label1.Name = "label1";
            label1.Size = new Size(99, 20);
            label1.TabIndex = 8;
            label1.Text = "Mã Sản Phẩm";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 45);
            label2.Name = "label2";
            label2.Size = new Size(101, 20);
            label2.TabIndex = 9;
            label2.Text = "Tên Sản Phẩm";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 84);
            label3.Name = "label3";
            label3.Size = new Size(101, 20);
            label3.TabIndex = 10;
            label3.Text = "Mã Danh Mục";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 116);
            label4.Name = "label4";
            label4.Size = new Size(138, 20);
            label4.TabIndex = 11;
            label4.Text = "Thông tin bảo hành";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(493, 17);
            label5.Name = "label5";
            label5.Size = new Size(113, 20);
            label5.TabIndex = 12;
            label5.Text = "Giá bán hiện tại";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(493, 55);
            label6.Name = "label6";
            label6.Size = new Size(78, 20);
            label6.TabIndex = 13;
            label6.Text = "Trạng Thái";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(493, 86);
            label7.Name = "label7";
            label7.Size = new Size(95, 20);
            label7.TabIndex = 14;
            label7.Text = "Số lượng tồn";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(493, 119);
            label8.Name = "label8";
            label8.Size = new Size(48, 20);
            label8.TabIndex = 15;
            label8.Text = "Mô tả";
            // 
            // dgvSanPham
            // 
            dgvSanPham.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSanPham.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSanPham.Columns.AddRange(new DataGridViewColumn[] { MaSP, TenSP, MaDanhMuc, MoTa, SoLuongTon, GiaBanHienTai, MaThuongHieu, NguongTonToiThieu, HinhAnh });
            dgvSanPham.Location = new Point(3, 241);
            dgvSanPham.Name = "dgvSanPham";
            dgvSanPham.RowHeadersWidth = 51;
            dgvSanPham.Size = new Size(1074, 362);
            dgvSanPham.TabIndex = 16;
            // 
            // MaSP
            // 
            MaSP.DataPropertyName = "MaSP";
            MaSP.HeaderText = "Mã Sản Phẩm";
            MaSP.MinimumWidth = 6;
            MaSP.Name = "MaSP";
            // 
            // TenSP
            // 
            TenSP.DataPropertyName = "TenSP";
            TenSP.HeaderText = "Tên Sản Phẩm";
            TenSP.MinimumWidth = 6;
            TenSP.Name = "TenSP";
            // 
            // MaDanhMuc
            // 
            MaDanhMuc.DataPropertyName = "MaDanhMuc";
            MaDanhMuc.HeaderText = "Mã Danh Mục";
            MaDanhMuc.MinimumWidth = 6;
            MaDanhMuc.Name = "MaDanhMuc";
            // 
            // MoTa
            // 
            MoTa.DataPropertyName = "MoTa";
            MoTa.HeaderText = "Mô tả";
            MoTa.MinimumWidth = 6;
            MoTa.Name = "MoTa";
            // 
            // SoLuongTon
            // 
            SoLuongTon.DataPropertyName = "SoLuongTon";
            SoLuongTon.HeaderText = "Số lượng tồn";
            SoLuongTon.MinimumWidth = 6;
            SoLuongTon.Name = "SoLuongTon";
            // 
            // GiaBanHienTai
            // 
            GiaBanHienTai.DataPropertyName = "GiaBanHienTai";
            GiaBanHienTai.HeaderText = "Giá bán hiện tại";
            GiaBanHienTai.MinimumWidth = 6;
            GiaBanHienTai.Name = "GiaBanHienTai";
            // 
            // MaThuongHieu
            // 
            MaThuongHieu.HeaderText = "Mã Thương Hiệu";
            MaThuongHieu.MinimumWidth = 6;
            MaThuongHieu.Name = "MaThuongHieu";
            // 
            // NguongTonToiThieu
            // 
            NguongTonToiThieu.HeaderText = "Nguong Ton Toi Thieu";
            NguongTonToiThieu.MinimumWidth = 6;
            NguongTonToiThieu.Name = "NguongTonToiThieu";
            // 
            // HinhAnh
            // 
            HinhAnh.HeaderText = "Hình Ảnh";
            HinhAnh.MinimumWidth = 6;
            HinhAnh.Name = "HinhAnh";
            // 
            // btnThem
            // 
            btnThem.Location = new Point(27, 194);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(94, 29);
            btnThem.TabIndex = 17;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(127, 194);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(94, 29);
            btnSua.TabIndex = 18;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(247, 194);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(94, 29);
            btnXoa.TabIndex = 19;
            btnXoa.Text = "Xoá";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnGhi
            // 
            btnGhi.Enabled = false;
            btnGhi.Location = new Point(366, 194);
            btnGhi.Name = "btnGhi";
            btnGhi.Size = new Size(94, 29);
            btnGhi.TabIndex = 20;
            btnGhi.Text = "Ghi dữ liệu";
            btnGhi.UseVisualStyleBackColor = true;
            btnGhi.Click += btnGhi_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(622, 194);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(94, 29);
            btnTimKiem.TabIndex = 22;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // btnTim
            // 
            btnTim.Location = new Point(751, 194);
            btnTim.Name = "btnTim";
            btnTim.Size = new Size(94, 29);
            btnTim.TabIndex = 23;
            btnTim.Text = "Tìm";
            btnTim.UseVisualStyleBackColor = true;
            btnTim.Click += btnTim_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Enabled = false;
            btnLamMoi.Location = new Point(494, 194);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(94, 29);
            btnLamMoi.TabIndex = 24;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(27, 152);
            label9.Name = "label9";
            label9.Size = new Size(114, 20);
            label9.TabIndex = 25;
            label9.Text = "Mã thương hiệu";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(493, 152);
            label10.Name = "label10";
            label10.Size = new Size(149, 20);
            label10.TabIndex = 26;
            label10.Text = "Ngưỡng tồn tối thiểu";
            // 
            // txtMoTa
            // 
            txtMoTa.Enabled = false;
            txtMoTa.Location = new Point(655, 116);
            txtMoTa.Name = "txtMoTa";
            txtMoTa.Size = new Size(151, 27);
            txtMoTa.TabIndex = 4;
            // 
            // txtNguongTonToiThieu
            // 
            txtNguongTonToiThieu.Enabled = false;
            txtNguongTonToiThieu.Location = new Point(655, 152);
            txtNguongTonToiThieu.Name = "txtNguongTonToiThieu";
            txtNguongTonToiThieu.Size = new Size(151, 27);
            txtNguongTonToiThieu.TabIndex = 27;
            // 
            // txtMaThuongHieu
            // 
            txtMaThuongHieu.Enabled = false;
            txtMaThuongHieu.Location = new Point(171, 145);
            txtMaThuongHieu.Name = "txtMaThuongHieu";
            txtMaThuongHieu.Size = new Size(250, 27);
            txtMaThuongHieu.TabIndex = 28;
            // 
            // txtHinhAnh
            // 
            txtHinhAnh.Enabled = false;
            txtHinhAnh.Location = new Point(917, 14);
            txtHinhAnh.Name = "txtHinhAnh";
            txtHinhAnh.Size = new Size(151, 27);
            txtHinhAnh.TabIndex = 30;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(843, 17);
            label11.Name = "label11";
            label11.Size = new Size(68, 20);
            label11.TabIndex = 29;
            label11.Text = "Hình ảnh";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1089, 615);
            Controls.Add(txtHinhAnh);
            Controls.Add(label11);
            Controls.Add(txtMaThuongHieu);
            Controls.Add(txtNguongTonToiThieu);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(btnLamMoi);
            Controls.Add(btnTim);
            Controls.Add(btnTimKiem);
            Controls.Add(btnGhi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(dgvSanPham);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cboTrangThai);
            Controls.Add(txtGiaBanHienTai);
            Controls.Add(txtSoLuongTon);
            Controls.Add(txtMoTa);
            Controls.Add(dtpThongTinBaoHanh);
            Controls.Add(txtMaDanhMuc);
            Controls.Add(txtTenSP);
            Controls.Add(txtMaSanPham);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSanPham).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMaSanPham;
        private TextBox txtTenSP;
        private TextBox txtMaDanhMuc;
        private DateTimePicker dtpThongTinBaoHanh;
        private TextBox txtSoLuongTon;
        private TextBox txtGiaBanHienTai;
        private ComboBox cboTrangThai;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private DataGridView dgvSanPham;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnGhi;
        private Button btnTimKiem;
        private Button btnTim;
        private Button btnLamMoi;
        private Label label9;
        private Label label10;
        private TextBox txtMoTa;
        private TextBox txtNguongTonToiThieu;
        private TextBox txtMaThuongHieu;
        private TextBox txtHinhAnh;
        private Label label11;
        private DataGridViewTextBoxColumn MaSP;
        private DataGridViewTextBoxColumn TenSP;
        private DataGridViewTextBoxColumn MaDanhMuc;
        private DataGridViewTextBoxColumn MoTa;
        private DataGridViewTextBoxColumn SoLuongTon;
        private DataGridViewTextBoxColumn GiaBanHienTai;
        private DataGridViewTextBoxColumn MaThuongHieu;
        private DataGridViewTextBoxColumn NguongTonToiThieu;
        private DataGridViewTextBoxColumn HinhAnh;
    }
}
