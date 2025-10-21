using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.NhanViens;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.KPINhanViens
{
    public class KpiNhanVien : FullAuditedAggregateRoot<Guid>
    {
        public Guid NhanVienId { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public decimal? MucLuongKpi { get; set; }  // Mức lương KPI riêng của nhân viên
        public decimal? PhanTramHoanThanh { get; set; }  // Phần trăm hoàn thành (dùng để tính thưởng: ThuongKpi = MucLuongKpi * PhanTramHoanThanh / 100)
        public decimal? DiemKpi { get; set; }
        public string MucXepLoai { get; set; }  // Ví dụ: "A", "B", "C"
        public decimal? ThuongKpi { get; set; }  // Thưởng KPI tính toán
        public Guid? NguoiDanhGiaId { get; set; }
        public string GhiChu { get; set; }

        public virtual NhanVien NhanVien { get; set; }
        public virtual ICollection<KeHoachCongViec> KeHoachCongViecs { get; set; }  // Kế hoạch công việc
        public virtual ICollection<MucTieuKpi> MucTieuKpis { get; set; }  // Mục tiêu KPI
        public virtual ICollection<TienDoLamViec> TienDoLamViecs { get; set; }  // Tiến độ làm việc
        public virtual ICollection<DanhGiaKpi> DanhGiaKpis { get; set; }
    }
}
