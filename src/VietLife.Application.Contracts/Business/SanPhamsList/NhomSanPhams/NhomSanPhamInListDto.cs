using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Business.SanPhamsList.NhomSanPhams
{
    public class NhomSanPhamInListDto : EntityDto<Guid>
    {
        public string TenNhom { get; set; }
        public string MaNhom { get; set; }
        public bool HieuLuc { get; set; }
    }
}
