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
    public class ThuChiConfiguration : IEntityTypeConfiguration<ThuChi>
    {
        public void Configure(EntityTypeBuilder<ThuChi> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "ThuChis");

            builder.HasKey(x => x.Id);

            // === Cấu hình thuộc tính ===
            builder.Property(x => x.MaPhieu)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.SoTien)
                   .HasPrecision(18, 2);

            builder.Property(x => x.NgayGiaoDich)
                   .IsRequired();

            builder.Property(x => x.LaThu)
                   .IsRequired()
                   .HasDefaultValue(true);

            // === Quan hệ với KhachHang ===
            builder.HasOne(x => x.KhachHang)
                   .WithMany(u => u.ThuChis)  // Nếu KhachHang có ICollection<ThuChi>
                   .HasForeignKey(x => x.KhachHangId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
