using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.PhongBans;

namespace VietLife.Configurations.PhongBans
{
    public class PhongBanConfiguration : IEntityTypeConfiguration<PhongBan>
    {
        public void Configure(EntityTypeBuilder<PhongBan> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "PhongBans");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TenPhongBan)
                   .IsRequired()
                   .HasMaxLength(255);
        }
    }
}
