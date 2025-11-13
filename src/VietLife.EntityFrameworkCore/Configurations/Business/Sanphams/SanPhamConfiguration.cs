using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.SanPhams;

namespace VietLife.Configurations.Business.Sanphams
{
    public class SanPhamConfiguration : IEntityTypeConfiguration<SanPham>
    {
        public void Configure(EntityTypeBuilder<SanPham> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "SanPhams");

            builder.HasKey(x => x.Id);

            // === Thuộc tính cơ bản ===
            builder.Property(x => x.Ma)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Ten)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.Model)
                   .HasMaxLength(100);

            builder.Property(x => x.MoTa)
                   .HasMaxLength(500);

            builder.Property(x => x.Anh)
                   .HasMaxLength(200);

            builder.Property(x => x.GiaBan)
                   .HasPrecision(18, 2);

            builder.Property(x => x.HoatDong)
                   .HasDefaultValue(true);

            // === Quan hệ với NhomSanPham ===
            builder.HasOne(x => x.NhomSanPham)
                   .WithMany(nsp => nsp.SanPhams)
                   .HasForeignKey(x => x.NhomSanPhamId)
                   .OnDelete(DeleteBehavior.Restrict);

            // === Quan hệ với DonViTinh ===
            builder.HasOne(x => x.DonViTinh)
                   .WithMany(dvt => dvt.SanPhams)
                   .HasForeignKey(x => x.DonViTinhId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
