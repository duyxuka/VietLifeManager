using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.NhanViens;
using VietLife.Catalog.CheDoNhanViens;

namespace VietLife.Configurations.CheDoNhanViens
{
    public class CheDoNhanVienConfiguration : IEntityTypeConfiguration<CheDoNhanVien>
    {
        public void Configure(EntityTypeBuilder<CheDoNhanVien> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "CheDoNhanViens");

            builder.HasKey(x => x.Id);

            builder.HasOne<NhanVien>(x => x.NhanVien)
                   .WithMany(u => u.CheDoNhanViens)
                   .HasForeignKey(x => x.NhanVienId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<LoaiCheDo>(x => x.LoaiCheDo)
                   .WithMany(u => u.CheDoNhanViens)
                   .HasForeignKey(x => x.LoaiCheDoId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
