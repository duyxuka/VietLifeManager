using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.NhanViens;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.Catalog.ChamCongs
{
    public class ChamCong : FullAuditedAggregateRoot<Guid>
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

        public virtual NhanVien NhanVien { get; set; }

        public void TinhCongNgay(TimeSpan gioLamChuan = default) // gioLamChuan mặc định 8 giờ
        {
            if (GioVao.HasValue && GioRa.HasValue)
            {
                var thoiGianLam = GioRa.Value - GioVao.Value;
                SoGioLam = (decimal)thoiGianLam.TotalHours;
                CongNgay = SoGioLam / (gioLamChuan.TotalHours > 0 ? (decimal)gioLamChuan.TotalHours : 8m); // Ví dụ: 8 giờ = 1 công
            }
        }
    }
}
