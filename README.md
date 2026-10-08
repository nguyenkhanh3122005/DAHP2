# ĐỒ ÁN HỌC PHẦN 2: XÂY DỰNG WEBSITE CỬA HÀNG KINH DOANH XE MÁY YAMAHA
**Đề tài số: 04** - Khoa Công nghệ Thông tin - Trường ĐH Công nghiệp Việt-Hung  
**Giảng viên hướng dẫn**: Thầy/Cô Nguyễn Hoàng Hà  

---

## 1. TỔNG QUAN & ĐÁP ỨNG TIÊU CHÍ ĐÁNH GIÁ (HƯỚNG TỚI ĐIỂM GIỎI)

| Yêu cầu đề tài | Chức năng trong hệ thống | Trạng thái |
| :--- | :--- | :---: |
| **1.a - Dreamweaver / Photoshop** | Toàn bộ hình ảnh sản phẩm, slider trang chủ và banner quảng cáo khuyến mãi được thiết kế chuẩn kích thước, tỷ lệ và nhận diện thương hiệu Yamaha Motor. | ✅ Hoàn thành |
| **1.b - CSS, Javascript, jQuery** | Giao diện Responsive hiện đại (Bootstrap 5, CSS3, jQuery), menu dropdown, sticky header, carousel chuyển động mượt mà. | ✅ Hoàn thành |
| **1.c - CSDL trên SQL Server** | Cơ sở dữ liệu `YamahaStoreDB` trên **Microsoft SQL Server 2022** gồm 7 bảng (`DanhMuc`, `XeMay`, `QuangCao`, `TinTuc`, `DangKyLaiThu`, `ThongKe`, `NguoiDung`). | ✅ Hoàn thành |
| **1.d - Lập trình C# ASP.NET** | Nền tảng **C# ASP.NET Core MVC** (.NET 9) kết nối Entity Framework Core. | ✅ Hoàn thành |
| **2.a - Quản lý thông tin & Tìm kiếm** | Thanh tìm kiếm đa năng theo tên xe, lọc phân khúc xe, lọc theo mức giá (Dưới 30tr, 30-50tr, trên 50tr) và phân khối. | ✅ Hoàn thành |
| **2.b - Tổ chức Menu đơn (Ngang, Dọc) & Thống kê** | **Menu ngang**: Trang chủ, Giới thiệu, Toàn bộ dòng xe, Bảng giá xe 2025, Tin tức, Đăng ký lái thử, Liên hệ.<br>**Menu dọc (Sidebar)**: Danh mục dòng xe (Xe tay ga, Xe số, Xe thể thao côn tay, Xe điện).<br>**Thống kê**: Hiển thị số người online thực tế và tổng lượt truy cập. | ✅ Hoàn thành |
| **2.c - Sản phẩm bán chạy (Mức Khá)** | Khu vực nổi bật trang chủ gắn badge **"BÁN CHẠY"** (Exciter 155 VVA, Grande Hybrid, NVX 155, Sirius FI, Janus 125). | ✅ Hoàn thành |
| **2.d - Hệ thống quảng cáo đi kèm (Mức Giỏi)** | Hệ thống banner quảng cáo (Trả góp 0%, Tặng mũ bảo hiểm chính hãng Yamaha, Tri ân trúng vàng, Đổi cũ lấy mới) hiển thị ở cột Sidebar và giữa trang; kèm phân hệ quản lý trong Admin. | ✅ Hoàn thành |

---

## 2. CẤU TRÚC THƯ MỤC DỰ ÁN

```
quick-chandrasekhar/
├── database/
│   └── YamahaStoreDB.sql         # Script tạo Database & Seed Data xe Yamaha trên SQL Server
├── docs/
│   ├── KeHoachLamViec_3Tuan.md   # Lịch trình làm việc 3 tuần (gửi GVHD)
│   └── DeCuongBaoCao_DoAn.md     # Đề cương Báo cáo chi tiết theo mẫu Khoa CNTT
├── YamahaStoreWeb/               # Source code chính ASP.NET Core MVC (C#)
│   ├── Controllers/              # Home, XeMay, DangKy, TinTuc, Admin Controllers
│   ├── Models/                   # Entity Models & DbContext
│   ├── ViewModels/               # HomeViewModel, XeMayFilterViewModel
│   ├── Views/                    # Toàn bộ giao diện Razor Views
│   └── wwwroot/                  # CSS, JS, Thư viện và Hình ảnh sản phẩm / banner
└── README.md
```

---

## 3. HƯỚNG DẪN CÀI ĐẶT & CHẠY DỰ ÁN

### Bước 1: Khởi tạo Cơ sở dữ liệu SQL Server
Mở terminal và chạy lệnh:
```bash
sqlcmd -S localhost -E -i database\YamahaStoreDB.sql
```

### Bước 2: Chạy ứng dụng Website
Di chuyển vào thư mục `YamahaStoreWeb` và khởi chạy:
```bash
cd YamahaStoreWeb
dotnet run --urls "http://localhost:5000"
```

### Bước 3: Truy cập hệ thống
- **Giao diện Người dùng (Client)**: [http://localhost:5000](http://localhost:5000)
- **Hệ thống Quản trị (Admin CMS)**: [http://localhost:5000/Admin](http://localhost:5000/Admin)
  - **Tài khoản**: `admin`
  - **Mật khẩu**: `admin123`
