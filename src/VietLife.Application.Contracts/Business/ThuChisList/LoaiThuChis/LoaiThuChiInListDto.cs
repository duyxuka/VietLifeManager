using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Business.ThuChisList.LoaiThuChis
{
    public class LoaiThuChiInListDto : EntityDto<Guid>
    {
        public string Ten { get; set; }
        public bool IsThu { get; set; } // true = Thu, false = Chi
        public string MoTa { get; set; }
    }
}
