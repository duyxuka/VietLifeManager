using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.TuongTac.Insurer;

namespace VietLife.Configurations.TuongTac.Insurer
{
    public class DangKyTuVanConfiguration : IEntityTypeConfiguration<DangKyTuVan>
    {
        public void Configure(EntityTypeBuilder<DangKyTuVan> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "DangKyTuVans");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.HoTen).IsRequired().HasMaxLength(100);
            builder.Property(x => x.SoDienThoai).IsRequired().HasMaxLength(20);

            builder.HasOne(x => x.SanPham)
                .WithMany()
                .HasForeignKey(x => x.SanPhamId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);

            builder.HasOne(x => x.Nhom)
                .WithMany()
                .HasForeignKey(x => x.NhomId)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);
        }
    }
}
