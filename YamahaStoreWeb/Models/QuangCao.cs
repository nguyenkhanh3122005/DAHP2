using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YamahaStoreWeb.Models
{
    [Table("QuangCao")]
    public class QuangCao
    {
        [Key]
        public int MaQC { get; set; }

        [Required(ErrorMessage = "Tiêu đề quảng cáo không được để trống")]
        [StringLength(200)]
        public string TieuDe { get; set; } = string.Empty;

        [Required(ErrorMessage = "Hình ảnh banner không được để trống")]
        [StringLength(300)]
        public string HinhAnhBanner { get; set; } = string.Empty;

        [StringLength(300)]
        public string? LinkLienKet { get; set; }

        [Required]
        [StringLength(50)]
        public string ViTri { get; set; } = "Sidebar"; // 'Sidebar', 'TopBanner', 'MidBanner', 'Popup'

        public int ThuTu { get; set; } = 0;

        public bool HienThi { get; set; } = true;
    }
}
