using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Business.SanPhamsList.DonViTinhs
{
    public class DonViTinhDto : IEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string TenDonVi { get; set; }
        public bool MacDinh { get; set; }
    }
}
