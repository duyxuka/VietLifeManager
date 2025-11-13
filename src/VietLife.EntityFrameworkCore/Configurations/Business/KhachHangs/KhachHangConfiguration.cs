using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.KhachHangs;

namespace VietLife.Configurations.Business.KhachHangs
{
    public class KhachHangConfiguration : IEntityTypeConfiguration<KhachHang>
    {
        public void Configure(EntityTypeBuilder<KhachHang> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "KhachHangs");

            builder.HasKey(x => x.Id);

            // === Thuộc tính cơ bản ===
            builder.Property(x => x.MaKhachHang)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.TenCongTy)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.TenGiaoDich)
                   .HasMaxLength(200);

            builder.Property(x => x.DienThoai)
                   .HasMaxLength(50);

            builder.Property(x => x.Email)
                   .HasMaxLength(100);

            builder.Property(x => x.DiaChi)
                   .HasMaxLength(500);

            builder.Property(x => x.TrangThai)
                   .HasDefaultValue(true);

            // === Quan hệ với LoaiKhachHang ===
            builder.HasOne(x => x.LoaiKhachHang)
                   .WithMany(l => l.KhachHangs)
                   .HasForeignKey(x => x.LoaiKhachHangId)
                   .OnDelete(DeleteBehavior.Restrict);

            // === Quan hệ với ThanhPho ===
            builder.HasOne(x => x.ThanhPho)
                   .WithMany(tp => tp.KhachHangs)
                   .HasForeignKey(x => x.ThanhPhoId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
