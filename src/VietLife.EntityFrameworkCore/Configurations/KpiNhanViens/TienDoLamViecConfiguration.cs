using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.KPINhanViens;

namespace VietLife.Configurations.KpiNhanViens
{
    public class TienDoLamViecConfiguration : IEntityTypeConfiguration<TienDoLamViec>
    {
        public void Configure(EntityTypeBuilder<TienDoLamViec> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "TienDoLamViecs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NgayCapNhat).IsRequired();
            builder.Property(x => x.GhiChu).HasMaxLength(500);

            builder.HasOne(x => x.KpiNhanVien).WithMany(x => x.TienDoLamViecs).HasForeignKey(x => x.KpiNhanVienId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
