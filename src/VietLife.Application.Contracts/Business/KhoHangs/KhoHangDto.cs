using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Business.KhoHangs
{
    public class KhoHangDto : IEntityDto<Guid>
    {
        public Guid Id { get; set; }

        public string TenKho { get; set; }
        public string DiaChi { get; set; }

        public Guid? ThanhPhoId { get; set; }
        public string TenThanhPho { get; set; }
    }
}
