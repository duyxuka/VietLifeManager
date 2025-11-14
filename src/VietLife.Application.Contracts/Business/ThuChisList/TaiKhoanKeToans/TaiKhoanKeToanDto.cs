using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.Business.ThuChisList.TaiKhoanKeToans
{
    public class TaiKhoanKeToanDto : IEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public string SoTaiKhoan { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MoTa { get; set; }
    }
}
