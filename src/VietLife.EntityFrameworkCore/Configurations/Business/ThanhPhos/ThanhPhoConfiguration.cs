using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.ThanhPhos;

namespace VietLife.Configurations.Business.ThanhPhos
{
    public class ThanhPhoConfiguration : IEntityTypeConfiguration<ThanhPho>
    {
        public void Configure(EntityTypeBuilder<ThanhPho> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "ThanhPhos");

            builder.HasKey(x => x.Id);

            // === Thuộc tính ===
            builder.Property(x => x.Ten)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.MaVung)
                   .IsRequired()
                   .HasMaxLength(10);
        }
    }
}
