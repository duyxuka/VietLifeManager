using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.ThuChis;

namespace VietLife.Configurations.Business.ThuChis
{
    public class LoaiThuChiConfiguration : IEntityTypeConfiguration<LoaiThuChi>
    {
        public void Configure(EntityTypeBuilder<LoaiThuChi> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "LoaiThuChis");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Ten)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.MoTa)
                .HasMaxLength(500);
        }
    }
}
