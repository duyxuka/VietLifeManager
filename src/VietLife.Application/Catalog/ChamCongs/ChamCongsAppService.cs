using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Catalog.PhongBans;
using VietLife.ChamCongs;
using VietLife.LichLamViecs;
using VietLife.NhanViens;
using VietLife.Permissions;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace VietLife.Catalog.ChamCongs
{
    [Authorize(VietLifePermissions.ChamCong.Default)]
    public class ChamCongsAppService : CrudAppService<ChamCong, ChamCongDto, Guid, PagedResultRequestDto, CreateUpdateChamCongDto, CreateUpdateChamCongDto>,
        IChamCongsAppService
    {
        private readonly ICurrentUser _currentUser;
        private readonly IRepository<NhanVien, Guid> _userRepository;
        private readonly IRepository<LichLamViec, Guid> _lichLamViecRepository;
        public ChamCongsAppService(IRepository<ChamCong, Guid> repository, ICurrentUser currentUser, IRepository<NhanVien, Guid> userRepository, IRepository<LichLamViec, Guid> lichLamViecRepository) : base(repository)
        {
            _currentUser = currentUser;
            _userRepository = userRepository;
            _lichLamViecRepository = lichLamViecRepository;

            GetPolicyName = VietLifePermissions.ChamCong.Default;
            GetListPolicyName = VietLifePermissions.ChamCong.Default;
            CreatePolicyName = VietLifePermissions.ChamCong.Create;
            UpdatePolicyName = VietLifePermissions.ChamCong.Update;
            DeletePolicyName = VietLifePermissions.ChamCong.Delete;
        }

        [Authorize(VietLifePermissions.ChamCong.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [Authorize(VietLifePermissions.ChamCong.Default)]
        public async Task<List<ChamCongInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            query = query.Where(x => !x.IsDeleted);
            var data = await AsyncExecuter.ToListAsync(query);

            return ObjectMapper.Map<List<ChamCong>, List<ChamCongInListDto>>(data);
        }

        [Authorize(VietLifePermissions.ChamCong.Default)]
        public async Task<PagedResultDto<ChamCongInListDto>> GetListFilterAsync(ChamCongListFilterDto input)
        {
            var chamCongQuery = await Repository.GetQueryableAsync();
            var nhanVienQuery = await _userRepository.GetQueryableAsync();

            var query = from cc in chamCongQuery
                        join nv in nhanVienQuery on cc.NhanVienId equals nv.Id into joined
                        from nv in joined.DefaultIfEmpty()
                        where !cc.IsDeleted &&
                              (!input.NhanVienId.HasValue || cc.NhanVienId == input.NhanVienId.Value)
                        orderby cc.NgayLam descending
                        select new ChamCongInListDto
                        {
                            Id = cc.Id,
                            NhanVienId = cc.NhanVienId,
                            TenNhanVien = nv != null ? nv.HoTen : "N/A",
                            NgayLam = cc.NgayLam,
                            GioVao = cc.GioVao,
                            GioRa = cc.GioRa,
                            SoGioLam = cc.SoGioLam,
                            SoPhutDiMuon = cc.SoPhutDiMuon,
                            SoPhutVeSom = cc.SoPhutVeSom,
                            CongNgay = cc.CongNgay,
                            TrangThai = cc.TrangThai
                        };

            var totalCount = await AsyncExecuter.LongCountAsync(query);
            var data = await AsyncExecuter.ToListAsync(query
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount));

            return new PagedResultDto<ChamCongInListDto>(totalCount, data);
        }

        [Authorize(VietLifePermissions.ChamCong.CheckIn)]
        public async Task CheckInAsync()
        {
            if (_currentUser.Id == null)
                throw new UserFriendlyException("Không thể xác định người dùng hiện tại!");

            var today = DateTime.Now.Date;
            var now = DateTime.Now;

            // Kiểm tra lịch làm việc
            var lichLamViec = await _lichLamViecRepository
                .FirstOrDefaultAsync(l => l.Thang == today.Month && l.Nam == today.Year);
            if (lichLamViec == null)
                throw new UserFriendlyException("Không tìm thấy lịch làm việc cho tháng này!");

            // Kiểm tra ngày làm việc
            var ngayLamList = lichLamViec.NgayLam?.Split(',').Select(int.Parse).ToList() ?? new List<int>();
            if (!ngayLamList.Contains(today.Day))
                throw new UserFriendlyException("Hôm nay không phải ngày làm việc!");

            // Kiểm tra đã check-in chưa
            var existing = await Repository.FirstOrDefaultAsync(x => x.NhanVienId == _currentUser.Id && x.NgayLam == today);
            if (existing != null)
                throw new UserFriendlyException("Bạn đã check-in hôm nay!");

            // Tính toán đi muộn
            var gioBatDau = lichLamViec.GioBatDauMacDinh ?? new TimeSpan(8, 30, 0); // Mặc định 8:30 AM
            var soPhutDiMuon = now.TimeOfDay > gioBatDau ? (decimal)(now.TimeOfDay - gioBatDau).TotalMinutes : 0;

            var chamCong = new ChamCong
            {
                NhanVienId = _currentUser.Id.Value,
                NgayLam = today,
                GioVao = now,
                SoPhutDiMuon = soPhutDiMuon,
                TrangThai = true,
                CongNgay = 1 // Mặc định 1 công, sẽ điều chỉnh khi check-out
            };

            await Repository.InsertAsync(chamCong);
        }

        [Authorize(VietLifePermissions.ChamCong.CheckOut)]
        public async Task CheckOutAsync()
        {
            if (_currentUser.Id == null)
                throw new UserFriendlyException("Không thể xác định người dùng hiện tại!");

            var today = DateTime.Now.Date;
            var now = DateTime.Now;

            // Tìm bản ghi chấm công hôm nay
            var chamCong = await Repository.FirstOrDefaultAsync(x => x.NhanVienId == _currentUser.Id && x.NgayLam == today);
            if (chamCong == null)
                throw new UserFriendlyException("Bạn chưa check-in hôm nay!");

            // Kiểm tra lịch làm việc
            var lichLamViec = await _lichLamViecRepository
                .FirstOrDefaultAsync(l => l.Thang == today.Month && l.Nam == today.Year);
            if (lichLamViec == null)
                throw new UserFriendlyException("Không tìm thấy lịch làm việc cho tháng này!");

            // Tính toán về sớm và số giờ làm
            var gioKetThuc = lichLamViec.GioKetThucMacDinh ?? new TimeSpan(17, 30, 0); // Mặc định 5:30 PM
            var soPhutVeSom = now.TimeOfDay < gioKetThuc ? (decimal)(gioKetThuc - now.TimeOfDay).TotalMinutes : 0;
            var soGioLam = chamCong.GioVao.HasValue ? (decimal)(now - chamCong.GioVao.Value).TotalHours : 0;

            // Tính công ngày
            chamCong.GioRa = now;
            chamCong.SoGioLam = soGioLam;
            chamCong.SoPhutVeSom = soPhutVeSom;
            chamCong.TinhCongNgay(new TimeSpan(8, 0, 0)); // 8 giờ = 1 công
            chamCong.TrangThai = false;

            await Repository.UpdateAsync(chamCong);
        }
    }
}
