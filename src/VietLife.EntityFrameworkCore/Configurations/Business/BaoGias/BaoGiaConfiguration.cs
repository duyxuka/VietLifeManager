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
    public class BaoGiaConfiguration : IEntityTypeConfiguration<BaoGia>
    {
        public void Configure(EntityTypeBuilder<BaoGia> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "BaoGias");

            builder.HasKey(x => x.Id);

            // === Thuộc tính cơ bản ===
            builder.Property(x => x.MaBaoGia)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.TieuDe)
                   .HasMaxLength(200);

            builder.Property(x => x.NgayBaoGia)
                   .IsRequired();

            builder.Property(x => x.TongTien)
                   .HasPrecision(18, 2)
                   .IsRequired();

            builder.Property(x => x.ChietKhau)
                   .HasPrecision(5, 2)
                   .HasDefaultValue(0);

            builder.Property(x => x.VAT)
                   .HasPrecision(5, 2)
                   .HasDefaultValue(0);

            builder.Property(x => x.DaChuyenDonHang)
                   .HasDefaultValue(false);

            // === Quan hệ với KhachHang ===
            builder.HasOne(x => x.KhachHang)
                   .WithMany(k => k.BaoGias)
                   .HasForeignKey(x => x.KhachHangId)
                   .OnDelete(DeleteBehavior.Restrict);

            // === Quan hệ với NhanVien ===
            builder.HasOne(x => x.NhanVien)
                   .WithMany()
                   .HasForeignKey(x => x.NhanVienId)
                   .OnDelete(DeleteBehavior.Restrict);

            // === Quan hệ với TienTe ===
            builder.HasOne(x => x.TienTe)
                   .WithMany(t => t.BaoGias)
                   .HasForeignKey(x => x.TienTeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
