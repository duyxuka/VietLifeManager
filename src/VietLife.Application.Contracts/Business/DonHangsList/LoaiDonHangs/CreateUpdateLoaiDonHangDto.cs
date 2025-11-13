using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Business.DonHangsList.LoaiDonHangs
{
    public class CreateUpdateLoaiDonHangDto
    {
        public string TenLoai { get; set; }
        public bool HieuLuc { get; set; } = true;
        public bool TuDongXuatKho { get; set; } = false;
    }
}
