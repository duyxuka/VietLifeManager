using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.ThuChis;

namespace VietLife.Configurations.Business.ThuChis
{
    public class ThuChiConfiguration : IEntityTypeConfiguration<ThuChi>
    {
            public void Configure(EntityTypeBuilder<ThuChi> builder)
            {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "ThuChis");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.MaPhieu)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.DienGiai)
                .HasMaxLength(500);

            builder.Property(x => x.SoTaiKhoanNganHang)
                .HasMaxLength(50);

            builder.Property(x => x.TenNganHang)
                .HasMaxLength(200);

            builder.Property(x => x.SoHoaDon)
                .HasMaxLength(50);

            // FK
            builder.HasOne(x => x.LoaiThuChi)
                .WithMany(l => l.ThuChis)
                .HasForeignKey(x => x.LoaiThuChiId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.TaiKhoanNo)
                .WithMany(l => l.ThuChisNo)
                .HasForeignKey(x => x.TaiKhoanNoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.TaiKhoanCo)
                .WithMany(l => l.ThuChisCo)
                .HasForeignKey(x => x.TaiKhoanCoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.NhanVien)
                .WithMany(l => l.ThuChis)
                .HasForeignKey(x => x.NguoiDuyetId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
