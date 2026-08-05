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
    public class SEOConfiguration : IEntityTypeConfiguration<SeoConfig>
    {
        public void Configure(EntityTypeBuilder<SeoConfig> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "SeoConfig");
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.PageKey).IsUnique();
            builder.Property(x => x.PageKey).IsRequired().HasMaxLength(100);
            builder.Property(x => x.SeoTitle).IsRequired().HasMaxLength(200);
            builder.Property(x => x.SeoKeywords).HasMaxLength(500);
            builder.Property(x => x.SeoDescription).HasMaxLength(1000);
            builder.Property(x => x.CanonicalUrl).HasMaxLength(500);
        }
    }
}
