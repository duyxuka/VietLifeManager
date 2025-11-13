using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.CheDos.CheDoNhanViens;
using VietLife.Catalog.NhanViens;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace VietLife.Catalog.CheDoNhanViens
{
    public class CheDoNhanViensAppService : CrudAppService<CheDoNhanVien, CheDoNhanVienDto, Guid, PagedResultRequestDto, CreateUpdateCheDoNhanVienDto, CreateUpdateCheDoNhanVienDto>,
        ICheDoNhanViensAppService
    {
        private readonly IRepository<NhanVien, Guid> _userRepository;
        private readonly IRepository<LoaiCheDo, Guid> _loaiCheDoRepository;
        private readonly IAuthorizationService _authService;
        private readonly IRepository<HopDongNhanVien, Guid> _hopDongRepository;
        public CheDoNhanViensAppService(IRepository<CheDoNhanVien, Guid> repository, IRepository<HopDongNhanVien, Guid> hopDongRepository, IRepository<NhanVien, Guid> userRepository, IRepository<LoaiCheDo, Guid> loaiCheDoRepository, IAuthorizationService authService) : base(repository)
        {
            _userRepository = userRepository;
            _loaiCheDoRepository = loaiCheDoRepository;
            _hopDongRepository = hopDongRepository;

            GetPolicyName = VietLifePermissions.CheDoNhanVien.View;
            GetListPolicyName = VietLifePermissions.CheDoNhanVien.View;
            CreatePolicyName = VietLifePermissions.CheDoNhanVien.Create;
            UpdatePolicyName = VietLifePermissions.CheDoNhanVien.Update;
            DeletePolicyName = VietLifePermissions.CheDoNhanVien.Delete;
            _authService = authService;
        }

        [Authorize(VietLifePermissions.CheDoNhanVien.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [Authorize(VietLifePermissions.CheDoNhanVien.View)]
        public async Task<List<CheDoNhanVienInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => !x.IsDeleted);
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<CheDoNhanVien>, List<CheDoNhanVienInListDto>>(data);
        }

        [Authorize(VietLifePermissions.CheDoNhanVien.View)]
        public async Task<PagedResultDto<CheDoNhanVienInListDto>> GetListFilterAsync(CheDoNhanVienListFilterDto input)
        {
            var cheDoQuery = await Repository.GetQueryableAsync();
            var nhanVienQuery = await _userRepository.GetQueryableAsync();
            var loaiCheDoQuery = await _loaiCheDoRepository.GetQueryableAsync();
            var hopDongQuery = await _hopDongRepository.GetQueryableAsync();

            var query = from cd in cheDoQuery
                        join nv in nhanVienQuery on cd.NhanVienId equals nv.Id into joinedNv
                        from nv in joinedNv.DefaultIfEmpty()
                        join lcd in loaiCheDoQuery on cd.LoaiCheDoId equals lcd.Id into joinedLcd
                        from lcd in joinedLcd.DefaultIfEmpty()
                        join hd in hopDongQuery on cd.NhanVienId equals hd.NhanVienId into joinedHd
                        from hd in joinedHd.DefaultIfEmpty()
                        where !cd.IsDeleted
                           && (hd == null || hd.LaHienHanh)
                        orderby cd.CreationTime descending
                        select new CheDoNhanVienInListDto
                        {
                            Id = cd.Id,
                            NhanVienId = cd.NhanVienId,
                            TenNhanVien = nv != null ? nv.HoTen : "N/A",
                            TenLoaiCheDo = lcd != null ? lcd.TenLoaiCheDo : "N/A",
                            SoNgay = cd.SoNgay,
                            SoCong = cd.SoCong,
                            ThanhTien = cd.ThanhTien,
                            NgayBatDau = cd.NgayBatDau,
                            NgayKetThuc = cd.NgayKetThuc,
                            LyDo = cd.LyDo,
                            GhiChu = cd.GhiChu,
                            TrangThai = cd.TrangThai,
                            NguoiDuyetId = cd.NguoiDuyetId,
                            DonGiaCong = hd != null ? hd.DonGiaCong : 0
                        };
            var canApprove = await _authService.IsGrantedAsync(VietLifePermissions.CheDoNhanVien.Approve);
            if (!canApprove && CurrentUser.Id.HasValue)
            {
                query = query.Where(x => x.NhanVienId == CurrentUser.Id.Value);
            }

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            return new PagedResultDto<CheDoNhanVienInListDto>(totalCount, data);
        }

        [Authorize(VietLifePermissions.CheDoNhanVien.Create)]
        public override async Task<CheDoNhanVienDto> CreateAsync(CreateUpdateCheDoNhanVienDto input)
        {
            // Gán NhanVienId là người đang đăng nhập
            if (CurrentUser.Id.HasValue)
            {
                input.NhanVienId = CurrentUser.Id.Value;
            }

            input.TrangThai = false;

            var entity = await base.MapToEntityAsync(input);
            var loaiCheDo = await _loaiCheDoRepository.GetAsync(input.LoaiCheDoId);
            entity.LoaiCheDo = loaiCheDo;
            var hopDongHienHanh = await _hopDongRepository
                .FirstOrDefaultAsync(hd => hd.NhanVienId == input.NhanVienId && hd.LaHienHanh);

            var donGiaCong = hopDongHienHanh?.DonGiaCong ?? 0;

            // 🔹 Gọi hàm tính Thành tiền
            entity.TinhThanhTien(donGiaCong);

            await Repository.InsertAsync(entity);
            await UnitOfWorkManager.Current.SaveChangesAsync();

            return await MapToGetOutputDtoAsync(entity);
        }

        [Authorize(VietLifePermissions.CheDoNhanVien.Update)]
        public override async Task<CheDoNhanVienDto> UpdateAsync(Guid id, CreateUpdateCheDoNhanVienDto input)
        {
            // Nếu muốn, bạn có thể tự động gán lại NhanVienId khi chỉnh sửa
            if (CurrentUser.Id.HasValue)
            {
                input.NhanVienId = CurrentUser.Id.Value;
            }

            var entity = await GetEntityByIdAsync(id);

            var canApprove = await _authService.IsGrantedAsync(VietLifePermissions.CheDoNhanVien.Approve);

            if (!canApprove)
            {
                input.TrangThai = entity.TrangThai;
                input.NguoiDuyetId = entity.NguoiDuyetId;
                input.LoaiCheDoId = entity.LoaiCheDoId;
            }

            await MapToEntityAsync(input, entity);

            // 🔹 Load lại LoaiCheDo
            var loaiCheDo = await _loaiCheDoRepository.GetAsync(input.LoaiCheDoId);
            entity.LoaiCheDo = loaiCheDo;

            var hopDongHienHanh = await _hopDongRepository
                .FirstOrDefaultAsync(hd => hd.NhanVienId == entity.NhanVienId && hd.LaHienHanh);

            var donGiaCong = hopDongHienHanh?.DonGiaCong ?? 0;

            // 🔹 Tính lại Thành tiền
            entity.TinhThanhTien(donGiaCong);

            await Repository.UpdateAsync(entity);
            await UnitOfWorkManager.Current.SaveChangesAsync();

            return await MapToGetOutputDtoAsync(entity);
        }
    }
}
