using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.CheDos.CheDoNhanViens;
using VietLife.CheDoNhanViens;
using VietLife.NhanViens;
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
        public CheDoNhanViensAppService(IRepository<CheDoNhanVien, Guid> repository, IRepository<NhanVien, Guid> userRepository, IRepository<LoaiCheDo, Guid> loaiCheDoRepository) : base(repository)
        {
            _userRepository = userRepository;
            _loaiCheDoRepository = loaiCheDoRepository;
        }

        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        public async Task<List<CheDoNhanVienInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => !x.IsDeleted);
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<CheDoNhanVien>, List<CheDoNhanVienInListDto>>(data);
        }

        public async Task<PagedResultDto<CheDoNhanVienInListDto>> GetListFilterAsync(CheDoNhanVienListFilterDto input)
        {
            var cheDoQuery = await Repository.GetQueryableAsync();
            var nhanVienQuery = await _userRepository.GetQueryableAsync();
            var loaiCheDoQuery = await _loaiCheDoRepository.GetQueryableAsync();

            var query = from cd in cheDoQuery
                        join nv in nhanVienQuery on cd.NhanVienId equals nv.Id into joinedNv
                        from nv in joinedNv.DefaultIfEmpty()
                        join lcd in loaiCheDoQuery on cd.LoaiCheDoId equals lcd.Id into joinedLcd
                        from lcd in joinedLcd.DefaultIfEmpty()
                        where !cd.IsDeleted
                              && cd.NhanVienId == CurrentUser.Id.Value
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
                            TrangThai = cd.TrangThai
                        };

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            return new PagedResultDto<CheDoNhanVienInListDto>(totalCount, data);
        }
        public override async Task<CheDoNhanVienDto> CreateAsync(CreateUpdateCheDoNhanVienDto input)
        {
            // Gán NhanVienId là người đang đăng nhập
            if (CurrentUser.Id.HasValue)
            {
                input.NhanVienId = CurrentUser.Id.Value;
            }
            var entity = await base.MapToEntityAsync(input);
            var loaiCheDo = await _loaiCheDoRepository.GetAsync(input.LoaiCheDoId);
            entity.LoaiCheDo = loaiCheDo;

            // 🔹 Lấy hệ số lương từ nhân viên (DonGiaCong)
            var nhanVien = await _userRepository.GetAsync(entity.NhanVienId);
            var heSoLuong = nhanVien?.DonGiaCong ?? 0;

            // 🔹 Gọi hàm tính Thành tiền
            entity.TinhThanhTien(heSoLuong);

            await Repository.InsertAsync(entity);
            await UnitOfWorkManager.Current.SaveChangesAsync();

            return await MapToGetOutputDtoAsync(entity);
        }

        public override async Task<CheDoNhanVienDto> UpdateAsync(Guid id, CreateUpdateCheDoNhanVienDto input)
        {
            // Nếu muốn, bạn có thể tự động gán lại NhanVienId khi chỉnh sửa
            if (CurrentUser.Id.HasValue)
            {
                input.NhanVienId = CurrentUser.Id.Value;
            }

            var entity = await GetEntityByIdAsync(id);
            await MapToEntityAsync(input, entity);

            // 🔹 Load lại LoaiCheDo
            var loaiCheDo = await _loaiCheDoRepository.GetAsync(input.LoaiCheDoId);
            entity.LoaiCheDo = loaiCheDo;

            var nhanVien = await _userRepository.GetAsync(entity.NhanVienId);
            var heSoLuong = nhanVien?.DonGiaCong ?? 0;

            // 🔹 Tính lại Thành tiền
            entity.TinhThanhTien(heSoLuong);

            await Repository.UpdateAsync(entity);
            await UnitOfWorkManager.Current.SaveChangesAsync();

            return await MapToGetOutputDtoAsync(entity);
        }
    }
}
