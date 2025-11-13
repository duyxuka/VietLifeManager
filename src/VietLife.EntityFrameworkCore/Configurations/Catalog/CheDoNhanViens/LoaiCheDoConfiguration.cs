using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.CheDoNhanViens;

namespace VietLife.Configurations.Catalog.CheDoNhanViens
{
    public class LoaiCheDoConfiguration : IEntityTypeConfiguration<LoaiCheDo>
    {
        public void Configure(EntityTypeBuilder<LoaiCheDo> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "LoaiCheDos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TenLoaiCheDo)
                   .IsRequired()
                   .HasMaxLength(255);
        }
    }
}
