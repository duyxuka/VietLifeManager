using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.NhanViens;
using VietLife.Permissions;
using VietLife.PhongBans;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace VietLife.Catalog.PhongBans
{
    public class PhongBansAppService : CrudAppService<PhongBan, PhongBanDto, Guid, PagedResultRequestDto, CreateUpdatePhongBanDto, CreateUpdatePhongBanDto>,
        IPhongBansAppService
    {
        private readonly IRepository<NhanVien, Guid> _userRepository;
        public PhongBansAppService(IRepository<PhongBan, Guid> repository, IRepository<NhanVien, Guid> userRepository) : base(repository)
        {
            _userRepository = userRepository;
        }

        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        public async Task<List<PhongBanInListDto>> GetListAllAsync()
        {
            var phongBanQuery = await Repository.GetQueryableAsync();
            var nhanVienQuery = await _userRepository.GetQueryableAsync();
            var query = from pb in phongBanQuery
                        join nv in nhanVienQuery on pb.TruongPhongId equals nv.Id into joined
                        from nv in joined.DefaultIfEmpty()
                        where !pb.IsDeleted
                        select new PhongBanInListDto
                        {
                            Id = pb.Id,
                            TenPhongBan = pb.TenPhongBan,
                            MoTa = pb.MoTa,
                            TruongPhongId = pb.TruongPhongId,
                            TruongPhongTen = nv != null ? nv.HoTen ?? nv.UserName : null
                        };
            var data = await AsyncExecuter.ToListAsync(query);

            return data;
        }

        public async Task<PagedResultDto<PhongBanInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var phongBanQuery = await Repository.GetQueryableAsync();
            var nhanVienQuery = await _userRepository.GetQueryableAsync();

            var query = from pb in phongBanQuery
                        join nv in nhanVienQuery on pb.TruongPhongId equals nv.Id into joined
                        from nv in joined.DefaultIfEmpty()
                        where !pb.IsDeleted &&
                              (string.IsNullOrWhiteSpace(input.Keyword) || pb.TenPhongBan.Contains(input.Keyword))
                        orderby pb.CreationTime descending
                        select new PhongBanInListDto
                        {
                            Id = pb.Id,
                            TenPhongBan = pb.TenPhongBan,
                            MoTa = pb.MoTa,
                            TruongPhongId = pb.TruongPhongId,
                            TruongPhongTen = nv != null ? nv.HoTen ?? nv.UserName : null
                        };

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(
                query.Skip(input.SkipCount).Take(input.MaxResultCount)
            );

            return new PagedResultDto<PhongBanInListDto>(totalCount, data);
        }

    }
}
