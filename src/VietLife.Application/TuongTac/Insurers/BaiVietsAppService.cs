using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
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
using VietLife.TuongTac.Insurer.BaiViets;
using VietLife.TuongTac.Media;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace VietLife.TuongTac.Insurers
{
    public class BaiVietsAppService : CrudAppService<
            BaiViet,
            BaiVietDto,
            Guid,
            PagedResultRequestDto,
            CreateUpdateBaiVietDto,
            CreateUpdateBaiVietDto>,
        IBaiVietsAppService
    {
        private readonly IMediaAppService _mediaAppService;

        public BaiVietsAppService(
            IRepository<BaiViet, Guid> repository,
            IMediaAppService mediaAppService)
            : base(repository)
        {
            _mediaAppService = mediaAppService;

            GetPolicyName = null;
            GetListPolicyName = null;
            CreatePolicyName = VietLifePermissions.BaiViet.Create;
            UpdatePolicyName = VietLifePermissions.BaiViet.Update;
            DeletePolicyName = VietLifePermissions.BaiViet.Delete;
        }

        // ================= CREATE =================
        [Authorize(VietLifePermissions.BaiViet.Create)]
        public override async Task<BaiVietDto> CreateAsync(CreateUpdateBaiVietDto input)
        {
            var baiViet = new BaiViet
            {
                NhomId = input.NhomId,
                SanPhamId = input.SanPhamId,
                TieuDe = input.TieuDe,
                Slug = input.Slug,
                MoTaNgan = input.MoTaNgan,
                NoiDung = input.NoiDung,
                XuatBanLuc = input.XuatBanLuc,
                HienThi = input.HienThi,
                SeoTitle = input.SeoTitle,
                SeoKeywords = input.SeoKeywords,
                SeoDescription = input.SeoDescription,
                AnhDaiDien = input.AnhDaiDien
            };

            var created = await Repository.InsertAsync(baiViet);
            return MapToGetOutputDto(created);
        }

        // ================= UPDATE =================
        [Authorize(VietLifePermissions.BaiViet.Update)]
        public override async Task<BaiVietDto> UpdateAsync(Guid id, CreateUpdateBaiVietDto input)
        {
            var baiViet = await Repository.GetAsync(id);
            var oldImage = baiViet.AnhDaiDien;

            baiViet.NhomId = input.NhomId;
            baiViet.SanPhamId = input.SanPhamId;
            baiViet.TieuDe = input.TieuDe;
            baiViet.Slug = input.Slug;
            baiViet.MoTaNgan = input.MoTaNgan;
            baiViet.NoiDung = input.NoiDung;
            baiViet.XuatBanLuc = input.XuatBanLuc;
            baiViet.HienThi = input.HienThi;
            baiViet.SeoTitle = input.SeoTitle;
            baiViet.SeoKeywords = input.SeoKeywords;
            baiViet.SeoDescription = input.SeoDescription;

            if (!string.IsNullOrWhiteSpace(input.AnhDaiDien) && input.AnhDaiDien != oldImage)
            {
                baiViet.AnhDaiDien = input.AnhDaiDien;

                // Xóa ảnh cũ trên storage (không block update nếu lỗi)
                if (!string.IsNullOrWhiteSpace(oldImage))
                {
                    try
                    {
                        await _mediaAppService.DeleteAsync(oldImage);
                    }
                    catch
                    {
                        Logger.LogWarning($"Không thể xóa ảnh cũ: {oldImage}");
                    }
                }
            }

            await Repository.UpdateAsync(baiViet);
            return MapToGetOutputDto(baiViet);
        }

        // ================= DELETE MULTIPLE =================
        [Authorize(VietLifePermissions.BaiViet.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            var list = await Repository.GetListAsync(x => ids.Contains(x.Id));

            foreach (var item in list)
            {
                if (!string.IsNullOrWhiteSpace(item.AnhDaiDien))
                {
                    try { await _mediaAppService.DeleteAsync(item.AnhDaiDien); }
                    catch { Logger.LogWarning($"Không thể xóa ảnh: {item.AnhDaiDien}"); }
                }
            }

            await Repository.DeleteManyAsync(list);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        // ================= GET (public) =================
        [AllowAnonymous]
        public override async Task<BaiVietDto> GetAsync(Guid id)
        {
            var baiViet = await Repository.GetAsync(x => x.Id == id && x.HienThi);
            return ObjectMapper.Map<BaiViet, BaiVietDto>(baiViet);
        }

        // ================= GET ALL (admin) =================
        [Authorize(VietLifePermissions.BaiViet.View)]
        public async Task<List<BaiVietInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            var list = await AsyncExecuter.ToListAsync(
                query.Where(x => x.HienThi)
            );
            return ObjectMapper.Map<List<BaiViet>, List<BaiVietInListDto>>(list);
        }

        // ================= FILTER + PAGING (public) =================
        [AllowAnonymous]
        public async Task<PagedResultDto<BaiVietInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = (await Repository.GetQueryableAsync())
                .AsNoTracking()
                .Where(x => x.HienThi)
                .WhereIf(
                    !string.IsNullOrWhiteSpace(input.Keyword),
                    x => x.TieuDe.Contains(input.Keyword)
                );

            var totalCount = await AsyncExecuter.LongCountAsync(query);

            var items = await AsyncExecuter.ToListAsync(
                query
                    .OrderByDescending(x => x.XuatBanLuc)
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount)
                    .Select(x => new BaiVietInListDto
                    {
                        Id = x.Id,
                        NhomId = x.NhomId,
                        NhomTen = x.Nhom != null ? x.Nhom.Ten : null,
                        SanPhamId = x.SanPhamId,
                        SanPhamTen = x.SanPham != null ? x.SanPham.Ten : null,
                        TieuDe = x.TieuDe,
                        Slug = x.Slug,
                        MoTaNgan = x.MoTaNgan,
                        AnhDaiDien = x.AnhDaiDien,
                        XuatBanLuc = x.XuatBanLuc,
                        HienThi = x.HienThi
                    })
            );

            return new PagedResultDto<BaiVietInListDto>(
                totalCount,
                items
            );
        }

        // ================= LỌC THEO SẢN PHẨM (public) =================
        [AllowAnonymous]
        public async Task<PagedResultDto<BaiVietInListDto>> GetListBySanPhamAsync(
            Guid sanPhamId, PagedResultRequestDto input)
        {
            var query = (await Repository.GetQueryableAsync())
                .Where(x => x.HienThi && x.SanPhamId == sanPhamId);

            var totalCount = await AsyncExecuter.LongCountAsync(query);

            var items = await AsyncExecuter.ToListAsync(
                query.OrderByDescending(x => x.XuatBanLuc)
                     .Skip(input.SkipCount)
                     .Take(input.MaxResultCount)
            );

            return new PagedResultDto<BaiVietInListDto>(
                totalCount,
                ObjectMapper.Map<List<BaiViet>, List<BaiVietInListDto>>(items)
            );
        }

        // ================= LỌC THEO NHÓM (public) =================
        [AllowAnonymous]
        public async Task<PagedResultDto<BaiVietInListDto>> GetListByNhomAsync(
            Guid nhomId, PagedResultRequestDto input)
        {
            var query = (await Repository.GetQueryableAsync())
                .Where(x => x.HienThi && x.NhomId == nhomId);

            var totalCount = await AsyncExecuter.LongCountAsync(query);

            var items = await AsyncExecuter.ToListAsync(
                query.OrderByDescending(x => x.XuatBanLuc)
                     .Skip(input.SkipCount)
                     .Take(input.MaxResultCount)
            );

            return new PagedResultDto<BaiVietInListDto>(
            totalCount,
                ObjectMapper.Map<List<BaiViet>, List<BaiVietInListDto>>(items)
            );
        }

        // ================= BÀI MỚI NHẤT (public) =================
        [AllowAnonymous]
        public async Task<List<BaiVietInListDto>> GetLatestAsync(int take = 6)
        {
            var query = (await Repository.GetQueryableAsync())
                .Where(x => x.HienThi)
                .OrderByDescending(x => x.XuatBanLuc)
                .Take(take);

            var list = await AsyncExecuter.ToListAsync(query);
            return ObjectMapper.Map<List<BaiViet>, List<BaiVietInListDto>>(list);
        }

        [AllowAnonymous]
        public async Task<BaiVietDto> GetBySlugAsync(string slug)
        {
            var query = await Repository.GetQueryableAsync();

            var baiViet = await AsyncExecuter.FirstOrDefaultAsync(
                query.Where(x => x.Slug == slug && x.HienThi)
            );

            if (baiViet == null)
            {
                return null;
            }

            return ObjectMapper.Map<BaiViet, BaiVietDto>(baiViet);
        }
    }
}
