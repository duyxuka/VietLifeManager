using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.NhanViens;

namespace VietLife.Configurations.Catalog.NhanViens
{
    public class LoaiHopDongConfiguration : IEntityTypeConfiguration<LoaiHopDong>
    {
        public void Configure(EntityTypeBuilder<LoaiHopDong> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "LoaiHopDongs");

            builder.HasKey(x => x.Id);

            // === Cấu hình độ dài và bắt buộc ===
            builder.Property(x => x.TenLoai)
                   .IsRequired()
                   .HasMaxLength(100);

            // === Cấu hình cột mặc định ===
            builder.Property(x => x.MacDinh)
                   .HasDefaultValue(false);
        }
    }
}
