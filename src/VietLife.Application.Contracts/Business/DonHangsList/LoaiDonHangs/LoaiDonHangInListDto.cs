using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Business.DonHangsList.LoaiDonHangs
{
    public class LoaiDonHangInListDto : EntityDto<Guid>
    {
        public string TenLoai { get; set; }
        public bool HieuLuc { get; set; }
        public bool TuDongXuatKho { get; set; }
    }
}
