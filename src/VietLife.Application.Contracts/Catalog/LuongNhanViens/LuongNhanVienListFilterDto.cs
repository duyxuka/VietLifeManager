using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Catalog.LuongNhanViens
{
    public class LuongNhanVienListFilterDto : BaseListFilterDto
    {
        public Guid? NhanVienId { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
    }
}
