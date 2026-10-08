-- ===================================================================
-- ĐỒ ÁN HỌC PHẦN 2: XÂY DỰNG WEBSITE CỬA HÀNG KINH DOANH XE MÁY YAMAHA
-- Đề tài số: 04 - Khoa Công nghệ Thông tin - Trường ĐH Công nghiệp Việt-Hung
-- Hệ quản trị CSDL: Microsoft SQL Server 2022
-- ===================================================================

USE master;
GO

IF EXISTS (SELECT name FROM sys.databases WHERE name = N'YamahaStoreDB')
BEGIN
    ALTER DATABASE YamahaStoreDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE YamahaStoreDB;
END
GO

CREATE DATABASE YamahaStoreDB;
GO

USE YamahaStoreDB;
GO

-- 1. BẢNG DANH MỤC DÒNG XE (Phục vụ Menu dọc - Mục 2.b)
CREATE TABLE DanhMuc (
    MaDanhMuc INT IDENTITY(1,1) PRIMARY KEY,
    TenDanhMuc NVARCHAR(100) NOT NULL,
    Slug VARCHAR(100) NOT NULL,
    MoTa NVARCHAR(500) NULL,
    Icon NVARCHAR(50) NULL,
    ThuTu INT DEFAULT 0,
    TrangThai BIT DEFAULT 1
);
GO

