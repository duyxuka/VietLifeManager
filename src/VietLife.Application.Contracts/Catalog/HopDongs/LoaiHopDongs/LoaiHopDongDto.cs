using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Catalog.HopDongs.LoaiHopDongs
{
    public class LoaiHopDongDto : IEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string TenLoai { get; set; } // Chính thức, Thử việc, Thời vụ
        public int? SoThangMacDinh { get; set; }
        public bool MacDinh { get; set; }
    }
}
