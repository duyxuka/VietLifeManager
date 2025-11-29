using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Business.ThanhPhos
{
    public class ThanhPhoInListDto : EntityDto<Guid>
    {
        public string Ten { get; set; }
        public string MaVung { get; set; }
        public int KhoHangCount { get; set; }
        public int KhachHangCount { get; set; }
    }
}
