using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Business.ThiChis
{
    public class ThuChiInListDto : EntityDto<Guid>
    {
        public string MaPhieu { get; set; }
        public bool LaThu { get; set; }
        public Guid? KhachHangId { get; set; }
        public decimal SoTien { get; set; }
        public DateTime NgayGiaoDich { get; set; }
    }
}
