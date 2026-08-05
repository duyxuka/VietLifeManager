using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.TuongTac.Insurer;

namespace VietLife.Configurations.TuongTac.Insurer
{
    public class SanPhamInsurerConfiguration : IEntityTypeConfiguration<SanPhamInsurer>
    {
        public void Configure(EntityTypeBuilder<SanPhamInsurer> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "SanPhamInsurers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ten).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(180);
            builder.Property(x => x.QuyenLoi).HasColumnType("nvarchar(max)");
            builder.Property(x => x.BieuPhi).HasColumnType("nvarchar(max)");
            builder.Property(x => x.TaiLieu).HasColumnType("nvarchar(max)");
            builder.Property(x => x.KhuyenMai).HasColumnType("nvarchar(max)");
            builder.Property(x => x.DangKy).HasColumnType("nvarchar(max)");
            builder.HasIndex(x => x.Slug).IsUnique();
        }
    }
}
