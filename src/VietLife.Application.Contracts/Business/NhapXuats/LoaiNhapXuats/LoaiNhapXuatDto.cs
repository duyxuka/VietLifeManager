using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Business.NhapXuats.LoaiNhapXuats
{
    public class LoaiNhapXuatDto : IEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string TenLoai { get; set; }
        public int KieuNhapXuat { get; set; }
        public bool TangGiamTon { get; set; }
    }
}
