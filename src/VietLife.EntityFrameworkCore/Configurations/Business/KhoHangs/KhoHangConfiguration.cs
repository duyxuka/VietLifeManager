using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.KhoHangs;

namespace VietLife.Configurations.Business.KhoHangs
{
    public class KhoHangConfiguration : IEntityTypeConfiguration<KhoHang>
    {
        public void Configure(EntityTypeBuilder<KhoHang> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "KhoHangs");

            builder.HasKey(x => x.Id);

            // === Thuộc tính cơ bản ===
            builder.Property(x => x.TenKho)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(x => x.DiaChi)
                   .HasMaxLength(500);

            // === Quan hệ với Thành Phố ===
            builder.HasOne(x => x.ThanhPho)
                   .WithMany(tp => tp.KhoHangs)
                   .HasForeignKey(x => x.ThanhPhoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
