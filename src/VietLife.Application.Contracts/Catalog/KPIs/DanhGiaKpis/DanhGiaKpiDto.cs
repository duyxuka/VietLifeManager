using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Catalog.KPIs.DanhGiaKpis
{
    public class DanhGiaKpiDto : IEntityDto<Guid>
    {
        public Guid KpiNhanVienId { get; set; }
        public decimal? DiemDanhGia { get; set; }
        public string NhanXet { get; set; }
        public Guid? NguoiDanhGiaId { get; set; }
        public Guid Id { get; set; }
    }
}
