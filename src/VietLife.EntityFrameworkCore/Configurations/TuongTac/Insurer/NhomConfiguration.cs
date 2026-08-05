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
    public class NhomConfiguration : IEntityTypeConfiguration<Nhom>
    {
        public void Configure(EntityTypeBuilder<Nhom> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "Nhoms");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Ten).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(120);
            builder.Property(x => x.MoTa).HasMaxLength(500);
            builder.Property(x => x.LogoUrl).HasMaxLength(200);
            builder.HasIndex(x => new { x.DanhMucId, x.Slug }).IsUnique();

            builder.HasMany(x => x.SanPhams)
                .WithOne(x => x.Nhom)
                .HasForeignKey(x => x.NhomId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.BaiViets)
                .WithOne(x => x.Nhom)
                .HasForeignKey(x => x.NhomId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
