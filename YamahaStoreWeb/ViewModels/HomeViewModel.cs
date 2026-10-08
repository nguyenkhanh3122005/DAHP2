using YamahaStoreWeb.Models;

namespace YamahaStoreWeb.ViewModels
{
    public class HomeViewModel
    {
        public List<DanhMuc> DanhMucs { get; set; } = new();
        public List<XeMay> XeBanChay { get; set; } = new(); // Yêu cầu 2.c
        public List<XeMay> XeMoiVe { get; set; } = new();
        public List<XeMay> TatCaXe { get; set; } = new();
        public List<QuangCao> QuangCaoSidebar { get; set; } = new(); // Yêu cầu 2.d
        public List<QuangCao> QuangCaoMid { get; set; } = new(); // Yêu cầu 2.d
        public List<TinTuc> TinTucs { get; set; } = new();
        public int TongLuotTruyCap { get; set; } // Yêu cầu 2.b
        public int SoNguoiOnline { get; set; } = 1; // Yêu cầu 2.b
    }

    public class XeMayFilterViewModel
    {
        public List<DanhMuc> DanhMucs { get; set; } = new();
        public List<XeMay> DanhSachXe { get; set; } = new();
        public List<QuangCao> QuangCaoSidebar { get; set; } = new();
        public string? Keyword { get; set; }
        public int? MaDanhMuc { get; set; }
        public string? KhoangGia { get; set; }
        public string? PhanKhoi { get; set; }
        public int TongSoLuong { get; set; }
        public int TongLuotTruyCap { get; set; }
        public int SoNguoiOnline { get; set; } = 1;
    }
}
