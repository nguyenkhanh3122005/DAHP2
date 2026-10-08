# BÁO CÁO ĐỒ ÁN HỌC PHẦN 2

**ĐỀ TÀI SỐ 04: XÂY DỰNG WEBSITE CỬA HÀNG KINH DOANH XE MÁY YAMAHA**

* **Đơn vị đào tạo**: Trường Đại học Công nghiệp Việt-Hung
* **Khoa**: Công nghệ Thông tin - **Bộ môn**: Công nghệ Thông tin
* **Giảng viên hướng dẫn**: Thầy/Cô Nguyễn Hoàng Hà
* **Sinh viên thực hiện**: [Họ tên SV 1] - [Mã SV 1], [Họ tên SV 2] - [Mã SV 2]

---

## MỤC LỤC CHI TIẾT BÁO CÁO

### LỜI CẢM ƠN
### NHẬN XÉT CỦA GIẢNG VIÊN HƯỚNG DẪN
### DANH MỤC CÁC KÝ HIỆU, CHỮ VIẾT TẮT
### DANH MỤC BẢNG BIỂU VÀ HÌNH VẼ

---

### MỞ ĐẦU
1. **Lý do chọn đề tài**:
   - Sự phát triển của thương mại điện tử và nhu cầu tìm hiểu, so sánh thông số kỹ thuật, bảng giá và đặt lịch lái thử xe máy trực tuyến.
   - Thương hiệu xe máy Yamaha tại thị trường Việt Nam với các dòng xe đa dạng (Xe tay ga, xe số, xe côn tay thể thao, xe điện).
   - Nhu cầu xây dựng một website bán hàng chuyên nghiệp, thẩm mỹ và đáp ứng trải nghiệm khách hàng tối ưu.
2. **Mục tiêu của đề tài**:
   - Xây dựng website giới thiệu và kinh doanh xe máy Yamaha đầy đủ tính năng: menu điều hướng khoa học, tìm kiếm, lọc theo phân khúc, sản phẩm bán chạy, hệ thống banner quảng cáo và phân hệ quản trị.
3. **Phạm vi và đối tượng nghiên cứu**:
   - Khảo sát các showroom Yamaha Town và hệ thống website chính hãng của Yamaha Motor Việt Nam.
   - Công nghệ áp dụng: C# ASP.NET Core MVC, Microsoft SQL Server 2022, Bootstrap 5, JavaScript/jQuery, Adobe Photoshop.

---

### CHƯƠNG 1: KHẢO SÁT HIỆN TRẠNG VÀ PHÂN TÍCH YÊU CẦU
* **1.1. Khảo sát nghiệp vụ kinh doanh xe máy tại đại lý Yamaha**
  - 1.1.1. Quy trình quản lý sản phẩm và dòng xe.
  - 1.1.2. Quy trình quảng bá sản phẩm, chương trình khuyến mãi và sản phẩm bán chạy.
  - 1.1.3. Quy trình tiếp nhận thông tin khách hàng đăng ký lái thử / tư vấn mua xe.
