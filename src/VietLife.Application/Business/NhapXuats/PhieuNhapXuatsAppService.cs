using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.NhapXuats.ChiTietPhieuNhapXuats;
using VietLife.Business.NhapXuats.PhieuNhapXuats;
using VietLife.Business.PhieuNhapXuats;
using VietLife.Catalog.NhanViens;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;

namespace VietLife.Business.NhapXuats
{
    public class PhieuNhapXuatsAppService : CrudAppService<
        PhieuNhapXuat,
        PhieuNhapXuatDto,
        Guid,
        PagedResultRequestDto,
        CreateUpdatePhieuNhapXuatDto,
        CreateUpdatePhieuNhapXuatDto>,
        IPhieuNhapXuatsAppService
    {
        private readonly IRepository<ChiTietPhieuNhapXuat, Guid> _chiTietRepo;
        private readonly IRepository<LoaiNhapXuat, Guid> _loaiNXRepo;
        private readonly IRepository<NhanVien, Guid> _nhanVienRepo;

        public PhieuNhapXuatsAppService(
            IRepository<PhieuNhapXuat, Guid> repository,
            IRepository<ChiTietPhieuNhapXuat, Guid> chiTietRepo,
            IRepository<LoaiNhapXuat, Guid> loaiNXRepo,
            IRepository<NhanVien, Guid> nhanVienRepo
            )
            : base(repository)
        {
            _chiTietRepo = chiTietRepo;
            _loaiNXRepo = loaiNXRepo;
            _nhanVienRepo = nhanVienRepo;

            GetPolicyName = VietLifePermissions.PhieuNhapXuat.View;
            GetListPolicyName = VietLifePermissions.PhieuNhapXuat.View;
            CreatePolicyName = VietLifePermissions.PhieuNhapXuat.Create;
            UpdatePolicyName = VietLifePermissions.PhieuNhapXuat.Update;
            DeletePolicyName = VietLifePermissions.PhieuNhapXuat.Delete;
        }

        [Authorize(VietLifePermissions.PhieuNhapXuat.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [Authorize(VietLifePermissions.PhieuNhapXuat.View)]
        public async Task<List<PhieuNhapXuatInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => !x.IsDeleted);

            var data = await AsyncExecuter.ToListAsync(query);
            return ObjectMapper.Map<List<PhieuNhapXuat>, List<PhieuNhapXuatInListDto>>(data);
        }

        [Authorize(VietLifePermissions.PhieuNhapXuat.View)]
        public async Task<PagedResultDto<PhieuNhapXuatInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var phieuQuery = await Repository.GetQueryableAsync();
            var loaiNXQuery = await _loaiNXRepo.GetQueryableAsync();
            var nhanVienQuery = await _nhanVienRepo.GetQueryableAsync();

            var query = from px in phieuQuery
                        join lx in loaiNXQuery on px.LoaiNhapXuatId equals lx.Id
                        join nv in nhanVienQuery on px.NhanVienLapId equals nv.Id
                        select new { px, lx, nv };

            if (!string.IsNullOrWhiteSpace(input.Keyword))
            {
                query = query.Where(x =>
                    x.px.MaPhieu.Contains(input.Keyword) ||
                    x.lx.TenLoai.Contains(input.Keyword) ||
                    x.nv.HoTen.Contains(input.Keyword));
            }

            var total = await AsyncExecuter.LongCountAsync(query);

            var list = await AsyncExecuter.ToListAsync(
                query.OrderByDescending(x => x.px.CreationTime)
                     .Skip(input.SkipCount)
                     .Take(input.MaxResultCount));

            var result = list.Select(x => new PhieuNhapXuatInListDto
            {
                Id = x.px.Id,
                MaPhieu = x.px.MaPhieu,
                NgayLap = x.px.NgayLap,
                LoaiNhapXuatTen = x.lx.TenLoai,
                TenNhanVienLap = x.nv.HoTen,
            }).ToList();

            return new PagedResultDto<PhieuNhapXuatInListDto>(total, result);
        }

