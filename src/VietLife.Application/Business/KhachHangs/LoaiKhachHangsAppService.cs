using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.KhachHangsList.LoaiKhachHangs;
using VietLife.Business.TienTes;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;

namespace VietLife.Business.KhachHangs
{
    public class LoaiKhachHangsAppService :
        CrudAppService<LoaiKhachHang, LoaiKhachHangDto, Guid, PagedResultRequestDto, CreateUpdateLoaiKhachHangDto, CreateUpdateLoaiKhachHangDto>,
        ILoaiKhachHangsAppService
    {
        private readonly IRepository<LoaiKhachHang, Guid> _repository;

        public LoaiKhachHangsAppService(IRepository<LoaiKhachHang, Guid> repository)
            : base(repository)
        {
            _repository = repository;

            GetPolicyName = VietLifePermissions.LoaiKhachHang.View;
            GetListPolicyName = VietLifePermissions.LoaiKhachHang.View;
            CreatePolicyName = VietLifePermissions.LoaiKhachHang.Create;
            UpdatePolicyName = VietLifePermissions.LoaiKhachHang.Update;
            DeletePolicyName = VietLifePermissions.LoaiKhachHang.Delete;
        }

        [Authorize(VietLifePermissions.LoaiKhachHang.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [Authorize(VietLifePermissions.LoaiKhachHang.View)]
        public async Task<List<LoaiKhachHangInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => !x.IsDeleted);
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<LoaiKhachHang>, List<LoaiKhachHangInListDto>>(data);
        }

        [Authorize(VietLifePermissions.LoaiKhachHang.View)]
        public async Task<PagedResultDto<LoaiKhachHangInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = from lkh in await _repository.GetQueryableAsync()
                        select new LoaiKhachHangInListDto
                        {
                            Id = lkh.Id,
                            Ten = lkh.Ten,
                            MoTa = lkh.MoTa,
                            HieuLuc = lkh.HieuLuc
                        };

            if (!string.IsNullOrWhiteSpace(input.Keyword))
            {
                query = query.Where(x => x.Ten.Contains(input.Keyword));
            }

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(
                query.Skip(input.SkipCount).Take(input.MaxResultCount)
            );

            return new PagedResultDto<LoaiKhachHangInListDto>(totalCount, data);
        }
    }
}
