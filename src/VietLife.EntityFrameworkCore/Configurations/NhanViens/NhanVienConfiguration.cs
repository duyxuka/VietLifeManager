using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.Identity;
using VietLife.Catalog.NhanViens;

namespace VietLife.Configurations.Users
{
    public class NhanVienConfiguration : IEntityTypeConfiguration<NhanVien>
    {
        public void Configure(EntityTypeBuilder<NhanVien> builder)
        {
            builder.ToTable("AbpUsers");

            builder.ConfigureByConvention();

            builder.Property(x => x.MaNv).HasMaxLength(50);
            builder.Property(x => x.HoTen).HasMaxLength(255);
            builder.Property(x => x.SoCmnd).HasMaxLength(20);
            builder.Property(x => x.NoiCapCmnd).HasMaxLength(100);
            builder.Property(x => x.DiaChi).HasMaxLength(255);
            builder.Property(x => x.TrangThai).HasMaxLength(50);

            builder.HasOne(x => x.PhongBan)
                   .WithMany(x => x.NhanViens)
                   .HasForeignKey(x => x.PhongBanId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.ChucVu)
                   .WithMany(x => x.NhanViens)
                   .HasForeignKey(x => x.ChucVuId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(x => x.ChiNhanh)
                   .WithMany(x => x.NhanViens)
                   .HasForeignKey(x => x.ChiNhanhId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
