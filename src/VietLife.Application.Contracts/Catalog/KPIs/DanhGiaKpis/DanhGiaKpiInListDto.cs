using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Catalog.KPIs.DanhGiaKpis
{
    public class DanhGiaKpiInListDto : EntityDto<Guid>
    {
        public Guid KpiNhanVienId { get; set; }
        public decimal? DiemDanhGia { get; set; }
        public string NhanXet { get; set; }
        public Guid? NguoiDanhGiaId { get; set; }
        public string TenKpi { get; set; }
        public string TenNhanVien { get; set; }
        public string TenNguoiDanhGia { get; set; }

    }
}
