namespace QUANLYCUAHANGDIENTHOAI
{
    partial class FormDangNhap
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
            pnlLeft = new Panel();
            lblBrand = new Label();
            pnlRight = new Panel();
            btnThoat = new Button();
            btnDangNhap = new Button();
            lblError = new Label();
            txtMatKhau = new TextBox();
            txtTenDangNhap = new TextBox();
            lblSubTitle = new Label();
            lblTitle = new Label();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.FromArgb(0, 122, 204);
            pnlLeft.Controls.Add(lblBrand);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Margin = new Padding(4, 5, 4, 5);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(467, 692);
            pnlLeft.TabIndex = 0;
            // 
            // lblBrand
            // 
            lblBrand.AutoSize = true;
            lblBrand.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblBrand.ForeColor = Color.White;
            lblBrand.Location = new Point(53, 277);
            lblBrand.Margin = new Padding(4, 0, 4, 0);
            lblBrand.Name = "lblBrand";
            lblBrand.Size = new Size(317, 82);
            lblBrand.TabIndex = 0;
            lblBrand.Text = "HỆ THỐNG\r\nQUẢN LÝ CỬA HÀNG";
            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.White;
            pnlRight.Controls.Add(btnThoat);
            pnlRight.Controls.Add(btnDangNhap);
            pnlRight.Controls.Add(lblError);
            pnlRight.Controls.Add(txtMatKhau);
            pnlRight.Controls.Add(txtTenDangNhap);
            pnlRight.Controls.Add(lblSubTitle);
            pnlRight.Controls.Add(lblTitle);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(467, 0);
            pnlRight.Margin = new Padding(4, 5, 4, 5);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(600, 692);
            pnlRight.TabIndex = 1;
            // 
            // btnThoat
            // 
            btnThoat.Cursor = Cursors.Hand;
            btnThoat.FlatAppearance.BorderSize = 0;
            btnThoat.FlatStyle = FlatStyle.Flat;
            btnThoat.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnThoat.ForeColor = Color.Gray;
            btnThoat.Location = new Point(547, 15);
            btnThoat.Margin = new Padding(4, 5, 4, 5);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(40, 46);
            btnThoat.TabIndex = 6;
            btnThoat.Text = "X";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.FromArgb(0, 122, 204);
            btnDangNhap.Cursor = Cursors.Hand;
            btnDangNhap.FlatAppearance.BorderSize = 0;
            btnDangNhap.FlatStyle = FlatStyle.Flat;
            btnDangNhap.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnDangNhap.ForeColor = Color.White;
            btnDangNhap.Location = new Point(73, 462);
            btnDangNhap.Margin = new Padding(4, 5, 4, 5);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(400, 69);
            btnDangNhap.TabIndex = 5;
            btnDangNhap.Text = "ĐĂNG NHẬP";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // lblError
            // 
            lblError.AutoSize = true;
            lblError.Font = new Font("Segoe UI", 9F);
            lblError.ForeColor = Color.Red;
            lblError.Location = new Point(73, 415);
            lblError.Margin = new Padding(4, 0, 4, 0);
            lblError.Name = "lblError";
            lblError.Size = new Size(0, 20);
            lblError.TabIndex = 4;
            lblError.Visible = false;
            // 
            // txtMatKhau
            // 
            txtMatKhau.BorderStyle = BorderStyle.FixedSingle;
            txtMatKhau.Font = new Font("Segoe UI", 12F);
            txtMatKhau.Location = new Point(73, 354);
            txtMatKhau.Margin = new Padding(4, 5, 4, 5);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.PlaceholderText = "Mật khẩu";
            txtMatKhau.Size = new Size(399, 34);
            txtMatKhau.TabIndex = 3;
            txtMatKhau.UseSystemPasswordChar = true;
            // 
            // txtTenDangNhap
            // 
            txtTenDangNhap.BorderStyle = BorderStyle.FixedSingle;
            txtTenDangNhap.Font = new Font("Segoe UI", 12F);
            txtTenDangNhap.Location = new Point(73, 262);
            txtTenDangNhap.Margin = new Padding(4, 5, 4, 5);
            txtTenDangNhap.Name = "txtTenDangNhap";
            txtTenDangNhap.PlaceholderText = "Tên đăng nhập";
            txtTenDangNhap.Size = new Size(399, 34);
            txtTenDangNhap.TabIndex = 2;
            // 
            // lblSubTitle
            // 
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new Font("Segoe UI", 10F);
            lblSubTitle.ForeColor = Color.Gray;
            lblSubTitle.Location = new Point(73, 162);
            lblSubTitle.Margin = new Padding(4, 0, 4, 0);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Size = new Size(270, 23);
            lblSubTitle.TabIndex = 1;
            lblSubTitle.Text = "Vui lòng nhập thông tin tài khoản";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 122, 204);
            lblTitle.Location = new Point(67, 92);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(246, 50);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "ĐĂNG NHẬP";
            // 
            // FormDangNhap
            // 
            AcceptButton = btnDangNhap;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1067, 692);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormDangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng Nhập Hệ Thống";
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.TextBox txtTenDangNhap;
        private System.Windows.Forms.TextBox txtMatKhau;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.Button btnDangNhap;
        private System.Windows.Forms.Button btnThoat;
    }
}