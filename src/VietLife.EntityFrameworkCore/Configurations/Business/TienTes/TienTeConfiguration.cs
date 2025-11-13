using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.TienTes;

namespace VietLife.Configurations.Business.TienTes
{
    public class TienTeConfiguration : IEntityTypeConfiguration<TienTe>
    {
        public void Configure(EntityTypeBuilder<TienTe> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "TienTes");

            builder.HasKey(x => x.Id);

            // === Thuộc tính ===
            builder.Property(x => x.TenTienTe)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.MaTienTe)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(x => x.TyGia)
                   .HasPrecision(18, 4)  // độ chính xác cho số thập phân
                   .HasDefaultValue(1);

            builder.Property(x => x.MacDinh)
                   .HasDefaultValue(false);
        }
    }
}
