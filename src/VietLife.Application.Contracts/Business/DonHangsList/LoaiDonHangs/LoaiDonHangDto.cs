using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Business.DonHangsList.LoaiDonHangs
{
    public class LoaiDonHangDto : IEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string TenLoai { get; set; }
        public bool HieuLuc { get; set; }
        public bool TuDongXuatKho { get; set; }
    }
}
