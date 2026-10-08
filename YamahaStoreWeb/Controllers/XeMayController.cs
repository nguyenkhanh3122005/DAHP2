using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YamahaStoreWeb.Models;
using YamahaStoreWeb.ViewModels;

namespace YamahaStoreWeb.Controllers
{
    public class XeMayController : Controller
    {
        private readonly YamahaDbContext _context;

        public XeMayController(YamahaDbContext context)
        {
            _context = context;
        }

        // Chức năng Tìm kiếm và lọc sản phẩm (Mục 2.a)
        [HttpGet]
        public async Task<IActionResult> Index(string? keyword, int? maDanhMuc, string? khoangGia, string? phanKhoi)
        {
            var query = _context.XeMays.Include(x => x.DanhMuc).AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var kw = keyword.Trim().ToLower();
                query = query.Where(x => x.TenXe.ToLower().Contains(kw) || 
                                         x.PhanKhoi.ToLower().Contains(kw) || 
                                         x.MauSac.ToLower().Contains(kw));
            }

            if (maDanhMuc.HasValue && maDanhMuc.Value > 0)
            {
                query = query.Where(x => x.MaDanhMuc == maDanhMuc.Value);
            }

            if (!string.IsNullOrWhiteSpace(phanKhoi))
            {
                query = query.Where(x => x.PhanKhoi.Contains(phanKhoi));
            }

            if (!string.IsNullOrWhiteSpace(khoangGia))
            {
                switch (khoangGia)
                {
                    case "duoi-30":
                        query = query.Where(x => x.GiaBan < 30000000);
                        break;
                    case "30-50":
                        query = query.Where(x => x.GiaBan >= 30000000 && x.GiaBan <= 50000000);
                        break;
                    case "tren-50":
                        query = query.Where(x => x.GiaBan > 50000000);
                        break;
                }
            }

            var stats = await _context.ThongKes.FirstOrDefaultAsync();
            var danhSachXe = await query.ToListAsync();

            var model = new XeMayFilterViewModel
            {
                DanhMucs = await _context.DanhMucs.Where(d => d.TrangThai).OrderBy(d => d.ThuTu).ToListAsync(),
                DanhSachXe = danhSachXe,
                QuangCaoSidebar = await _context.QuangCaos.Where(q => q.HienThi && q.ViTri == "Sidebar").OrderBy(q => q.ThuTu).ToListAsync(),
                Keyword = keyword,
                MaDanhMuc = maDanhMuc,
                KhoangGia = khoangGia,
                PhanKhoi = phanKhoi,
                TongSoLuong = danhSachXe.Count,
                TongLuotTruyCap = stats?.TongLuotTruyCap ?? 15850,
                SoNguoiOnline = 9
            };

            return View(model);
        }

        // Chi tiết xe máy và thông số kỹ thuật (hỗ trợ cả slug và id)
        [HttpGet]
        public async Task<IActionResult> ChiTiet(string? id, string? slug)
        {
            var key = !string.IsNullOrEmpty(slug) ? slug : id;
            if (string.IsNullOrEmpty(key))
            {
                return RedirectToAction(nameof(Index));
            }

            var xe = await _context.XeMays
                .Include(x => x.DanhMuc)
                .FirstOrDefaultAsync(x => x.Slug == key);

            if (xe == null && int.TryParse(key, out int maXe))
            {
                xe = await _context.XeMays.Include(x => x.DanhMuc).FirstOrDefaultAsync(x => x.MaXe == maXe);
            }

            if (xe == null)
            {
                return NotFound();
            }

            // Tăng số lượt xem
            xe.LuotXem += 1;
            await _context.SaveChangesAsync();

            // Xe liên quan
            var xeLienQuan = await _context.XeMays
                .Where(x => x.MaDanhMuc == xe.MaDanhMuc && x.MaXe != xe.MaXe)
                .Take(4)
                .ToListAsync();

            ViewBag.XeLienQuan = xeLienQuan;
            ViewBag.QuangCaoSidebar = await _context.QuangCaos.Where(q => q.HienThi && q.ViTri == "Sidebar").OrderBy(q => q.ThuTu).ToListAsync();
            ViewBag.DanhMucs = await _context.DanhMucs.Where(d => d.TrangThai).OrderBy(d => d.ThuTu).ToListAsync();

            return View(xe);
        }
    }
}
