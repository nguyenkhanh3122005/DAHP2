using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YamahaStoreWeb.Models;

namespace YamahaStoreWeb.Controllers
{
    public class DangKyController : Controller
    {
        private readonly YamahaDbContext _context;

        public DangKyController(YamahaDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int? maXe)
        {
            ViewBag.DanhSachXe = await _context.XeMays.OrderBy(x => x.TenXe).ToListAsync();
            ViewBag.MaXeChon = maXe;
            ViewBag.DanhMucs = await _context.DanhMucs.Where(d => d.TrangThai).OrderBy(d => d.ThuTu).ToListAsync();
            ViewBag.QuangCaoSidebar = await _context.QuangCaos.Where(q => q.HienThi && q.ViTri == "Sidebar").OrderBy(q => q.ThuTu).ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GuiDangKy(DangKyLaiThu model)
        {
            if (ModelState.IsValid)
            {
                model.NgayGui = DateTime.Now;
                model.TrangThai = "Chờ xử lý";
                _context.DangKyLaiThus.Add(model);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Đăng ký thành công! Nhân viên Yamaha Town sẽ liên hệ tư vấn trong vòng 15 phút.";
                return RedirectToAction(nameof(Index));
            }

            ViewBag.DanhSachXe = await _context.XeMays.OrderBy(x => x.TenXe).ToListAsync();
            ViewBag.DanhMucs = await _context.DanhMucs.Where(d => d.TrangThai).OrderBy(d => d.ThuTu).ToListAsync();
            ViewBag.QuangCaoSidebar = await _context.QuangCaos.Where(q => q.HienThi && q.ViTri == "Sidebar").OrderBy(q => q.ThuTu).ToListAsync();
            return View("Index", model);
        }
    }
}
