using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Catalog.CheDos.CheDoNhanViens
{
    public class CheDoNhanVienListFilterDto : BaseListFilterDto
    {
        public Guid? NhanVienId { get; set; }
    }
}
