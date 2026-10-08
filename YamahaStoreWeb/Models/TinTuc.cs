using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YamahaStoreWeb.Models
{
    [Table("TinTuc")]
    public class TinTuc
    {
        [Key]
        public int MaTin { get; set; }

        [Required]
        [StringLength(250)]
        public string TieuDe { get; set; } = string.Empty;

        [StringLength(250)]
        public string Slug { get; set; } = string.Empty;

        [StringLength(300)]
        public string HinhAnh { get; set; } = string.Empty;

        [StringLength(500)]
        public string TomTat { get; set; } = string.Empty;

        public string NoiDung { get; set; } = string.Empty;

        public DateTime NgayDang { get; set; } = DateTime.Now;
    }
}
