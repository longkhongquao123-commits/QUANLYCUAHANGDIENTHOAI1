namespace Quanlybanhang
{
    partial class ThongKeDoanhThu
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieu)).BeginInit();
            this.SuspendLayout();
            //
            // lblTuNgay
            //
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.Location = new System.Drawing.Point(20, 22);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(50, 17);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày";
            //
            // dtpTuNgay
            //
            this.dtpTuNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTuNgay.Location = new System.Drawing.Point(80, 18);
            this.dtpTuNgay.Name = "dtpTuNgay";
            this.dtpTuNgay.Size = new System.Drawing.Size(110, 22);
            this.dtpTuNgay.TabIndex = 1;
            //
            // lblDenNgay
            //
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.Location = new System.Drawing.Point(210, 22);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(58, 17);
            this.lblDenNgay.TabIndex = 2;
            this.lblDenNgay.Text = "Đến ngày";
            //
            // dtpDenNgay
            //
            this.dtpDenNgay.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDenNgay.Location = new System.Drawing.Point(280, 18);
            this.dtpDenNgay.Name = "dtpDenNgay";
            this.dtpDenNgay.Size = new System.Drawing.Size(110, 22);
            this.dtpDenNgay.TabIndex = 3;
            //
            // lblKieuXem
            //
            this.lblKieuXem.AutoSize = true;
            this.lblKieuXem.Location = new System.Drawing.Point(410, 22);
            this.lblKieuXem.Name = "lblKieuXem";
            this.lblKieuXem.Size = new System.Drawing.Size(55, 17);
            this.lblKieuXem.TabIndex = 4;
            this.lblKieuXem.Text = "Xem theo";
            //
            // cboKieuXem
            //
            this.cboKieuXem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKieuXem.FormattingEnabled = true;
            this.cboKieuXem.Location = new System.Drawing.Point(480, 18);
            this.cboKieuXem.Name = "cboKieuXem";
            this.cboKieuXem.Size = new System.Drawing.Size(150, 24);
            this.cboKieuXem.TabIndex = 5;
            //
            // btnXem
            //
            this.btnXem.Location = new System.Drawing.Point(650, 15);
            this.btnXem.Name = "btnXem";
            this.btnXem.Size = new System.Drawing.Size(100, 30);
            this.btnXem.TabIndex = 6;
            this.btnXem.Text = "Xem";
            this.btnXem.UseVisualStyleBackColor = true;
            //
            // btnXuat
            //
            this.btnXuat.Location = new System.Drawing.Point(765, 15);
            this.btnXuat.Name = "btnXuat";
            this.btnXuat.Size = new System.Drawing.Size(110, 30);
            this.btnXuat.TabIndex = 7;
            this.btnXuat.Text = "Xuất CSV";
            this.btnXuat.UseVisualStyleBackColor = true;
            //
            // dgvThongKe
            //
            this.dgvThongKe.AllowUserToAddRows = false;
            this.dgvThongKe.AllowUserToDeleteRows = false;
            this.dgvThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Location = new System.Drawing.Point(20, 60);
            this.dgvThongKe.MultiSelect = false;
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.ReadOnly = true;
            this.dgvThongKe.RowHeadersWidth = 51;
            this.dgvThongKe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongKe.Size = new System.Drawing.Size(900, 200);
            this.dgvThongKe.TabIndex = 8;
            //
            // lblPhieu
            //
            this.lblPhieu.AutoSize = true;
            this.lblPhieu.Location = new System.Drawing.Point(20, 275);
            this.lblPhieu.Name = "lblPhieu";
            this.lblPhieu.Size = new System.Drawing.Size(300, 17);
            this.lblPhieu.TabIndex = 9;
            this.lblPhieu.Text = "Phiếu nguồn của dòng đang chọn (bấm đúp 1 phiếu để xem chi tiết)";
            //
            // dgvPhieu
            //
            this.dgvPhieu.AllowUserToAddRows = false;
            this.dgvPhieu.AllowUserToDeleteRows = false;
            this.dgvPhieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieu.Location = new System.Drawing.Point(20, 300);
            this.dgvPhieu.MultiSelect = false;
            this.dgvPhieu.Name = "dgvPhieu";
            this.dgvPhieu.ReadOnly = true;
            this.dgvPhieu.RowHeadersWidth = 51;
            this.dgvPhieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieu.Size = new System.Drawing.Size(900, 190);
            this.dgvPhieu.TabIndex = 10;
            //
            // lblTong
            //
            this.lblTong.AutoSize = true;
            this.lblTong.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTong.Location = new System.Drawing.Point(20, 513);
            this.lblTong.Name = "lblTong";
            this.lblTong.Size = new System.Drawing.Size(121, 20);
            this.lblTong.TabIndex = 11;
            this.lblTong.Text = "Tổng doanh thu";
            //
            // txtTongDoanhThu
            //
            this.txtTongDoanhThu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.txtTongDoanhThu.Location = new System.Drawing.Point(160, 510);
            this.txtTongDoanhThu.Name = "txtTongDoanhThu";
            this.txtTongDoanhThu.ReadOnly = true;
            this.txtTongDoanhThu.Size = new System.Drawing.Size(220, 27);
            this.txtTongDoanhThu.TabIndex = 12;
            this.txtTongDoanhThu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            //
            // Form3
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 556);
            this.Controls.Add(this.txtTongDoanhThu);
            this.Controls.Add(this.lblTong);
            this.Controls.Add(this.dgvPhieu);
            this.Controls.Add(this.lblPhieu);
            this.Controls.Add(this.dgvThongKe);
            this.Controls.Add(this.btnXuat);
            this.Controls.Add(this.btnXem);
            this.Controls.Add(this.cboKieuXem);
            this.Controls.Add(this.lblKieuXem);
            this.Controls.Add(this.dtpDenNgay);
            this.Controls.Add(this.lblDenNgay);
            this.Controls.Add(this.dtpTuNgay);
            this.Controls.Add(this.lblTuNgay);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê doanh thu";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

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