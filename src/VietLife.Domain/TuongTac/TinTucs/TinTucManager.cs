using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Guids;
using Volo.Abp;

namespace VietLife.TuongTac.TinTucs
{
    public class TinTucManager : DomainService
    {
        private readonly IRepository<TinTuc, Guid> _tinTucRepository;

        public TinTucManager(IRepository<TinTuc, Guid> tinTucRepository)
        {
            _tinTucRepository = tinTucRepository;
        }

        public async Task<TinTuc> CreateAsync(
            string tieuDe,
            string noiDung,
            DateTime ngayDang,
            bool trangThai)
        {
            // Validate quan trọng ở đây!
            Check.NotNullOrWhiteSpace(tieuDe, nameof(tieuDe));

            // Có thể check trùng tiêu đề, hoặc các rule khác

            return new TinTuc(
                GuidGenerator.Create(),
                tieuDe,
                noiDung,
                ngayDang,
                trangThai
            );
        }

        public async Task UpdateAsync(
            TinTuc tinTuc,
            string tieuDe,
            string noiDung,
            DateTime ngayDang,
            bool trangThai)
        {
            Check.NotNullOrWhiteSpace(tieuDe, nameof(tieuDe));

            tinTuc.TieuDe = tieuDe;
            tinTuc.NoiDung = noiDung;
            tinTuc.NgayDang = ngayDang;
            tinTuc.TrangThai = trangThai;
        }
    }
}
