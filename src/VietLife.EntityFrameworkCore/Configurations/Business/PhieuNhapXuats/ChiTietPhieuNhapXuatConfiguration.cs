using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.PhieuNhapXuats;

namespace VietLife.Configurations.Business.PhieuNhapXuats
{
    public class ChiTietPhieuNhapXuatConfiguration : IEntityTypeConfiguration<ChiTietPhieuNhapXuat>
    {
        public void Configure(EntityTypeBuilder<ChiTietPhieuNhapXuat> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "ChiTietPhieuNhapXuats");

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

            builder.Property(x => x.GiaVon)
                   .HasPrecision(18, 2)
                   .HasDefaultValue(0);

            // === Quan hệ với PhieuNhapXuat ===
            builder.HasOne(x => x.PhieuNhapXuat)
                   .WithMany(p => p.ChiTietPhieuNhapXuats)
                   .HasForeignKey(x => x.PhieuNhapXuatId)
                   .OnDelete(DeleteBehavior.Cascade);

            // === Quan hệ với SanPham ===
            builder.HasOne(x => x.SanPham)
                   .WithMany(s => s.ChiTietPhieuNhapXuats)
                   .HasForeignKey(x => x.SanPhamId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
