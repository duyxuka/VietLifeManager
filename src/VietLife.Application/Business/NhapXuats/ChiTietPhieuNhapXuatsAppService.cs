using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.NhapXuats.ChiTietPhieuNhapXuats;
using VietLife.Business.PhieuNhapXuats;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace VietLife.Business.NhapXuats
{
    public class ChiTietPhieuNhapXuatsAppService : CrudAppService<
        ChiTietPhieuNhapXuat,
        ChiTietPhieuNhapXuatDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateChiTietPhieuNhapXuatDto,
        CreateUpdateChiTietPhieuNhapXuatDto>,
    IChiTietPhieuNhapXuatsAppService
    {
        public ChiTietPhieuNhapXuatsAppService(IRepository<ChiTietPhieuNhapXuat, Guid> repository)
            : base(repository)
        {
            GetPolicyName = VietLifePermissions.PhieuNhapXuat.View;
            GetListPolicyName = VietLifePermissions.PhieuNhapXuat.View;
            CreatePolicyName = VietLifePermissions.PhieuNhapXuat.Create;
            UpdatePolicyName = VietLifePermissions.PhieuNhapXuat.Update;
            DeletePolicyName = VietLifePermissions.PhieuNhapXuat.Delete;
        }

        [Authorize(VietLifePermissions.PhieuNhapXuat.View)]
        public async Task<List<ChiTietPhieuNhapXuatDto>> GetListByPhieuIdAsync(Guid phieuId)
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => x.PhieuNhapXuatId == phieuId);
            var list = await AsyncExecuter.ToListAsync(query);
            return ObjectMapper.Map<List<ChiTietPhieuNhapXuat>, List<ChiTietPhieuNhapXuatDto>>(list);
        }

        [Authorize(VietLifePermissions.PhieuNhapXuat.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        public override async Task<ChiTietPhieuNhapXuatDto> CreateAsync(CreateUpdateChiTietPhieuNhapXuatDto input)
        {
            var entity = ObjectMapper.Map<CreateUpdateChiTietPhieuNhapXuatDto, ChiTietPhieuNhapXuat>(input);
            await Repository.InsertAsync(entity);
            return ObjectMapper.Map<ChiTietPhieuNhapXuat, ChiTietPhieuNhapXuatDto>(entity);
        }

        public override async Task<ChiTietPhieuNhapXuatDto> UpdateAsync(Guid id, CreateUpdateChiTietPhieuNhapXuatDto input)
        {
            var entity = await Repository.GetAsync(id);
            ObjectMapper.Map(input, entity);
            await Repository.UpdateAsync(entity);
            return ObjectMapper.Map<ChiTietPhieuNhapXuat, ChiTietPhieuNhapXuatDto>(entity);
        }
    }
}
