using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Business.NhapXuats.PhieuNhapXuats
{
    public class PhieuNhapXuatInListDto : EntityDto<Guid>
    {
        public string MaPhieu { get; set; }
        public string LoaiNhapXuatTen { get; set; }
        public string KhoTen { get; set; }
        public string KhoDenTen { get; set; }
        public DateTime NgayLap { get; set; }
        public string TenNhanVienLap { get; set; }
    }
}
