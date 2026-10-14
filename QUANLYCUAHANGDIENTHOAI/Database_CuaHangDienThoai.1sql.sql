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
USE QuanLyCuaHangDienThoai;
GO

-- 1. (Mục 16) Thêm ràng buộc UNIQUE cho Số chứng từ trong bảng PhieuNhap
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'UQ_PhieuNhap_SoChungTu')
BEGIN
    ALTER TABLE PhieuNhap ADD CONSTRAINT UQ_PhieuNhap_SoChungTu UNIQUE (SoChungTu);
END
GO

-- 2. (Mục 18) Stored Procedure Thống kê TOP N hàng bán chạy theo Tháng/Năm
CREATE OR ALTER PROCEDURE sp_ThongKeHangBanChay
    @Thang INT,
    @Nam INT,
    @TopN INT = 5
AS
BEGIN
    SELECT TOP (@TopN)
        sp.MaSP,
        sp.TenSP,
        SUM(ct.SoLuong) AS TongSoLuongBan,
        SUM(ct.ThanhTien) AS TongDoanhThu
    FROM ChiTietPhieuXuat ct
    INNER JOIN PhieuXuat px ON ct.MaPX = px.MaPX
    INNER JOIN SanPham sp ON ct.MaSP = sp.MaSP
    WHERE px.TrangThai = N'Hoàn tất'
      AND (@Thang = 0 OR MONTH(px.NgayXuat) = @Thang)
      AND (@Nam = 0 OR YEAR(px.NgayXuat) = @Nam)
    GROUP BY sp.MaSP, sp.TenSP
    ORDER BY TongSoLuongBan DESC, TongDoanhThu DESC;
END
GO

