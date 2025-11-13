using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Business.ThiChis
{
    public class ThuChiDto : IEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string MaPhieu { get; set; }
        public bool LaThu { get; set; } // true = thu, false = chi
        public Guid? KhachHangId { get; set; }
        public decimal SoTien { get; set; }
        public DateTime NgayGiaoDich { get; set; }
        public int? TaiKhoanNoId { get; set; }
        public int? TaiKhoanCoId { get; set; }
    }
}
