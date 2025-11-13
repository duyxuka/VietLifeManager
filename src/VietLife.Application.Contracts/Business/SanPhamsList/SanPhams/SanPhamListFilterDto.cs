using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Business.SanPhamsList.SanPhams
{
    public class SanPhamListFilterDto : BaseListFilterDto
    {
        public Guid? NhomSanPhamId { get; set; }
    }
}
