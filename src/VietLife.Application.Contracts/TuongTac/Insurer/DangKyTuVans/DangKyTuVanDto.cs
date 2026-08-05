using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace VietLife.TuongTac.Insurer.DangKyTuVans
{
    public class DangKyTuVanDto : IEntityDto<Guid>
    {
        public Guid Id { get; set; }
        public Guid? NhomId { get; set; }
        public Guid? SanPhamId { get; set; }
        public string SanPhamTen { get; set; }
        public string NhomTen { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
    }

    public class DangKyTuVanInListDto : EntityDto<Guid>
    {
        public Guid? NhomId { get; set; }
        public string NhomTen { get; set; }
        public Guid? SanPhamId { get; set; }
        public string SanPhamTen { get; set; }

        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public DateTime CreationTime { get; set; }
    }

    public class CreateUpdateDangKyTuVanDto
    {
        public Guid? SanPhamId { get; set; }
        public Guid? NhomId { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
    }
}
