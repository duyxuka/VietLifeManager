using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Business.ThuChisList.LoaiThuChis
{
    public class LoaiThuChiDto : IEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string Ten { get; set; }
        public bool IsThu { get; set; }
        public string MoTa { get; set; }
    }
}
