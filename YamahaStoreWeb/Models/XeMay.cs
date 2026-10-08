using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YamahaStoreWeb.Models
{
    [Table("XeMay")]
    public class XeMay
    {
        [Key]
        public int MaXe { get; set; }

        [Required(ErrorMessage = "Tên xe không được để trống")]
        [StringLength(150)]
        public string TenXe { get; set; } = string.Empty;

        [StringLength(150)]
        public string Slug { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng chọn danh mục xe")]
        public int MaDanhMuc { get; set; }

        [ForeignKey("MaDanhMuc")]
        public virtual DanhMuc? DanhMuc { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập giá bán")]
        [Column(TypeName = "decimal(18, 0)")]
        public decimal GiaBan { get; set; }

        [Column(TypeName = "decimal(18, 0)")]
        public decimal? GiaKhuyenMai { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập dung tích phân khối")]
        [StringLength(50)]
        public string PhanKhoi { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập màu sắc")]
        [StringLength(200)]
        public string MauSac { get; set; } = string.Empty;

        [StringLength(300)]
        public string HinhAnh { get; set; } = string.Empty;

        public string? ThongSoKT { get; set; }

        public string? MoTa { get; set; }

        public bool IsBanChay { get; set; } = false;

        public bool IsMoiVe { get; set; } = false;

        public int SoLuongTon { get; set; } = 10;

        public int LuotXem { get; set; } = 0;

        public DateTime NgayTao { get; set; } = DateTime.Now;
    }
}
