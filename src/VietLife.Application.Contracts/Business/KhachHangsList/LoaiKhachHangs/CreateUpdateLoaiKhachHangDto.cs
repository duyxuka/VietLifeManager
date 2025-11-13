using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Business.KhachHangsList.LoaiKhachHangs
{
    public class CreateUpdateLoaiKhachHangDto
    {
        public string Ten { get; set; }
        public string MoTa { get; set; }
        public bool HieuLuc { get; set; } = true;
    }
}
