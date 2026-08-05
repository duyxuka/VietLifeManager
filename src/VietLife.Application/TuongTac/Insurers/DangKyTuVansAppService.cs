using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Permissions;
using VietLife.TuongTac.Insurer;
using VietLife.TuongTac.Insurer.DangKyTuVans;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace VietLife.TuongTac.Insurers
{
    public class DangKyTuVansAppService : CrudAppService<
            DangKyTuVan,
            DangKyTuVanDto,
            Guid,
            PagedResultRequestDto,
            CreateUpdateDangKyTuVanDto,
            CreateUpdateDangKyTuVanDto>,
        IDangKyTuVansAppService
    {
        public DangKyTuVansAppService(IRepository<DangKyTuVan, Guid> repository)
            : base(repository)
        {
            // Public: khách hàng submit form không cần đăng nhập
            GetPolicyName = VietLifePermissions.DangKyTuVan.View;
            GetListPolicyName = VietLifePermissions.DangKyTuVan.View;
            CreatePolicyName = null;
            UpdatePolicyName = VietLifePermissions.DangKyTuVan.Update;
            DeletePolicyName = VietLifePermissions.DangKyTuVan.Delete;
        }

        // ================= CREATE (public — form đăng ký) =================
        [AllowAnonymous]
        public override async Task<DangKyTuVanDto> CreateAsync(CreateUpdateDangKyTuVanDto input)
        {
            var dangKy = new DangKyTuVan
            {
                SanPhamId = input.SanPhamId,
                NhomId = input.NhomId,
                HoTen = input.HoTen,
                SoDienThoai = input.SoDienThoai,
            };

            var created = await Repository.InsertAsync(dangKy);
            return MapToGetOutputDto(created);
        }

        // ================= UPDATE (admin) =================
        [Authorize(VietLifePermissions.DangKyTuVan.Update)]
        public override async Task<DangKyTuVanDto> UpdateAsync(Guid id, CreateUpdateDangKyTuVanDto input)
        {
            var dangKy = await Repository.GetAsync(id);

            dangKy.SanPhamId = input.SanPhamId;
            dangKy.NhomId = input.NhomId;
            dangKy.HoTen = input.HoTen;
            dangKy.SoDienThoai = input.SoDienThoai;

            await Repository.UpdateAsync(dangKy);
            return MapToGetOutputDto(dangKy);
        }

        // ================= DELETE MULTIPLE (admin) =================
        [Authorize(VietLifePermissions.DangKyTuVan.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        // ================= GET ALL (admin) =================
        [Authorize(VietLifePermissions.DangKyTuVan.View)]
        public async Task<List<DangKyTuVanInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            var list = await AsyncExecuter.ToListAsync(
                query.OrderByDescending(x => x.CreationTime)
            );
            return ObjectMapper.Map<List<DangKyTuVan>, List<DangKyTuVanInListDto>>(list);
        }

        // ================= FILTER + PAGING (admin) =================
        [Authorize(VietLifePermissions.DangKyTuVan.View)]
        public async Task<PagedResultDto<DangKyTuVanInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = (await Repository.GetQueryableAsync())
                .AsNoTracking()
                .WhereIf(
                    !string.IsNullOrWhiteSpace(input.Keyword),
                    x => x.HoTen.Contains(input.Keyword) ||
                         x.SoDienThoai.Contains(input.Keyword)
                );

            var totalCount = await AsyncExecuter.LongCountAsync(query);

            var items = await AsyncExecuter.ToListAsync(
                query
                    .OrderByDescending(x => x.CreationTime)
                    .Skip(input.SkipCount)
                    .Take(input.MaxResultCount)
                    .Select(x => new DangKyTuVanInListDto
                    {
                        Id = x.Id,

                        NhomId = x.NhomId,
                        NhomTen = x.Nhom != null ? x.Nhom.Ten : null,

                        SanPhamId = x.SanPhamId,
                        SanPhamTen = x.SanPham != null ? x.SanPham.Ten : null,

                        HoTen = x.HoTen,
                        SoDienThoai = x.SoDienThoai,

                        CreationTime = x.CreationTime
                    })
            );

            return new PagedResultDto<DangKyTuVanInListDto>(
                totalCount,
                items
            );
        }

        // ================= LỌC THEO SẢN PHẨM (admin) =================
        [Authorize(VietLifePermissions.DangKyTuVan.View)]
        public async Task<PagedResultDto<DangKyTuVanInListDto>> GetListBySanPhamAsync(
            Guid sanPhamId, PagedResultRequestDto input)
        {
            var query = (await Repository.GetQueryableAsync())
                .Where(x => x.SanPhamId == sanPhamId);

            var totalCount = await AsyncExecuter.LongCountAsync(query);

            var items = await AsyncExecuter.ToListAsync(
                query.OrderByDescending(x => x.CreationTime)
                     .Skip(input.SkipCount)
                     .Take(input.MaxResultCount)
            );

            return new PagedResultDto<DangKyTuVanInListDto>(
                totalCount,
                ObjectMapper.Map<List<DangKyTuVan>, List<DangKyTuVanInListDto>>(items)
            );
        }

        // ================= LỌC THEO NHÓM (admin) =================
        [Authorize(VietLifePermissions.DangKyTuVan.View)]
        public async Task<PagedResultDto<DangKyTuVanInListDto>> GetListByNhomAsync(
            Guid nhomId, PagedResultRequestDto input)
        {
            var query = (await Repository.GetQueryableAsync())
                .Where(x => x.NhomId == nhomId);

            var totalCount = await AsyncExecuter.LongCountAsync(query);

            var items = await AsyncExecuter.ToListAsync(
                query.OrderByDescending(x => x.CreationTime)
                     .Skip(input.SkipCount)
                     .Take(input.MaxResultCount)
            );

            return new PagedResultDto<DangKyTuVanInListDto>(
                totalCount,
                ObjectMapper.Map<List<DangKyTuVan>, List<DangKyTuVanInListDto>>(items)
            );
        }
    }
}
