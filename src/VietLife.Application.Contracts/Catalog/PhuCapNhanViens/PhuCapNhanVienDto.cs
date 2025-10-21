using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Catalog.PhuCapNhanViens
{
    public class PhuCapNhanVienDto : IEntityDto<Guid>
    {
        public Guid ChucVuId { get; set; }
        public string TenPhuCap { get; set; }
        public decimal SoTien { get; set; }
        public Guid Id { get; set; }
    }
}
