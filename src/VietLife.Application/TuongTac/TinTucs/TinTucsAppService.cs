using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VietLife.Permissions;
using VietLife.TuongTac.TinTucs;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain.Repositories;

namespace VietLife.TuongTac.TinTucs
{
    public class TinTucsAppService : CrudAppService<
            TinTuc,
            TinTucDto,
            Guid,
            PagedResultRequestDto,
            CreateUpdateTinTucDto,
            CreateUpdateTinTucDto>,
        ITinTucsAppService
    {
        private readonly TinTucManager _tinTucManager;
        private readonly IBlobContainer<AnhTinTucContainer> _fileContainer;

        public TinTucsAppService(
            IRepository<TinTuc, Guid> repository,
            TinTucManager tinTucManager,
            IBlobContainer<AnhTinTucContainer> fileContainer)
            : base(repository)
        {
            _tinTucManager = tinTucManager;
            _fileContainer = fileContainer;

            GetPolicyName = null;
            GetListPolicyName = null;
            CreatePolicyName = VietLifePermissions.TinTuc.Create;
            UpdatePolicyName = VietLifePermissions.TinTuc.Update;
            DeletePolicyName = VietLifePermissions.TinTuc.Delete;
        }

        [Authorize(VietLifePermissions.TinTuc.Create)]
        public override async Task<TinTucDto> CreateAsync(CreateUpdateTinTucDto input)
        {
            // Dùng manager → tự động validate TieuDe không null
            var tinTuc = await _tinTucManager.CreateAsync(
                input.TieuDe,
                input.NoiDung,
                input.NgayDang,
                input.TrangThai
            );

            if (!string.IsNullOrEmpty(input.AnhContent))
            {
                await SaveThumbnailImageAsync(input.AnhName, input.AnhContent);
                tinTuc.Anh = input.AnhName;
            }

            var created = await Repository.InsertAsync(tinTuc);
            return MapToGetOutputDto(created); // hoặc ObjectMapper
        }

        [Authorize(VietLifePermissions.TinTuc.Update)]
        public override async Task<TinTucDto> UpdateAsync(Guid id, CreateUpdateTinTucDto input)
        {
            var tinTuc = await Repository.GetAsync(id);

            await _tinTucManager.UpdateAsync(
                tinTuc,
                input.TieuDe,
                input.NoiDung,
                input.NgayDang,
                input.TrangThai
            );

            if (!string.IsNullOrEmpty(input.AnhContent))
            {
                await SaveThumbnailImageAsync(input.AnhName, input.AnhContent);
                tinTuc.Anh = input.AnhName;
            }

            await Repository.UpdateAsync(tinTuc);
            return MapToGetOutputDto(tinTuc);
        }

        [Authorize(VietLifePermissions.TinTuc.Delete)]
        // ================= DELETE MULTIPLE =================
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [Authorize(VietLifePermissions.TinTuc.View)]
        // ================= GET ALL =================
        public async Task<List<TinTucInListDto>> GetListAllAsync()
        {
            var queryable = await Repository.GetQueryableAsync();
            var list = await AsyncExecuter.ToListAsync(
                queryable.Where(x => x.TrangThai)
            );

            return ObjectMapper.Map<List<TinTuc>, List<TinTucInListDto>>(list);
        }

        // ================= FILTER + PAGING =================
        [AllowAnonymous]
        public async Task<PagedResultDto<TinTucInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = (await Repository.GetQueryableAsync())
                .Where(x => x.TrangThai)
                .WhereIf(
                    !string.IsNullOrWhiteSpace(input.Keyword),
                    x => x.TieuDe.Contains(input.Keyword)
                );

            var totalCount = await AsyncExecuter.LongCountAsync(query);

            var items = await AsyncExecuter.ToListAsync(
                query.OrderByDescending(x => x.NgayDang)
                     .Skip(input.SkipCount)
                     .Take(input.MaxResultCount)
            );

            return new PagedResultDto<TinTucInListDto>(
                totalCount,
                ObjectMapper.Map<List<TinTuc>, List<TinTucInListDto>>(items)
            );
        }

        [AllowAnonymous]
        public override async Task<TinTucDto> GetAsync(Guid id)
        {
            var tinTuc = await Repository.GetAsync(x => x.Id == id && x.TrangThai);
            return ObjectMapper.Map<TinTuc, TinTucDto>(tinTuc);
        }

        [AllowAnonymous]
        public async Task<List<TinTucInListDto>> GetLatestAsync(int take = 6)
        {
            var query = (await Repository.GetQueryableAsync())
                .Where(x => x.TrangThai)
                .OrderByDescending(x => x.NgayDang)
                .Take(take);

            var list = await AsyncExecuter.ToListAsync(query);
            return ObjectMapper.Map<List<TinTuc>, List<TinTucInListDto>>(list);
        }

        // ================= IMAGE =================
        private async Task SaveThumbnailImageAsync(string fileName, string base64)
        {
            Regex regex = new Regex(@"^[\w/\:.-]+;base64,");
            base64 = regex.Replace(base64, string.Empty);
            var bytes = Convert.FromBase64String(base64);
            await _fileContainer.SaveAsync(fileName, bytes, overrideExisting: true);
        }

        public async Task<string> GetThumbnailImageAsync(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return null;

            var fileBytes = await _fileContainer.GetAllBytesOrNullAsync(fileName);
            if (fileBytes == null) return null;

            return Convert.ToBase64String(fileBytes);
        }
    }
}