        [Authorize(VietLifePermissions.PhieuNhapXuat.View)]
        public override async Task<PhieuNhapXuatDto> GetAsync(Guid id)
        {
            await CheckGetPolicyAsync();

            var query = await Repository.WithDetailsAsync(x => x.ChiTietPhieuNhapXuats);
            var entity = await AsyncExecuter.FirstOrDefaultAsync(query, x => x.Id == id);

            if (entity == null)
                throw new EntityNotFoundException(typeof(PhieuNhapXuat), id);

            var dto = await MapToGetOutputDtoAsync(entity);

            if (entity.LoaiNhapXuatId != Guid.Empty)
            {
                var loai = await _loaiNXRepo.GetAsync(entity.LoaiNhapXuatId);
                dto.LoaiNhapXuatTen = loai.TenLoai;
            }

            if (entity.NhanVienLapId.HasValue)
            {
                var nv = await _nhanVienRepo.GetAsync(entity.NhanVienLapId.Value);
                dto.TenNhanVienLap = nv.HoTen;
            }

            return dto;
        }

        [Authorize(VietLifePermissions.PhieuNhapXuat.Create)]
        public override async Task<PhieuNhapXuatDto> CreateAsync(CreateUpdatePhieuNhapXuatDto input)
        {
            await CheckCreatePolicyAsync();

            var entity = ObjectMapper.Map<CreateUpdatePhieuNhapXuatDto, PhieuNhapXuat>(input);

            await Repository.InsertAsync(entity);

            if (input.ChiTietPhieuNhapXuats != null)
            {
                foreach (var ct in input.ChiTietPhieuNhapXuats)
                {
                    // Nếu Id null hoặc Guid.Empty => tạo mới
                    if (ct.Id == Guid.Empty)
                    {
                        ct.PhieuNhapXuatId = entity.Id;
                        var detail = ObjectMapper.Map<CreateUpdateChiTietPhieuNhapXuatDto, ChiTietPhieuNhapXuat>(ct);
                        await _chiTietRepo.InsertAsync(detail);
                    }
                }
            }

            await UnitOfWorkManager.Current.SaveChangesAsync();
            return ObjectMapper.Map<PhieuNhapXuat, PhieuNhapXuatDto>(entity);
        }

        [Authorize(VietLifePermissions.PhieuNhapXuat.Update)]
        public override async Task<PhieuNhapXuatDto> UpdateAsync(Guid id, CreateUpdatePhieuNhapXuatDto input)
        {
            await CheckUpdatePolicyAsync();

            var entity = await Repository.GetAsync(id);
            ObjectMapper.Map(input, entity);

            var oldDetails = await _chiTietRepo.GetListAsync(x => x.PhieuNhapXuatId == id);
            var requestIds = input.ChiTietPhieuNhapXuats
                .Where(x => x.Id != Guid.Empty)
                .Select(x => x.Id)
                .ToList();

            // Xóa các chi tiết không còn trong request
            foreach (var old in oldDetails)
            {
                if (!requestIds.Contains(old.Id))
                    await _chiTietRepo.DeleteAsync(old);
            }

            // Thêm hoặc cập nhật chi tiết
            foreach (var ct in input.ChiTietPhieuNhapXuats)
            {
                if (ct.Id == Guid.Empty)
                {
                    var detail = ObjectMapper.Map<CreateUpdateChiTietPhieuNhapXuatDto, ChiTietPhieuNhapXuat>(ct);
                    detail.PhieuNhapXuatId = id;
                    await _chiTietRepo.InsertAsync(detail);
                }
                else
                {
                    var exist = oldDetails.First(x => x.Id == ct.Id);
                    ObjectMapper.Map(ct, exist);
                    await _chiTietRepo.UpdateAsync(exist);
                }
            }

            await UnitOfWorkManager.Current.SaveChangesAsync();
            return ObjectMapper.Map<PhieuNhapXuat, PhieuNhapXuatDto>(entity);
        }
    }
}
