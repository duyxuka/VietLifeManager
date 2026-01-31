using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.TuongTac.TinTucs
{
    public class TinTucInListDto : EntityDto<Guid>
    {
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayDang { get; set; }
        public string Anh { get; set; }
        public bool TrangThai { get; set; }
    }
}
