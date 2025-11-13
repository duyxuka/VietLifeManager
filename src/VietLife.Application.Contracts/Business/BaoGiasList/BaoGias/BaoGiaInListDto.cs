using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Business.BaoGiasList.BaoGias
{
    public class BaoGiaInListDto : EntityDto<Guid>
    {
        public string MaBaoGia { get; set; }
        public string TieuDe { get; set; }
        public decimal TongTien { get; set; }
        public bool DaChuyenDonHang { get; set; }
    }
}
