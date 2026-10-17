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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).BeginInit();
            this.pnlHoaDon.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Phiếu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 262);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Phương thức:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Khách đưa: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Khách hàng: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 346);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Tiền thừa:";
            // 
            // txtPhieu
            // 
            this.txtPhieu.Location = new System.Drawing.Point(135, 82);
            this.txtPhieu.Name = "txtPhieu";
            this.txtPhieu.ReadOnly = true;
            this.txtPhieu.Size = new System.Drawing.Size(100, 22);
            this.txtPhieu.TabIndex = 5;
            // 
            // txtKhachHang
            // 
            this.txtKhachHang.Location = new System.Drawing.Point(135, 114);
            this.txtKhachHang.Name = "txtKhachHang";
            this.txtKhachHang.ReadOnly = true;
            this.txtKhachHang.Size = new System.Drawing.Size(100, 22);
            this.txtKhachHang.TabIndex = 6;
            // 
            // txtKhachDua
            // 
            this.txtKhachDua.Location = new System.Drawing.Point(135, 297);
            this.txtKhachDua.Name = "txtKhachDua";
            this.txtKhachDua.Size = new System.Drawing.Size(121, 22);
            this.txtKhachDua.TabIndex = 7;
            this.txtKhachDua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTienThua
            // 
            this.txtTienThua.Location = new System.Drawing.Point(135, 340);
            this.txtTienThua.Name = "txtTienThua";
            this.txtTienThua.ReadOnly = true;
            this.txtTienThua.Size = new System.Drawing.Size(121, 22);
            this.txtTienThua.TabIndex = 8;
            this.txtTienThua.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cboPhuongThuc
            // 
            this.cboPhuongThuc.FormattingEnabled = true;
            this.cboPhuongThuc.Items.AddRange(new object[] {
            "Tiền mặt",
            "Chuyển khoản"});
            this.cboPhuongThuc.Location = new System.Drawing.Point(135, 259);
            this.cboPhuongThuc.Name = "cboPhuongThuc";
            this.cboPhuongThuc.Size = new System.Drawing.Size(133, 24);
            this.cboPhuongThuc.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(130, 158);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 29);
            this.label6.TabIndex = 10;
            this.label6.Text = "Cần thanh toán:";
            // 
            // txtCanThanhToan
            // 
            this.txtCanThanhToan.Location = new System.Drawing.Point(140, 201);
            this.txtCanThanhToan.Name = "txtCanThanhToan";
            this.txtCanThanhToan.ReadOnly = true;
            this.txtCanThanhToan.Size = new System.Drawing.Size(116, 22);
            this.txtCanThanhToan.TabIndex = 11;
            this.txtCanThanhToan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(30, 399);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(82, 23);
            this.btnXacNhan.TabIndex = 12;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(253, 395);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.TabIndex = 13;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // btnIn
            // 
            this.btnIn.Enabled = false;
            this.btnIn.Location = new System.Drawing.Point(140, 395);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 23);
            this.btnIn.TabIndex = 14;
            this.btnIn.Text = "In";
            this.btnIn.UseVisualStyleBackColor = true;
            // 
            // chkDaNhanDu
            // 
            this.chkDaNhanDu.AutoSize = true;
            this.chkDaNhanDu.Location = new System.Drawing.Point(298, 262);
            this.chkDaNhanDu.Name = "chkDaNhanDu";
            this.chkDaNhanDu.Size = new System.Drawing.Size(206, 20);
            this.chkDaNhanDu.TabIndex = 15;
            this.chkDaNhanDu.Text = "Đã nhận đủ tiền chuyển khoản";
            this.chkDaNhanDu.UseVisualStyleBackColor = true;
            this.chkDaNhanDu.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(99, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(254, 42);
            this.label7.TabIndex = 16;
            this.label7.Text = "Hóa đơn hàng";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(46, 89);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "Mã phiếu:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(46, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 16);
            this.label9.TabIndex = 18;
            this.label9.Text = "Tên khách hàng:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(283, 89);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "Ngày:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(46, 349);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 16);
            this.label11.TabIndex = 20;
            this.label11.Text = "Tổng thanh toán:";
            // 
            // txtHDMaPhieu
            // 
            this.txtHDMaPhieu.Location = new System.Drawing.Point(158, 86);
            this.txtHDMaPhieu.Name = "txtHDMaPhieu";
            this.txtHDMaPhieu.Size = new System.Drawing.Size(95, 22);
            this.txtHDMaPhieu.TabIndex = 22;
            this.txtHDMaPhieu.TextChanged += new System.EventHandler(this.txtMaPhieu_TextChanged);
            // 
            // txtHDTenKhachHang
            // 
            this.txtHDTenKhachHang.Location = new System.Drawing.Point(158, 129);
            this.txtHDTenKhachHang.Name = "txtHDTenKhachHang";
            this.txtHDTenKhachHang.Size = new System.Drawing.Size(95, 22);
            this.txtHDTenKhachHang.TabIndex = 24;
            // 
            // txtHDTongThanhToan
            // 
            this.txtHDTongThanhToan.Location = new System.Drawing.Point(184, 343);
            this.txtHDTongThanhToan.Name = "txtHDTongThanhToan";
            this.txtHDTongThanhToan.Size = new System.Drawing.Size(95, 22);
            this.txtHDTongThanhToan.TabIndex = 26;
            // 
            // dtpHDNgay
            // 
            this.dtpHDNgay.Location = new System.Drawing.Point(355, 89);
            this.dtpHDNgay.Name = "dtpHDNgay";
            this.dtpHDNgay.Size = new System.Drawing.Size(229, 22);
            this.dtpHDNgay.TabIndex = 27;
            // 
            // dgvHoaDon
            // 
            this.dgvHoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHoaDon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sanpham,
            this.soluong,
            this.dongia,
            this.giamgia,
            this.thanhtien});
            this.dgvHoaDon.Location = new System.Drawing.Point(51, 175);
            this.dgvHoaDon.Name = "dgvHoaDon";
            this.dgvHoaDon.RowHeadersWidth = 51;
            this.dgvHoaDon.RowTemplate.Height = 24;
            this.dgvHoaDon.Size = new System.Drawing.Size(677, 129);
            this.dgvHoaDon.TabIndex = 28;
            // 
            // sanpham
            // 
            this.sanpham.DataPropertyName = "SanPham";
            this.sanpham.HeaderText = "Sản phẩm";
            this.sanpham.MinimumWidth = 6;
            this.sanpham.Name = "sanpham";
            this.sanpham.Width = 125;
            // 
            // soluong
            // 
            this.soluong.DataPropertyName = "SoLuong";
            this.soluong.HeaderText = "Số Lượng";
            this.soluong.MinimumWidth = 6;
            this.soluong.Name = "soluong";
            this.soluong.Width = 125;
            // 
            // dongia
            // 
            this.dongia.DataPropertyName = "DonGia";
            this.dongia.HeaderText = "Đơn giá";
            this.dongia.MinimumWidth = 6;
            this.dongia.Name = "dongia";
            this.dongia.Width = 125;
            // 
            // giamgia
            // 
            this.giamgia.DataPropertyName = "GiamGia";
            this.giamgia.HeaderText = "Giảm giá";
            this.giamgia.MinimumWidth = 6;
            this.giamgia.Name = "giamgia";
            this.giamgia.Width = 125;
            // 
            // thanhtien
            // 
            this.thanhtien.DataPropertyName = "ThanhTien";
            this.thanhtien.HeaderText = "Thành tiền";
            this.thanhtien.MinimumWidth = 6;
            this.thanhtien.Name = "thanhtien";
            this.thanhtien.Width = 125;
            // 
            // pnlHoaDon
            // 
            this.pnlHoaDon.Controls.Add(this.label7);
            this.pnlHoaDon.Controls.Add(this.dgvHoaDon);
            this.pnlHoaDon.Controls.Add(this.label8);
            this.pnlHoaDon.Controls.Add(this.dtpHDNgay);
            this.pnlHoaDon.Controls.Add(this.label9);
            this.pnlHoaDon.Controls.Add(this.txtHDTongThanhToan);
            this.pnlHoaDon.Controls.Add(this.label10);
            this.pnlHoaDon.Controls.Add(this.txtHDTenKhachHang);
            this.pnlHoaDon.Controls.Add(this.label11);
            this.pnlHoaDon.Controls.Add(this.txtHDMaPhieu);
            this.pnlHoaDon.Location = new System.Drawing.Point(617, 114);
            this.pnlHoaDon.Name = "pnlHoaDon";
            this.pnlHoaDon.Size = new System.Drawing.Size(784, 380);
            this.pnlHoaDon.TabIndex = 29;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1482, 542);
            this.Controls.Add(this.pnlHoaDon);
            this.Controls.Add(this.chkDaNhanDu);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.txtCanThanhToan);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboPhuongThuc);
            this.Controls.Add(this.txtTienThua);
            this.Controls.Add(this.txtKhachDua);
            this.Controls.Add(this.txtKhachHang);
            this.Controls.Add(this.txtPhieu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Thanh toán";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoaDon)).EndInit();
            this.pnlHoaDon.ResumeLayout(false);
            this.pnlHoaDon.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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