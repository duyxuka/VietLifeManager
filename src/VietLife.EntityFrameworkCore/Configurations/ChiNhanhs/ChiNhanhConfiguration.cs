using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.PhongBans;
using VietLife.ChiNhanhs;

namespace VietLife.Configurations.ChiNhanhs
{
    public class ChiNhanhConfiguration : IEntityTypeConfiguration<ChiNhanh>
    {
        public void Configure(EntityTypeBuilder<ChiNhanh> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "ChiNhanhs");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TenChiNhanh)
                   .IsRequired()
                   .HasMaxLength(255);
        }
    }
}
