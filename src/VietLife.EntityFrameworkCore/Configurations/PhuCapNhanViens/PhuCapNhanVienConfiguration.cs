using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.PhuCapNhanViens;
using VietLife.Chucvus;

namespace VietLife.Configurations.PhuCapNhanViens
{
    public class PhuCapNhanVienConfiguration : IEntityTypeConfiguration<PhuCapNhanVien>
    {
        public void Configure(EntityTypeBuilder<PhuCapNhanVien> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "PhuCapNhanViens");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.TenPhuCap)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.SoTien)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.HasOne<ChucVu>(x => x.ChucVu)
                   .WithMany(u => u.PhuCapNhanViens)
                   .HasForeignKey(x => x.ChucVuId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
