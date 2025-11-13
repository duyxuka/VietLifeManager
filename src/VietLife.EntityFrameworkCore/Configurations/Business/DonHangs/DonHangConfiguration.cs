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
    public class DonHangConfiguration : IEntityTypeConfiguration<DonHang>
    {
        public void Configure(EntityTypeBuilder<DonHang> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "DonHangs");

            builder.HasKey(x => x.Id);

            // === Thuộc tính cơ bản ===
            builder.Property(x => x.MaDonHang)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.MaDonHangGoc)
                   .HasMaxLength(50);

            builder.Property(x => x.NgayDatHang)
                   .IsRequired();

            builder.Property(x => x.TongTien)
                   .HasPrecision(18, 2)
                   .IsRequired();

            // === Quan hệ với BaoGia ===
            builder.HasOne(x => x.BaoGia)
                   .WithMany(b => b.DonHangs)
                   .HasForeignKey(x => x.BaoGiaId)
                   .OnDelete(DeleteBehavior.Restrict);

            // === Quan hệ với KhachHang ===
            builder.HasOne(x => x.KhachHang)
                   .WithMany(k => k.DonHangs)
                   .HasForeignKey(x => x.KhachHangId)
                   .OnDelete(DeleteBehavior.Restrict);

            // === Quan hệ với LoaiDonHang ===
            builder.HasOne(x => x.LoaiDonHang)
                   .WithMany(l => l.DonHangs)
                   .HasForeignKey(x => x.LoaiDonHangId)
                   .OnDelete(DeleteBehavior.Restrict);

            // === Quan hệ với NhanVienBanHang ===
            builder.HasOne(x => x.NhanVienBanHang)
                   .WithMany()
                   .HasForeignKey(x => x.NhanVienBanHangId)
                   .OnDelete(DeleteBehavior.Restrict);

            // === Quan hệ với NhanVienGiaoHang ===
            builder.HasOne(x => x.NhanVienGiaoHang)
                   .WithMany()
                   .HasForeignKey(x => x.NhanVienGiaoHangId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
