using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.PhongBans;
using VietLife.Chucvus;
using VietLife.NhanViens;
using VietLife.PhongBans;
using VietLife.PhuCapNhanViens;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace VietLife.Catalog.PhuCapNhanViens
{
    public class PhuCapNhanViensAppService : CrudAppService<PhuCapNhanVien, PhuCapNhanVienDto, Guid, PagedResultRequestDto, CreateUpdatePhuCapNhanVienDto, CreateUpdatePhuCapNhanVienDto>,
        IPhuCapNhanViensAppService
    {
        private readonly IRepository<ChucVu, Guid> _chucvuRepository;
        public PhuCapNhanViensAppService(IRepository<PhuCapNhanVien, Guid> repository, IRepository<ChucVu, Guid> chucvuRepository) : base(repository)
        {
            _chucvuRepository = chucvuRepository;
        }

        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        public async Task<List<PhuCapNhanVienInListDto>> GetListAllAsync()
        {
            var phucapnhanvienQuery = await Repository.GetQueryableAsync();
            var chucvuQuery = await _chucvuRepository.GetQueryableAsync();
            var query = from pb in phucapnhanvienQuery
                        join nv in chucvuQuery on pb.ChucVuId equals nv.Id into joined
                        from nv in joined.DefaultIfEmpty()
                        where !pb.IsDeleted
                        select new PhuCapNhanVienInListDto
                        {
                            Id = pb.Id,
                            TenPhuCap = pb.TenPhuCap,
                            SoTien = pb.SoTien,
                            ChucVuId = pb.ChucVuId,
                            ChucVuTen = nv != null ? nv.TenChucVu : null
                        };
            var data = await AsyncExecuter.ToListAsync(query);

            return data;
        }

        public async Task<PagedResultDto<PhuCapNhanVienInListDto>> GetListFilterAsync(PhuCapNhanVienFilterListDto input)
        {
            var phuCapQuery = await Repository.GetQueryableAsync();
            var chucVuQuery = await _chucvuRepository.GetQueryableAsync();

            var query =
                from pc in phuCapQuery
                join cv in chucVuQuery on pc.ChucVuId equals cv.Id into joinedCv
                from cv in joinedCv.DefaultIfEmpty()
                where !pc.IsDeleted &&
                      (!input.ChucVuId.HasValue || pc.ChucVuId == input.ChucVuId.Value) &&
                      (string.IsNullOrWhiteSpace(input.Keyword) || pc.TenPhuCap.Contains(input.Keyword))
                orderby pc.CreationTime descending
                select new PhuCapNhanVienInListDto
                {
                    Id = pc.Id,
                    TenPhuCap = pc.TenPhuCap,
                    SoTien = pc.SoTien,
                    ChucVuId = pc.ChucVuId,
                    ChucVuTen = cv != null ? cv.TenChucVu : null
                };

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(
                query.Skip(input.SkipCount).Take(input.MaxResultCount)
            );

            return new PagedResultDto<PhuCapNhanVienInListDto>(totalCount, data);
        }

    }
}
