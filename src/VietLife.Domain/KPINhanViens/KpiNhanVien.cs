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
        public KpiNhanVien()
        {
            KeHoachCongViecs = new HashSet<KeHoachCongViec>();
            MucTieuKpis = new HashSet<MucTieuKpi>();
            TienDoLamViecs = new HashSet<TienDoLamViec>();
            DanhGiaKpis = new HashSet<DanhGiaKpi>();
        }

        // Method tính ThuongKpi
        public void TinhPhanTramHoanThanh(decimal tongTrongSo, decimal tongDiem)
        {
            if (tongTrongSo == 0)
                PhanTramHoanThanh = 0;
            else
                PhanTramHoanThanh = (tongDiem / tongTrongSo) * 100;
        }

        public void TinhThuongKpi()
        {
            if (MucLuongKpi > 0 && PhanTramHoanThanh > 0)
                ThuongKpi = MucLuongKpi * (PhanTramHoanThanh / 100);
            else
                ThuongKpi = 0;
        }
    }
}
