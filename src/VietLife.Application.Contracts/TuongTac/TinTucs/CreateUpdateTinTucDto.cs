using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.TuongTac.TinTucs
{
    public class CreateUpdateTinTucDto
    {
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public DateTime NgayDang { get; set; }
        public string Anh { get; set; }
        public bool TrangThai { get; set; }
        public string AnhName { get; set; }
        public string AnhContent { get; set; }
    }
}
