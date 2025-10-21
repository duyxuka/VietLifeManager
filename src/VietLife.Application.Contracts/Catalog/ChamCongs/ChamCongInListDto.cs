using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Catalog.ChamCongs
{
    public class ChamCongInListDto : EntityDto<Guid>
    {
        public Guid NhanVienId { get; set; }
        public DateTime NgayLam { get; set; }
        public DateTime? GioVao { get; set; }
        public DateTime? GioRa { get; set; }
        public decimal? SoGioLam { get; set; }
        public decimal? SoPhutDiMuon { get; set; }
        public decimal? SoPhutVeSom { get; set; }
        public decimal? CongNgay { get; set; }
        public bool TrangThai { get; set; }
        public string TenNhanVien { get; set; }
    }
}
