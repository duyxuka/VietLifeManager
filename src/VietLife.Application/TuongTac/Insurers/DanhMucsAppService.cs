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
using VietLife.TuongTac.Insurer.DanhMucs;
using VietLife.TuongTac.Media;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace VietLife.TuongTac.Insurers
{
    public class DanhMucsAppService : CrudAppService<
            DanhMuc,
            DanhMucDto,
            Guid,
            PagedResultRequestDto,
            CreateUpdateDanhMucDto,
            CreateUpdateDanhMucDto>,
        IDanhMucsAppService
    {
        private readonly IMediaAppService _mediaAppService;

        public DanhMucsAppService(
            IRepository<DanhMuc, Guid> repository,
            IMediaAppService mediaAppService)
            : base(repository)
        {
            _mediaAppService = mediaAppService;

            GetPolicyName = null;
            GetListPolicyName = null;
            CreatePolicyName = VietLifePermissions.DanhMuc.Create;
            UpdatePolicyName = VietLifePermissions.DanhMuc.Update;
            DeletePolicyName = VietLifePermissions.DanhMuc.Delete;
        }

        // ================= CREATE =================
        [Authorize(VietLifePermissions.DanhMuc.Create)]
        public override async Task<DanhMucDto> CreateAsync(CreateUpdateDanhMucDto input)
        {
            var danhMuc = new DanhMuc
            {
                Ten = input.Ten,
                Slug = input.Slug,
                MoTa = input.MoTa,
                ThuTu = input.ThuTu,
                AnhMenu = input.AnhMenu
            };

            var created = await Repository.InsertAsync(danhMuc);
            return MapToGetOutputDto(created);
        }

        // ================= UPDATE =================
        [Authorize(VietLifePermissions.DanhMuc.Update)]
        public override async Task<DanhMucDto> UpdateAsync(Guid id, CreateUpdateDanhMucDto input)
        {
            var danhMuc = await Repository.GetAsync(id);
            var oldImage = danhMuc.AnhMenu;

            danhMuc.Ten = input.Ten;
            danhMuc.Slug = input.Slug;
            danhMuc.MoTa = input.MoTa;
            danhMuc.ThuTu = input.ThuTu;

            if (!string.IsNullOrWhiteSpace(input.AnhMenu) && input.AnhMenu != oldImage)
            {
                danhMuc.AnhMenu = input.AnhMenu;

                if (!string.IsNullOrWhiteSpace(oldImage))
                {
                    try
                    {
                        await _mediaAppService.DeleteAsync(oldImage);
                    }
                    catch
                    {
                        Logger.LogWarning($"Không thể xóa ảnh menu cũ: {oldImage}");
                    }
                }
            }

            await Repository.UpdateAsync(danhMuc);
            return MapToGetOutputDto(danhMuc);
        }

        [Authorize(VietLifePermissions.DanhMuc.Delete)]
        public override async Task DeleteAsync(Guid id)
        {
            var danhMuc = await Repository.GetAsync(id);

            if (!string.IsNullOrWhiteSpace(danhMuc.AnhMenu))
            {
                try { await _mediaAppService.DeleteAsync(danhMuc.AnhMenu); }
                catch { Logger.LogWarning($"Không thể xóa ảnh menu: {danhMuc.AnhMenu}"); }
            }

            await base.DeleteAsync(id);
        }

        // ================= DELETE MULTIPLE =================
        [Authorize(VietLifePermissions.DanhMuc.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            var list = await Repository.GetListAsync(x => ids.Contains(x.Id));

            foreach (var item in list)
            {
                if (!string.IsNullOrWhiteSpace(item.AnhMenu))
                {
                    try { await _mediaAppService.DeleteAsync(item.AnhMenu); }
                    catch { Logger.LogWarning($"Không thể xóa ảnh menu: {item.AnhMenu}"); }
                }
            }

            await Repository.DeleteManyAsync(list);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }


        // ================= GET (public) =================
        [AllowAnonymous]
        public override async Task<DanhMucDto> GetAsync(Guid id)
        {
            var danhMuc = await Repository.GetAsync(id);
            return ObjectMapper.Map<DanhMuc, DanhMucDto>(danhMuc);
        }

        // ================= GET ALL (admin) =================
        [Authorize(VietLifePermissions.DanhMuc.View)]
        public async Task<List<DanhMucInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            var list = await AsyncExecuter.ToListAsync(
                query.OrderBy(x => x.ThuTu)
            );
            return ObjectMapper.Map<List<DanhMuc>, List<DanhMucInListDto>>(list);
        }

        // ================= FILTER + PAGING (public) =================
        [AllowAnonymous]
        public async Task<PagedResultDto<DanhMucInListDto>> GetListFilterAsync(BaseListFilterDto input)
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

            return new PagedResultDto<DanhMucInListDto>(
                totalCount,
                ObjectMapper.Map<List<DanhMuc>, List<DanhMucInListDto>>(items)
            );
        }

        [AllowAnonymous]
        public async Task<List<DanhMucMenuDto>> GetMenuAsync()
        {
            var query = await Repository.GetQueryableAsync();

            return await AsyncExecuter.ToListAsync(
                query
                    .OrderBy(x => x.ThuTu)
                    .Select(dm => new DanhMucMenuDto
                    {
                        Ten = dm.Ten,
                        Slug = dm.Slug,
                        MoTa = dm.MoTa,
                        AnhMenu = dm.AnhMenu,
                        Nhoms = dm.Nhoms
                            .OrderBy(n => n.ThuTu)
                            .Select(n => new NhomMenuDto
                            {
                                Ten = n.Ten,
                                Slug = n.Slug,
                                SanPhams = n.SanPhams
                                    .Where(s => s.HienThi)
                                    .OrderBy(s => s.ThuTu)
                                    .Select(s => new SanPhamMenuDto
                                    {
                                        Ten = s.Ten,
                                        Slug = s.Slug
                                    }).ToList()
                            }).ToList()
                    })
            );
        }
        
    }
}
