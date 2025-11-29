using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.ThanhPhos;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace VietLife.Business.KhoHangs
{
    public class KhoHangsAppService :
         CrudAppService<KhoHang, KhoHangDto, Guid, PagedResultRequestDto, CreateUpdateKhoHangDto, CreateUpdateKhoHangDto>,
         IKhoHangsAppService
    {
        private readonly IRepository<KhoHang, Guid> _repository;
        private readonly IRepository<ThanhPho, Guid> _thanhPhoRepository;

        public KhoHangsAppService(IRepository<KhoHang, Guid> repository,
                                  IRepository<ThanhPho, Guid> thanhPhoRepository) : base(repository)
        {
            _repository = repository;
            _thanhPhoRepository = thanhPhoRepository;

            GetPolicyName = VietLifePermissions.KhoHang.View;
            GetListPolicyName = VietLifePermissions.KhoHang.View;
            CreatePolicyName = VietLifePermissions.KhoHang.Create;
            UpdatePolicyName = VietLifePermissions.KhoHang.Update;
            DeletePolicyName = VietLifePermissions.KhoHang.Delete;
        }

        [Authorize(VietLifePermissions.KhoHang.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }
        [Authorize(VietLifePermissions.KhoHang.View)]
        public async Task<List<KhoHangInListDto>> GetListAllAsync()
        {
            // Join với ThanhPho
            var query = from kho in await _repository.GetQueryableAsync()
                        join tp in await _thanhPhoRepository.GetQueryableAsync()
                        on kho.ThanhPhoId equals tp.Id into tpGroup
                        from tp in tpGroup.DefaultIfEmpty()
                        select new KhoHangInListDto
                        {
                            Id = kho.Id,
                            TenKho = kho.TenKho,
                            DiaChi = kho.DiaChi,
                            ThanhPhoId = kho.ThanhPhoId,
                            TenThanhPho = tp.Ten
                        };

            return await AsyncExecuter.ToListAsync(query);
        }

        [Authorize(VietLifePermissions.KhoHang.View)]
        public async Task<PagedResultDto<KhoHangInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = from kho in await _repository.GetQueryableAsync()
                        join tp in await _thanhPhoRepository.GetQueryableAsync()
                        on kho.ThanhPhoId equals tp.Id into tpGroup
                        from tp in tpGroup.DefaultIfEmpty()
                        select new KhoHangInListDto
                        {
                            Id = kho.Id,
                            TenKho = kho.TenKho,
                            DiaChi = kho.DiaChi,
                            ThanhPhoId = kho.ThanhPhoId,
                            TenThanhPho = tp.Ten
                        };

            if (!string.IsNullOrWhiteSpace(input.Keyword))
            {
                query = query.Where(x => x.TenKho.Contains(input.Keyword));
            }

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            return new PagedResultDto<KhoHangInListDto>(totalCount, data);
        }
    }
}
