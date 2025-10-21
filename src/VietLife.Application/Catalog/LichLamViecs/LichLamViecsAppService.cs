using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.LichLamViecs;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace VietLife.Catalog.LichLamViecs
{
    public class LichLamViecsAppService : CrudAppService<LichLamViec, LichLamViecDto, Guid, PagedResultRequestDto, CreateUpdateLichLamViecDto, CreateUpdateLichLamViecDto>,
        ILichLamViecsAppService
    {
        public LichLamViecsAppService(IRepository<LichLamViec, Guid> repository) : base(repository)
        {

        }

        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        public async Task<List<LichLamViecInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => !x.IsDeleted);
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<LichLamViec>, List<LichLamViecInListDto>>(data);
        }

        public async Task<PagedResultDto<LichLamViecInListDto>> GetListFilterAsync(LichLamViecListFilterDto input)
        {
            var query = await Repository.GetQueryableAsync();

            var currentDate = DateTime.Now;
            var startDate = input.StartDate ?? new DateTime(currentDate.Year, currentDate.Month, 1);
            var endDate = input.EndDate ?? startDate.AddMonths(1).AddDays(-1);

            // Lấy danh sách các tháng - năm trong khoảng ngày được chọn
            var startMonth = startDate.Month;
            var startYear = startDate.Year;
            var endMonth = endDate.Month;
            var endYear = endDate.Year;

            // Lọc theo khoảng tháng-năm
            query = query.Where(x =>
                (x.Nam > startYear || (x.Nam == startYear && x.Thang >= startMonth)) &&
                (x.Nam < endYear || (x.Nam == endYear && x.Thang <= endMonth))
            );

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(
                query.OrderByDescending(x => x.CreationTime)
                     .Skip(input.SkipCount)
                     .Take(input.MaxResultCount)
            );

            return new PagedResultDto<LichLamViecInListDto>(
                totalCount,
                ObjectMapper.Map<List<LichLamViec>, List<LichLamViecInListDto>>(data)
            );
        }
    }
}
