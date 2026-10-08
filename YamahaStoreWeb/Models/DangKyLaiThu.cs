using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YamahaStoreWeb.Models
{
    [Table("DangKyLaiThu")]
    public class DangKyLaiThu
    {
        [Key]
        public int MaDK { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ và tên")]
        [StringLength(100)]
        public string HoTen { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [StringLength(20)]
        public string SoDienThoai { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [StringLength(100)]
        public string? Email { get; set; }

        public int? MaXe { get; set; }

        [ForeignKey("MaXe")]
        public virtual XeMay? XeMay { get; set; }

        [StringLength(500)]
        public string? GhiChu { get; set; }

        public DateTime NgayGui { get; set; } = DateTime.Now;

        [StringLength(50)]
        public string TrangThai { get; set; } = "Chờ xử lý";
    }
}
