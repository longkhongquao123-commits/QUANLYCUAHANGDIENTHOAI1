-- 1. Tạo cơ sở dữ liệu
CREATE DATABASE QuanLyCuaHangDienThoai;
GO
USE  QuanLyCuaHangDienThoai;
GO

-- =============================================
-- PHẦN 1: QUẢN LÝ NHÂN SỰ & PHÂN QUYỀN (Nguyễn Thành Long, Vũ Ngọc Đức)
-- =============================================

-- Bảng Nhân Viên
CREATE TABLE NhanVien (
    MaNV VARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE,
    DiaChi NVARCHAR(255),
    SoDienThoai VARCHAR(15),
    BoPhan NVARCHAR(50),
    VaiTro NVARCHAR(50), -- Gồm: Quản lý, Nhân viên bán hàng, Nhân viên kho/kỹ thuật
    TrangThai NVARCHAR(50) DEFAULT N'Đang làm việc' -- Đang làm việc, Nghỉ việc
);

-- Bảng Tài Khoản
CREATE TABLE TaiKhoan (
    TenDangNhap VARCHAR(50) PRIMARY KEY,
    MatKhauHash VARCHAR(255) NOT NULL,
    MaNV VARCHAR(20) NOT NULL,
    SoLanDangNhapSai INT DEFAULT 0,
    TrangThai NVARCHAR(50) DEFAULT N'Hoạt động', -- Hoạt động, Tạm khóa
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

-- =============================================
-- PHẦN 2: QUẢN LÝ KHÁCH HÀNG & DANH MỤC (Kiều Văn Đại, Nguyễn Ngọc Long)
-- =============================================

-- Bảng Khách Hàng
CREATE TABLE KhachHang (
    MaKH VARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(15) NOT NULL UNIQUE,
    Email VARCHAR(100),
    DiaChi NVARCHAR(255),
    TrangThai NVARCHAR(50) DEFAULT N'Hoạt động'
);

-- Bảng Danh Mục Sản Phẩm
CREATE TABLE DanhMuc (
    MaDanhMuc VARCHAR(20) PRIMARY KEY,
    TenDanhMuc NVARCHAR(100) NOT NULL,
    MoTa NVARCHAR(MAX)
);

-- =============================================
-- PHẦN 3: QUẢN LÝ SẢN PHẨM & TỒN KHO (Kiều Văn Đại, Chu Xuân Đạt)
-- =============================================

-- Bảng Sản Phẩm / Hàng Hóa
CREATE TABLE SanPham (
    MaSP VARCHAR(20) PRIMARY KEY,
    TenSP NVARCHAR(150) NOT NULL,
    MaDanhMuc VARCHAR(20) NOT NULL,
    ThongTinBaoHanh NVARCHAR(255), -- Ví dụ: 12 tháng
    MoTa NVARCHAR(MAX),
    SoLuongTon INT DEFAULT 0,
    GiaBanHienTai DECIMAL(18,0) DEFAULT 0,
    TrangThai NVARCHAR(50) DEFAULT N'Đang kinh doanh', -- Đang kinh doanh, Ngừng kinh doanh
    FOREIGN KEY (MaDanhMuc) REFERENCES DanhMuc(MaDanhMuc)
);

-- Bảng Thiết bị / IMEI (Quản lý chi tiết từng máy) - Nguyễn Đức Phong
CREATE TABLE ThietBiIMEI (
    IMEI VARCHAR(50) PRIMARY KEY,
    MaSP VARCHAR(20) NOT NULL,
    MauSac NVARCHAR(50),
    DungLuong VARCHAR(50),
    NgayBaoHanhDen DATE NULL,
    TrangThai NVARCHAR(50) DEFAULT N'Chưa bán', -- Chưa bán, Đã bán, Chờ bảo hành, Đã bảo hành
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

-- Lịch sử thay đổi giá bán
CREATE TABLE LichSuGia (
    MaLichSuGia INT IDENTITY(1,1) PRIMARY KEY,
    MaSP VARCHAR(20) NOT NULL,
    GiaBan DECIMAL(18,0) NOT NULL,
    TuNgay DATETIME NOT NULL,
    DenNgay DATETIME NULL,
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

-- =============================================
-- PHẦN 4: QUẢN LÝ NHẬP HÀNG & NHÀ CUNG CẤP (Nguyễn Ngọc Long, Vũ Ngọc Đức)
-- =============================================

-- Bảng Nhà Cung Cấp
CREATE TABLE NhaCungCap (
    MaNCC VARCHAR(20) PRIMARY KEY,
    TenNCC NVARCHAR(150) NOT NULL,
    DiaChi NVARCHAR(255),
    SoDienThoai VARCHAR(15),
    Email VARCHAR(100),
    TrangThai NVARCHAR(50) DEFAULT N'Đang hợp tác'
);

-- Bảng Phiếu Nhập
CREATE TABLE PhieuNhap (
    MaPN VARCHAR(20) PRIMARY KEY,
    MaNCC VARCHAR(20) NOT NULL,
    MaNV VARCHAR(20) NOT NULL,
    NgayNhap DATETIME DEFAULT GETDATE(),
    SoChungTu VARCHAR(50),
    TongTienNhap DECIMAL(18,0) DEFAULT 0,
    TrangThai NVARCHAR(50) DEFAULT N'Nháp', -- Nháp, Hoàn tất, Hủy
    FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

-- Bảng Chi Tiết Phiếu Nhập
CREATE TABLE ChiTietPhieuNhap (
    MaPN VARCHAR(20) NOT NULL,
    MaSP VARCHAR(20) NOT NULL,
    SoLuongNhap INT NOT NULL,
    DonGiaNhap DECIMAL(18,0) NOT NULL,
    ThanhTien DECIMAL(18,0) NOT NULL,
    KetQuaKiemTra NVARCHAR(255),
    GhiChu NVARCHAR(255),
    PRIMARY KEY (MaPN, MaSP),
    FOREIGN KEY (MaPN) REFERENCES PhieuNhap(MaPN),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

-- (Thiết bị IMEI sẽ được liên kết ngầm với lô hàng nhập, khi làm thực tế có thể thêm cột MaPN vào bảng ThietBiIMEI để dễ truy vết).
ALTER TABLE ThietBiIMEI ADD MaPN VARCHAR(20) NULL;
ALTER TABLE ThietBiIMEI ADD CONSTRAINT FK_ThietBi_PhieuNhap FOREIGN KEY (MaPN) REFERENCES PhieuNhap(MaPN);

-- =============================================
-- PHẦN 5: QUẢN LÝ XUẤT HÀNG / BÁN HÀNG (Nguyễn Đức Phong)
-- =============================================

-- Bảng Phiếu Xuất (Hóa đơn)
CREATE TABLE PhieuXuat (
    MaPX VARCHAR(20) PRIMARY KEY,
    MaKH VARCHAR(20) NOT NULL,
    MaNV VARCHAR(20) NOT NULL,
    NgayXuat DATETIME DEFAULT GETDATE(),
    PhuongThucThanhToan NVARCHAR(50), -- Tiền mặt, Chuyển khoản
    TongTien DECIMAL(18,0) DEFAULT 0,
    TongGiamGia DECIMAL(18,0) DEFAULT 0,
    ThanhToan DECIMAL(18,0) DEFAULT 0,
    TrangThai NVARCHAR(50) DEFAULT N'Nháp', -- Nháp, Hoàn tất
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

-- Bảng Chi Tiết Phiếu Xuất
CREATE TABLE ChiTietPhieuXuat (
    MaPX VARCHAR(20) NOT NULL,
    MaSP VARCHAR(20) NOT NULL,
    SoLuong INT NOT NULL,
    DonGia DECIMAL(18,0) NOT NULL,
    ThueSuat DECIMAL(5,2) DEFAULT 0,
    GiamGia DECIMAL(18,0) DEFAULT 0,
    ThanhTien DECIMAL(18,0) NOT NULL,
    PRIMARY KEY (MaPX, MaSP),
    FOREIGN KEY (MaPX) REFERENCES PhieuXuat(MaPX),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

-- =============================================
-- PHẦN 6: QUẢN LÝ KIỂM KÊ (Chu Xuân Đạt)
-- =============================================

-- Bảng Phiếu Điều Chỉnh Tồn
CREATE TABLE PhieuDieuChinhTon (
    MaPhieuDC VARCHAR(20) PRIMARY KEY,
    NgayDieuChinh DATETIME DEFAULT GETDATE(),
    MaNVLap VARCHAR(20) NOT NULL,
    MaNVDuyet VARCHAR(20) NULL,
    LyDo NVARCHAR(MAX),
    TrangThaiDuyet NVARCHAR(50) DEFAULT N'Chờ duyệt', -- Chờ duyệt, Đã duyệt, Hủy
    FOREIGN KEY (MaNVLap) REFERENCES NhanVien(MaNV),
    FOREIGN KEY (MaNVDuyet) REFERENCES NhanVien(MaNV)
);

-- Bảng Chi Tiết Điều Chỉnh Tồn
CREATE TABLE ChiTietDieuChinh (
    MaPhieuDC VARCHAR(20) NOT NULL,
    MaSP VARCHAR(20) NOT NULL,
    SoTonHeThong INT NOT NULL,
    SoTonThucTe INT NOT NULL,
    ChenhLech AS (SoTonThucTe - SoTonHeThong),
    PRIMARY KEY (MaPhieuDC, MaSP),
    FOREIGN KEY (MaPhieuDC) REFERENCES PhieuDieuChinhTon(MaPhieuDC),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);
GO
USE QuanLyCuaHangDienThoai;
GO

-- =============================================
-- 1. THÊM DỮ LIỆU BẢNG NHÂN VIÊN
-- =============================================
INSERT INTO NhanVien (MaNV, HoTen, NgaySinh, DiaChi, SoDienThoai, BoPhan, VaiTro, TrangThai)
VALUES 
('NV01', N'Nguyễn Đức Huy', '1990-05-15', N'Hà Nội', '0987654321', N'Quản lý', N'Quản lý', N'Đang làm việc'),
('NV02', N'Nguyễn Hoàng Việt', '1995-08-20', N'Hà Nội', '0912345678', N'Kinh doanh', N'Nhân viên bán hàng', N'Đang làm việc'),
('NV03', N'Nguyễn Văn Hùng', '1998-11-10', N'Hà Nội', '0909888999', N'Kho', N'Nhân viên kho/kỹ thuật', N'Đang làm việc');

-- =============================================
-- 2. THÊM DỮ LIỆU BẢNG TÀI KHOẢN 
-- (Lưu ý: Mật khẩu hash ở đây là chuỗi demo, khi code C# cần hash thật bằng BCrypt/MD5)
-- =============================================
INSERT INTO TaiKhoan (TenDangNhap, MatKhauHash, MaNV, SoLanDangNhapSai, TrangThai)
VALUES 
('admin', '123456_hash', 'NV01', 0, N'Hoạt động'),
('banhang1', '123456_hash', 'NV02', 0, N'Hoạt động'),
('khokythuat', '123456_hash', 'NV03', 0, N'Hoạt động');

-- =============================================
-- 3. THÊM DỮ LIỆU BẢNG KHÁCH HÀNG
-- =============================================
INSERT INTO KhachHang (MaKH, HoTen, SoDienThoai, Email, DiaChi, TrangThai)
VALUES 
('KH01', N'Trần Thị Lan', '0966777888', 'lan.tran@email.com', N'Cầu Giấy, Hà Nội', N'Hoạt động'),
('KH02', N'Lê Văn Đạt', '0977111222', 'dat.le@email.com', N'Đống Đa, Hà Nội', N'Hoạt động'),
('KH03', N'Phạm Băng Băng', '0933444555', 'bang.pham@email.com', N'Thanh Xuân, Hà Nội', N'Hoạt động');

-- =============================================
-- 4. THÊM DỮ LIỆU BẢNG DANH MỤC
-- =============================================
INSERT INTO DanhMuc (MaDanhMuc, TenDanhMuc, MoTa)
VALUES 
('DM01', N'Điện thoại Apple', N'Các dòng iPhone chính hãng'),
('DM02', N'Điện thoại Samsung', N'Các dòng Galaxy S, A, Z'),
('DM03', N'Phụ kiện', N'Sạc, cáp, tai nghe, ốp lưng');

-- =============================================
-- 5. THÊM DỮ LIỆU BẢNG SẢN PHẨM
-- =============================================
INSERT INTO SanPham (MaSP, TenSP, MaDanhMuc, ThongTinBaoHanh, MoTa, SoLuongTon, GiaBanHienTai, TrangThai)
VALUES 
('SP01', N'iPhone 15 Pro Max 256GB', 'DM01', N'12 tháng', N'Màu Titan tự nhiên', 10, 29000000, N'Đang kinh doanh'),
('SP02', N'Samsung Galaxy S24 Ultra', 'DM02', N'12 tháng', N'Màu Đen Titanium', 5, 27500000, N'Đang kinh doanh'),
('SP03', N'Củ sạc nhanh Apple 20W', 'DM03', N'6 tháng', N'Sạc chính hãng cổng Type-C', 50, 450000, N'Đang kinh doanh');

-- =============================================
-- 6. THÊM DỮ LIỆU BẢNG NHÀ CUNG CẤP
-- =============================================
INSERT INTO NhaCungCap (MaNCC, TenNCC, DiaChi, SoDienThoai, Email, TrangThai)
VALUES 
('NCC01', N'Công ty TNHH Phân phối Apple VN', N'Quận 1, TP HCM', '18001111', 'contact@applevn.com', N'Đang hợp tác'),
('NCC02', N'Công ty CP Viễn thông Samsung', N'Bắc Ninh', '18002222', 'contact@samsungvn.com', N'Đang hợp tác');

-- =============================================
-- 7. THÊM DỮ LIỆU BẢNG PHIẾU NHẬP & CHI TIẾT
-- =============================================
INSERT INTO PhieuNhap (MaPN, MaNCC, MaNV, NgayNhap, SoChungTu, TongTienNhap, TrangThai)
VALUES 
('PN001', 'NCC01', 'NV03', '2026-09-01', 'HD_APP01', 270000000, N'Hoàn tất'),
('PN002', 'NCC02', 'NV03', '2026-09-05', 'HD_SAM01', 125000000, N'Hoàn tất');

INSERT INTO ChiTietPhieuNhap (MaPN, MaSP, SoLuongNhap, DonGiaNhap, ThanhTien, KetQuaKiemTra, GhiChu)
VALUES 
('PN001', 'SP01', 10, 27000000, 270000000, N'Đạt yêu cầu', N'Hàng nguyên seal'),
('PN002', 'SP02', 5, 25000000, 125000000, N'Đạt yêu cầu', N'Hàng nguyên seal');

-- =============================================
-- 8. THÊM DỮ LIỆU THIẾT BỊ / IMEI
-- =============================================
-- 2 Máy iPhone 15 Promax (1 máy đã bán, 1 máy còn trong kho)
INSERT INTO ThietBiIMEI (IMEI, MaSP, MauSac, DungLuong, NgayBaoHanhDen, TrangThai, MaPN)
VALUES 
('358123456780001', 'SP01', N'Titan Tự Nhiên', '256GB', '2027-09-10', N'Đã bán', 'PN001'),
('358123456780002', 'SP01', N'Titan Tự Nhiên', '256GB', NULL, N'Chưa bán', 'PN001');

-- =============================================
-- 9. THÊM DỮ LIỆU BẢNG PHIẾU XUẤT (HÓA ĐƠN) & CHI TIẾT
-- =============================================
-- Giả lập bán 1 chiếc iPhone 15 Pro Max cho khách KH01
INSERT INTO PhieuXuat (MaPX, MaKH, MaNV, NgayXuat, PhuongThucThanhToan, TongTien, TongGiamGia, ThanhToan, TrangThai)
VALUES 
('PX001', 'KH01', 'NV02', '2026-09-10', N'Chuyển khoản', 29000000, 500000, 28500000, N'Hoàn tất');

INSERT INTO ChiTietPhieuXuat (MaPX, MaSP, SoLuong, DonGia, ThueSuat, GiamGia, ThanhTien)
VALUES 
('PX001', 'SP01', 1, 29000000, 10, 500000, 28500000);

-- =============================================
-- 10. THÊM DỮ LIỆU PHIẾU ĐIỀU CHỈNH TỒN
-- =============================================
INSERT INTO PhieuDieuChinhTon (MaPhieuDC, NgayDieuChinh, MaNVLap, MaNVDuyet, LyDo, TrangThaiDuyet)
VALUES 
('PDC01', '2026-09-15', 'NV03', 'NV01', N'Hư hỏng 1 củ sạc do vô nước', N'Đã duyệt');

INSERT INTO ChiTietDieuChinh (MaPhieuDC, MaSP, SoTonHeThong, SoTonThucTe)
VALUES 
('PDC01', 'SP03', 51, 50);

GO
SELECT* FROM dbo.ChiTietDieuChinh


-- =============================================
-- 1. BỔ SUNG CHO PHẦN TÀI KHOẢN & NHÂN SỰ (Nguyễn Thành Long, Kiều Văn Đại)
-- =============================================

-- Thêm cột LanDangNhapCuoiCung vào bảng TaiKhoan
ALTER TABLE TaiKhoan
ADD LanDangNhapCuoiCung DATETIME NULL;
GO

-- Tạo bảng NhatKy (Ghi nhận lịch sử đăng nhập/đăng xuất và các thao tác)
CREATE TABLE NhatKyHeThong (
    MaNhatKy INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap VARCHAR(50) NOT NULL,
    ThoiGian DATETIME DEFAULT GETDATE(),
    LoaiHanhDong NVARCHAR(50) NOT NULL, -- Ví dụ: Đăng nhập, Đăng xuất, Thêm mới, Xóa...
    DoiTuong NVARCHAR(100),             -- Bảng hoặc chức năng bị tác động
    MoTaChiTiet NVARCHAR(MAX),          -- Lưu địa chỉ IP, hoặc chi tiết thao tác
    FOREIGN KEY (TenDangNhap) REFERENCES TaiKhoan(TenDangNhap)
);
GO

-- =============================================
-- 2. BỔ SUNG CHO PHẦN DANH MỤC & THƯƠNG HIỆU (Nguyễn Ngọc Long)
-- =============================================

-- Tạo bảng ThuongHieu
CREATE TABLE ThuongHieu (
    MaThuongHieu VARCHAR(20) PRIMARY KEY,
    TenThuongHieu NVARCHAR(100) NOT NULL UNIQUE,
    XuatXu NVARCHAR(100)
);
GO

-- Bổ sung cột MaThuongHieu vào bảng SanPham
ALTER TABLE SanPham
ADD MaThuongHieu VARCHAR(20) NULL;
GO
ALTER TABLE SanPham ADD CONSTRAINT FK_SanPham_ThuongHieu FOREIGN KEY (MaThuongHieu) REFERENCES ThuongHieu(MaThuongHieu);
GO

-- =============================================
-- 3. BỔ SUNG CHO PHẦN KHO & KIỂM KÊ (Vũ Ngọc Đức)
-- =============================================

-- Tạo bảng GiaoDichKho (Để truy vết và thống kê Nhập - Xuất - Tồn chính xác)
CREATE TABLE GiaoDichKho (
    MaGiaoDich INT IDENTITY(1,1) PRIMARY KEY,
    MaSP VARCHAR(20) NOT NULL,
    NgayGiaoDich DATETIME DEFAULT GETDATE(),
    LoaiGiaoDich NVARCHAR(50) NOT NULL, -- Nhập kho, Xuất bán, Điều chỉnh tồn
    SoLuongThayDoi INT NOT NULL,        -- Số âm (-) nếu xuất/giảm, số dương (+) nếu nhập/tăng
    SoTonSauGiaoDich INT NOT NULL,      -- Ghi lại số tồn cuối cùng sau khi giao dịch thành công
    MaChungTu VARCHAR(50),              -- Lưu mã phiếu nhập, phiếu xuất hoặc phiếu điều chỉnh
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);
GO

-- (Tùy chọn) Sửa lại tên cột trong bảng ThietBiIMEI cho đúng với biểu đồ thiết kế nếu cần:
-- Hiện tại bảng tên là ThietBiIMEI, nếu code C# Đức để là ThietBi thì có thể dùng lệnh đổi tên bảng.
-- EXEC sp_rename 'ThietBiIMEI', 'ThietBi';
-- Tuy nhiên tôi khuyên nên giữ nguyên ThietBiIMEI cho rõ nghĩa.

-- =============================================
-- 4. BỔ SUNG CHO PHẦN BÁN HÀNG & XUẤT HÀNG (Chu Xuân Đạt)
-- =============================================

-- Tạo bảng trung gian để lưu chi tiết từng IMEI khách mua trong 1 phiếu xuất
-- (Vì 1 dòng ChiTietPhieuXuat có thể bán 2, 3 cái điện thoại cùng loại, nên cần lưu IMEI riêng)
CREATE TABLE ChiTietXuat_IMEI (
    MaPX VARCHAR(20) NOT NULL,
    MaSP VARCHAR(20) NOT NULL,
    IMEI VARCHAR(50) NOT NULL,
    PRIMARY KEY (MaPX, MaSP, IMEI),
    FOREIGN KEY (MaPX, MaSP) REFERENCES ChiTietPhieuXuat(MaPX, MaSP),
    FOREIGN KEY (IMEI) REFERENCES ThietBiIMEI(IMEI)
);
GO


-- =============================================
-- 1. THÊM DỮ LIỆU BẢNG THƯƠNG HIỆU
-- =============================================
INSERT INTO ThuongHieu (MaThuongHieu, TenThuongHieu, XuatXu)
VALUES 
('TH01', 'Apple', N'Mỹ'),
('TH02', 'Samsung', N'Hàn Quốc'),
('TH03', 'Xiaomi', N'Trung Quốc');

-- Cập nhật lại cột MaThuongHieu cho các sản phẩm đã có trong bảng SanPham
UPDATE SanPham SET MaThuongHieu = 'TH01' WHERE MaSP = 'SP01' OR MaSP = 'SP03';
UPDATE SanPham SET MaThuongHieu = 'TH02' WHERE MaSP = 'SP02';

-- =============================================
-- 2. THÊM DỮ LIỆU BẢNG NHẬT KÝ HỆ THỐNG
-- (Giả lập Long - admin đã đăng nhập và thêm nhân viên mới)
-- =============================================
INSERT INTO NhatKyHeThong (TenDangNhap, ThoiGian, LoaiHanhDong, DoiTuong, MoTaChiTiet)
VALUES 
('admin', '2026-09-10 08:00:00', N'Đăng nhập', N'Hệ thống', N'Đăng nhập thành công từ IP: 192.168.1.5'),
('admin', '2026-09-10 08:30:00', N'Thêm mới', N'Nhân Viên', N'Thêm nhân viên NV04 - Lê Anh Tuấn'),
('banhang1', '2026-09-10 09:00:00', N'Đăng nhập', N'Hệ thống', N'Đăng nhập thành công từ IP: 192.168.1.10');

-- =============================================
-- 3. THÊM DỮ LIỆU BẢNG GIAO DỊCH KHO 
-- (Ghi vết lại các nghiệp vụ Nhập, Xuất, Điều chỉnh tồn đã làm ở kịch bản trước)
-- =============================================
-- Ghi vết: Nhập 10 chiếc iPhone 15 Pro Max (SP01) từ phiếu PN001
INSERT INTO GiaoDichKho (MaSP, NgayGiaoDich, LoaiGiaoDich, SoLuongThayDoi, SoTonSauGiaoDich, MaChungTu)
VALUES 
('SP01', '2026-09-01 10:00:00', N'Nhập kho', 10, 10, 'PN001'),
-- Ghi vết: Nhập 5 chiếc Samsung S24 Ultra (SP02) từ phiếu PN002
('SP02', '2026-09-05 14:00:00', N'Nhập kho', 5, 5, 'PN002'),
-- Ghi vết: Xuất bán 1 chiếc iPhone 15 Pro Max (SP01) từ phiếu PX001
('SP01', '2026-09-10 09:30:00', N'Xuất bán', -1, 9, 'PX001'),
-- Ghi vết: Nhập 50 củ sạc ban đầu (giả định)
('SP03', '2026-09-01 08:00:00', N'Nhập kho', 50, 50, 'PN_INIT'),
-- Ghi vết: Điều chỉnh giảm 1 củ sạc (SP03) do hư hỏng từ phiếu PDC01
('SP03', '2026-09-15 16:00:00', N'Điều chỉnh tồn', -1, 49, 'PDC01');

-- =============================================
-- 4. THÊM DỮ LIỆU BẢNG CHI TIẾT XUẤT_IMEI 
-- (Gắn chính xác số IMEI của chiếc iPhone đã bán cho hóa đơn PX001)
-- =============================================
INSERT INTO ChiTietXuat_IMEI (MaPX, MaSP, IMEI)
VALUES 
('PX001', 'SP01', '358123456780001');

GO
Select*from ThietBiIMEI 
Select*from SanPham
USE QuanLyCuaHangDienThoai;
GO

-- 2. Đổi dữ liệu cũ sang trạng thái mới
UPDATE ThietBiIMEI SET TrangThai = N'Trong kho' WHERE TrangThai = N'Chưa bán';
GO
-- 3. Đổi DEFAULT
DECLARE @df NVARCHAR(200);
SELECT @df = dc.name FROM sys.default_constraints dc
JOIN sys.columns c ON c.object_id = dc.parent_object_id AND c.column_id = dc.parent_column_id
WHERE dc.parent_object_id = OBJECT_ID('ThietBiIMEI') AND c.name = 'TrangThai';
IF @df IS NOT NULL EXEC('ALTER TABLE ThietBiIMEI DROP CONSTRAINT ' + @df);
ALTER TABLE ThietBiIMEI ADD CONSTRAINT DF_ThietBi_TrangThai DEFAULT N'Trong kho' FOR TrangThai;
GO
-- 4. Thêm CHECK trạng thái
ALTER TABLE ThietBiIMEI ADD CONSTRAINT CK_ThietBi_TrangThai
CHECK (TrangThai IN (N'Trong kho', N'Đã giữ', N'Đã bán', N'Lỗi'));
GO
--Kiểm tra 
SELECT IMEI, TrangThai FROM ThietBiIMEI;
-- Dòng 0001 là "Đã bán", dòng 0002 là "Trong kho"

-- Phải báo lỗi CHECK:
INSERT INTO ThietBiIMEI (IMEI, MaSP, TrangThai) VALUES ('358123456780099', 'SP01', N'Hỏng');
-- =====================================================================
-- 02_Kho.sql  -  Phần SQL của Vũ Ngọc Đức (UC-10, UC-11, UC-12)
-- Chạy SAU script chung của nhóm. Có thể chạy lại nhiều lần (có kiểm tra tồn tại).
-- =====================================================================
USE QuanLyCuaHangDienThoai;
GO
 Select*from SanPham
 Select*from GiaoDichKho 

-- =====================================================================
-- 0. SỬA DỮ LIỆU MẪU CHO KHỚP VỚI GiaoDichKho
-- =====================================================================
UPDATE SanPham SET SoLuongTon = 9  WHERE MaSP = 'SP01';   -- nhập 10, bán 1
UPDATE SanPham SET SoLuongTon = 49 WHERE MaSP = 'SP03';   -- nhập 50, điều chỉnh -1
 
-- Phiếu PDC01: tồn hệ thống thực tế lúc đó là 50, kiểm đếm được 49
UPDATE ChiTietDieuChinh SET SoTonHeThong = 50, SoTonThucTe = 49
WHERE MaPhieuDC = 'PDC01' AND MaSP = 'SP03';
GO
 
-- =====================================================================
-- UC-10: QUẢN LÝ THIẾT BỊ / IMEI
-- =====================================================================
 
-- 10.1 Trạng thái theo đề: Trong kho / Đã giữ / Đã bán / Lỗi
-- (a) Bỏ CHECK cũ nếu trước đó đã chạy bản nhiều trạng thái hơn
IF EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_ThietBi_TrangThai')
    ALTER TABLE ThietBiIMEI DROP CONSTRAINT CK_ThietBi_TrangThai;
GO
 
-- (b) Đổi giá trị cũ "Chưa bán" thành "Trong kho"
UPDATE ThietBiIMEI SET TrangThai = N'Trong kho' WHERE TrangThai = N'Chưa bán';
GO
 
-- (c) Đổi DEFAULT của cột TrangThai thành "Trong kho"
DECLARE @df NVARCHAR(200);
SELECT @df = dc.name
FROM sys.default_constraints dc
JOIN sys.columns c ON c.object_id = dc.parent_object_id AND c.column_id = dc.parent_column_id
WHERE dc.parent_object_id = OBJECT_ID('ThietBiIMEI') AND c.name = 'TrangThai';
IF @df IS NOT NULL EXEC('ALTER TABLE ThietBiIMEI DROP CONSTRAINT ' + @df);
ALTER TABLE ThietBiIMEI ADD CONSTRAINT DF_ThietBi_TrangThai DEFAULT N'Trong kho' FOR TrangThai;
GO
 
-- (d) CHECK mới: đúng 4 trạng thái. Nếu báo lỗi, chạy SELECT DISTINCT TrangThai FROM ThietBiIMEI
--     để tìm giá trị lạ (ví dụ 'Chờ bảo hành') rồi sửa trước khi chạy lại.
ALTER TABLE ThietBiIMEI ADD CONSTRAINT CK_ThietBi_TrangThai
CHECK (TrangThai IN (N'Trong kho', N'Đã giữ', N'Đã bán', N'Lỗi'));
GO
 
-- 10.2 CHECK định dạng IMEI: đúng 15 chữ số
IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_ThietBi_IMEI15')
    ALTER TABLE ThietBiIMEI ADD CONSTRAINT CK_ThietBi_IMEI15
    CHECK (LEN(IMEI) = 15 AND IMEI NOT LIKE '%[^0-9]%');
GO
 
-- 10.3 Trigger chặn xóa thiết bị đã nhập kho (có MaPN) hoặc đã bán (có trong ChiTietXuat_IMEI)
CREATE OR ALTER TRIGGER trg_ThietBi_ChanXoa
ON ThietBiIMEI
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1
               FROM deleted d
               WHERE d.MaPN IS NOT NULL
                  OR EXISTS (SELECT 1 FROM ChiTietXuat_IMEI x WHERE x.IMEI = d.IMEI))
    BEGIN
        RAISERROR(N'Không thể xóa: thiết bị đã nhập kho hoặc đã bán.', 16, 1);
        RETURN;
    END
 
    DELETE t FROM ThietBiIMEI t JOIN deleted d ON d.IMEI = t.IMEI;
END
GO
 
-- =====================================================================
-- UC-11: PHIẾU ĐIỀU CHỈNH TỒN (KIỂM KÊ)
-- =====================================================================
 
-- 11.0 Bảng TonKho (đề yêu cầu). SanPham.SoLuongTon vẫn giữ để phần của Long và Đạt không phải sửa;
--      trigger bên dưới tự đồng bộ TonKho mỗi khi SoLuongTon thay đổi.
IF OBJECT_ID('TonKho', 'U') IS NULL
    CREATE TABLE TonKho (
        MaSP        VARCHAR(20) NOT NULL CONSTRAINT PK_TonKho PRIMARY KEY
                    CONSTRAINT FK_TonKho_SanPham REFERENCES SanPham(MaSP),
        SoLuong     INT NOT NULL CONSTRAINT DF_TonKho_SoLuong DEFAULT 0,
        NgayCapNhat DATETIME NOT NULL CONSTRAINT DF_TonKho_Ngay DEFAULT GETDATE()
    );
GO
 
-- Nạp tồn hiện có từ SanPham (chỉ thêm sản phẩm chưa có dòng)
INSERT INTO TonKho (MaSP, SoLuong)
SELECT s.MaSP, ISNULL(s.SoLuongTon, 0)
FROM SanPham s
WHERE NOT EXISTS (SELECT 1 FROM TonKho k WHERE k.MaSP = s.MaSP);
GO
 
-- Trigger: SanPham.SoLuongTon đổi thì TonKho đổi theo (thêm sản phẩm mới cũng tự có dòng TonKho)
CREATE OR ALTER TRIGGER trg_SanPham_DongBoTonKho
ON SanPham
AFTER INSERT, UPDATE
AS
BEGIN
    SET NOCOUNT ON;
    IF UPDATE(SoLuongTon)
    BEGIN
        MERGE TonKho AS t
        USING (SELECT MaSP, ISNULL(SoLuongTon, 0) AS SoLuongTon FROM inserted) AS i
           ON t.MaSP = i.MaSP
        WHEN MATCHED AND t.SoLuong <> i.SoLuongTon THEN
            UPDATE SET t.SoLuong = i.SoLuongTon, t.NgayCapNhat = GETDATE()
        WHEN NOT MATCHED THEN
            INSERT (MaSP, SoLuong) VALUES (i.MaSP, i.SoLuongTon);
    END
END
GO
 
-- 11.1 CHECK trạng thái duyệt
IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_PDC_TrangThai')
    ALTER TABLE PhieuDieuChinhTon ADD CONSTRAINT CK_PDC_TrangThai
    CHECK (TrangThaiDuyet IN (N'Chờ duyệt', N'Đã duyệt', N'Hủy'));
GO
 
-- 11.2 CHECK loại giao dịch kho
IF NOT EXISTS (SELECT 1 FROM sys.check_constraints WHERE name = 'CK_GiaoDichKho_Loai')
    ALTER TABLE GiaoDichKho ADD CONSTRAINT CK_GiaoDichKho_Loai
    CHECK (LoaiGiaoDich IN (N'Nhập kho', N'Xuất bán', N'Điều chỉnh tồn'));
GO
 
-- 11.3 Index cho GiaoDichKho (báo cáo NXT lọc theo sản phẩm và ngày)
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'IX_GiaoDichKho_MaSP_Ngay')
    CREATE INDEX IX_GiaoDichKho_MaSP_Ngay
    ON GiaoDichKho (MaSP, NgayGiaoDich) INCLUDE (LoaiGiaoDich, SoLuongThayDoi, MaChungTu);
GO
 
-- 11.4 Duyệt phiếu: trong 1 transaction, cập nhật tồn + ghi lịch sử + đổi trạng thái
CREATE OR ALTER PROCEDURE sp_DuyetPhieuDieuChinh
    @MaPhieuDC VARCHAR(20),
    @MaNVDuyet VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
     BEGIN TRY
        BEGIN TRAN ;
 
        -- Chỉ Quản lý đang làm việc mới được duyệt
        IF NOT EXISTS (SELECT 1 FROM NhanVien
                       WHERE MaNV = @MaNVDuyet AND VaiTro = N'Quản lý' AND TrangThai = N'Đang làm việc')
            THROW 50002, N'Chỉ Quản lý mới được duyệt phiếu.', 1;
 
        -- Phiếu phải còn "Chờ duyệt" (khóa dòng để tránh 2 người duyệt cùng lúc)
        IF NOT EXISTS (SELECT 1 FROM PhieuDieuChinhTon WITH (UPDLOCK, HOLDLOCK)
                       WHERE MaPhieuDC = @MaPhieuDC AND TrangThaiDuyet = N'Chờ duyệt')
            THROW 50001, N'Phiếu không tồn tại hoặc đã được xử lý.', 1;
 
        -- Ghi lịch sử TRƯỚC khi đổi tồn (cần tồn hiện tại để tính số thay đổi)
        INSERT INTO GiaoDichKho (MaSP, LoaiGiaoDich, SoLuongThayDoi, SoTonSauGiaoDich, MaChungTu)
        SELECT c.MaSP, N'Điều chỉnh tồn', c.SoTonThucTe - k.SoLuong, c.SoTonThucTe, @MaPhieuDC
        FROM ChiTietDieuChinh c
        JOIN TonKho k ON k.MaSP = c.MaSP
        WHERE c.MaPhieuDC = @MaPhieuDC AND c.SoTonThucTe <> k.SoLuong;
 
        -- Cập nhật TonKho theo số thực tế
        UPDATE k SET k.SoLuong = c.SoTonThucTe, k.NgayCapNhat = GETDATE()
        FROM TonKho k
        JOIN ChiTietDieuChinh c ON c.MaSP = k.MaSP
        WHERE c.MaPhieuDC = @MaPhieuDC;
 
        -- Giữ SanPham.SoLuongTon đồng bộ (phần của Long, Đạt vẫn đọc cột này)
        UPDATE s SET s.SoLuongTon = c.SoTonThucTe
        FROM SanPham s
        JOIN ChiTietDieuChinh c ON c.MaSP = s.MaSP
        WHERE c.MaPhieuDC = @MaPhieuDC;
 
        -- Đổi trạng thái phiếu
        UPDATE PhieuDieuChinhTon
        SET TrangThaiDuyet = N'Đã duyệt', MaNVDuyet = @MaNVDuyet
        WHERE MaPhieuDC = @MaPhieuDC;
 
        COMMIT;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0 ROLLBACK;
        THROW;
    END CATCH
END
GO
 
-- 11.5 Từ chối phiếu (không đụng tới tồn kho)
CREATE OR ALTER PROCEDURE sp_TuChoiPhieuDieuChinh
    @MaPhieuDC VARCHAR(20),
    @MaNVDuyet VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
 
    IF NOT EXISTS (SELECT 1 FROM NhanVien
                   WHERE MaNV = @MaNVDuyet AND VaiTro = N'Quản lý' AND TrangThai = N'Đang làm việc')
        THROW 50002, N'Chỉ Quản lý mới được từ chối phiếu.', 1;
 
    UPDATE PhieuDieuChinhTon
    SET TrangThaiDuyet = N'Hủy', MaNVDuyet = @MaNVDuyet
    WHERE MaPhieuDC = @MaPhieuDC AND TrangThaiDuyet = N'Chờ duyệt';
 
    IF @@ROWCOUNT = 0
        THROW 50001, N'Phiếu không tồn tại hoặc đã được xử lý.', 1;
END
GO
 
-- =====================================================================
-- UC-12: THỐNG KÊ NHẬP - XUẤT - TỒN
-- =====================================================================
 
-- 12.1 Ngưỡng tồn tối thiểu để cảnh báo (nếu Ngọc Long đã thêm cột này thì bỏ qua đoạn này)
IF COL_LENGTH('SanPham', 'NguongTonToiThieu') IS NULL
    ALTER TABLE SanPham ADD NguongTonToiThieu INT NOT NULL
        CONSTRAINT DF_SanPham_NguongTon DEFAULT 5;
GO
 
-- 12.2 Báo cáo NXT theo khoảng ngày, có lọc danh mục (NULL = tất cả)
CREATE OR ALTER PROCEDURE sp_NhapXuatTon
    @TuNgay DATETIME,
    @DenNgay DATETIME,
    @MaDanhMuc VARCHAR(20) = NULL
AS
BEGIN
    SET NOCOUNT ON;
 
    WITH t AS (
        SELECT s.MaSP, s.TenSP, s.NguongTonToiThieu,
            ISNULL(SUM(CASE WHEN g.NgayGiaoDich < @TuNgay THEN g.SoLuongThayDoi END), 0) AS TonDau,
            ISNULL(SUM(CASE WHEN g.NgayGiaoDich BETWEEN @TuNgay AND @DenNgay
                             AND g.LoaiGiaoDich = N'Nhập kho' THEN g.SoLuongThayDoi END), 0) AS Nhap,
            ISNULL(-SUM(CASE WHEN g.NgayGiaoDich BETWEEN @TuNgay AND @DenNgay
                              AND g.LoaiGiaoDich = N'Xuất bán' THEN g.SoLuongThayDoi END), 0) AS Xuat,
            ISNULL(SUM(CASE WHEN g.NgayGiaoDich BETWEEN @TuNgay AND @DenNgay
                             AND g.LoaiGiaoDich = N'Điều chỉnh tồn' THEN g.SoLuongThayDoi END), 0) AS DieuChinh,
            ISNULL(SUM(CASE WHEN g.NgayGiaoDich <= @DenNgay THEN g.SoLuongThayDoi END), 0) AS TonCuoi
        FROM SanPham s
        LEFT JOIN GiaoDichKho g ON g.MaSP = s.MaSP
        WHERE (@MaDanhMuc IS NULL OR s.MaDanhMuc = @MaDanhMuc)
        GROUP BY s.MaSP, s.TenSP, s.NguongTonToiThieu
    )
    SELECT *,
           CASE WHEN TonCuoi < NguongTonToiThieu THEN N'Dưới ngưỡng' ELSE N'Đủ hàng' END AS CanhBao
    FROM t
    ORDER BY MaSP;
END
GO
 
-- 12.3 Xem chứng từ nguồn của một sản phẩm trong khoảng ngày (double-click trên báo cáo)
CREATE OR ALTER PROCEDURE sp_ChungTuNguon
    @MaSP VARCHAR(20),
    @TuNgay DATETIME,
    @DenNgay DATETIME
AS
BEGIN
    SET NOCOUNT ON;
    SELECT NgayGiaoDich, LoaiGiaoDich, SoLuongThayDoi, SoTonSauGiaoDich, MaChungTu
    FROM GiaoDichKho
    WHERE MaSP = @MaSP AND NgayGiaoDich BETWEEN @TuNgay AND @DenNgay
    ORDER BY NgayGiaoDich;
END
GO
 
-- 12.4 View cảnh báo: sản phẩm có tồn hiện tại dưới ngưỡng tối thiểu
CREATE OR ALTER VIEW vw_CanhBaoTonThap
AS
SELECT s.MaSP, s.TenSP, k.SoLuong AS TonHienTai, s.NguongTonToiThieu
FROM SanPham s
JOIN TonKho k ON k.MaSP = s.MaSP
WHERE k.SoLuong < s.NguongTonToiThieu;
GO
 
-- =====================================================================
-- KIỂM TRA SAU KHI CHẠY
-- =====================================================================
 
-- (a) Báo cáo NXT tháng 9/2026
EXEC sp_NhapXuatTon '2026-09-01', '2026-09-30 23:59:59';
 
-- (b) Tổng GiaoDichKho phải bằng TonKho và SanPham.SoLuongTon (cột Lech = 0 với cả 3 sản phẩm)
SELECT s.MaSP, s.SoLuongTon, k.SoLuong AS TonKho,
       ISNULL(SUM(g.SoLuongThayDoi), 0) AS TongGiaoDich,
       k.SoLuong - ISNULL(SUM(g.SoLuongThayDoi), 0) AS Lech
FROM SanPham s
JOIN TonKho k ON k.MaSP = s.MaSP
LEFT JOIN GiaoDichKho g ON g.MaSP = s.MaSP
GROUP BY s.MaSP, s.SoLuongTon, k.SoLuong;
 
-- (e) Cảnh báo tồn thấp (đặt ngưỡng cao để thử: 
UPDATE SanPham SET NguongTonToiThieu = 60 WHERE MaSP = 'SP03';
SELECT * FROM vw_CanhBaoTonThap;
 
-- (c) Thử trigger chặn xóa: phải báo lỗi vì IMEI đã nhập và đã bán
 DELETE FROM ThietBiIMEI WHERE IMEI = '358123456780001';
 
-- (d) Thử duyệt phiếu (bỏ comment, chạy từng khối):
 INSERT INTO PhieuDieuChinhTon (MaPhieuDC, MaNVLap, LyDo) VALUES ('PDC02', 'NV03', N'Kiểm kê cuối tháng');
 INSERT INTO ChiTietDieuChinh (MaPhieuDC, MaSP, SoTonHeThong, SoTonThucTe) VALUES ('PDC02', 'SP03', 49, 48);
 SELECT SoLuongTon FROM SanPham WHERE MaSP = 'SP03';          -- vẫn 49 (chưa duyệt)
 EXEC sp_DuyetPhieuDieuChinh 'PDC02', 'NV02';                  -- phải lỗi: NV02 không phải Quản lý
  EXEC sp_DuyetPhieuDieuChinh 'PDC02', 'NV01';                  -- thành công
 SELECT SoLuongTon FROM SanPham WHERE MaSP = 'SP03';          -- thành 48
  EXEC sp_DuyetPhieuDieuChinh 'PDC02', 'NV01';                  -- phải lỗi: phiếu đã xử lý
GO
SELECT name FROM sys.procedures WHERE name LIKE 'sp_%';