-- 2. BẢNG SẢN PHẨM XE MÁY (Phục vụ Mục 2.a & 2.c Sản phẩm bán chạy)
CREATE TABLE XeMay (
    MaXe INT IDENTITY(1,1) PRIMARY KEY,
    TenXe NVARCHAR(150) NOT NULL,
    Slug VARCHAR(150) NOT NULL,
    MaDanhMuc INT NOT NULL FOREIGN KEY REFERENCES DanhMuc(MaDanhMuc) ON DELETE CASCADE,
    GiaBan DECIMAL(18,0) NOT NULL,
    GiaKhuyenMai DECIMAL(18,0) NULL,
    PhanKhoi NVARCHAR(50) NOT NULL,
    MauSac NVARCHAR(200) NOT NULL,
    HinhAnh NVARCHAR(300) NOT NULL,
    ThongSoKT NVARCHAR(MAX) NULL,
    MoTa NVARCHAR(MAX) NULL,
    IsBanChay BIT DEFAULT 0,  -- Yêu cầu mục 2.c (Sản phẩm bán chạy - Đạt mức Khá)
    IsMoiVe BIT DEFAULT 0,
    SoLuongTon INT DEFAULT 10,
    LuotXem INT DEFAULT 0,
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

-- 3. BẢNG QUẢNG CÁO ĐI KÈM (Yêu cầu mục 2.d - Đạt mức Giỏi)
CREATE TABLE QuangCao (
    MaQC INT IDENTITY(1,1) PRIMARY KEY,
    TieuDe NVARCHAR(200) NOT NULL,
    HinhAnhBanner NVARCHAR(300) NOT NULL,
    LinkLienKet NVARCHAR(300) NULL,
    ViTri VARCHAR(50) NOT NULL, -- 'Sidebar', 'TopBanner', 'MidBanner', 'Popup'
    ThuTu INT DEFAULT 0,
    HienThi BIT DEFAULT 1
);
GO

-- 4. BẢNG TIN TỨC & KHUYẾN MÃI (Phục vụ trang thông tin Menu ngang - Mục 2.b)
CREATE TABLE TinTuc (
    MaTin INT IDENTITY(1,1) PRIMARY KEY,
    TieuDe NVARCHAR(250) NOT NULL,
    Slug VARCHAR(250) NOT NULL,
    HinhAnh NVARCHAR(300) NOT NULL,
    TomTat NVARCHAR(500) NOT NULL,
    NoiDung NVARCHAR(MAX) NOT NULL,
    NgayDang DATETIME DEFAULT GETDATE()
);
GO

-- 5. BẢNG ĐĂNG KÝ LÁI THỬ & TƯ VẤN MUA XE
CREATE TABLE DangKyLaiThu (
    MaDK INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    SoDienThoai VARCHAR(20) NOT NULL,
    Email VARCHAR(100) NULL,
    MaXe INT NULL FOREIGN KEY REFERENCES XeMay(MaXe) ON DELETE SET NULL,
    GhiChu NVARCHAR(500) NULL,
    NgayGui DATETIME DEFAULT GETDATE(),
    TrangThai NVARCHAR(50) DEFAULT N'Chờ xử lý' -- 'Chờ xử lý', 'Đã liên hệ', 'Hoàn tất'
);
GO

-- 6. BẢNG THỐNG KÊ TRUY CẬP (Yêu cầu mục 2.b)
CREATE TABLE ThongKe (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    TongLuotTruyCap INT DEFAULT 0,
    NgayCapNhat DATETIME DEFAULT GETDATE()
);
GO

-- 7. BẢNG NGƯỜI DÙNG QUẢN TRỊ (Admin CMS)
CREATE TABLE NguoiDung (
    MaND INT IDENTITY(1,1) PRIMARY KEY,
    TaiKhoan VARCHAR(50) UNIQUE NOT NULL,
    MatKhau VARCHAR(100) NOT NULL,
    HoTen NVARCHAR(100) NOT NULL,
    Email VARCHAR(100) NULL,
    VaiTro VARCHAR(20) DEFAULT 'Admin'
);
GO

-- ===================================================================
-- NẠP DỮ LIỆU BAN ĐẦU (SEED DATA CHUẨN THỰC TẾ YAMAHA MOTOR VIỆT NAM)
-- ===================================================================

-- Nạp Danh mục
INSERT INTO DanhMuc (TenDanhMuc, Slug, MoTa, Icon, ThuTu, TrangThai) VALUES
(N'Xe tay ga', 'xe-tay-ga', N'Dòng xe tay ga hiện đại, tiết kiệm xăng với động cơ Blue Core', 'bi-scooter', 1, 1),
(N'Xe số', 'xe-so', N'Dòng xe số bền bỉ, tiết kiệm nhiên liệu, phù hợp mọi nẻo đường', 'bi-bicycle', 2, 1),
(N'Xe thể thao - Côn tay', 'xe-the-thao-con-tay', N'Đậm chất thể thao, mạnh mẽ, dẫn đầu phân khúc Underbone & Naked', 'bi-speedometer2', 3, 1),
(N'Xe điện', 'xe-dien', N'Xe máy điện thông minh thế hệ mới thân thiện môi trường', 'bi-lightning-charge', 4, 1);
GO

-- Nạp Sản phẩm Xe Máy (Gồm các mẫu Hot có IsBanChay = 1 để đáp ứng mục 2.c)
INSERT INTO XeMay (TenXe, Slug, MaDanhMuc, GiaBan, GiaKhuyenMai, PhanKhoi, MauSac, HinhAnh, ThongSoKT, MoTa, IsBanChay, IsMoiVe, SoLuongTon, LuotXem) VALUES
(N'Yamaha Exciter 155 VVA - ABS', 'yamaha-exciter-155-vva-abs', 3, 52000000, 50500000, '155cc', N'Xanh GP, Đen Nhám, Đỏ Bạc', '/images/products/exciter-155.png', 
N'Động cơ: 4 thì, 4 van, SOHC, làm mát bằng dung dịch; Dung tích: 155cc; Công suất cực đại: 17.7 mã lực / 9,500 vòng/phút; Hệ thống phanh: Phanh đĩa ABS 2 piston; Bình xăng: 5.4 Lít; Hộp số: 6 cấp có trợ lực và chống trượt côn (A&S); Khóa thông minh: Smartkey.', 
N'Yamaha Exciter 155 VVA tiếp tục khẳng định vị thế "Ông vua đường phố" với hệ thống van biến thiên VVA vượt trội, phanh đĩa ABS chống bó cứng an toàn tối đa và thiết kế khí động học lấy cảm hứng từ siêu mô tô YZF-R1.', 1, 1, 15, 1280),

(N'Yamaha Grande Blue Core Hybrid', 'yamaha-grande-blue-core-hybrid', 1, 49500000, 48000000, '125cc', N'Trắng Ngọc Trai, Xanh Lam, Đỏ Mận', '/images/products/grande-hybrid.png',
N'Động cơ: Blue Core Hybrid 125cc, 4 thì, SOHC, làm mát bằng không khí; Công suất: 8.3 mã lực / 6,500 vòng/phút; Mức tiêu thụ nhiên liệu: 1.66 lít/100km (Top 1 tiết kiệm xăng); Cốp xe: 27 lít cực rộng; Cổng sạc điện thoại: Có kèm hộc để đồ; Khóa: Smartkey.',
N'Yamaha Grande Hybrid - Nữ hoàng xe tay ga tiết kiệm xăng số 1 Việt Nam. Trang bị hệ thống trợ lực điện Hybrid giúp xe tăng tốc êm ái, kết nối điện thoại Y-Connect thông minh và thiết kế phong cách thanh lịch châu Âu.', 1, 1, 20, 960),

(N'Yamaha NVX 155 VVA', 'yamaha-nvx-155-vva', 1, 55000000, 53500000, '155cc', N'Xám Đen, Xanh GP, Đen Vàng', '/images/products/nvx-155.png',
N'Động cơ: Blue Core 155cc VVA, làm mát dung dịch; Công suất: 15.4 mã lực; Phanh ABS bánh trước; Bình xăng: 5.5 Lít; Cốp: 25 Lít; Bánh xe lớn: 14 inch thể thao; Kết nối Y-Connect.',
N'Yamaha NVX 155 VVA là mẫu xe ga thể thao dành riêng cho phái mạnh, mang phong cách cơ bắp, động cơ 155cc mạnh mẽ vượt trội và tích hợp công nghệ kết nối điện thoại Y-Connect đỉnh cao.', 1, 0, 12, 840),

(N'Yamaha Sirius FI', 'yamaha-sirius-fi', 2, 21500000, 20800000, '115cc', N'Đỏ Đen, Xám Đen, Trắng Xanh', '/images/products/sirius-fi.png',
N'Động cơ: 4 thì, 2 van, SOHC, làm mát bằng không khí; Dung tích: 115cc; Phun xăng điện tử FI; Tiêu hao nhiên liệu: 1.57 lít/100km; Khối lượng: 98kg nhẹ nhàng linh hoạt; Phanh: Đĩa / Đùm.',
N'Yamaha Sirius FI là mẫu xe số quốc dân bền bỉ, tiết kiệm xăng kỷ lục, thiết kế gọn gàng, tăng tốc mượt mà và chi phí vận hành cực kỳ kinh tế cho mọi gia đình Việt.', 1, 0, 30, 1540),

(N'Yamaha Janus 125', 'yamaha-janus-125', 1, 29000000, 28200000, '125cc', N'Đỏ Đen, Xanh Ngọc, Bạc Đen', '/images/products/janus-125.png',
N'Động cơ: Blue Core 125cc làm mát bằng không khí; Trọng lượng: 99kg siêu nhẹ; Cốp xe rộng rãi chứa 2 mũ nửa đầu; Khóa thông minh Smartkey (bản Giới hạn); Tiêu hao nhiên liệu: 1.87 lít/100km.',
N'Yamaha Janus sở hữu thiết kế trẻ trung, năng động, hướng tới thế hệ Gen Z trẻ trung năng động. Xe vận hành nhẹ nhàng, động cơ Blue Core bền bỉ và nhiều tiện ích thông minh.', 1, 1, 18, 710),

(N'Yamaha Jupiter Finn', 'yamaha-jupiter-finn', 2, 27500000, 27000000, '115cc', N'Bạc Đen, Xanh Xám, Vàng Đen', '/images/products/jupiter-finn.png',
N'Động cơ: 115cc phun xăng điện tử FI; Hệ thống phanh kết hợp UBS (Unified Brake System) an toàn vượt trội; Hộc chứa đồ phía trước tiện lợi; Mức tiêu thụ nhiên liệu: 1.64 lít/100km.',
N'Yamaha Jupiter Finn - Mẫu xe số gia đình thông minh tiên phong trang bị phanh kết hợp UBS an toàn cho mọi lứa tuổi, kiểu dáng trang nhã và động cơ êm ái.', 0, 1, 10, 450),

(N'Yamaha YZF-R15 V4', 'yamaha-yzf-r15-v4', 3, 78000000, 76000000, '155cc', N'Xanh Racing Blue, Đen Nhám', '/images/products/r15-v4.png',
N'Động cơ: 155cc VVA làm mát bằng dung dịch; Công suất: 19.3 mã lực; Phuộc trước Upside Down thể thao; Hệ thống phanh ABS 2 kênh; Hệ thống sang số nhanh Quick Shifter; Bộ ly hợp trợ lực và chống trượt A&S.',
N'Yamaha YZF-R15 V4 kế thừa trọn vẹn ADN đường đua của siêu phẩm R1, trang bị phuộc hành trình ngược Upside Down và Quick Shifter cao cấp bậc nhất.', 0, 1, 5, 620),

(N'Yamaha MT-15', 'yamaha-mt-15', 3, 69000000, 68000000, '155cc', N'Xám Cyan, Đen Midnight', '/images/products/mt-15.png',
N'Động cơ: 155cc SOHC 4 van VVA; Công suất: 19 mã lực; Đèn pha LED đôi phong cách Samurai hầm hố; Phuộc USD thể thao; Bánh sau kích thước lớn 140/70-17 bám đường chắc chắn.',
N'Yamaha MT-15 biểu tượng Naked bike của bóng đêm ("The Dark Side of Japan"), tư thế ngồi thẳng thoải mái và khả năng bứt tốc phấn khích trên từng cung đường.', 0, 0, 6, 530),

(N'Yamaha NEO''S (Xe máy điện)', 'yamaha-neos-electric', 4, 49000000, 47500000, N'Điện', N'Trắng, Đen, Xanh Ngọc', '/images/products/neos-electric.png',
N'Động cơ điện YIPU thế hệ 2 không chổi than gắn trục bánh sau; Pin Lithium-ion có thể tháo rời tiện lợi; Quãng đường di chuyển: 72km/lần sạc (có thể lắp thêm pin thứ 2 lên 144km); Kết nối Y-Connect.',
N'Yamaha NEO''S là xe máy điện tiên phong tiêu chuẩn toàn cầu của Yamaha Motor Nhật Bản, vận hành êm ái không tiếng ồn, không phát thải và sạc điện thông minh tại nhà.', 0, 1, 8, 480);
GO

-- Nạp Hệ thống Quảng cáo đi kèm (Yêu cầu mục 2.d - Đạt mức Giỏi)
INSERT INTO QuangCao (TieuDe, HinhAnhBanner, LinkLienKet, ViTri, ThuTu, HienThi) VALUES
(N'Mua xe Yamaha - Trả góp lãi suất 0% chỉ từ 500k/tháng', '/images/ads/banner-tra-gop.png', '/DangKyLaiThu', 'Sidebar', 1, 1),
(N'Tặng ngay Mũ bảo hiểm chính hãng Yamaha & Voucher 1.000.000đ', '/images/ads/banner-tang-non.png', '/DangKyLaiThu', 'Sidebar', 2, 1),
(N'Lễ hội Tri ân Khách hàng - Cơ hội trúng xe Grande Hybrid & Vàng 9999', '/images/ads/banner-tri-an.png', '/TinTuc/ChiTiet/1', 'MidBanner', 3, 1),
(N'Đổi xe cũ lấy Exciter 155 VVA - Trợ giá thêm đến 4.000.000 VNĐ', '/images/ads/banner-doi-xe.png', '/XeMay/ChiTiet/yamaha-exciter-155-vva-abs', 'Sidebar', 4, 1);
GO

-- Nạp Tin tức & Khuyến mãi (Menu ngang)
INSERT INTO TinTuc (TieuDe, Slug, HinhAnh, TomTat, NoiDung, NgayDang) VALUES
(N'Yamaha Việt Nam giới thiệu Exciter 155 VVA phiên bản ABS cao cấp', 'yamaha-gioi-thieu-exciter-155-vva-abs', '/images/news/news-exciter.jpg',
N'Mẫu xe côn tay huyền thoại được nâng cấp toàn diện với hệ thống chống bó cứng phanh ABS, khẳng định vị thế dẫn đầu phân khúc.',
N'Ngày 15/01/2025, Yamaha Motor Việt Nam chính thức giới thiệu Exciter 155 VVA thế hệ mới trang bị hệ thống phanh ABS hai piston cùng bộ tem xe phong cách đường đua thể thao...', GETDATE() - 2),

(N'Ưu đãi tháng: Hỗ trợ 100% lệ phí trước bạ khi mua dòng xe Grande Hybrid', 'uu-dai-ho-tro-truoc-ba-grande-hybrid', '/images/news/news-grande.jpg',
N'Cơ hội sở hữu mẫu xe tay ga tiết kiệm xăng số 1 Việt Nam với gói quà tặng và ưu đãi hấp dẫn nhất năm.',
N'Nhằm tri ân khách hàng nhân dịp đầu năm, Yamaha Town triển khai chương trình hỗ trợ 100% lệ phí trước bạ hoặc tặng voucher tiền mặt giá trị cho khách hàng đặt mua xe Grande...', GETDATE() - 5),

(N'Quy trình bảo dưỡng xe máy định kỳ 6 bước chuẩn Nhật Bản tại Yamaha Town', 'quy-trinh-bao-duong-xe-may-chuan-nhat-ban', '/images/news/news-service.jpg',
N'Khám phá quy trình chăm sóc xe máy tiêu chuẩn từ đội ngũ kỹ thuật viên tay nghề cao và phụ tùng Yamaha chính hãng.',
N'Bảo dưỡng định kỳ là yếu tố sống còn giúp động cơ xe vận hành bền bỉ, tiết kiệm nhiên liệu và an toàn tối đa cho người lái...', GETDATE() - 10);
GO

-- Nạp Thống kê truy cập (Yêu cầu mục 2.b)
INSERT INTO ThongKe (TongLuotTruyCap, NgayCapNhat) VALUES (15840, GETDATE());
GO

-- Nạp Người dùng quản trị (Admin CMS)
INSERT INTO NguoiDung (TaiKhoan, MatKhau, HoTen, Email, VaiTro) VALUES 
('admin', 'admin123', N'Quản trị viên Yamaha Town', 'nguyenkhanh141225@gmail.com', 'Admin');
GO

PRINT N'===> ĐÃ TẠO DATABASE YamahaStoreDB VÀ NẠP DỮ LIỆU THÀNH CÔNG!';
GO
