using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Catalog.HopDongs.HopDongNhanViens
{
    public class HopDongNhanVienInListDto : EntityDto<Guid>
    {
        public Guid NhanVienId { get; set; }
        public string TenNhanVien { get; set; }
        public string MaHopDong { get; set; }
        public Guid LoaiHopDongId { get; set; }
        public string TenLoaiHopDong { get; set; }

        public DateTime NgayKy { get; set; }
        public DateTime NgayHieuLuc { get; set; }
        public DateTime? NgayHetHan { get; set; }

        public decimal LuongCoBan { get; set; }
        public string TrangThai { get; set; }
        public bool LaHienHanh { get; set; }
    }

}
