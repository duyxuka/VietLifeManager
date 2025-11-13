using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.NhanViens;
using VietLife.Catalog.ChamCongs;

namespace VietLife.Configurations.Catalog.ChamCongs
{
    public class ChamCongConfiguration : IEntityTypeConfiguration<ChamCong>
    {
        public void Configure(EntityTypeBuilder<ChamCong> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "ChamCongs");
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.NhanVien)
                   .WithMany(u => u.ChamCongs)
                   .HasForeignKey(x => x.NhanVienId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
