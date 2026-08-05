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
    public class DanhMucConfiguration : IEntityTypeConfiguration<DanhMuc>
    {
        public void Configure(EntityTypeBuilder<DanhMuc> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "DanhMucs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ten).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(120);
            builder.Property(x => x.MoTa).HasMaxLength(500);
            builder.Property(x => x.AnhMenu).HasMaxLength(200);
            builder.HasIndex(x => x.Slug).IsUnique();

            builder.HasMany(x => x.Nhoms)
                .WithOne(x => x.DanhMuc)
                .HasForeignKey(x => x.DanhMucId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
