using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.TuongTac.Insurer;

namespace VietLife.Configurations.TuongTac.Insurer
{
    public class BaiVietConfiguration : IEntityTypeConfiguration<BaiViet>
    {
        public void Configure(EntityTypeBuilder<BaiViet> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "BaiViets");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TieuDe).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(220);
            builder.Property(x => x.MoTaNgan).HasMaxLength(300);
            builder.Property(x => x.AnhDaiDien).HasMaxLength(200);
            builder.HasIndex(x => x.Slug).IsUnique();

            builder.HasOne(x => x.Nhom)
                .WithMany(x => x.BaiViets)
                .HasForeignKey(x => x.NhomId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.SanPham)
                .WithMany()
                .HasForeignKey(x => x.SanPhamId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);
        }
    }
}
