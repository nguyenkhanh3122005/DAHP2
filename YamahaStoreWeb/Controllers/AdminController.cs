using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YamahaStoreWeb.Models;

namespace YamahaStoreWeb.Controllers
{
    public class AdminController : Controller
    {
        private readonly YamahaDbContext _context;

        public AdminController(YamahaDbContext context)
        {
            _context = context;
        }

        private bool IsAdminLoggedIn()
        {
            return HttpContext.Session.GetString("AdminUser") != null;
        }

        // ================= ĐĂNG NHẬP / ĐĂNG XUẤT =================
        [HttpGet]
        public IActionResult Login()
        {
            if (IsAdminLoggedIn())
            {
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string taiKhoan, string matKhau)
        {
            var user = await _context.NguoiDungs
                .FirstOrDefaultAsync(u => u.TaiKhoan == taiKhoan && u.MatKhau == matKhau);

            if (user != null)
            {
                HttpContext.Session.SetString("AdminUser", user.TaiKhoan);
                HttpContext.Session.SetString("AdminName", user.HoTen);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Error = "Tài khoản hoặc mật khẩu không chính xác!";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction(nameof(Login));
        }

        // ================= TỔNG QUAN DASHBOARD =================
        public async Task<IActionResult> Index()
        {
            if (!IsAdminLoggedIn()) return RedirectToAction(nameof(Login));

            ViewBag.TongSoXe = await _context.XeMays.CountAsync();
            ViewBag.TongDanhMuc = await _context.DanhMucs.CountAsync();
            ViewBag.TongQuangCao = await _context.QuangCaos.CountAsync();
            ViewBag.TongDangKy = await _context.DangKyLaiThus.CountAsync();
            
            var stats = await _context.ThongKes.FirstOrDefaultAsync();
            ViewBag.TongLuotTruyCap = stats?.TongLuotTruyCap ?? 0;

            var dsDangKyMoi = await _context.DangKyLaiThus
                .Include(d => d.XeMay)
                .OrderByDescending(d => d.NgayGui)
                .Take(5)
                .ToListAsync();

            return View(dsDangKyMoi);
        }

        // ================= QUẢN LÝ SẢN PHẨM XE MÁY (Mục 2.a & 2.c) =================
        public async Task<IActionResult> XeMay()
        {
            if (!IsAdminLoggedIn()) return RedirectToAction(nameof(Login));

            var danhSachXe = await _context.XeMays
                .Include(x => x.DanhMuc)
                .OrderByDescending(x => x.MaXe)
                .ToListAsync();
            return View(danhSachXe);
        }

        [HttpGet]
        public async Task<IActionResult> ThemXe()
        {
            if (!IsAdminLoggedIn()) return RedirectToAction(nameof(Login));

            ViewBag.DanhMucs = await _context.DanhMucs.Where(d => d.TrangThai).ToListAsync();
            return View(new XeMay());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ThemXe(XeMay model)
        {
            if (!IsAdminLoggedIn()) return RedirectToAction(nameof(Login));

            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(model.Slug))
                {
                    model.Slug = GenerateSlug(model.TenXe);
                }
                if (string.IsNullOrEmpty(model.HinhAnh))
                {
                    model.HinhAnh = "/images/products/exciter-155.png";
                }
                model.NgayTao = DateTime.Now;
                _context.XeMays.Add(model);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Thêm xe máy mới thành công!";
                return RedirectToAction(nameof(XeMay));
            }

            ViewBag.DanhMucs = await _context.DanhMucs.Where(d => d.TrangThai).ToListAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SuaXe(int id)
        {
            if (!IsAdminLoggedIn()) return RedirectToAction(nameof(Login));

            var xe = await _context.XeMays.FindAsync(id);
            if (xe == null) return NotFound();

            ViewBag.DanhMucs = await _context.DanhMucs.Where(d => d.TrangThai).ToListAsync();
            return View(xe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SuaXe(XeMay model)
        {
            if (!IsAdminLoggedIn()) return RedirectToAction(nameof(Login));

            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(model.Slug))
                {
                    model.Slug = GenerateSlug(model.TenXe);
                }
                _context.XeMays.Update(model);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Cập nhật thông tin xe thành công!";
                return RedirectToAction(nameof(XeMay));
            }

            ViewBag.DanhMucs = await _context.DanhMucs.Where(d => d.TrangThai).ToListAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> XoaXe(int id)
        {
            if (!IsAdminLoggedIn()) return RedirectToAction(nameof(Login));

            var xe = await _context.XeMays.FindAsync(id);
            if (xe != null)
            {
                _context.XeMays.Remove(xe);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Đã xóa sản phẩm thành công!";
            }
            return RedirectToAction(nameof(XeMay));
        }

        // ================= QUẢN LÝ QUẢNG CÁO (Mục 2.d - Điểm Giỏi) =================
        public async Task<IActionResult> QuangCao()
        {
            if (!IsAdminLoggedIn()) return RedirectToAction(nameof(Login));

            var ads = await _context.QuangCaos.OrderBy(q => q.ThuTu).ToListAsync();
            return View(ads);
        }

        [HttpGet]
        public IActionResult ThemQuangCao()
        {
            if (!IsAdminLoggedIn()) return RedirectToAction(nameof(Login));
            return View(new QuangCao());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ThemQuangCao(QuangCao model)
        {
            if (!IsAdminLoggedIn()) return RedirectToAction(nameof(Login));

            if (ModelState.IsValid)
            {
                _context.QuangCaos.Add(model);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Thêm banner quảng cáo thành công!";
                return RedirectToAction(nameof(QuangCao));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> SuaQuangCao(int id)
        {
            if (!IsAdminLoggedIn()) return RedirectToAction(nameof(Login));

            var qc = await _context.QuangCaos.FindAsync(id);
            if (qc == null) return NotFound();

            return View(qc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SuaQuangCao(QuangCao model)
        {
            if (!IsAdminLoggedIn()) return RedirectToAction(nameof(Login));

            if (ModelState.IsValid)
            {
                _context.QuangCaos.Update(model);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Cập nhật banner quảng cáo thành công!";
                return RedirectToAction(nameof(QuangCao));
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> XoaQuangCao(int id)
        {
            if (!IsAdminLoggedIn()) return RedirectToAction(nameof(Login));

            var qc = await _context.QuangCaos.FindAsync(id);
            if (qc != null)
            {
                _context.QuangCaos.Remove(qc);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Đã xóa banner quảng cáo!";
            }
            return RedirectToAction(nameof(QuangCao));
        }

        // ================= QUẢN LÝ ĐĂNG KÝ LÁI THỬ =================
        public async Task<IActionResult> DangKy()
        {
            if (!IsAdminLoggedIn()) return RedirectToAction(nameof(Login));

            var danhSach = await _context.DangKyLaiThus
                .Include(d => d.XeMay)
                .OrderByDescending(d => d.NgayGui)
                .ToListAsync();
            return View(danhSach);
        }

        [HttpPost]
        public async Task<IActionResult> CapNhatTrangThaiDangKy(int id, string trangThai)
        {
            if (!IsAdminLoggedIn()) return RedirectToAction(nameof(Login));

            var dk = await _context.DangKyLaiThus.FindAsync(id);
            if (dk != null)
            {
                dk.TrangThai = trangThai;
                await _context.SaveChangesAsync();
                TempData["Success"] = "Cập nhật trạng thái thành công!";
            }
            return RedirectToAction(nameof(DangKy));
        }

        private string GenerateSlug(string title)
        {
            string slug = title.ToLower().Trim();
            string[] vietnamese = new string[] { "aáàảãạăắằẳẵặâấầẩẫậ", "dđ", "eéèẻẽẹêếềểễệ", "iíìỉĩị", "oóòỏõọôốồổỗộơớờởỡợ", "uúùủũụưứừửữự", "yýỳỷỹỵ" };
            char[] ascii = new char[] { 'a', 'd', 'e', 'i', 'o', 'u', 'y' };

            for (int i = 0; i < vietnamese.Length; i++)
            {
                foreach (char c in vietnamese[i])
                {
                    slug = slug.Replace(c, ascii[i]);
                }
            }

            slug = System.Text.RegularExpressions.Regex.Replace(slug, @"[^a-z0-9\s-]", "");
            slug = System.Text.RegularExpressions.Regex.Replace(slug, @"\s+", "-").Trim('-');
            return slug;
        }
    }
}
