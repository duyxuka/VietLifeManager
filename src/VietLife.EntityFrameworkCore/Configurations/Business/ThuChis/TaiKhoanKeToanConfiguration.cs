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
    public class TaiKhoanKeToanConfiguration : IEntityTypeConfiguration<TaiKhoanKeToan>
    {
        public void Configure(EntityTypeBuilder<TaiKhoanKeToan> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "TaiKhoanKeToans");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.SoTaiKhoan)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.TenTaiKhoan)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.MoTa)
                .HasMaxLength(500);
        }
    }
}
