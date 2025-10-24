using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Catalog.KPIs.KpiNhanViens
{
    public class CreateUpdateKpiNhanVienDto
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
    }
}