-- 3. (Mục 17) Stored Procedure Hoàn tất Phiếu Nhập (Dùng Transaction)
CREATE OR ALTER PROCEDURE sp_HoanTatPhieuNhap
    @MaPN VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;
    BEGIN TRY
        -- Kiểm tra phiếu nhập có tồn tại và đang ở trạng thái Nháp không
        IF NOT EXISTS (SELECT 1 FROM PhieuNhap WHERE MaPN = @MaPN AND TrangThai = N'Nháp')
        BEGIN
            RAISERROR(N'Phiếu nhập không tồn tại hoặc đã được hoàn tất trước đó!', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- Kiểm tra phiếu nhập đã có dòng chi tiết chưa
        IF NOT EXISTS (SELECT 1 FROM ChiTietPhieuNhap WHERE MaPN = @MaPN)
        BEGIN
            RAISERROR(N'Phiếu nhập chưa có mặt hàng nào!', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- 1. Chỉ cộng số lượng tồn kho cho những dòng hàng "Đạt yêu cầu"
        UPDATE sp
        SET sp.SoLuongTon = sp.SoLuongTon + ct.SoLuongNhap
        FROM SanPham sp
        INNER JOIN ChiTietPhieuNhap ct ON sp.MaSP = ct.MaSP
        WHERE ct.MaPN = @MaPN AND ct.KetQuaKiemTra = N'Đạt yêu cầu';

        -- 2. Ghi nhận lịch sử vào bảng GiaoDichKho cho các mặt hàng đạt yêu cầu
        INSERT INTO GiaoDichKho (MaSP, NgayGiaoDich, LoaiGiaoDich, SoLuongThayDoi, SoTonSauGiaoDich, MaChungTu)
        SELECT 
            ct.MaSP, 
            GETDATE(), 
            N'Nhập kho', 
            ct.SoLuongNhap, 
            sp.SoLuongTon, 
            @MaPN
        FROM ChiTietPhieuNhap ct
        INNER JOIN SanPham sp ON ct.MaSP = sp.MaSP
        WHERE ct.MaPN = @MaPN AND ct.KetQuaKiemTra = N'Đạt yêu cầu';

        -- 3. Cập nhật trạng thái IMEI của phiếu nhập này:
        -- Hàng đạt -> "Chưa bán" (trong kho); Hàng lỗi -> "Chờ trả"
        UPDATE tb
        SET tb.TrangThai = CASE 
                                WHEN ct.KetQuaKiemTra = N'Đạt yêu cầu' THEN N'Chưa bán'
                                ELSE N'Chờ trả'
                           END
        FROM ThietBiIMEI tb
        INNER JOIN ChiTietPhieuNhap ct ON tb.MaPN = ct.MaPN AND tb.MaSP = ct.MaSP
        WHERE tb.MaPN = @MaPN;

        -- 4. Cập nhật tổng tiền và đổi trạng thái Phiếu Nhập sang "Hoàn tất"
        UPDATE PhieuNhap
        SET TongTienNhap = (SELECT ISNULL(SUM(ThanhTien), 0) FROM ChiTietPhieuNhap WHERE MaPN = @MaPN),
            TrangThai = N'Hoàn tất'
        WHERE MaPN = @MaPN;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END
GO
USE QuanLyCuaHangDienThoai;
GO

-- =============================================
-- THÊM DỮ LIỆU BÁN HÀNG TRONG THÁNG 9/2026 ĐỂ LÀM GIÀU BIỂU ĐỒ THỐNG KÊ
-- =============================================

-- Hóa đơn PX002: Khách KH02 mua 2 chiếc Samsung S24 Ultra
INSERT INTO PhieuXuat (MaPX, MaKH, MaNV, NgayXuat, PhuongThucThanhToan, TongTien, TongGiamGia, ThanhToan, TrangThai)
VALUES ('PX002', 'KH02', 'NV02', '2026-09-12 14:30:00', N'Chuyển khoản', 55000000, 0, 55000000, N'Hoàn tất');

INSERT INTO ChiTietPhieuXuat (MaPX, MaSP, SoLuong, DonGia, ThueSuat, GiamGia, ThanhTien)
VALUES ('PX002', 'SP02', 2, 27500000, 10, 0, 55000000);

-- Hóa đơn PX003: Khách KH03 mua 1 chiếc iPhone 15 Pro Max + 5 Củ sạc nhanh
INSERT INTO PhieuXuat (MaPX, MaKH, MaNV, NgayXuat, PhuongThucThanhToan, TongTien, TongGiamGia, ThanhToan, TrangThai)
VALUES ('PX003', 'KH03', 'NV02', '2026-09-15 09:15:00', N'Tiền mặt', 31250000, 250000, 31000000, N'Hoàn tất');

INSERT INTO ChiTietPhieuXuat (MaPX, MaSP, SoLuong, DonGia, ThueSuat, GiamGia, ThanhTien)
VALUES ('PX003', 'SP01', 1, 29000000, 10, 0, 29000000);

INSERT INTO ChiTietPhieuXuat (MaPX, MaSP, SoLuong, DonGia, ThueSuat, GiamGia, ThanhTien)
VALUES ('PX003', 'SP03', 5, 450000, 10, 250000, 2000000);

-- Hóa đơn PX004: Khách KH01 mua thêm 3 Củ sạc nhanh 20W
INSERT INTO PhieuXuat (MaPX, MaKH, MaNV, NgayXuat, PhuongThucThanhToan, TongTien, TongGiamGia, ThanhToan, TrangThai)
VALUES ('PX004', 'KH01', 'NV02', '2026-09-20 16:45:00', N'Chuyển khoản', 1350000, 0, 1350000, N'Hoàn tất');

INSERT INTO ChiTietPhieuXuat (MaPX, MaSP, SoLuong, DonGia, ThueSuat, GiamGia, ThanhTien)
VALUES ('PX004', 'SP03', 3, 450000, 10, 0, 1350000);

-- Hóa đơn PX005: Khách KH02 mua thêm 1 chiếc Samsung S24 Ultra
INSERT INTO PhieuXuat (MaPX, MaKH, MaNV, NgayXuat, PhuongThucThanhToan, TongTien, TongGiamGia, ThanhToan, TrangThai)
VALUES ('PX005', 'KH02', 'NV02', '2026-09-28 10:00:00', N'Tiền mặt', 27500000, 0, 27500000, N'Hoàn tất');

INSERT INTO ChiTietPhieuXuat (MaPX, MaSP, SoLuong, DonGia, ThueSuat, GiamGia, ThanhTien)
VALUES ('PX005', 'SP02', 1, 27500000, 10, 0, 27500000);
GO