* **1.2. Yêu cầu của đề tài theo phiếu giao việc**
  - 1.2.1. Yêu cầu lý thuyết (Dreamweaver, Photoshop, CSS, JS, SQL Server, C# ASP.NET).
  - 1.2.2. Yêu cầu sản phẩm (Menu ngang/dọc, tìm kiếm, thống kê truy cập, sản phẩm bán chạy, hệ thống quảng cáo).
* **1.3. Phân tích yêu cầu chức năng (Use Case)**
  - 1.3.1. Nhóm chức năng Khách hàng (Xem danh mục xe, tìm kiếm, xem chi tiết & thông số kỹ thuật, xem sản phẩm bán chạy, đăng ký lái thử).
  - 1.3.2. Nhóm chức năng Quản trị viên (Đăng nhập, quản lý sản phẩm xe máy, quản lý banner quảng cáo, duyệt yêu cầu lái thử, xem thống kê).
* **1.4. Yêu cầu phi chức năng**
  - Giao diện đẹp, nhận diện thương hiệu Yamaha (Xanh GP, Đỏ, Trắng, Đen), responsive hiển thị tốt trên máy tính và di động, bảo mật dữ liệu.

---

### CHƯƠNG 2: CƠ SỞ LÝ THUYẾT VÀ CÔNG NGHỆ ÁP DỤNG
* **2.1. Ngôn ngữ C# và nền tảng ASP.NET Core MVC**
  - Mô hình kiến trúc Model - View - Controller.
  - Ưu điểm về hiệu năng, tính module hóa và dễ bảo trì.
* **2.2. Hệ quản trị cơ sở dữ liệu Microsoft SQL Server 2022**
  - Khái quát về SQL Server và công cụ SQL Server Management Studio (SSMS).
  - Cơ chế toàn vẹn dữ liệu, khóa chính, khóa ngoại.
* **2.3. Entity Framework Core (ORM)**
  - Cơ chế ánh xạ đối tượng và thao tác truy vấn LINQ.
* **2.4. Công nghệ Frontend & Đồ họa**
  - HTML5, CSS3, JavaScript, thư viện jQuery.
  - Bootstrap 5 framework xây dựng giao diện responsive đa thiết bị.
  - Ứng dụng Adobe Photoshop trong thiết kế Logo, Banner quảng cáo và xử lý hình ảnh sản phẩm.

---

### CHƯƠNG 3: THIẾT KẾ HỆ THỐNG
* **3.1. Thiết kế kiến trúc tổng thể của website**
  - Mô hình tổ chức Menu ngang (Trang chủ, Giới thiệu, Bảng giá xe, Tin tức, Đăng ký lái thử, Liên hệ).
  - Mô hình tổ chức Menu dọc (Danh mục dòng xe: Xe tay ga, Xe số, Xe thể thao côn tay, Xe điện).
* **3.2. Thiết kế Cơ sở dữ liệu**
  - 3.2.1. Lược đồ quan hệ thực thể (ERD).
  - 3.2.2. Chi tiết cấu trúc các bảng:
    - Bảng `DanhMuc` (Danh mục dòng xe).
    - Bảng `XeMay` (Thông tin xe, giá, màu sắc, thông số kỹ thuật, cờ `IsBanChay`).
    - Bảng `QuangCao` (Quản lý banner quảng cáo đi kèm theo vị trí).
    - Bảng `TinTuc` (Bài viết tin tức & khuyến mãi).
    - Bảng `DangKyLaiThu` (Thông tin khách hàng đặt lịch).
    - Bảng `ThongKe` (Thống kê lượt truy cập hệ thống).
    - Bảng `NguoiDung` (Tài khoản quản trị viên).
* **3.3. Thiết kế giao diện người dùng (UI/UX)**
  - Thiết kế layout trang chủ với bố cục đa cột, thanh bên sidebar và slider banner.
  - Thiết kế khối "Sản phẩm bán chạy" (Hot Trends) và khối "Quảng cáo khuyến mãi đi kèm".

---

### CHƯƠNG 4: CÀI ĐẶT VÀ KẾT QUẢ THỰC NGHIỆM
* **4.1. Môi trường cài đặt và cấu hình**
  - Cấu hình chuỗi kết nối kết nối SQL Server trong `appsettings.json`.
* **4.2. Giao diện và chức năng phía Người dùng (Client)**
  - 4.2.1. Trang chủ với Menu ngang, Menu dọc và Slider banner.
  - 4.2.2. Khối hiển thị **Sản phẩm bán chạy** (Mục 2.c - Tiêu chí Khá).
  - 4.2.3. **Hệ thống quảng cáo đi kèm** (Mục 2.d - Tiêu chí Giỏi): Banner khuyến mãi trả góp 0%, tặng quà, đổi cũ lấy mới.
  - 4.2.4. Chức năng tìm kiếm xe đa tiêu chí và bộ lọc phân loại dòng xe (Mục 2.a, 2.b).
  - 4.2.5. Widget **Thống kê truy cập**: Lượt online thực tế và tổng lượt truy cập (Mục 2.b).
  - 4.2.6. Trang chi tiết xe và Form đăng ký lái thử trực tuyến.
* **4.3. Phân hệ Quản trị viên (Admin Panel)**
  - 4.3.1. Đăng nhập hệ thống bảo mật.
  - 4.3.2. Quản lý sản phẩm xe máy (Thêm mới, Chỉnh sửa thông số, Xóa xe, Cài đặt xe bán chạy).
  - 4.3.3. Quản lý hệ thống banner quảng cáo (Thêm mới, gán vị trí, Bật/Tắt hiển thị).
  - 4.3.4. Quản lý danh sách khách hàng đăng ký lái thử và xử lý trạng thái.
* **4.4. Đánh giá kiểm thử phần mềm**
  - Kết quả kiểm thử các trường hợp dữ liệu hợp lệ và không hợp lệ.

---

### KẾT LUẬN VÀ HƯỚNG PHÁT TRIỂN
* **1. Đánh giá kết quả đạt được đối chiếu với đề bài**:
  - Hoàn thành đầy đủ 100% các yêu cầu từ mức Đạt, Khá đến Giỏi (Gồm mục 1.a-d, 2.a, 2.b, 2.c, 2.d).
* **2. Hạn chế của hệ thống**:
  - Chưa tích hợp cổng thanh toán trực tuyến (VNPAY, MoMo).
* **3. Hướng phát triển trong tương lai**:
  - Tích hợp tính năng so sánh trực quan giữa 2 dòng xe.
  - Tích hợp Chatbot tư vấn báo giá tự động 24/7.

---

### TÀI LIỆU THAM KHẢO
1. Microsoft Documentation: ASP.NET Core MVC Overview.
2. Microsoft SQL Server 2022 Technical Documentation.
3. Trang thông tin chính thức Yamaha Motor Việt Nam (https://yamaha-motor.com.vn).
4. Giáo trình Thiết kế Web và Lập trình Ứng dụng Web - Khoa CNTT, ĐH Công nghiệp Việt-Hung.
