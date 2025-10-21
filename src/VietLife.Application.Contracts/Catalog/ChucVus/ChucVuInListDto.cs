using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Catalog.ChucVus
{
    public class ChucVuInListDto : EntityDto<Guid>
    {
        public string TenChucVu { get; set; }
        public string MoTa { get; set; }
    }
}
