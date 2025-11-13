using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Business.TienTes
{
    public class TienTeInListDto : EntityDto<Guid>
    {
        public string TenTienTe { get; set; }
        public string MaTienTe { get; set; }
        public decimal TyGia { get; set; } = 1;
        public bool MacDinh { get; set; } = false;
    }
}
