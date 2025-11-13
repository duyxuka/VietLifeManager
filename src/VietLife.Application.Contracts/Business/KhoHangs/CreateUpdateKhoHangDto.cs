using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Business.KhoHangs
{
    public class CreateUpdateKhoHangDto
    {
        public string TenKho { get; set; }
        public string DiaChi { get; set; }
        public Guid? ThanhPhoId { get; set; }
    }
}
