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
    public class PhieuNhapXuatConfiguration : IEntityTypeConfiguration<PhieuNhapXuat>
    {
        public void Configure(EntityTypeBuilder<PhieuNhapXuat> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "PhieuNhapXuats");

            builder.HasKey(x => x.Id);

            // === Thuộc tính cơ bản ===
            builder.Property(x => x.MaPhieu)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.NgayLap)
                   .IsRequired();

            // === Quan hệ với LoaiNhapXuat ===
            builder.HasOne(x => x.LoaiNhapXuat)
                   .WithMany(l => l.PhieuNhapXuats)
                   .HasForeignKey(x => x.LoaiNhapXuatId)
                   .OnDelete(DeleteBehavior.Restrict);

            // === Quan hệ với KhoHang ===
            builder.HasOne(p => p.KhoHang)
                    .WithMany(k => k.PhieuNhapXuatsGoc)
                    .HasForeignKey(p => p.KhoId)
                    .OnDelete(DeleteBehavior.Restrict);

            // === Quan hệ với KhoDen (chuyển kho) ===
            builder.HasOne(p => p.KhoDen)
                    .WithMany(k => k.PhieuNhapXuatsDen)
                    .HasForeignKey(p => p.KhoDenId)
                    .OnDelete(DeleteBehavior.Restrict);

            // === Quan hệ với DonHang ===
            builder.HasOne(x => x.DonHang)
                   .WithMany(d => d.PhieuNhapXuats)
                   .HasForeignKey(x => x.DonHangId)
                   .OnDelete(DeleteBehavior.Restrict);

            // === Quan hệ với BaoGia ===
            builder.HasOne(x => x.BaoGia)
                   .WithMany(b => b.PhieuNhapXuats)
                   .HasForeignKey(x => x.BaoGiaId)
                   .OnDelete(DeleteBehavior.Restrict);

            // === Quan hệ với NhanVienLap ===
            builder.HasOne(x => x.NhanVienLap)
                   .WithMany(i => i.PhieuNhapXuats)
                   .HasForeignKey(x => x.NhanVienLapId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
