using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.TuongTac.TinTucs
{
    public class TinTuc : FullAuditedAggregateRoot<Guid>
    {
        public TinTuc(Guid id, string tieuDe, string noiDung, DateTime ngayDang, bool trangThai) : base(id)
        {
            TieuDe = tieuDe;
            NoiDung = noiDung;
            NgayDang = ngayDang;
            TrangThai = trangThai;
        }

        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayDang { get; set; }
        public string Anh { get; set; }
        public bool TrangThai { get; set; }
    }
}
