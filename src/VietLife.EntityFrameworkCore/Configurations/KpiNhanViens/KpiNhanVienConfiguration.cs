using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.KPINhanViens;
using VietLife.NhanViens;

namespace VietLife.Configurations.KpiNhanViens
{
    public class KpiNhanVienConfiguration : IEntityTypeConfiguration<KpiNhanVien>
    {
        public void Configure(EntityTypeBuilder<KpiNhanVien> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "KpiNhanViens");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MucXepLoai).HasMaxLength(255);
            builder.Property(x => x.DiemKpi).HasColumnType("decimal(5,2)");

            builder.HasOne<NhanVien>(x => x.NhanVien)
                   .WithMany(x => x.KpiNhanViens)
                   .HasForeignKey(x => x.NhanVienId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
