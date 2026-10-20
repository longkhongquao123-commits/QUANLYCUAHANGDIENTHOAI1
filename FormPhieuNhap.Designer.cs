
namespace QUANLYCUAHANGDIENTHOAI
{
    partial class FormPhieuNhap
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

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            tlpHeader = new TableLayoutPanel();
            lblTongTienPhieu = new Label();
            lblNhap = new Label();
            lblTitle = new Label();
            grpThongTinPhieu = new GroupBox();
            btnTaoPhieuMoi = new Button();
            dtpNgayNhap = new DateTimePicker();
            lblNgayNhap = new Label();
            txtSoChungTu = new TextBox();
            lblSoChungTu = new Label();
            cboNhanVien = new ComboBox();
            lblNhanVien = new Label();
            cboNhaCungCap = new ComboBox();
            lblNCC = new Label();
            txtMaPN = new TextBox();
            lblMaPN = new Label();
            grpChiTietMatHang = new GroupBox();
            lblThanhTienPreview = new Label();
            txtGhiChu = new TextBox();
            lblGhiChu = new Label();
            cboKetQuaKiemTra = new ComboBox();
            lblKiemDinh = new Label();
            txtDonGiaNhap = new TextBox();
            lblDonGia = new Label();
            numSoLuong = new NumericUpDown();
            lblSoLuong = new Label();
            cboSanPham = new ComboBox();
            lblSanPham = new Label();
            pnlActions = new Panel();
            btnHoanTatNhap = new Button();
            btnNhapIMEI = new Button();
            btnHuy = new Button();
            btnGhi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            pnlSearch = new Panel();
            btnLamMoiTimKiem = new Button();
            btnTimKiem = new Button();
            txtTimThanhTien = new TextBox();
            lblTimTien = new Label();
            txtTimKiemTen = new TextBox();
            lblTimTen = new Label();
            dgvChiTietNhap = new DataGridView();
            MaPN = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            pnlHeader.SuspendLayout();
            tlpHeader.SuspendLayout();
            grpThongTinPhieu.SuspendLayout();
            grpChiTietMatHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
            pnlActions.SuspendLayout();
            pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(30, 41, 59);
            pnlHeader.Controls.Add(tlpHeader);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(17, 0, 17, 0);
            pnlHeader.Size = new Size(1237, 73);
            pnlHeader.TabIndex = 5;
            // 
            // tlpHeader
            // 
            // Bố cục tự canh: [Tiêu đề (tự giãn)] [Nhãn Nháp (tự giãn)] [Tổng tiền - phần còn lại, canh phải]
            // Không còn tọa độ cố định nên không bị tràn/chồng chữ khi đổi DPI, phông chữ hoặc kích thước form.
            tlpHeader.BackColor = Color.Transparent;
            tlpHeader.ColumnCount = 3;
            tlpHeader.ColumnStyles.Add(new ColumnStyle());
            tlpHeader.ColumnStyles.Add(new ColumnStyle());
            tlpHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpHeader.Controls.Add(lblTitle, 0, 0);
            tlpHeader.Controls.Add(lblNhap, 1, 0);
            tlpHeader.Controls.Add(lblTongTienPhieu, 2, 0);
            tlpHeader.Dock = DockStyle.Fill;
            tlpHeader.Location = new Point(17, 0);
            tlpHeader.Margin = new Padding(0);
            tlpHeader.Name = "tlpHeader";
            tlpHeader.RowCount = 1;
            tlpHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpHeader.Size = new Size(1203, 73);
            tlpHeader.TabIndex = 0;
            // 
            // lblTongTienPhieu
            // 
            lblTongTienPhieu.Anchor = AnchorStyles.Right;
            lblTongTienPhieu.AutoSize = true;
            lblTongTienPhieu.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblTongTienPhieu.ForeColor = Color.FromArgb(56, 189, 248);
            lblTongTienPhieu.Margin = new Padding(16, 0, 0, 0);
            lblTongTienPhieu.Name = "lblTongTienPhieu";
            lblTongTienPhieu.Size = new Size(255, 30);
            lblTongTienPhieu.TabIndex = 2;
            lblTongTienPhieu.Text = "Tổng tiền phiếu: 0 VNĐ";
            lblTongTienPhieu.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblNhap
            // 
            lblNhap.Anchor = AnchorStyles.Left;
            lblNhap.AutoSize = true;
            lblNhap.BackColor = Color.FromArgb(245, 158, 11);
            lblNhap.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblNhap.ForeColor = Color.White;
            lblNhap.Margin = new Padding(14, 0, 0, 0);
            lblNhap.Name = "lblNhap";
            lblNhap.Padding = new Padding(9, 4, 9, 4);
            lblNhap.Size = new Size(78, 33);
            lblNhap.TabIndex = 1;
            lblNhap.Text = "Nháp";
            lblNhap.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.Left;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Margin = new Padding(0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(671, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ PHIẾU NHẬP KHO VÀ KIỂM ĐỊNH CHẤT LƯỢNG";
            lblTitle.Click += lblTitle_Click;
            // 
            // grpThongTinPhieu
            // 
            grpThongTinPhieu.BackColor = Color.White;
            grpThongTinPhieu.Controls.Add(btnTaoPhieuMoi);
            grpThongTinPhieu.Controls.Add(dtpNgayNhap);
            grpThongTinPhieu.Controls.Add(lblNgayNhap);
            grpThongTinPhieu.Controls.Add(txtSoChungTu);
            grpThongTinPhieu.Controls.Add(lblSoChungTu);
            grpThongTinPhieu.Controls.Add(cboNhanVien);
            grpThongTinPhieu.Controls.Add(lblNhanVien);
            grpThongTinPhieu.Controls.Add(cboNhaCungCap);
            grpThongTinPhieu.Controls.Add(lblNCC);
            grpThongTinPhieu.Controls.Add(txtMaPN);
            grpThongTinPhieu.Controls.Add(lblMaPN);
            grpThongTinPhieu.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            grpThongTinPhieu.Location = new Point(14, 87);
            grpThongTinPhieu.Margin = new Padding(3, 4, 3, 4);
            grpThongTinPhieu.Name = "grpThongTinPhieu";
            grpThongTinPhieu.Padding = new Padding(3, 4, 3, 4);
            grpThongTinPhieu.Size = new Size(549, 280);
            grpThongTinPhieu.TabIndex = 4;
            grpThongTinPhieu.TabStop = false;
            grpThongTinPhieu.Text = "1. Thông tin chung Phiếu Nhập (Master)";
            // 
            // btnTaoPhieuMoi
            // 
            btnTaoPhieuMoi.BackColor = Color.FromArgb(14, 165, 233);
            btnTaoPhieuMoi.FlatStyle = FlatStyle.Flat;
            btnTaoPhieuMoi.Font = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            btnTaoPhieuMoi.ForeColor = Color.White;
            btnTaoPhieuMoi.Location = new Point(398, 37);
            btnTaoPhieuMoi.Margin = new Padding(3, 4, 3, 4);
            btnTaoPhieuMoi.Name = "btnTaoPhieuMoi";
            btnTaoPhieuMoi.Size = new Size(131, 35);
            btnTaoPhieuMoi.TabIndex = 0;
            btnTaoPhieuMoi.Text = "+ Tạo mã PN mới";
            btnTaoPhieuMoi.UseVisualStyleBackColor = false;
            btnTaoPhieuMoi.Click += btnTaoPhieuMoi_Click;
            // 
            // dtpNgayNhap
            // 
            dtpNgayNhap.Font = new Font("Segoe UI", 9.5F);
            dtpNgayNhap.Format = DateTimePickerFormat.Short;
            dtpNgayNhap.Location = new Point(166, 228);
            dtpNgayNhap.Margin = new Padding(3, 4, 3, 4);
            dtpNgayNhap.Name = "dtpNgayNhap";
            dtpNgayNhap.Size = new Size(363, 29);
            dtpNgayNhap.TabIndex = 1;
            // 
            // lblNgayNhap
            // 
            lblNgayNhap.AutoSize = true;
            lblNgayNhap.Font = new Font("Segoe UI", 9.5F);
            lblNgayNhap.Location = new Point(17, 232);
            lblNgayNhap.Name = "lblNgayNhap";
            lblNgayNhap.Size = new Size(119, 21);
            lblNgayNhap.TabIndex = 2;
            lblNgayNhap.Text = "Ngày nhập kho:";
            // 
            // txtSoChungTu
            // 
            txtSoChungTu.Font = new Font("Segoe UI", 9.5F);
            txtSoChungTu.Location = new Point(166, 183);
            txtSoChungTu.Margin = new Padding(3, 4, 3, 4);
            txtSoChungTu.Name = "txtSoChungTu";
            txtSoChungTu.Size = new Size(363, 29);
            txtSoChungTu.TabIndex = 3;
            // 
            // lblSoChungTu
            // 
            lblSoChungTu.AutoSize = true;
            lblSoChungTu.Font = new Font("Segoe UI", 9.5F);
            lblSoChungTu.Location = new Point(17, 187);
            lblSoChungTu.Name = "lblSoChungTu";
            lblSoChungTu.Size = new Size(117, 21);
            lblSoChungTu.TabIndex = 4;
            lblSoChungTu.Text = "Số chứng từ (*):";
            // 
            // cboNhanVien
            // 
            cboNhanVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhanVien.Font = new Font("Segoe UI", 9.5F);
            cboNhanVien.Location = new Point(166, 135);
            cboNhanVien.Margin = new Padding(3, 4, 3, 4);
            cboNhanVien.Name = "cboNhanVien";
            cboNhanVien.Size = new Size(363, 29);
            cboNhanVien.TabIndex = 5;
            // 
            // lblNhanVien
            // 
            lblNhanVien.AutoSize = true;
            lblNhanVien.Font = new Font("Segoe UI", 9.5F);
            lblNhanVien.Location = new Point(17, 139);
            lblNhanVien.Name = "lblNhanVien";
            lblNhanVien.Size = new Size(130, 21);
            lblNhanVien.TabIndex = 6;
            lblNhanVien.Text = "Nhân viên lập (*):";
            // 
            // cboNhaCungCap
            // 
            cboNhaCungCap.DropDownStyle = ComboBoxStyle.DropDownList;
            cboNhaCungCap.Font = new Font("Segoe UI", 9.5F);
            cboNhaCungCap.Location = new Point(166, 87);
            cboNhaCungCap.Margin = new Padding(3, 4, 3, 4);
            cboNhaCungCap.Name = "cboNhaCungCap";
            cboNhaCungCap.Size = new Size(363, 29);
            cboNhaCungCap.TabIndex = 7;
            // 
            // lblNCC
            // 
            lblNCC.AutoSize = true;
            lblNCC.Font = new Font("Segoe UI", 9.5F);
            lblNCC.Location = new Point(17, 91);
            lblNCC.Name = "lblNCC";
            lblNCC.Size = new Size(129, 21);
            lblNCC.TabIndex = 8;
            lblNCC.Text = "Nhà cung cấp (*):";
            // 
            // txtMaPN
            // 
            txtMaPN.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            txtMaPN.Location = new Point(166, 39);
            txtMaPN.Margin = new Padding(3, 4, 3, 4);
            txtMaPN.Name = "txtMaPN";
            txtMaPN.Size = new Size(222, 29);
            txtMaPN.TabIndex = 9;
            // 
            // lblMaPN
            // 
            lblMaPN.AutoSize = true;
            lblMaPN.Font = new Font("Segoe UI", 9.5F);
            lblMaPN.Location = new Point(17, 43);
            lblMaPN.Name = "lblMaPN";
            lblMaPN.Size = new Size(138, 21);
            lblMaPN.TabIndex = 10;
            lblMaPN.Text = "Mã phiếu nhập (*):";
            // 
            // grpChiTietMatHang
            // 
            grpChiTietMatHang.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpChiTietMatHang.BackColor = Color.White;
            grpChiTietMatHang.Controls.Add(lblThanhTienPreview);
            grpChiTietMatHang.Controls.Add(txtGhiChu);
            grpChiTietMatHang.Controls.Add(lblGhiChu);
            grpChiTietMatHang.Controls.Add(cboKetQuaKiemTra);
            grpChiTietMatHang.Controls.Add(lblKiemDinh);
            grpChiTietMatHang.Controls.Add(txtDonGiaNhap);
            grpChiTietMatHang.Controls.Add(lblDonGia);
            grpChiTietMatHang.Controls.Add(numSoLuong);
            grpChiTietMatHang.Controls.Add(lblSoLuong);
            grpChiTietMatHang.Controls.Add(cboSanPham);
            grpChiTietMatHang.Controls.Add(lblSanPham);
            grpChiTietMatHang.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            grpChiTietMatHang.Location = new Point(577, 87);
            grpChiTietMatHang.Margin = new Padding(3, 4, 3, 4);
            grpChiTietMatHang.Name = "grpChiTietMatHang";
            grpChiTietMatHang.Padding = new Padding(3, 4, 3, 4);
            grpChiTietMatHang.Size = new Size(646, 280);
            grpChiTietMatHang.TabIndex = 3;
            grpChiTietMatHang.TabStop = false;
            grpChiTietMatHang.Text = "2. Chi tiết Mặt hàng & Kiểm định chất lượng (Detail)";
            // 
            // lblThanhTienPreview
            // 
            lblThanhTienPreview.AutoSize = true;
            lblThanhTienPreview.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblThanhTienPreview.ForeColor = Color.FromArgb(22, 163, 74);
            lblThanhTienPreview.Location = new Point(314, 91);
            lblThanhTienPreview.Name = "lblThanhTienPreview";
            lblThanhTienPreview.Size = new Size(149, 21);
            lblThanhTienPreview.TabIndex = 0;
            lblThanhTienPreview.Text = "Thành tiền: 0 VNĐ";
            // 
            // txtGhiChu
            // 
            txtGhiChu.Font = new Font("Segoe UI", 9.5F);
            txtGhiChu.Location = new Point(160, 228);
            txtGhiChu.Margin = new Padding(3, 4, 3, 4);
            txtGhiChu.Name = "txtGhiChu";
            txtGhiChu.Size = new Size(462, 29);
            txtGhiChu.TabIndex = 1;
            // 
            // lblGhiChu
            // 
            lblGhiChu.AutoSize = true;
            lblGhiChu.Font = new Font("Segoe UI", 9.5F);
            lblGhiChu.Location = new Point(21, 232);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(127, 21);
            lblGhiChu.TabIndex = 2;
            lblGhiChu.Text = "Ghi chú kiểm tra:";
            // 
            // cboKetQuaKiemTra
            // 
            cboKetQuaKiemTra.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKetQuaKiemTra.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            cboKetQuaKiemTra.Location = new Point(160, 183);
            cboKetQuaKiemTra.Margin = new Padding(3, 4, 3, 4);
            cboKetQuaKiemTra.Name = "cboKetQuaKiemTra";
            cboKetQuaKiemTra.Size = new Size(462, 29);
            cboKetQuaKiemTra.TabIndex = 3;
            // 
            // lblKiemDinh
            // 
            lblKiemDinh.AutoSize = true;
            lblKiemDinh.Font = new Font("Segoe UI", 9.5F);
            lblKiemDinh.Location = new Point(21, 187);
            lblKiemDinh.Name = "lblKiemDinh";
            lblKiemDinh.Size = new Size(107, 21);
            lblKiemDinh.TabIndex = 4;
            lblKiemDinh.Text = "Kết quả KT (*):";
            // 
            // txtDonGiaNhap
            // 
            txtDonGiaNhap.Font = new Font("Segoe UI", 9.5F);
            txtDonGiaNhap.Location = new Point(160, 135);
            txtDonGiaNhap.Margin = new Padding(3, 4, 3, 4);
            txtDonGiaNhap.Name = "txtDonGiaNhap";
            txtDonGiaNhap.Size = new Size(462, 29);
            txtDonGiaNhap.TabIndex = 5;
            // 
            // lblDonGia
            // 
            lblDonGia.AutoSize = true;
            lblDonGia.Font = new Font("Segoe UI", 9.5F);
            lblDonGia.Location = new Point(21, 139);
            lblDonGia.Name = "lblDonGia";
            lblDonGia.Size = new Size(128, 21);
            lblDonGia.TabIndex = 6;
            lblDonGia.Text = "Đơn giá nhập (*):";
            // 
            // numSoLuong
            // 
            numSoLuong.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            numSoLuong.Location = new Point(160, 88);
            numSoLuong.Margin = new Padding(3, 4, 3, 4);
            numSoLuong.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSoLuong.Name = "numSoLuong";
            numSoLuong.Size = new Size(137, 29);
            numSoLuong.TabIndex = 7;
            numSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblSoLuong
            // 
            lblSoLuong.AutoSize = true;
            lblSoLuong.Font = new Font("Segoe UI", 9.5F);
            lblSoLuong.Location = new Point(21, 91);
            lblSoLuong.Name = "lblSoLuong";
            lblSoLuong.Size = new Size(136, 21);
            lblSoLuong.TabIndex = 8;
            lblSoLuong.Text = "Số lượng nhập (*):";
            // 
            // cboSanPham
            // 
            cboSanPham.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSanPham.Font = new Font("Segoe UI", 9.5F);
            cboSanPham.Location = new Point(160, 39);
            cboSanPham.Margin = new Padding(3, 4, 3, 4);
            cboSanPham.Name = "cboSanPham";
            cboSanPham.Size = new Size(462, 29);
            cboSanPham.TabIndex = 9;
            // 
            // lblSanPham
            // 
            lblSanPham.AutoSize = true;
            lblSanPham.Font = new Font("Segoe UI", 9.5F);
            lblSanPham.Location = new Point(21, 43);
            lblSanPham.Name = "lblSanPham";
            lblSanPham.Size = new Size(104, 21);
            lblSanPham.TabIndex = 10;
            lblSanPham.Text = "Sản phẩm (*):";
            // 
            // pnlActions
            // 
            pnlActions.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlActions.BackColor = Color.FromArgb(241, 245, 249);
            pnlActions.Controls.Add(btnHoanTatNhap);
            pnlActions.Controls.Add(btnNhapIMEI);
            pnlActions.Controls.Add(btnHuy);
            pnlActions.Controls.Add(btnGhi);
            pnlActions.Controls.Add(btnXoa);
            pnlActions.Controls.Add(btnSua);
            pnlActions.Controls.Add(btnThem);
            pnlActions.Location = new Point(14, 376);
            pnlActions.Margin = new Padding(3, 4, 3, 4);
            pnlActions.Name = "pnlActions";
            pnlActions.Size = new Size(1209, 64);
            pnlActions.TabIndex = 2;
            // 
            // btnHoanTatNhap
            // 
            btnHoanTatNhap.BackColor = Color.FromArgb(22, 163, 74);
            btnHoanTatNhap.FlatStyle = FlatStyle.Flat;
            btnHoanTatNhap.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnHoanTatNhap.ForeColor = Color.White;
            btnHoanTatNhap.Location = new Point(971, 8);
            btnHoanTatNhap.Margin = new Padding(3, 4, 3, 4);
            btnHoanTatNhap.Name = "btnHoanTatNhap";
            btnHoanTatNhap.Size = new Size(226, 48);
            btnHoanTatNhap.TabIndex = 0;
            btnHoanTatNhap.Text = "✅ Hoàn tất phiếu nhập";
            btnHoanTatNhap.UseVisualStyleBackColor = false;
            btnHoanTatNhap.Click += btnHoanTatNhap_Click;
            // 
            // btnNhapIMEI
            // 
            btnNhapIMEI.BackColor = Color.FromArgb(124, 58, 237);
            btnNhapIMEI.FlatStyle = FlatStyle.Flat;
            btnNhapIMEI.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnNhapIMEI.ForeColor = Color.White;
            btnNhapIMEI.Location = new Point(753, 8);
            btnNhapIMEI.Margin = new Padding(3, 4, 3, 4);
            btnNhapIMEI.Name = "btnNhapIMEI";
            btnNhapIMEI.Size = new Size(212, 48);
            btnNhapIMEI.TabIndex = 1;
            btnNhapIMEI.Text = "📱 Nhập IMEI từng dòng";
            btnNhapIMEI.UseVisualStyleBackColor = false;
            btnNhapIMEI.Click += btnNhapIMEI_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = Color.FromArgb(100, 116, 139);
            btnHuy.FlatStyle = FlatStyle.Flat;
            btnHuy.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(598, 8);
            btnHuy.Margin = new Padding(3, 4, 3, 4);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(120, 48);
            btnHuy.TabIndex = 2;
            btnHuy.Text = "✖️ Hủy bỏ";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // btnGhi
            // 
            btnGhi.BackColor = Color.FromArgb(5, 150, 105);
            btnGhi.FlatStyle = FlatStyle.Flat;
            btnGhi.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnGhi.ForeColor = Color.White;
            btnGhi.Location = new Point(440, 8);
            btnGhi.Margin = new Padding(3, 4, 3, 4);
            btnGhi.Name = "btnGhi";
            btnGhi.Size = new Size(149, 48);
            btnGhi.TabIndex = 3;
            btnGhi.Text = "💾 Ghi dữ liệu";
            btnGhi.UseVisualStyleBackColor = false;
            btnGhi.Click += btnGhi_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.FromArgb(220, 38, 38);
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(287, 8);
            btnXoa.Margin = new Padding(3, 4, 3, 4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(126, 48);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "🗑️ Xóa dòng";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.FromArgb(217, 119, 6);
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(152, 8);
            btnSua.Margin = new Padding(3, 4, 3, 4);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(126, 48);
            btnSua.TabIndex = 5;
            btnSua.Text = "✏️ Sửa dòng";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.FromArgb(37, 99, 235);
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(11, 8);
            btnThem.Margin = new Padding(3, 4, 3, 4);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(131, 48);
            btnThem.TabIndex = 6;
            btnThem.Text = "➕ Thêm dòng";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // pnlSearch
            // 
            pnlSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSearch.BackColor = Color.White;
            pnlSearch.Controls.Add(btnLamMoiTimKiem);
            pnlSearch.Controls.Add(btnTimKiem);
            pnlSearch.Controls.Add(txtTimThanhTien);
            pnlSearch.Controls.Add(lblTimTien);
            pnlSearch.Controls.Add(txtTimKiemTen);
            pnlSearch.Controls.Add(lblTimTen);
            pnlSearch.Location = new Point(14, 448);
            pnlSearch.Margin = new Padding(3, 4, 3, 4);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(1209, 53);
            pnlSearch.TabIndex = 1;
            // 
            // btnLamMoiTimKiem
            // 
            btnLamMoiTimKiem.BackColor = Color.FromArgb(226, 232, 240);
            btnLamMoiTimKiem.FlatStyle = FlatStyle.Flat;
            btnLamMoiTimKiem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLamMoiTimKiem.ForeColor = Color.FromArgb(30, 41, 59);
            btnLamMoiTimKiem.Location = new Point(966, 7);
            btnLamMoiTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnLamMoiTimKiem.Name = "btnLamMoiTimKiem";
            btnLamMoiTimKiem.Size = new Size(137, 39);
            btnLamMoiTimKiem.TabIndex = 0;
            btnLamMoiTimKiem.Text = "Hiện tất cả";
            btnLamMoiTimKiem.UseVisualStyleBackColor = false;
            btnLamMoiTimKiem.Click += btnLamMoiTimKiem_Click;
            // 
            // btnTimKiem
            // 
            btnTimKiem.BackColor = Color.FromArgb(30, 41, 59);
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(829, 7);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(126, 39);
            btnTimKiem.TabIndex = 1;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // txtTimThanhTien
            // 
            txtTimThanhTien.Font = new Font("Segoe UI", 9.5F);
            txtTimThanhTien.Location = new Point(629, 9);
            txtTimThanhTien.Margin = new Padding(3, 4, 3, 4);
            txtTimThanhTien.Name = "txtTimThanhTien";
            txtTimThanhTien.Size = new Size(182, 29);
            txtTimThanhTien.TabIndex = 2;
            // 
            // lblTimTien
            // 
            lblTimTien.AutoSize = true;
            lblTimTien.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTimTien.Location = new Point(474, 13);
            lblTimTien.Name = "lblTimTien";
            lblTimTien.Size = new Size(161, 21);
            lblTimTien.TabIndex = 3;
            lblTimTien.Text = "Hoặc Thành tiền >=";
            // 
            // txtTimKiemTen
            // 
            txtTimKiemTen.Font = new Font("Segoe UI", 9.5F);
            txtTimKiemTen.Location = new Point(189, 9);
            txtTimKiemTen.Margin = new Padding(3, 4, 3, 4);
            txtTimKiemTen.Name = "txtTimKiemTen";
            txtTimKiemTen.Size = new Size(262, 29);
            txtTimKiemTen.TabIndex = 4;
            // 
            // lblTimTen
            // 
            lblTimTen.AutoSize = true;
            lblTimTen.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblTimTen.Location = new Point(11, 13);
            lblTimTen.Name = "lblTimTen";
            lblTimTen.Size = new Size(188, 21);
            lblTimTen.TabIndex = 5;
            lblTimTen.Text = "🔍 Tìm tên SP / Mã PN:";
            // 
            // dgvChiTietNhap
            // 
            dgvChiTietNhap.AllowUserToAddRows = false;
            dgvChiTietNhap.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvChiTietNhap.BackgroundColor = Color.White;
            dgvChiTietNhap.ColumnHeadersHeight = 38;
            dgvChiTietNhap.Columns.AddRange(new DataGridViewColumn[] { MaPN, Column1, Column2, Column3, Column4, Column5, Column6, Column7 });
            dgvChiTietNhap.Location = new Point(14, 509);
            dgvChiTietNhap.Margin = new Padding(3, 4, 3, 4);
            dgvChiTietNhap.MultiSelect = false;
            dgvChiTietNhap.Name = "dgvChiTietNhap";
            dgvChiTietNhap.ReadOnly = true;
            dgvChiTietNhap.RowHeadersVisible = false;
            dgvChiTietNhap.RowHeadersWidth = 51;
            dgvChiTietNhap.RowTemplate.Height = 32;
            dgvChiTietNhap.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChiTietNhap.Size = new Size(1209, 340);
            dgvChiTietNhap.TabIndex = 0;
            dgvChiTietNhap.CellClick += dgvChiTietNhap_CellClick;
            // 
            // MaPN
            // 
            MaPN.DataPropertyName = "MaPN";
            MaPN.HeaderText = "Mã Phiếu Nhập";
            MaPN.MinimumWidth = 6;
            MaPN.Name = "MaPN";
            MaPN.ReadOnly = true;
            MaPN.Width = 125;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "MaSP";
            Column1.HeaderText = "Mã Sản Phẩm";
            Column1.MinimumWidth = 6;
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 125;
            // 
            // Column2
            // 
            Column2.DataPropertyName = "TenSP";
            Column2.HeaderText = "Tên Sản Phẩm";
            Column2.MinimumWidth = 6;
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            Column2.Width = 125;
            // 
            // Column3
            // 
            Column3.DataPropertyName = "SoLuongNhap";
            Column3.HeaderText = "Số lượng";
            Column3.MinimumWidth = 6;
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 125;
            // 
            // Column4
            // 
            Column4.DataPropertyName = "DonGiaNhap";
            Column4.HeaderText = "Đơn Giá Nhập";
            Column4.MinimumWidth = 6;
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 125;
            // 
            // Column5
            // 
            Column5.DataPropertyName = "ThanhTien";
            Column5.HeaderText = "Thành Tiền";
            Column5.MinimumWidth = 6;
            Column5.Name = "Column5";
            Column5.ReadOnly = true;
            Column5.Width = 125;
            // 
            // Column6
            // 
            Column6.DataPropertyName = "KetQuaKiemTra";
            Column6.HeaderText = "Kết Quả Kiểm Tra";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Width = 125;
            // 
            // Column7
            // 
            Column7.DataPropertyName = "GhiChu";
            Column7.HeaderText = "Ghi Chú";
            Column7.MinimumWidth = 6;
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            Column7.Width = 125;
            // 
            // FormPhieuNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1237, 867);
            Controls.Add(dgvChiTietNhap);
            Controls.Add(pnlSearch);
            Controls.Add(pnlActions);
            Controls.Add(grpChiTietMatHang);
            Controls.Add(grpThongTinPhieu);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 9F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormPhieuNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Nhập Hàng & Kiểm Định Chất Lượng (Mục 16 & 17)";
            Load += FormPhieuNhap_Load;
            pnlHeader.ResumeLayout(false);
            tlpHeader.ResumeLayout(false);
            tlpHeader.PerformLayout();
            grpThongTinPhieu.ResumeLayout(false);
            grpThongTinPhieu.PerformLayout();
            grpChiTietMatHang.ResumeLayout(false);
            grpChiTietMatHang.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
            pnlActions.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietNhap).EndInit();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.TableLayoutPanel tlpHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNhap;
        private System.Windows.Forms.Label lblTongTienPhieu;
        private System.Windows.Forms.GroupBox grpThongTinPhieu;
        private System.Windows.Forms.Button btnTaoPhieuMoi;
        private System.Windows.Forms.DateTimePicker dtpNgayNhap;
        private System.Windows.Forms.Label lblNgayNhap;
        private System.Windows.Forms.TextBox txtSoChungTu;
        private System.Windows.Forms.Label lblSoChungTu;
        private System.Windows.Forms.ComboBox cboNhanVien;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.ComboBox cboNhaCungCap;
        private System.Windows.Forms.Label lblNCC;
        private System.Windows.Forms.TextBox txtMaPN;
        private System.Windows.Forms.Label lblMaPN;
        private System.Windows.Forms.GroupBox grpChiTietMatHang;
        private System.Windows.Forms.Label lblThanhTienPreview;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.ComboBox cboKetQuaKiemTra;
        private System.Windows.Forms.Label lblKiemDinh;
        private System.Windows.Forms.TextBox txtDonGiaNhap;
        private System.Windows.Forms.Label lblDonGia;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.ComboBox cboSanPham;
        private System.Windows.Forms.Label lblSanPham;
        private System.Windows.Forms.Panel pnlActions;
        private System.Windows.Forms.Button btnHoanTatNhap;
        private System.Windows.Forms.Button btnNhapIMEI;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnGhi;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Panel pnlSearch;
        private System.Windows.Forms.Button btnLamMoiTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimThanhTien;
        private System.Windows.Forms.Label lblTimTien;
        private System.Windows.Forms.TextBox txtTimKiemTen;
        private System.Windows.Forms.Label lblTimTen;
        private System.Windows.Forms.DataGridView dgvChiTietNhap;
        private DataGridViewTextBoxColumn MaPN;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
    }
}







