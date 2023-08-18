using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace NhanSuAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> opt) : base(opt)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .Build();
            var strConn = config["ConnectionStrings:DefaultConnection"];
            return strConn;
        }
        #region DbSet
        public DbSet<PhongBan>? PhongBans { get; set; }
        public DbSet<NhanSu>? NhanSus { get; set; }
        public DbSet<PhanCong>? PhanCongs { get; set; }
        public DbSet<CongViec>? CongViecs { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Many to Many relation between NhanVien and DuAn
            modelBuilder.Entity<PhanCong>()
                    .HasKey(t => new { t.MaNhanSu, t.MaCongViec });
            modelBuilder.Entity<PhanCong>()
                    .HasOne(t => t.NhanSu)
                    .WithMany(t => t.PhanCongs)
                    .HasForeignKey(f => f.MaNhanSu);

        }

    }
}
