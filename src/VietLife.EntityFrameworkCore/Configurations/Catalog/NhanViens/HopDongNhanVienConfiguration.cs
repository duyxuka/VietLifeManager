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
    public class HopDongNhanVienConfiguration : IEntityTypeConfiguration<HopDongNhanVien>
    {
        public void Configure(EntityTypeBuilder<HopDongNhanVien> builder)
        {
            builder.ToTable(VietLifeConsts.DbTablePrefix + "HopDongNhanViens");

            builder.HasKey(x => x.Id);

            // === NHÂN VIÊN ký hợp đồng ===
            builder.HasOne(x => x.NhanVien)
                   .WithMany(u => u.HopDongNhanViens)
                   .HasForeignKey(x => x.NhanVienId)
                   .OnDelete(DeleteBehavior.Restrict);

            // === LOẠI HỢP ĐỒNG ===
            builder.HasOne(x => x.LoaiHopDong)
                   .WithMany(u => u.HopDongNhanViens)
                   .HasForeignKey(x => x.LoaiHopDongId)
                   .OnDelete(DeleteBehavior.Restrict);

            // === NGƯỜI DUYỆT ===
            builder.HasOne(x => x.NguoiDuyet)
                   .WithMany()
                   .HasForeignKey(x => x.NguoiDuyetId)
                   .OnDelete(DeleteBehavior.Restrict);

            // === Cấu hình độ dài các trường chuỗi ===
            builder.Property(x => x.MaHopDong)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.TrangThai)
                   .HasMaxLength(50);

            builder.Property(x => x.GhiChu)
                   .HasMaxLength(500);
        }
    }
}
