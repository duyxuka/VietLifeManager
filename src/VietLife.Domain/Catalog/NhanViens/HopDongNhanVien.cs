using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.Catalog.NhanViens
{
    public class HopDongNhanVien : FullAuditedAggregateRoot<Guid>
    {
        // === NHÂN VIÊN ===
        public Guid NhanVienId { get; set; }
        public virtual NhanVien NhanVien { get; set; }

        // === THÔNG TIN HỢP ĐỒNG ===
        public string MaHopDong { get; set; } // HDLD-2025-001

        public Guid LoaiHopDongId { get; set; }
        public virtual LoaiHopDong LoaiHopDong { get; set; }

        public DateTime NgayKy { get; set; }
        public DateTime NgayHieuLuc { get; set; }
        public DateTime? NgayHetHan { get; set; }

        //[Comment("Số tháng hợp đồng")]
        public int? SoThang { get; set; }

        //[Comment("Lương cơ bản trong hợp đồng")]
        public decimal LuongCoBan { get; set; }

        //[Comment("Đơn giá công ngày")]
        public decimal DonGiaCong { get; set; }

        //[Comment("Trạng thái: Chờ duyệt, Đã duyệt, Từ chối, Hết hạn")]
        public string TrangThai { get; set; } = "Chờ duyệt";

        public Guid? NguoiDuyetId { get; set; }
        public virtual NhanVien NguoiDuyet { get; set; }
        public DateTime? NgayDuyet { get; set; }
        public string GhiChu { get; set; }
        //[Comment("Là hợp đồng hiện hành không?")]
        public bool LaHienHanh { get; set; } = false;
    }
}
