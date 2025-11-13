using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.NhanViens;
using Volo.Abp.Domain.Entities.Auditing;

namespace VietLife.Catalog.CheDoNhanViens
{
    public class CheDoNhanVien : FullAuditedAggregateRoot<Guid>
    {
        public Guid NhanVienId { get; set; }
        public Guid LoaiCheDoId { get; set; }
        public bool TrangThai { get; set; }
        public Guid? NguoiDuyetId { get; set; }
        public decimal? SoNgay { get; set; }
        public decimal? SoCong { get; set; }
        public decimal? ThanhTien { get; set; }
        public string LyDo { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string GhiChu { get; set; }

        public virtual NhanVien NhanVien { get; set; }
        public virtual LoaiCheDo LoaiCheDo { get; set; }
        public void TinhThanhTien(HopDongNhanVien hopDongHienHanh)
        {
            if (LoaiCheDo == null || hopDongHienHanh == null)
            {
                ThanhTien = 0;
                return;
            }

            var donGiaCong = hopDongHienHanh.DonGiaCong;
            var heSoCong = LoaiCheDo.HeSoCong;

            // ƯU TIÊN: Dùng SoCong nếu có (tăng ca, làm thêm)
            if (SoCong.HasValue && SoCong.Value > 0)
            {
                ThanhTien = SoCong.Value * donGiaCong * heSoCong;
            }
            // Dùng SoNgay nếu không có SoCong (nghỉ phép, nghỉ không lương)
            else if (SoNgay.HasValue && SoNgay.Value > 0)
            {
                ThanhTien = SoNgay.Value * donGiaCong * heSoCong;
            }
            else
            {
                ThanhTien = 0;
            }
        }

        // Overload: dùng khi đã có donGiaCong
        public void TinhThanhTien(decimal donGiaCong)
        {
            if (LoaiCheDo == null)
            {
                ThanhTien = 0;
                return;
            }

            var heSoCong = LoaiCheDo.HeSoCong;

            if (SoCong.HasValue && SoCong.Value > 0)
            {
                ThanhTien = SoCong.Value * donGiaCong * heSoCong;
            }
            else if (SoNgay.HasValue && SoNgay.Value > 0)
            {
                ThanhTien = SoNgay.Value * donGiaCong * heSoCong;
            }
            else
            {
                ThanhTien = 0;
            }
        }
    }

}
