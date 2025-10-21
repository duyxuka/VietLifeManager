using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Catalog.PhongBans
{
    public class PhongBanDto : IEntityDto<Guid>
    {
        public string TenPhongBan { get; set; }
        public string MoTa { get; set; }
        public Guid? TruongPhongId { get; set; }
        public Guid Id { get; set; }
    }
}
