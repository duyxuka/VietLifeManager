using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VietLife.Permissions;
using VietLife.TuongTac.Insurer;
using VietLife.TuongTac.Insurer.Nhoms;
using VietLife.TuongTac.Media;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace VietLife.TuongTac.Insurers
{
    public class NhomsAppService : CrudAppService<
            Nhom,
            NhomDto,
            Guid,
            PagedResultRequestDto,
            CreateUpdateNhomDto,
            CreateUpdateNhomDto>,
        INhomsAppService
    {
        private readonly IMediaAppService _mediaAppService;

        public NhomsAppService(
            IRepository<Nhom, Guid> repository,
            IMediaAppService mediaAppService)
            : base(repository)
        {
            _mediaAppService = mediaAppService;

            GetPolicyName = null;
            GetListPolicyName = null;
            CreatePolicyName = VietLifePermissions.Nhom.Create;
            UpdatePolicyName = VietLifePermissions.Nhom.Update;
            DeletePolicyName = VietLifePermissions.Nhom.Delete;
        }

        // ================= CREATE =================
        [Authorize(VietLifePermissions.Nhom.Create)]
        public override async Task<NhomDto> CreateAsync(CreateUpdateNhomDto input)
        {
            var nhom = new Nhom
            {
                DanhMucId = input.DanhMucId,
                Ten = input.Ten,
                Slug = input.Slug,
                MoTa = input.MoTa,
                ThuTu = input.ThuTu,
                SeoTitle = input.SeoTitle,
                SeoKeywords = input.SeoKeywords,
                SeoDescription = input.SeoDescription,
                LogoUrl = input.LogoUrl
            };

            var created = await Repository.InsertAsync(nhom);
            return MapToGetOutputDto(created);
        }

        // ================= UPDATE =================
        [Authorize(VietLifePermissions.Nhom.Update)]
        public override async Task<NhomDto> UpdateAsync(Guid id, CreateUpdateNhomDto input)
        {
            var nhom = await Repository.GetAsync(id);
            var oldLogo = nhom.LogoUrl;

            nhom.DanhMucId = input.DanhMucId;
            nhom.Ten = input.Ten;
            nhom.Slug = input.Slug;
            nhom.MoTa = input.MoTa;
            nhom.ThuTu = input.ThuTu;
            nhom.SeoTitle = input.SeoTitle;
            nhom.SeoKeywords = input.SeoKeywords;
            nhom.SeoDescription = input.SeoDescription;

            if (!string.IsNullOrWhiteSpace(input.LogoUrl) && input.LogoUrl != oldLogo)
            {
                nhom.LogoUrl = input.LogoUrl;

                if (!string.IsNullOrWhiteSpace(oldLogo))
                {
                    try
                    {
                        await _mediaAppService.DeleteAsync(oldLogo);
                    }
                    catch
                    {
                        Logger.LogWarning($"Không thể xóa logo cũ: {oldLogo}");
                    }
                }
            }

            await Repository.UpdateAsync(nhom);
            return MapToGetOutputDto(nhom);
        }

        [Authorize(VietLifePermissions.Nhom.Delete)]
        public override async Task DeleteAsync(Guid id)
        {
            var nhom = await Repository.GetAsync(id);

            if (!string.IsNullOrWhiteSpace(nhom.LogoUrl))
            {
                try { await _mediaAppService.DeleteAsync(nhom.LogoUrl); }
                catch { Logger.LogWarning($"Không thể xóa logo: {nhom.LogoUrl}"); }
            }

            await base.DeleteAsync(id);
        }

        // ================= DELETE MULTIPLE =================
        [Authorize(VietLifePermissions.Nhom.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            var list = await Repository.GetListAsync(x => ids.Contains(x.Id));

            foreach (var item in list)
            {
                if (!string.IsNullOrWhiteSpace(item.LogoUrl))
                {
                    try { await _mediaAppService.DeleteAsync(item.LogoUrl); }
                    catch { Logger.LogWarning($"Không thể xóa logo: {item.LogoUrl}"); }
                }
            }

            await Repository.DeleteManyAsync(list);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        // ================= GET (public) =================
        [AllowAnonymous]
        public override async Task<NhomDto> GetAsync(Guid id)
        {
            var nhom = await Repository.GetAsync(id);
            return ObjectMapper.Map<Nhom, NhomDto>(nhom);
        }

        // ================= GET ALL (admin) =================
        [Authorize(VietLifePermissions.Nhom.View)]
        public async Task<List<NhomInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            var list = await AsyncExecuter.ToListAsync(
                query.OrderBy(x => x.ThuTu)
            );
            return ObjectMapper.Map<List<Nhom>, List<NhomInListDto>>(list);
        }

        [AllowAnonymous]
        public async Task<NhomDto> GetBySlugAsync(string slug)
        {
            var query = await Repository.GetQueryableAsync();
            var nhom = await AsyncExecuter.FirstOrDefaultAsync(
                query.Where(x => x.Slug == slug)
            );

            if (nhom == null)
                throw new Volo.Abp.UserFriendlyException($"Không tìm thấy nhóm với slug: '{slug}'");

            return ObjectMapper.Map<Nhom, NhomDto>(nhom);
        }

        // ================= FILTER + PAGING (public) =================
        [AllowAnonymous]
        public async Task<PagedResultDto<NhomInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = (await Repository.GetQueryableAsync())
                .WhereIf(
                    !string.IsNullOrWhiteSpace(input.Keyword),
                    x => x.Ten.Contains(input.Keyword)
                );

            var totalCount = await AsyncExecuter.LongCountAsync(query);

            var items = await AsyncExecuter.ToListAsync(
                query.OrderBy(x => x.ThuTu)
                     .Skip(input.SkipCount)
                     .Take(input.MaxResultCount)
            );

            return new PagedResultDto<NhomInListDto>(
            totalCount,
                ObjectMapper.Map<List<Nhom>, List<NhomInListDto>>(items)
            );
        }

        // ================= LỌC THEO DANH MỤC (public) =================
        [AllowAnonymous]
        public async Task<List<NhomInListDto>> GetListByDanhMucAsync(Guid danhMucId)
        {
            var query = (await Repository.GetQueryableAsync())
                .Where(x => x.DanhMucId == danhMucId)
                .OrderBy(x => x.ThuTu);

            var list = await AsyncExecuter.ToListAsync(query);
            return ObjectMapper.Map<List<Nhom>, List<NhomInListDto>>(list);
        }
    }
}
