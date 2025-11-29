using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.DonHangsList.ChiTietDonHangs;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace VietLife.Business.DonHangs
{
    public class ChiTietDonHangsAppService : CrudAppService<
    ChiTietDonHang,
    ChiTietDonHangDto,
    Guid,
    PagedResultRequestDto,
    CreateUpdateChiTietDonHangDto,
    CreateUpdateChiTietDonHangDto>,
    IChiTietDonHangsAppService
    {
        public ChiTietDonHangsAppService(IRepository<ChiTietDonHang, Guid> repo)
            : base(repo)
        {
        }

        public async Task<List<ChiTietDonHangDto>> GetByDonHangIdAsync(Guid donHangId)
        {
            var list = await Repository.GetListAsync(x => x.DonHangId == donHangId);
            return ObjectMapper.Map<List<ChiTietDonHang>, List<ChiTietDonHangDto>>(list);
        }
    }
}
