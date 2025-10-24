using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Catalog.KPIs.MucTieuKpis
{
    public class CreateUpdateMucTieuKpiDto
    {
        public Guid KpiNhanVienId { get; set; }
        public Guid? KeHoachCongViecId { get; set; }
        public string TenMucTieu { get; set; }
        public decimal? GiaTriMucTieu { get; set; }  // Giá trị mục tiêu
        public decimal? GiaTriThucHien { get; set; }  // Giá trị thực tế đạt được
        public string DonVi { get; set; }  // Đơn vị đo lường
        public decimal TrongSo { get; set; }  // Trọng số của mục tiêu trong KPI
    }
}
