using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BaiTieuLuan.DAL
{
    public partial class QLNhanVienModel : DbContext
    {
        public QLNhanVienModel()
            : base("name=AppConnectionString")
        {
        }

        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhongBan>()
                .HasMany(e => e.NhanViens)
                .WithOptional(e => e.PhongBan)
                .HasForeignKey(e => e.IDPhongBan);
        }
    }
}
