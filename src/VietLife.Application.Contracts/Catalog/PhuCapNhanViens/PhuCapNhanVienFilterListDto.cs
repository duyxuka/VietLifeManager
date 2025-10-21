using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Catalog.PhuCapNhanViens
{
    public class PhuCapNhanVienFilterListDto : BaseListFilterDto
    {
        public Guid? ChucVuId { get; set; }
    }
}
