using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.BaoGiasList.ChiTietBaoGias;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace VietLife.Business.BaoGias
{
    public class ChiTietBaoGiasAppService : CrudAppService<
        ChiTietBaoGia,
        ChiTietBaoGiaDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateChiTietBaoGiaDto,
        CreateUpdateChiTietBaoGiaDto>,
        IChiTietBaoGiasAppService
    {
        public ChiTietBaoGiasAppService(IRepository<ChiTietBaoGia, Guid> repository)
            : base(repository)
        {
            GetPolicyName = VietLifePermissions.BaoGia.View;
            GetListPolicyName = VietLifePermissions.BaoGia.View;
            CreatePolicyName = VietLifePermissions.BaoGia.Create;
            UpdatePolicyName = VietLifePermissions.BaoGia.Update;
            DeletePolicyName = VietLifePermissions.BaoGia.Delete;
        }

        [Authorize(VietLifePermissions.BaoGia.View)]
        public async Task<List<ChiTietBaoGiaDto>> GetByBaoGiaIdAsync(Guid baoGiaId)
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => x.BaoGiaId == baoGiaId);

            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<ChiTietBaoGia>, List<ChiTietBaoGiaDto>>(data);
        }
    }
}
