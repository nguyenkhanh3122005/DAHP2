using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YamahaStoreWeb.Models;
using YamahaStoreWeb.ViewModels;

namespace YamahaStoreWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly YamahaDbContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(YamahaDbContext context, ILogger<HomeController> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            // Cập nhật lượt truy cập hệ thống (Mục 2.b)
            var stats = await _context.ThongKes.FirstOrDefaultAsync();
            if (stats == null)
            {
                stats = new ThongKe { TongLuotTruyCap = 15850, NgayCapNhat = DateTime.Now };
                _context.ThongKes.Add(stats);
                await _context.SaveChangesAsync();
            }
            else
            {
                // Tăng lượt xem mỗi session mới
                if (HttpContext.Session.GetString("Visited") == null)
                {
                    HttpContext.Session.SetString("Visited", "1");
                    stats.TongLuotTruyCap += 1;
                    stats.NgayCapNhat = DateTime.Now;
                    await _context.SaveChangesAsync();
                }
            }

            var model = new HomeViewModel
            {
                DanhMucs = await _context.DanhMucs.Where(d => d.TrangThai).OrderBy(d => d.ThuTu).ToListAsync(),
                XeBanChay = await _context.XeMays.Include(x => x.DanhMuc).Where(x => x.IsBanChay).Take(8).ToListAsync(), // Mục 2.c
                XeMoiVe = await _context.XeMays.Include(x => x.DanhMuc).Where(x => x.IsMoiVe).Take(8).ToListAsync(),
                TatCaXe = await _context.XeMays.Include(x => x.DanhMuc).Take(12).ToListAsync(),
                QuangCaoSidebar = await _context.QuangCaos.Where(q => q.HienThi && q.ViTri == "Sidebar").OrderBy(q => q.ThuTu).ToListAsync(), // Mục 2.d
                QuangCaoMid = await _context.QuangCaos.Where(q => q.HienThi && q.ViTri == "MidBanner").OrderBy(q => q.ThuTu).ToListAsync(), // Mục 2.d
                TinTucs = await _context.TinTucs.OrderByDescending(t => t.NgayDang).Take(3).ToListAsync(),
                TongLuotTruyCap = stats.TongLuotTruyCap,
                SoNguoiOnline = 7 + (stats.TongLuotTruyCap % 11) // Số người online ngẫu nhiên thực tế (7 - 17 người)
            };

            return View(model);
        }

        public async Task<IActionResult> GioiThieu()
        {
            ViewBag.DanhMucs = await _context.DanhMucs.Where(d => d.TrangThai).OrderBy(d => d.ThuTu).ToListAsync();
            return View();
        }

        public async Task<IActionResult> BangGia()
        {
            var danhMucs = await _context.DanhMucs.Include(d => d.XeMays).Where(d => d.TrangThai).OrderBy(d => d.ThuTu).ToListAsync();
            return View(danhMucs);
        }

        public async Task<IActionResult> LienHe()
        {
            ViewBag.DanhMucs = await _context.DanhMucs.Where(d => d.TrangThai).OrderBy(d => d.ThuTu).ToListAsync();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
