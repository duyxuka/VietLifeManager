using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VietLife.Catalog.LichLamViecs
{
    public class CreateUpdateLichLamViecDto
    {
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string NgayLam { get; set; }  // Chuỗi ngày làm việc, ví dụ: "1,2,3,...,31" (dùng để parse)
        public string NgayNghi { get; set; }  // Chuỗi ngày nghỉ, ví dụ: "5,12,19,26" (Chủ Nhật, lễ)
        public string CaLamMacDinh { get; set; }  // Ca làm mặc định (ví dụ: "Sáng", "Chiều", "Full")
        public TimeSpan? GioBatDauMacDinh { get; set; }  // Giờ bắt đầu mặc định
        public TimeSpan? GioKetThucMacDinh { get; set; }  // Giờ kết thúc mặc định
        public string GhiChu { get; set; }
    }
}
