using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.ChiNhanhs;
using VietLife.NhanViens;
using VietLife.PhongBans;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.CheDoNhanViens
{
    public class CheDoNhanVien : FullAuditedAggregateRoot<Guid>
    {
        public Guid NhanVienId { get; set; }
        public Guid LoaiCheDoId { get; set; }  
        public bool TrangThai { get; set; } 
        public Guid? NguoiDuyetId { get; set; } 
        public decimal? SoNgay { get; set; } 
        public decimal? SoCong { get; set; }  
        public decimal? ThanhTien { get; set; }  
        public string LyDo { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string GhiChu { get; set; }

        public virtual NhanVien NhanVien { get; set; }
        public virtual LoaiCheDo LoaiCheDo { get; set; }
    }
}
