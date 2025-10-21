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
    public class MucTieuKpiConfiguration : IEntityTypeConfiguration<MucTieuKpi>
    {
        public void Configure(EntityTypeBuilder<MucTieuKpi> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "MucTieuKpis");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TenMucTieu).IsRequired().HasMaxLength(250);
            builder.Property(x => x.DonVi).HasMaxLength(50);
            builder.Property(x => x.TrongSo).IsRequired();

            builder.HasOne(x => x.KpiNhanVien).WithMany(x => x.MucTieuKpis).HasForeignKey(x => x.KpiNhanVienId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
