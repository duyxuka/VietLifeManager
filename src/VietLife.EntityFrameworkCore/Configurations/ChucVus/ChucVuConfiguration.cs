using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Chucvus;

namespace VietLife.Configurations.ChucVus
{
    public class ChucVuConfiguration : IEntityTypeConfiguration<ChucVu>
    {
        public void Configure(EntityTypeBuilder<ChucVu> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "ChucVus");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TenChucVu)
                   .IsRequired()
                   .HasMaxLength(255);
        }
    }
}
