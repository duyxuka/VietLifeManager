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
    public class DonViTinhConfiguration : IEntityTypeConfiguration<DonViTinh>
    {
        public void Configure(EntityTypeBuilder<DonViTinh> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "DonViTinhs");

            builder.HasKey(x => x.Id);

            // === Thuộc tính cơ bản ===
            builder.Property(x => x.TenDonVi)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.MacDinh)
                   .HasDefaultValue(false);
        }
    }
}
