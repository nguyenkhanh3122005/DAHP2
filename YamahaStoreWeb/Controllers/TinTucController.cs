using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YamahaStoreWeb.Models;

namespace YamahaStoreWeb.Controllers
{
    public class TinTucController : Controller
    {
        private readonly YamahaDbContext _context;

        public TinTucController(YamahaDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tinTucs = await _context.TinTucs.OrderByDescending(t => t.NgayDang).ToListAsync();
            ViewBag.DanhMucs = await _context.DanhMucs.Where(d => d.TrangThai).OrderBy(d => d.ThuTu).ToListAsync();
            ViewBag.QuangCaoSidebar = await _context.QuangCaos.Where(q => q.HienThi && q.ViTri == "Sidebar").OrderBy(q => q.ThuTu).ToListAsync();
            return View(tinTucs);
        }

        [HttpGet]
        public async Task<IActionResult> ChiTiet(string? id, string? slug)
        {
            var key = !string.IsNullOrEmpty(slug) ? slug : id;
            if (string.IsNullOrEmpty(key))
            {
                return RedirectToAction(nameof(Index));
            }

            var tin = await _context.TinTucs.FirstOrDefaultAsync(t => t.Slug == key);
            if (tin == null && int.TryParse(key, out int maTin))
            {
                tin = await _context.TinTucs.FirstOrDefaultAsync(t => t.MaTin == maTin);
            }

            if (tin == null)
            {
                return NotFound();
            }

            ViewBag.TinMoi = await _context.TinTucs.Where(t => t.MaTin != tin.MaTin).Take(4).ToListAsync();
            ViewBag.DanhMucs = await _context.DanhMucs.Where(d => d.TrangThai).OrderBy(d => d.ThuTu).ToListAsync();
            ViewBag.QuangCaoSidebar = await _context.QuangCaos.Where(q => q.HienThi && q.ViTri == "Sidebar").OrderBy(q => q.ThuTu).ToListAsync();
            return View(tin);
        }
    }
}
