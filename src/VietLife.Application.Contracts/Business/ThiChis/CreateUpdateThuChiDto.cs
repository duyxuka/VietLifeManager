using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Business.ThiChis
{
    public class CreateUpdateThuChiDto
    {
        public string MaPhieu { get; set; }
        public bool LaThu { get; set; }
        public Guid? KhachHangId { get; set; }
        public decimal SoTien { get; set; }
        public DateTime NgayGiaoDich { get; set; }
        public int? TaiKhoanNoId { get; set; }
        public int? TaiKhoanCoId { get; set; }
    }
}
