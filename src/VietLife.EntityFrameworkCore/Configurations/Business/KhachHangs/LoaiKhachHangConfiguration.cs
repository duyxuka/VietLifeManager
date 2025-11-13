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
    public class LoaiKhachHangConfiguration : IEntityTypeConfiguration<LoaiKhachHang>
    {
        public void Configure(EntityTypeBuilder<LoaiKhachHang> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "LoaiKhachHangs");

            builder.HasKey(x => x.Id);

            // === Thuộc tính cơ bản ===
            builder.Property(x => x.Ten)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.MoTa)
                   .HasMaxLength(500);

            builder.Property(x => x.HieuLuc)
                   .HasDefaultValue(true);
        }
    }
}
