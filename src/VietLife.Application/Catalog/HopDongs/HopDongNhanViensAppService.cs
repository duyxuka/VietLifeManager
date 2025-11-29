using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.HopDongs.HopDongNhanViens;
using VietLife.Catalog.NhanViens;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace VietLife.Catalog.HopDongs
{
    public class HopDongNhanViensAppService : CrudAppService<
        HopDongNhanVien,
        HopDongNhanVienDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateHopDongNhanVienDto,
        CreateUpdateHopDongNhanVienDto>,
        IHopDongNhanViensAppService
    {
        private readonly IRepository<NhanVien, Guid> _nhanVienRepository;
        private readonly IRepository<LoaiHopDong, Guid> _loaiHopDongRepository;
        public HopDongNhanViensAppService(IRepository<HopDongNhanVien, Guid> repository,
            IRepository<NhanVien, Guid> nhanVienRepository,
            IRepository<LoaiHopDong, Guid> loaiHopDongRepository) : base(repository)
        {
            _nhanVienRepository = nhanVienRepository;
            _loaiHopDongRepository = loaiHopDongRepository;

            GetPolicyName = VietLifePermissions.HopDongNhanVien.View;
            GetListPolicyName = VietLifePermissions.HopDongNhanVien.View;
            CreatePolicyName = VietLifePermissions.HopDongNhanVien.Create;
            UpdatePolicyName = VietLifePermissions.HopDongNhanVien.Update;
            DeletePolicyName = VietLifePermissions.HopDongNhanVien.Delete;
        }

        [Authorize(VietLifePermissions.HopDongNhanVien.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [Authorize(VietLifePermissions.HopDongNhanVien.View)]
        public async Task<List<HopDongNhanVienInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => !x.IsDeleted);
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<HopDongNhanVien>, List<HopDongNhanVienInListDto>>(data);
        }

        [Authorize(VietLifePermissions.HopDongNhanVien.View)]
        public async Task<PagedResultDto<HopDongNhanVienInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = await Repository.GetQueryableAsync();
            var joinedQuery = from hd in query
                              join nv in (await _nhanVienRepository.GetQueryableAsync()) on hd.NhanVienId equals nv.Id
                              join loai in (await _loaiHopDongRepository.GetQueryableAsync()) on hd.LoaiHopDongId equals loai.Id
                              where !hd.IsDeleted
                              select new HopDongNhanVienInListDto
                              {
                                  Id = hd.Id,
                                  MaHopDong = hd.MaHopDong,
                                  NhanVienId = hd.NhanVienId,
                                  LoaiHopDongId = hd.LoaiHopDongId,
                                  TenNhanVien = nv.HoTen,
                                  TenLoaiHopDong = loai.TenLoai,
                                  LaHienHanh = hd.LaHienHanh
                              };

            if (!string.IsNullOrWhiteSpace(input.Keyword))
            {
                joinedQuery = joinedQuery.Where(x => x.MaHopDong.Contains(input.Keyword)
                                                  || x.TenNhanVien.Contains(input.Keyword)
                                                  || x.TenLoaiHopDong.Contains(input.Keyword));
            }
            var totalCount = await AsyncExecuter.LongCountAsync(joinedQuery);
            var data = await AsyncExecuter.ToListAsync(joinedQuery
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            return new PagedResultDto<HopDongNhanVienInListDto>(totalCount, data);
        }
    }
}
