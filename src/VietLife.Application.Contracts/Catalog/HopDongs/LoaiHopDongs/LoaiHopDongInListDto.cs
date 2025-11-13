using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Catalog.HopDongs.LoaiHopDongs
{
    public class LoaiHopDongInListDto : EntityDto<Guid>
    {
        public string TenLoai { get; set; }
        public int? SoThangMacDinh { get; set; }
        public bool MacDinh { get; set; }
    }
}
