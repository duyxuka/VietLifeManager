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
    public class DanhGiaKpiConfiguration : IEntityTypeConfiguration<DanhGiaKpi>
    {
        public void Configure(EntityTypeBuilder<DanhGiaKpi> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "DanhGiaKpis");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.NhanXet).HasMaxLength(500);

            builder.HasOne(x => x.KpiNhanVien).WithMany(x => x.DanhGiaKpis).HasForeignKey(x => x.KpiNhanVienId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}
