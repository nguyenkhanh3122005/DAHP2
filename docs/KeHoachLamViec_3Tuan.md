# KẾ HOẠCH LÀM VIỆC THEO TUẦN (TIẾN ĐỘ THỰC HIỆN ĐỒ ÁN)

* **Trường**: Đại học Công nghiệp Việt-Hung
* **Khoa**: Công nghệ Thông tin - **Bộ môn**: Công nghệ Thông tin
* **Học phần**: Đồ án học phần 2
* **Đề tài số 04**: Xây dựng website cửa hàng kinh doanh xe máy Yamaha
* **Giảng viên hướng dẫn**: Thầy/Cô Nguyễn Hoàng Hà
* **Số lượng sinh viên**: 02 sinh viên
  * **Sinh viên 1**: Nguyễn Văn A - Mã SV: [Điền mã SV] (Phụ trách Frontend, Đồ họa, Báo cáo)
  * **Sinh viên 2**: Trần Văn B - Mã SV: [Điền mã SV] (Phụ trách Backend, CSDL, Tích hợp hệ thống)
* **Thời gian thực hiện**: 3 tuần (Từ ngày [dd/mm/2026] đến [dd/mm/2026])

---

## BẢNG TIẾN ĐỘ CHI TIẾT THEO TUẦN

### TUẦN 1: Khảo sát, Đặc tả yêu cầu & Thiết kế Cơ sở dữ liệu (Mục 1.a, 1.c)
* **Mục tiêu**: Nắm vững yêu cầu đề bài, thu thập dữ liệu về hãng xe Yamaha, thiết kế cơ sở dữ liệu trên SQL Server và phác thảo giao diện.
* **Phân công công việc**:
  * **Sinh viên 1**:
    - Khảo sát các dòng xe thực tế của Yamaha (Exciter, Grande, NVX, Sirius, Janus, MT-15...).
    - Sử dụng Photoshop thiết kế Logo đại lý, Banner quảng cáo ưu đãi (Mục 2.d), banner slider trang chủ.
    - Phác thảo wireframe giao diện bố cục: Menu ngang, Menu dọc, khu vực sản phẩm bán chạy.
  * **Sinh viên 2**:
    - Phân tích yêu cầu chức năng (Use Case Diagram, Class Diagram).
    - Thiết kế mô hình dữ liệu quan hệ (ERD) trên SQL Server: bảng DanhMuc, XeMay, QuangCao, TinTuc, DangKyLaiThu, ThongKe, NguoiDung.
    - Viết script `YamahaStoreDB.sql` khởi tạo CSDL và nạp dữ liệu mẫu.
    - Khởi tạo project ASP.NET Core MVC (C#).
* **Kết quả bàn giao tuần 1**: File script CSDL `YamahaStoreDB.sql`, lược đồ ERD, bộ ảnh banner đồ họa.
* **Báo cáo GVHD**: Gửi email báo cáo tiến độ tuần 1 kèm file thiết kế CSDL và giao diện phác thảo.

---

### TUẦN 2: Cắt giao diện Frontend & Lập trình chức năng Client (Mục 1.b, 1.d, 2.a, 2.b, 2.c)
* **Mục tiêu**: Xây dựng hoàn chỉnh giao diện người dùng, kết nối CSDL hiển thị sản phẩm, sản phẩm bán chạy, tìm kiếm và thống kê.
* **Phân công công việc**:
  * **Sinh viên 1**:
    - Xây dựng Layout Responsive (Bootstrap 5, CSS3, jQuery): Menu ngang quản lý trang thông tin, Menu dọc danh mục xe Yamaha.
    - Thiết kế Widget Thống kê truy cập (hiển thị số người online và tổng lượt truy cập).
    - Xây dựng giao diện trang Chi tiết xe (thông số kỹ thuật, màu sắc, giá bán).
  * **Sinh viên 2**:
    - Kết nối Entity Framework Core với Microsoft SQL Server 2022.
    - Lập trình hiển thị sản phẩm theo danh mục (Xe tay ga, Xe số, Xe thể thao, Xe điện).
    - Lập trình module **Sản phẩm bán chạy** (`IsBanChay = 1`) nổi bật trên trang chủ (Mục 2.c - Tiêu chí Khá).
    - Lập trình bộ máy tìm kiếm xe theo tên, lọc theo khoảng giá và phân khối (Mục 2.a).
    - Lập trình form Đăng ký lái thử và gửi yêu cầu tư vấn xe.
* **Kết quả bàn giao tuần 2**: Website chạy thử nghiệm được các chức năng phía Client trên localhost.
* **Báo cáo GVHD**: Báo cáo trực tiếp hoặc gửi video demo giao diện + các chức năng tìm kiếm, lọc sản phẩm cho GVHD.

---

### TUẦN 3: Xây dựng Hệ thống Quảng cáo, Phân hệ Quản trị Admin & Viết Báo cáo (Mục 2.d, 3.c, 3.d)
* **Mục tiêu**: Hoàn thiện tính năng điểm Giỏi (Hệ thống quảng cáo đi kèm 2.d), phân hệ Admin, kiểm thử toàn diện và đóng gói báo cáo nộp Khoa.
* **Phân công công việc**:
  * **Sinh viên 1**:
    - Tích hợp **Hệ thống quảng cáo đi kèm** (Mục 2.d): Hiển thị banner khuyến mãi ở cột sidebar và banner trúng thưởng giữa trang; hỗ trợ quản lý vị trí quảng cáo.
    - Soạn thảo tài liệu **Báo cáo Đồ án học phần 2** bằng Microsoft Word theo chuẩn mẫu của Bộ môn Công nghệ thông tin.
    - Chụp ảnh minh họa giao diện, đóng gói phụ lục hướng dẫn cài đặt.
  * **Sinh viên 2**:
    - Xây dựng phân hệ Quản trị viên (Admin CMS): Đăng nhập, Quản lý sản phẩm xe (Thêm/Sửa/Xóa/Upload ảnh), Quản lý banner quảng cáo, Quản lý danh sách khách đăng ký lái thử.
    - Kiểm thử hệ thống (Test tính năng, bảo mật SQL Injection, responsive trên di động).
    - Đóng gói mã nguồn (Source Code) và file backup CSDL (.sql).
* **Kết quả bàn giao tuần 3**: Sản phẩm website hoàn chỉnh + File CSDL + Bản in Báo cáo đồ án đóng quyển.
* **Báo cáo GVHD**: Gặp GVHD xin nhận xét, hoàn thiện chỉnh sửa lần cuối và xin chữ ký duyệt bảo vệ đồ án.

---

*Hà Nội, ngày ... tháng ... năm 2026*  
**Nhóm sinh viên thực hiện**  
*(Ký và ghi rõ họ tên)*
