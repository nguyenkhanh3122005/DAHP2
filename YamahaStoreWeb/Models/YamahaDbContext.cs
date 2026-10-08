using Microsoft.EntityFrameworkCore;

namespace YamahaStoreWeb.Models
{
    public class YamahaDbContext : DbContext
    {
        public YamahaDbContext(DbContextOptions<YamahaDbContext> options) : base(options)
        {
        }

        public DbSet<DanhMuc> DanhMucs { get; set; } = null!;
        public DbSet<XeMay> XeMays { get; set; } = null!;
        public DbSet<QuangCao> QuangCaos { get; set; } = null!;
        public DbSet<TinTuc> TinTucs { get; set; } = null!;
        public DbSet<DangKyLaiThu> DangKyLaiThus { get; set; } = null!;
        public DbSet<ThongKe> ThongKes { get; set; } = null!;
        public DbSet<NguoiDung> NguoiDungs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DanhMuc>().ToTable("DanhMuc");
            modelBuilder.Entity<XeMay>().ToTable("XeMay");
            modelBuilder.Entity<QuangCao>().ToTable("QuangCao");
            modelBuilder.Entity<TinTuc>().ToTable("TinTuc");
            modelBuilder.Entity<DangKyLaiThu>().ToTable("DangKyLaiThu");
            modelBuilder.Entity<ThongKe>().ToTable("ThongKe");
            modelBuilder.Entity<NguoiDung>().ToTable("NguoiDung");
        }
    }
}
