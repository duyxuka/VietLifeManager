using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.DonHangs;

namespace VietLife.Configurations.Business.DonHangs
{
    public class ChiTietDonHangConfiguration : IEntityTypeConfiguration<ChiTietDonHang>
    {
        public void Configure(EntityTypeBuilder<ChiTietDonHang> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "ChiTietDonHangs");

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

            builder.Property(x => x.VAT)
                   .HasPrecision(5, 2)
                   .HasDefaultValue(0);

            // === Quan hệ với DonHang ===
            builder.HasOne(x => x.DonHang)
                   .WithMany(d => d.ChiTietDonHangs)
                   .HasForeignKey(x => x.DonHangId)
                   .OnDelete(DeleteBehavior.Restrict);

            // === Quan hệ với SanPham ===
            builder.HasOne(x => x.SanPham)
                   .WithMany(s => s.ChiTietDonHangs)
                   .HasForeignKey(x => x.SanPhamId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
