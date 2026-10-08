using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YamahaStoreWeb.Models
{
    [Table("DanhMuc")]
    public class DanhMuc
    {
        [Key]
        public int MaDanhMuc { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(100)]
        public string TenDanhMuc { get; set; } = string.Empty;

        [StringLength(100)]
        public string Slug { get; set; } = string.Empty;

        [StringLength(500)]
        public string? MoTa { get; set; }

        [StringLength(50)]
        public string? Icon { get; set; }

        public int ThuTu { get; set; } = 0;

        public bool TrangThai { get; set; } = true;

        public virtual ICollection<XeMay>? XeMays { get; set; }
    }
}
