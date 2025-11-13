using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Business.DonHangsList.DonHangs
{
    public class DonHangInListDto : EntityDto<Guid>
    {
        public string MaDonHang { get; set; }
        public string MaDonHangGoc { get; set; }
        public DateTime NgayDatHang { get; set; }
        public decimal TongTien { get; set; }
    }
}
