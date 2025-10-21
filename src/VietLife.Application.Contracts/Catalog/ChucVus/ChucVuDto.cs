using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Catalog.ChucVus
{
    public class ChucVuDto : IEntityDto<Guid>
    {
        public string TenChucVu { get; set; }
        public string MoTa { get; set; }
        public Guid Id { get; set; }
    }
}
