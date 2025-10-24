using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Catalog.KPIs.KeHoachCongViecs
{
    public class KeHoachCongViecInListDto : EntityDto<Guid>
    {
        public Guid KpiNhanVienId { get; set; }
        public string TenKeHoach { get; set; }
        public string MoTa { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public decimal TrongSo { get; set; }
        public decimal SoMucTieu { get; set; }
        public string TenKpi { get; set; }
        public string TenNhanVien { get; set; }
    }
}
