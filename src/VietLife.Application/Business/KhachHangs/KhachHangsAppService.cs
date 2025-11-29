using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.KhachHangsList.KhachHangs;
using VietLife.Business.ThanhPhos;
using VietLife.Business.TienTes;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;

namespace VietLife.Business.KhachHangs
{
    public class KhachHangsAppService :
        CrudAppService<KhachHang, KhachHangDto, Guid, PagedResultRequestDto, CreateUpdateKhachHangDto, CreateUpdateKhachHangDto>,
        IKhachHangsAppService
    {
        private readonly IRepository<KhachHang, Guid> _repository;
        private readonly IRepository<LoaiKhachHang, Guid> _loaiKhachHangRepository;
        private readonly IRepository<ThanhPho, Guid> _thanhPhoRepository;

        public KhachHangsAppService(
            IRepository<KhachHang, Guid> repository,
            IRepository<LoaiKhachHang, Guid> loaiKhachHangRepository,
            IRepository<ThanhPho, Guid> thanhPhoRepository)
            : base(repository)
        {
            _repository = repository;
            _loaiKhachHangRepository = loaiKhachHangRepository;
            _thanhPhoRepository = thanhPhoRepository;

            GetPolicyName = VietLifePermissions.KhachHang.View;
            GetListPolicyName = VietLifePermissions.KhachHang.View;
            CreatePolicyName = VietLifePermissions.KhachHang.Create;
            UpdatePolicyName = VietLifePermissions.KhachHang.Update;
            DeletePolicyName = VietLifePermissions.KhachHang.Delete;
        }

        // Xóa nhiều khách hàng
        [Authorize(VietLifePermissions.KhachHang.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        // Lấy toàn bộ (không phân trang)
        [Authorize(VietLifePermissions.KhachHang.View)]
        public async Task<List<KhachHangInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => !x.IsDeleted);
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<KhachHang>, List<KhachHangInListDto>>(data);
        }

        // Lọc + phân trang
        [Authorize(VietLifePermissions.KhachHang.View)]
        public async Task<PagedResultDto<KhachHangInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var khQuery = await _repository.GetQueryableAsync();
            var loaiQuery = await _loaiKhachHangRepository.GetQueryableAsync();
            var tpQuery = await _thanhPhoRepository.GetQueryableAsync();

            var query = from kh in khQuery
                        join loai in loaiQuery on kh.LoaiKhachHangId equals loai.Id into loaiGroup
                        from loai in loaiGroup.DefaultIfEmpty()
                        join tp in tpQuery on kh.ThanhPhoId equals tp.Id into tpGroup
                        from tp in tpGroup.DefaultIfEmpty()
                        select new KhachHangInListDto
                        {
                            Id = kh.Id,
                            MaKhachHang = kh.MaKhachHang,
                            TenCongTy = kh.TenCongTy,
                            TenKhachHang = kh.TenKhachHang,
                            TenGiaoDich = kh.TenGiaoDich,
                            DienThoai = kh.DienThoai,
                            Email = kh.Email,
                            DiaChi = kh.DiaChi,
                            TrangThai = kh.TrangThai,

                            LoaiKhachHangId = kh.LoaiKhachHangId,
                            LoaiKhachHangTen = loai != null ? loai.Ten : null,

                            ThanhPhoId = kh.ThanhPhoId,
                            ThanhPhoTen = tp != null ? tp.Ten : null
                        };

            // Điều kiện lọc
            if (!string.IsNullOrWhiteSpace(input.Keyword))
            {
                query = query.Where(x =>
                    x.TenCongTy.Contains(input.Keyword) ||
                    x.TenGiaoDich.Contains(input.Keyword) ||
                    x.DienThoai.Contains(input.Keyword) ||
                    x.Email.Contains(input.Keyword)
                );
            }

            var totalCount = await AsyncExecuter.LongCountAsync(query);

            var data = await AsyncExecuter.ToListAsync(
                query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
            );

            return new PagedResultDto<KhachHangInListDto>(totalCount, data);
        }
    }
}
