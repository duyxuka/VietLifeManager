using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.BaoGiasList.BaoGias;
using VietLife.Business.BaoGiasList.ChiTietBaoGias;
using VietLife.Business.KhachHangs;
using VietLife.Catalog.NhanViens;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace VietLife.Business.BaoGias
{
    public class BaoGiasAppService : CrudAppService<
        BaoGia,
        BaoGiaDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdateBaoGiaDto,
        CreateUpdateBaoGiaDto>,
        IBaoGiasAppService
    {
        private readonly IRepository<ChiTietBaoGia, Guid> _chiTietBaoGiaRepository;
        private readonly IRepository<KhachHang, Guid> _khachHangRepository;
        private readonly IRepository<NhanVien, Guid> _nhanVienRepository;
        public BaoGiasAppService(IRepository<BaoGia, Guid> repository, IRepository<ChiTietBaoGia, Guid> chiTietBaoGiaRepository, IRepository<KhachHang, Guid> khacHangRepository, IRepository<NhanVien, Guid> nhanVienRepository)
            : base(repository)
        {
            GetPolicyName = VietLifePermissions.BaoGia.View;
            GetListPolicyName = VietLifePermissions.BaoGia.View;
            CreatePolicyName = VietLifePermissions.BaoGia.Create;
            UpdatePolicyName = VietLifePermissions.BaoGia.Update;
            DeletePolicyName = VietLifePermissions.BaoGia.Delete;
            _chiTietBaoGiaRepository = chiTietBaoGiaRepository;
            _khachHangRepository = khacHangRepository;
            _nhanVienRepository = nhanVienRepository;
        }

        //❗ Xóa nhiều
        [Authorize(VietLifePermissions.BaoGia.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        //❗ Lấy tất cả không phân trang
        [Authorize(VietLifePermissions.BaoGia.View)]
        public async Task<List<BaoGiaInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => !x.IsDeleted);

            var data = await AsyncExecuter.ToListAsync(query);
            return ObjectMapper.Map<List<BaoGia>, List<BaoGiaInListDto>>(data);
        }

        [Authorize(VietLifePermissions.BaoGia.View)]
        public override async Task<BaoGiaDto> GetAsync(Guid id)
        {
            // Cần thay đổi để sử dụng Repository.WithDetails() hoặc override GetQueryableAsync
            // Nếu không muốn thay đổi GetQueryableAsync, bạn có thể override GetAsync như sau:
            await CheckGetPolicyAsync();

            var query = await Repository.WithDetailsAsync(x => x.ChiTietBaoGias); // <--- Quan trọng: Include chi tiết báo giá

            var entity = await AsyncExecuter.FirstOrDefaultAsync(query, x => x.Id == id);

            if (entity == null)
            {
                // Xử lý không tìm thấy entity
                throw new EntityNotFoundException(typeof(BaoGia), id);
            }

            return await MapToGetOutputDtoAsync(entity);
        }

        //❗ Filter + phân trang
        [Authorize(VietLifePermissions.BaoGia.View)]
        public async Task<PagedResultDto<BaoGiaInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var baoGiaQuery = await Repository.GetQueryableAsync();
            var khachHangQuery = await _khachHangRepository.GetQueryableAsync();
            var nhanVienQuery = await _nhanVienRepository.GetQueryableAsync();

            var query = from bg in baoGiaQuery
                        join kh in khachHangQuery on bg.KhachHangId.Value equals kh.Id
                        join nv in nhanVienQuery on bg.NhanVienId.Value equals nv.Id
                        select new { bg, kh, nv };

            if (!string.IsNullOrWhiteSpace(input.Keyword))
            {
                query = query.Where(x =>
                    x.bg.TieuDe.Contains(input.Keyword)
                    || x.bg.MaBaoGia.Contains(input.Keyword)
                );
            }

            var total = await AsyncExecuter.LongCountAsync(query);

            var list = await AsyncExecuter.ToListAsync(
                query
                .OrderByDescending(x => x.bg.CreationTime)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
            );

            var result = list.Select(x => new BaoGiaInListDto
            {
                Id = x.bg.Id,
                MaBaoGia = x.bg.MaBaoGia,
                TieuDe = x.bg.TieuDe,
                NgayBaoGia = x.bg.NgayBaoGia,
                TenKhachHang = x.kh.TenKhachHang,
                TenNhanVien = x.nv.HoTen,
                TongTien = x.bg.TongTien
            }).ToList();

            return new PagedResultDto<BaoGiaInListDto>(total, result);
        }

        [Authorize(VietLifePermissions.BaoGia.Create)]
        public override async Task<BaoGiaDto> CreateAsync(CreateUpdateBaoGiaDto input)
        {
            await CheckCreatePolicyAsync();

            var baoGia = ObjectMapper.Map<CreateUpdateBaoGiaDto, BaoGia>(input);

            await Repository.InsertAsync(baoGia);

            if (input.ChiTietBaoGias != null)
            {
                foreach (var ct in input.ChiTietBaoGias)
                {
                    var detail = ObjectMapper.Map<CreateUpdateChiTietBaoGiaDto, ChiTietBaoGia>(ct);
                    detail.BaoGiaId = baoGia.Id;
                    await _chiTietBaoGiaRepository.InsertAsync(detail);
                }
            }

            await UnitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<BaoGia, BaoGiaDto>(baoGia);
        }

        [Authorize(VietLifePermissions.BaoGia.Update)]
        public override async Task<BaoGiaDto> UpdateAsync(Guid id, CreateUpdateBaoGiaDto input)
        {
            await CheckUpdatePolicyAsync();

            var baoGia = await Repository.GetAsync(id);
            ObjectMapper.Map(input, baoGia);

            var oldDetails = await _chiTietBaoGiaRepository.GetListAsync(x => x.BaoGiaId == id);
            var requestIds = input.ChiTietBaoGias.Where(x => x.Id != null).Select(x => x.Id).ToList();

            // Xóa các chi tiết đã xoá trên FE
            foreach (var old in oldDetails)
            {
                if (!requestIds.Contains(old.Id))
                    await _chiTietBaoGiaRepository.DeleteAsync(old);
            }

            // Thêm / cập nhật chi tiết
            foreach (var ct in input.ChiTietBaoGias)
            {
                if (ct.Id == null)
                {
                    var newDetail = ObjectMapper.Map<CreateUpdateChiTietBaoGiaDto, ChiTietBaoGia>(ct);
                    newDetail.BaoGiaId = id;
                    await _chiTietBaoGiaRepository.InsertAsync(newDetail);
                }
                else
                {
                    var existing = oldDetails.First(x => x.Id == ct.Id);
                    ObjectMapper.Map(ct, existing);
                    await _chiTietBaoGiaRepository.UpdateAsync(existing);
                }
            }

            await UnitOfWorkManager.Current.SaveChangesAsync();
            return ObjectMapper.Map<BaoGia, BaoGiaDto>(baoGia);
        }
    }
}
