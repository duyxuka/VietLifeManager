using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Catalog.PhongBans
{
    public class PhongBanInListDto : EntityDto<Guid>
    {
        public string TenPhongBan { get; set; }
        public string MoTa { get; set; }
        public Guid? TruongPhongId { get; set; }
        public string TruongPhongTen { get; set; }
    }
}
