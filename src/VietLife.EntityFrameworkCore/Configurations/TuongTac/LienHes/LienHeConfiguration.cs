using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.TuongTac.LienHes;

namespace VietLife.Configurations.TuongTac.LienHes
{
    public class LienHeConfiguration : IEntityTypeConfiguration<LienHe>
    {
        public void Configure(EntityTypeBuilder<LienHe> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "LienHes");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.HoVaTen)
                   .IsRequired()
                   .HasMaxLength(255);
            builder.Property(x => x.SoDienThoai)
                   .IsRequired()
                   .HasMaxLength(255);
        }
    }
}
