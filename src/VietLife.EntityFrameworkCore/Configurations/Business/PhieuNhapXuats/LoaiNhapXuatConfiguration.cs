using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.PhieuNhapXuats;

namespace VietLife.Configurations.Business.PhieuNhapXuats
{
    public class LoaiNhapXuatConfiguration : IEntityTypeConfiguration<LoaiNhapXuat>
    {
        public void Configure(EntityTypeBuilder<LoaiNhapXuat> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "LoaiNhapXuats");

            builder.HasKey(x => x.Id);

            // === Thuộc tính cơ bản ===
            builder.Property(x => x.TenLoai)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.KieuNhapXuat)
                   .IsRequired();

            builder.Property(x => x.TangGiamTon)
                   .IsRequired();
        }
    }
}
