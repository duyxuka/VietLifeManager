using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Catalog.ChiNhanhs
{
    public class ChiNhanhDto : IEntityDto<Guid>
    {
        public string TenChiNhanh { get; set; }
        public string MoTa { get; set; }
        public Guid Id { get; set; }
    }
}
