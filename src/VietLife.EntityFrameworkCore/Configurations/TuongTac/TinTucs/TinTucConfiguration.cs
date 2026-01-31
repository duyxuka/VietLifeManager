using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.TuongTac.LienHes;
using VietLife.TuongTac.TinTucs;

namespace VietLife.Configurations.TuongTac.TinTucs
{
    public class TinTucConfiguration : IEntityTypeConfiguration<TinTuc>
    {
        public void Configure(EntityTypeBuilder<TinTuc> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "TinTucs");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TieuDe)
                   .IsRequired()
                   .HasMaxLength(255);
        }
    }
}
