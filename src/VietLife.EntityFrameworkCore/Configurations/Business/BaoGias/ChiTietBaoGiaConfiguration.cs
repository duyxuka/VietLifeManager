using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.BaoGias;

namespace VietLife.Configurations.Business.BaoGias
{
    public class ChiTietBaoGiaConfiguration : IEntityTypeConfiguration<ChiTietBaoGia>
    {
        public void Configure(EntityTypeBuilder<ChiTietBaoGia> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "ChiTietBaoGias");

            builder.HasKey(x => x.Id);

            // === Thuộc tính cơ bản ===
            builder.Property(x => x.SoLuong)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(x => x.DonGia)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(x => x.ChietKhau)
                   .HasPrecision(5, 2)
                   .HasDefaultValue(0);

            // === Quan hệ với BaoGia ===
            builder.HasOne(x => x.BaoGia)
                   .WithMany(b => b.ChiTietBaoGias)
                   .HasForeignKey(x => x.BaoGiaId)
                   .OnDelete(DeleteBehavior.Cascade);

            // === Quan hệ với SanPham ===
            builder.HasOne(x => x.SanPham)
                   .WithMany(s => s.ChiTietBaoGias)
                   .HasForeignKey(x => x.SanPhamId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
