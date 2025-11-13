using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.NhanViens;
using VietLife.Catalog.LuongNhanViens;

namespace VietLife.Configurations.Catalog.LuongNhanViens
{
    public class LuongNhanVienConfiguration : IEntityTypeConfiguration<LuongNhanVien>
    {
        public void Configure(EntityTypeBuilder<LuongNhanVien> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "LuongNhanViens");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.PhuCap).HasColumnType("decimal(18,2)");
            builder.Property(x => x.TongLuong).HasColumnType("decimal(18,2)");

            builder.HasOne(x => x.NhanVien)
                   .WithMany(x => x.LuongNhanViens)
                   .HasForeignKey(x => x.NhanVienId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
