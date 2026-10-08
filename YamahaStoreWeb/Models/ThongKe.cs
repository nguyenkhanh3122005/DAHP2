using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YamahaStoreWeb.Models
{
    [Table("ThongKe")]
    public class ThongKe
    {
        [Key]
        public int Id { get; set; }

        public int TongLuotTruyCap { get; set; } = 0;

        public DateTime NgayCapNhat { get; set; } = DateTime.Now;
    }

    [Table("NguoiDung")]
    public class NguoiDung
    {
        [Key]
        public int MaND { get; set; }

        [Required]
        [StringLength(50)]
        public string TaiKhoan { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string MatKhau { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string HoTen { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Email { get; set; }

        [StringLength(20)]
        public string VaiTro { get; set; } = "Admin";
    }
}
