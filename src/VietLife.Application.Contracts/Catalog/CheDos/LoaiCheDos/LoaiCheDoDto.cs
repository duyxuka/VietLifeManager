using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Catalog.CheDos.LoaiCheDos
{
    public class LoaiCheDoDto : IEntityDto<Guid>
    {
        public string TenLoaiCheDo { get; set; }
        public decimal HeSoCong { get; set; }
        public string MoTa { get; set; }
        public Guid Id { get; set; }
    }
}
