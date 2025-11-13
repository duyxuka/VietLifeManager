using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.SanPhams;

namespace VietLife.Configurations.Business.Sanphams
{
    public class NhomSanPhamConfiguration : IEntityTypeConfiguration<NhomSanPham>
    {
        public void Configure(EntityTypeBuilder<NhomSanPham> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "NhomSanPhams");

            builder.HasKey(x => x.Id);

            // === Thuộc tính cơ bản ===
            builder.Property(x => x.TenNhom)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.MaNhom)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.HieuLuc)
                   .HasDefaultValue(true);
        }
    }
}
