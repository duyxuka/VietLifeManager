using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.KPINhanViens;

namespace VietLife.Configurations.KpiNhanViens
{
    public class KeHoachCongViecConfiguration : IEntityTypeConfiguration<KeHoachCongViec>
    {
        public void Configure(EntityTypeBuilder<KeHoachCongViec> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "KeHoachCongViecs");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.TenKeHoach).IsRequired().HasMaxLength(100);
            builder.Property(x => x.MoTa).HasMaxLength(500);
            builder.Property(x => x.TrongSo).IsRequired();

            builder.HasOne(x => x.KpiNhanVien).WithMany(x => x.KeHoachCongViecs).HasForeignKey(x => x.KpiNhanVienId).OnDelete(DeleteBehavior.Restrict); ;
        }
    }
}
