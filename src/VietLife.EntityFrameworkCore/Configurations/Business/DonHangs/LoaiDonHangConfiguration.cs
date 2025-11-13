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
    public class LoaiDonHangConfiguration : IEntityTypeConfiguration<LoaiDonHang>
    {
        public void Configure(EntityTypeBuilder<LoaiDonHang> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "LoaiDonHangs");

            builder.HasKey(x => x.Id);

            // === Thuộc tính cơ bản ===
            builder.Property(x => x.TenLoai)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.HieuLuc)
                   .HasDefaultValue(true);

            builder.Property(x => x.TuDongXuatKho)
                   .HasDefaultValue(false);
        }
    }
}
