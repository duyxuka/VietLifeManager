using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.ThuChis;
using Volo.Abp.Application.Dtos;

namespace VietLife.Business.ThuChisList.ThuChis
{
    public class ThuChiInListDto : EntityDto<Guid>
    {
        public string MaPhieu { get; set; }
        public DateTime NgayGiaoDich { get; set; }
        public decimal SoTien { get; set; }
        public string LoaiThuChiTen { get; set; }
        public ThuChiStatus Status { get; set; }
    }
}
