using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.LichLamViecs;

namespace VietLife.Configurations.Catalog.LichLamViecs
{
    public class LichLamViecConfiguration : IEntityTypeConfiguration<LichLamViec>
    {
        public void Configure(EntityTypeBuilder<LichLamViec> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "LichLamViecs");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nam).IsRequired();
            builder.Property(x => x.Thang).IsRequired();
            builder.Property(x => x.NgayLam).HasMaxLength(500);
            builder.Property(x => x.NgayNghi).HasMaxLength(500);

        }
    }
}
