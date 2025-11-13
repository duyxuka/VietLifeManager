using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Business.TienTes
{
    public class TienTeDto : IEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string TenTienTe { get; set; }
        public string MaTienTe { get; set; }
        public decimal TyGia { get; set; } = 1;
        public bool MacDinh { get; set; } = false;
    }
}
