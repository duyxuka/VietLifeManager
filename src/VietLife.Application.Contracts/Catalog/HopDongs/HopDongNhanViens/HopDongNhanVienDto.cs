using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Catalog.HopDongs.HopDongNhanViens
{
    public class HopDongNhanVienDto : IEntityDto<Guid>
    {
        public Guid Id { get; set; }

        // === NHÂN VIÊN ===
        public Guid NhanVienId { get; set; }
        public string TenNhanVien { get; set; }

        // === THÔNG TIN HỢP ĐỒNG ===
        public string MaHopDong { get; set; }
        public Guid LoaiHopDongId { get; set; }
        public string TenLoaiHopDong { get; set; }

        public DateTime NgayKy { get; set; }
        public DateTime NgayHieuLuc { get; set; }
        public DateTime? NgayHetHan { get; set; }

        public int? SoThang { get; set; }
        public decimal LuongCoBan { get; set; }
        public decimal DonGiaCong { get; set; }

        public string TrangThai { get; set; }
        public Guid? NguoiDuyetId { get; set; }
        public string TenNguoiDuyet { get; set; }

        public DateTime? NgayDuyet { get; set; }
        public string GhiChu { get; set; }
        public bool LaHienHanh { get; set; }
    }
}
