namespace Quanlybanhang
{
    partial class ThanhToan
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
            System.Windows.Forms.DataGridViewCellStyle styleHeader = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleCell = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleAlt = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle styleGiua = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle stylePhai1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle stylePhai2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle stylePhai3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTieuDe = new System.Windows.Forms.Panel();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.lblPhuDe = new System.Windows.Forms.Label();
            this.pnlThongTin = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPhieu = new System.Windows.Forms.TextBox();
            this.txtKhachHang = new System.Windows.Forms.TextBox();
            this.txtKhachDua = new System.Windows.Forms.TextBox();
            this.txtTienThua = new System.Windows.Forms.TextBox();
            this.cboPhuongThuc = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCanThanhToan = new System.Windows.Forms.TextBox();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.chkDaNhanDu = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtHDMaPhieu = new System.Windows.Forms.TextBox();
            this.txtHDTenKhachHang = new System.Windows.Forms.TextBox();
            this.txtHDTongThanhToan = new System.Windows.Forms.TextBox();
            this.dtpHDNgay = new System.Windows.Forms.DateTimePicker();
            this.dgvHoaDon = new System.Windows.Forms.DataGridView();
            this.sanpham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dongia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giamgia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.thanhtien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHoaDon = new System.Windows.Forms.Panel();
            this.lblDuongKe = new System.Windows.Forms.Label();
            this.lblCamOn = new System.Windows.Forms.Label();
            this.pnlTieuDe.SuspendLayout();
            this.pnlThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.pnlHoaDon.SuspendLayout();
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
            this.pnlTieuDe.Size = new System.Drawing.Size(1482, 56);
            this.pnlTieuDe.TabIndex = 40;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.ForeColor = System.Drawing.Color.White;
            this.lblTieuDe.Location = new System.Drawing.Point(18, 5);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(150, 28);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "THANH TOÁN";
            // 
            // lblPhuDe
            // 
            this.lblPhuDe.AutoSize = true;
            this.lblPhuDe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhuDe.ForeColor = System.Drawing.Color.FromArgb(200, 215, 240);
            this.lblPhuDe.Location = new System.Drawing.Point(21, 34);
            this.lblPhuDe.Name = "lblPhuDe";
            this.lblPhuDe.Size = new System.Drawing.Size(250, 17);
            this.lblPhuDe.TabIndex = 1;
            this.lblPhuDe.Text = "Xác nhận phiếu bán hàng và nhận tiền";
            // 
            // pnlThongTin
            // 
            this.pnlThongTin.BackColor = System.Drawing.Color.White;
            this.pnlThongTin.Controls.Add(this.label1);
            this.pnlThongTin.Controls.Add(this.txtPhieu);
            this.pnlThongTin.Controls.Add(this.label4);
            this.pnlThongTin.Controls.Add(this.txtKhachHang);
            this.pnlThongTin.Controls.Add(this.label6);
            this.pnlThongTin.Controls.Add(this.txtCanThanhToan);
            this.pnlThongTin.Controls.Add(this.label2);
            this.pnlThongTin.Controls.Add(this.cboPhuongThuc);
            this.pnlThongTin.Controls.Add(this.chkDaNhanDu);
            this.pnlThongTin.Controls.Add(this.label3);
            this.pnlThongTin.Controls.Add(this.txtKhachDua);
            this.pnlThongTin.Controls.Add(this.label5);
            this.pnlThongTin.Controls.Add(this.txtTienThua);
            this.pnlThongTin.Controls.Add(this.btnXacNhan);
            this.pnlThongTin.Controls.Add(this.btnIn);
            this.pnlThongTin.Controls.Add(this.btnDong);
            this.pnlThongTin.Location = new System.Drawing.Point(16, 66);
            this.pnlThongTin.Name = "pnlThongTin";
            this.pnlThongTin.Size = new System.Drawing.Size(570, 460);
            this.pnlThongTin.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(30, 64, 124);
            this.label1.Location = new System.Drawing.Point(24, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Phiếu:";
            // 
            // txtPhieu
            // 
            this.txtPhieu.BackColor = System.Drawing.Color.FromArgb(232, 237, 245);
            this.txtPhieu.Location = new System.Drawing.Point(150, 22);
            this.txtPhieu.Name = "txtPhieu";
            this.txtPhieu.ReadOnly = true;
            this.txtPhieu.Size = new System.Drawing.Size(200, 25);
            this.txtPhieu.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(30, 64, 124);
            this.label4.Location = new System.Drawing.Point(24, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Khách hàng: ";
            // 
            // txtKhachHang
            // 
            this.txtKhachHang.BackColor = System.Drawing.Color.FromArgb(232, 237, 245);
            this.txtKhachHang.Location = new System.Drawing.Point(150, 62);
            this.txtKhachHang.Name = "txtKhachHang";
            this.txtKhachHang.ReadOnly = true;
            this.txtKhachHang.Size = new System.Drawing.Size(390, 25);
            this.txtKhachHang.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(30, 64, 124);
            this.label6.Location = new System.Drawing.Point(24, 108);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 21);
            this.label6.TabIndex = 10;
            this.label6.Text = "Cần thanh toán:";
            // 
            // txtCanThanhToan
            // 
            this.txtCanThanhToan.BackColor = System.Drawing.Color.White;
            this.txtCanThanhToan.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCanThanhToan.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.txtCanThanhToan.Location = new System.Drawing.Point(24, 136);
            this.txtCanThanhToan.Name = "txtCanThanhToan";
            this.txtCanThanhToan.ReadOnly = true;
            this.txtCanThanhToan.Size = new System.Drawing.Size(516, 43);
            this.txtCanThanhToan.TabIndex = 11;
            this.txtCanThanhToan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(30, 64, 124);
            this.label2.Location = new System.Drawing.Point(24, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Phương thức:";
            // 
            // cboPhuongThuc
            // 
            this.cboPhuongThuc.FormattingEnabled = true;
            this.cboPhuongThuc.Items.AddRange(new object[] {
            "Tiền mặt",
            "Chuyển khoản"});
            this.cboPhuongThuc.Location = new System.Drawing.Point(150, 212);
            this.cboPhuongThuc.Name = "cboPhuongThuc";
            this.cboPhuongThuc.Size = new System.Drawing.Size(200, 25);
            this.cboPhuongThuc.TabIndex = 9;
            // 
            // chkDaNhanDu
            // 
            this.chkDaNhanDu.AutoSize = true;
            this.chkDaNhanDu.Location = new System.Drawing.Point(150, 246);
            this.chkDaNhanDu.Name = "chkDaNhanDu";
            this.chkDaNhanDu.Size = new System.Drawing.Size(206, 21);
            this.chkDaNhanDu.TabIndex = 15;
            this.chkDaNhanDu.Text = "Đã nhận đủ tiền chuyển khoản";
            this.chkDaNhanDu.UseVisualStyleBackColor = true;
            this.chkDaNhanDu.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(30, 64, 124);
            this.label3.Location = new System.Drawing.Point(24, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Khách đưa: ";
            // 
            // txtKhachDua
            // 
            this.txtKhachDua.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhachDua.Location = new System.Drawing.Point(150, 284);
            this.txtKhachDua.Name = "txtKhachDua";
            this.txtKhachDua.Size = new System.Drawing.Size(250, 27);
            this.txtKhachDua.TabIndex = 7;
            this.txtKhachDua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(30, 64, 124);
            this.label5.Location = new System.Drawing.Point(24, 338);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tiền thừa:";
            // 
            // txtTienThua
            // 
            this.txtTienThua.BackColor = System.Drawing.Color.FromArgb(232, 237, 245);
            this.txtTienThua.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTienThua.ForeColor = System.Drawing.Color.FromArgb(39, 130, 80);
            this.txtTienThua.Location = new System.Drawing.Point(150, 332);
            this.txtTienThua.Name = "txtTienThua";
            this.txtTienThua.ReadOnly = true;
            this.txtTienThua.Size = new System.Drawing.Size(250, 27);
            this.txtTienThua.TabIndex = 8;
            this.txtTienThua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.FromArgb(39, 174, 96);
            this.btnXacNhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXacNhan.FlatAppearance.BorderSize = 0;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Location = new System.Drawing.Point(24, 394);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(200, 48);
            this.btnXacNhan.TabIndex = 12;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            // 
            // btnIn
            // 
            this.btnIn.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            this.btnIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIn.Enabled = false;
            this.btnIn.FlatAppearance.BorderSize = 0;
            this.btnIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIn.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.ForeColor = System.Drawing.Color.White;
            this.btnIn.Location = new System.Drawing.Point(238, 394);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(150, 48);
            this.btnIn.TabIndex = 14;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = false;
            // 
            // btnDong
            // 
            this.btnDong.BackColor = System.Drawing.Color.FromArgb(127, 140, 141);
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(402, 394);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(138, 48);
            this.btnDong.TabIndex = 13;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(30, 64, 124);
            this.label7.Location = new System.Drawing.Point(300, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(220, 37);
            this.label7.TabIndex = 16;
            this.label7.Text = "Hóa đơn hàng";
            // 
            // lblDuongKe
            // 
            this.lblDuongKe.BackColor = System.Drawing.Color.FromArgb(30, 64, 124);
            this.lblDuongKe.Location = new System.Drawing.Point(40, 62);
            this.lblDuongKe.Name = "lblDuongKe";
            this.lblDuongKe.Size = new System.Drawing.Size(770, 2);
            this.lblDuongKe.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(30, 64, 124);
            this.label8.Location = new System.Drawing.Point(40, 86);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "Mã phiếu:";
            // 
            // txtHDMaPhieu
            // 
            this.txtHDMaPhieu.BackColor = System.Drawing.Color.White;
            this.txtHDMaPhieu.Location = new System.Drawing.Point(170, 82);
            this.txtHDMaPhieu.Name = "txtHDMaPhieu";
            this.txtHDMaPhieu.ReadOnly = true;
            this.txtHDMaPhieu.Size = new System.Drawing.Size(200, 25);
            this.txtHDMaPhieu.TabIndex = 22;
            this.txtHDMaPhieu.TextChanged += new System.EventHandler(this.txtMaPhieu_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.FromArgb(30, 64, 124);
            this.label10.Location = new System.Drawing.Point(450, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "Ngày:";
            // 
            // dtpHDNgay
            // 
            this.dtpHDNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHDNgay.Location = new System.Drawing.Point(510, 82);
            this.dtpHDNgay.Name = "dtpHDNgay";
            this.dtpHDNgay.Size = new System.Drawing.Size(180, 25);
            this.dtpHDNgay.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(30, 64, 124);
            this.label9.Location = new System.Drawing.Point(40, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "Tên khách hàng:";
            // 
            // txtHDTenKhachHang
            // 
            this.txtHDTenKhachHang.BackColor = System.Drawing.Color.White;
            this.txtHDTenKhachHang.Location = new System.Drawing.Point(170, 122);
            this.txtHDTenKhachHang.Name = "txtHDTenKhachHang";
            this.txtHDTenKhachHang.ReadOnly = true;
            this.txtHDTenKhachHang.Size = new System.Drawing.Size(300, 25);
            this.txtHDTenKhachHang.TabIndex = 24;
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.AllowUserToAddRows = false;
            this.dgvHoaDon.AllowUserToDeleteRows = false;
            this.dgvHoaDon.AllowUserToResizeRows = false;
            styleAlt.BackColor = System.Drawing.Color.FromArgb(244, 247, 252);
            this.dgvHoaDon.AlternatingRowsDefaultCellStyle = styleAlt;
            this.dgvHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoaDon.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHoaDon.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvHoaDon.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            styleHeader.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            styleHeader.BackColor = System.Drawing.Color.FromArgb(30, 64, 124);
            styleHeader.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            styleHeader.ForeColor = System.Drawing.Color.White;
            styleHeader.SelectionBackColor = System.Drawing.Color.FromArgb(30, 64, 124);
            styleHeader.SelectionForeColor = System.Drawing.Color.White;
            styleHeader.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoaDon.ColumnHeadersDefaultCellStyle = styleHeader;
            this.dgvHoaDon.ColumnHeadersHeight = 34;
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sanpham,
            this.soluong,
            this.dongia,
            this.giamgia,
            this.thanhtien});
            styleCell.BackColor = System.Drawing.Color.White;
            styleCell.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            styleCell.ForeColor = System.Drawing.Color.FromArgb(40, 40, 40);
            styleCell.SelectionBackColor = System.Drawing.Color.FromArgb(189, 215, 238);
            styleCell.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvHoaDon.DefaultCellStyle = styleCell;
            this.dgvHoaDon.EnableHeadersVisualStyles = false;
            this.dgvHoaDon.GridColor = System.Drawing.Color.FromArgb(221, 227, 236);
            this.dgvHoaDon.Location = new System.Drawing.Point(40, 172);
            this.dgvHoaDon.MultiSelect = false;
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.ReadOnly = true;
            this.dgvHoaDon.RowHeadersVisible = false;
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.RowTemplate.Height = 28;
            this.dgvHoaDon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoaDon.Size = new System.Drawing.Size(770, 196);
            this.dgvHoaDon.TabIndex = 28;
            // 
            // sanpham
            // 
            this.sanpham.DataPropertyName = "SanPham";
            this.sanpham.FillWeight = 220F;
            this.sanpham.HeaderText = "Sản phẩm";
            this.sanpham.MinimumWidth = 6;
            this.sanpham.Name = "sanpham";
            // 
            // soluong
            // 
            styleGiua.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.soluong.DefaultCellStyle = styleGiua;
            this.soluong.DataPropertyName = "SoLuong";
            this.soluong.FillWeight = 70F;
            this.soluong.HeaderText = "Số Lượng";
            this.soluong.MinimumWidth = 6;
            this.soluong.Name = "soluong";
            // 
            // dongia
            // 
            stylePhai1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.dongia.DefaultCellStyle = stylePhai1;
            this.dongia.DataPropertyName = "DonGia";
            this.dongia.FillWeight = 100F;
            this.dongia.HeaderText = "Đơn giá";
            this.dongia.MinimumWidth = 6;
            this.dongia.Name = "dongia";
            // 
            // giamgia
            // 
            stylePhai2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.giamgia.DefaultCellStyle = stylePhai2;
            this.giamgia.DataPropertyName = "GiamGia";
            this.giamgia.FillWeight = 90F;
            this.giamgia.HeaderText = "Giảm giá";
            this.giamgia.MinimumWidth = 6;
            this.giamgia.Name = "giamgia";
            // 
            // thanhtien
            // 
            stylePhai3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            stylePhai3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            stylePhai3.ForeColor = System.Drawing.Color.FromArgb(30, 64, 124);
            this.thanhtien.DefaultCellStyle = stylePhai3;
            this.thanhtien.DataPropertyName = "ThanhTien";
            this.thanhtien.FillWeight = 110F;
            this.thanhtien.HeaderText = "Thành tiền";
            this.thanhtien.MinimumWidth = 6;
            this.thanhtien.Name = "thanhtien";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(30, 64, 124);
            this.label11.Location = new System.Drawing.Point(40, 392);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 21);
            this.label11.TabIndex = 20;
            this.label11.Text = "Tổng thanh toán:";
            // 
            // txtHDTongThanhToan
            // 
            this.txtHDTongThanhToan.BackColor = System.Drawing.Color.White;
            this.txtHDTongThanhToan.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHDTongThanhToan.ForeColor = System.Drawing.Color.FromArgb(192, 57, 43);
            this.txtHDTongThanhToan.Location = new System.Drawing.Point(210, 386);
            this.txtHDTongThanhToan.Name = "txtHDTongThanhToan";
            this.txtHDTongThanhToan.ReadOnly = true;
            this.txtHDTongThanhToan.Size = new System.Drawing.Size(260, 32);
            this.txtHDTongThanhToan.TabIndex = 26;
            this.txtHDTongThanhToan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCamOn
            // 
            this.lblCamOn.AutoSize = true;
            this.lblCamOn.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCamOn.ForeColor = System.Drawing.Color.Gray;
            this.lblCamOn.Location = new System.Drawing.Point(330, 428);
            this.lblCamOn.Name = "lblCamOn";
            this.lblCamOn.Size = new System.Drawing.Size(190, 19);
            this.lblCamOn.TabIndex = 31;
            this.lblCamOn.Text = "Cảm ơn quý khách!";
            // 
            // pnlHoaDon
            // 
            this.pnlHoaDon.BackColor = System.Drawing.Color.White;
            this.pnlHoaDon.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHoaDon.Controls.Add(this.label7);
            this.pnlHoaDon.Controls.Add(this.lblDuongKe);
            this.pnlHoaDon.Controls.Add(this.label8);
            this.pnlHoaDon.Controls.Add(this.txtHDMaPhieu);
            this.pnlHoaDon.Controls.Add(this.label10);
            this.pnlHoaDon.Controls.Add(this.dtpHDNgay);
            this.pnlHoaDon.Controls.Add(this.label9);
            this.pnlHoaDon.Controls.Add(this.txtHDTenKhachHang);
            this.pnlHoaDon.Controls.Add(this.dgvHoaDon);
            this.pnlHoaDon.Controls.Add(this.label11);
            this.pnlHoaDon.Controls.Add(this.txtHDTongThanhToan);
            this.pnlHoaDon.Controls.Add(this.lblCamOn);
            this.pnlHoaDon.Location = new System.Drawing.Point(617, 66);
            this.pnlHoaDon.Name = "pnlHoaDon";
            this.pnlHoaDon.Size = new System.Drawing.Size(850, 460);
            this.pnlHoaDon.TabIndex = 29;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(240, 243, 248);
            this.ClientSize = new System.Drawing.Size(1482, 542);
            this.Controls.Add(this.pnlHoaDon);
            this.Controls.Add(this.pnlThongTin);
            this.Controls.Add(this.pnlTieuDe);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form2";
            this.Text = "Thanh toán";
            this.pnlTieuDe.ResumeLayout(false);
            this.pnlTieuDe.PerformLayout();
            this.pnlThongTin.ResumeLayout(false);
            this.pnlThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.pnlHoaDon.ResumeLayout(false);
            this.pnlHoaDon.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTieuDe;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label lblPhuDe;
        private System.Windows.Forms.Panel pnlThongTin;
        private System.Windows.Forms.Label lblDuongKe;
        private System.Windows.Forms.Label lblCamOn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPhieu;
        private System.Windows.Forms.TextBox txtKhachHang;
        private System.Windows.Forms.TextBox txtKhachDua;
        private System.Windows.Forms.TextBox txtTienThua;
        private System.Windows.Forms.ComboBox cboPhuongThuc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCanThanhToan;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.CheckBox chkDaNhanDu;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtHDMaPhieu;
        private System.Windows.Forms.TextBox txtHDTenKhachHang;
        private System.Windows.Forms.TextBox txtHDTongThanhToan;
        private System.Windows.Forms.DateTimePicker dtpHDNgay;
        private System.Windows.Forms.DataGridView dgvHoaDon;
        private System.Windows.Forms.DataGridViewTextBoxColumn sanpham;
        private System.Windows.Forms.DataGridViewTextBoxColumn soluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn dongia;
        private System.Windows.Forms.DataGridViewTextBoxColumn giamgia;
        private System.Windows.Forms.DataGridViewTextBoxColumn thanhtien;
        private System.Windows.Forms.Panel pnlHoaDon;
    }
}