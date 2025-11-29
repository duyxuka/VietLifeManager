using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.BaoGias;
using VietLife.Business.BaoGiasList.BaoGias;
using VietLife.Business.BaoGiasList.ChiTietBaoGias;
using VietLife.Business.DonHangsList.ChiTietDonHangs;
using VietLife.Business.DonHangsList.DonHangs;
using VietLife.Business.KhachHangs;
using VietLife.Catalog.NhanViens;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Uow;

namespace VietLife.Business.DonHangs
{
    public class DonHangsAppService : CrudAppService<
    DonHang,
    DonHangDto,
    Guid,
    PagedResultRequestDto,
    CreateUpdateDonHangDto,
    CreateUpdateDonHangDto>,
    IDonHangsAppService
    {
        private readonly IRepository<ChiTietDonHang, Guid> _chiTietRepo;
        private readonly IRepository<KhachHang, Guid> _khachHangRepository;
        private readonly IRepository<NhanVien, Guid> _nhanVienRepository;

        public DonHangsAppService(
            IRepository<DonHang, Guid> repo,
            IRepository<ChiTietDonHang, Guid> chiTietRepo, IRepository<KhachHang, Guid> khacHangRepository, IRepository<NhanVien, Guid> nhanVienRepository)
            : base(repo)
        {
            _chiTietRepo = chiTietRepo;

            GetPolicyName = VietLifePermissions.DonHang.View;
            GetListPolicyName = VietLifePermissions.DonHang.View;
            CreatePolicyName = VietLifePermissions.DonHang.Create;
            UpdatePolicyName = VietLifePermissions.DonHang.Update;
            DeletePolicyName = VietLifePermissions.DonHang.Delete;
            _khachHangRepository = khacHangRepository;
            _nhanVienRepository = nhanVienRepository;
        }
        [Authorize(VietLifePermissions.DonHang.View)]
        public override async Task<DonHangDto> GetAsync(Guid id)
        {
            await CheckGetPolicyAsync();

            var query = await Repository.WithDetailsAsync(x => x.ChiTietDonHangs);
            var entity = await AsyncExecuter.FirstOrDefaultAsync(query, x => x.Id == id);

            if (entity == null)
                throw new EntityNotFoundException(typeof(DonHang), id);

            return await MapToGetOutputDtoAsync(entity);
        }
        // CREATE
        [Authorize(VietLifePermissions.DonHang.Create)]
        public override async Task<DonHangDto> CreateAsync(CreateUpdateDonHangDto input)
        {
            // Mapping input sang entity
            var entity = ObjectMapper.Map<CreateUpdateDonHangDto, DonHang>(input);

            // Lưu DonHang trước để lấy Id
            await Repository.InsertAsync(entity);

            // Thêm chi tiết DonHang
            if (input.ChiTietDonHangs != null && input.ChiTietDonHangs.Any())
            {
                var chiTietList = new List<ChiTietDonHang>();

                foreach (var ct in input.ChiTietDonHangs)
                {
                    // Validation đơn giản
                    if (ct.SoLuong <= 0) ct.SoLuong = 1;
                    if (ct.DonGia < 0) ct.DonGia = 0;
                    if (ct.ChietKhau < 0) ct.ChietKhau = 0;
                    if (ct.VAT < 0) ct.VAT = 0;

                    chiTietList.Add(new ChiTietDonHang
                    {
                        DonHangId = entity.Id,
                        SanPhamId = ct.SanPhamId,
                        SoLuong = ct.SoLuong,
                        DonGia = ct.DonGia,
                        ChietKhau = ct.ChietKhau,
                        VAT = ct.VAT
                    });
                }

                await _chiTietRepo.InsertManyAsync(chiTietList);

                // Tính tổng tiền
                entity.TongTien = chiTietList.Sum(x =>
                    x.SoLuong * x.DonGia * (1 - x.ChietKhau / 100) * (1 + x.VAT / 100));
            }

            await UnitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<DonHang, DonHangDto>(entity);
        }

        // UPDATE
        [Authorize(VietLifePermissions.DonHang.Update)]
        public override async Task<DonHangDto> UpdateAsync(Guid id, CreateUpdateDonHangDto input)
        {
            await CheckUpdatePolicyAsync();

            var donHang = await Repository.GetAsync(id);
            ObjectMapper.Map(input, donHang);

            var oldDetails = await _chiTietRepo.GetListAsync(x => x.DonHangId == id);

            var requestIds = input.ChiTietDonHangs
                .Where(x => x.Id != Guid.Empty)
                .Select(x => x.Id)
                .ToList();

            // Xóa chi tiết không còn trong request
            foreach (var old in oldDetails)
            {
                if (!requestIds.Contains(old.Id))
                    await _chiTietRepo.DeleteAsync(old);
            }

            // Thêm / cập nhật chi tiết
            foreach (var ct in input.ChiTietDonHangs)
            {
                if (ct.SoLuong <= 0) ct.SoLuong = 1;
                if (ct.DonGia < 0) ct.DonGia = 0;
                if (ct.ChietKhau < 0) ct.ChietKhau = 0;
                if (ct.VAT < 0) ct.VAT = 0;

                if (ct.Id == Guid.Empty)
                {
                    var newDetail = new ChiTietDonHang
                    {
                        DonHangId = id,
                        SanPhamId = ct.SanPhamId,
                        SoLuong = ct.SoLuong,
                        DonGia = ct.DonGia,
                        ChietKhau = ct.ChietKhau,
                        VAT = ct.VAT
                    };
                    await _chiTietRepo.InsertAsync(newDetail);
                }
                else
                {
                    var existing = oldDetails.FirstOrDefault(x => x.Id == ct.Id);
                    if (existing != null)
                    {
                        ObjectMapper.Map(ct, existing);
                        await _chiTietRepo.UpdateAsync(existing);
                    }
                }
            }

            // Tính lại tổng tiền
            var updatedDetails = await _chiTietRepo.GetListAsync(x => x.DonHangId == id);
            donHang.TongTien = updatedDetails.Sum(x =>
                x.SoLuong * x.DonGia * (1 - x.ChietKhau / 100) * (1 + x.VAT / 100));

            await UnitOfWorkManager.Current.SaveChangesAsync();

            return ObjectMapper.Map<DonHang, DonHangDto>(donHang);
        }

        // DELETE MULTIPLE
        [Authorize(VietLifePermissions.DonHang.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [Authorize(VietLifePermissions.DonHang.View)]
        // GET ALL
        public async Task<List<DonHangInListDto>> GetListAllAsync()
        {
            var query = await Repository.GetQueryableAsync();
            var data = await AsyncExecuter.ToListAsync(query);
            return ObjectMapper.Map<List<DonHang>, List<DonHangInListDto>>(data);
        }

        // FILTER
        [Authorize(VietLifePermissions.DonHang.View)]
        public async Task<PagedResultDto<DonHangInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var donHangQuery = await Repository.GetQueryableAsync();
            var khachHangQuery = await _khachHangRepository.GetQueryableAsync();
            var nhanVienQuery = await _nhanVienRepository.GetQueryableAsync();

            var query = from dh in donHangQuery
                        join kh in khachHangQuery on dh.KhachHangId equals kh.Id
                        join nv in nhanVienQuery on dh.NhanVienBanHangId equals nv.Id
                        select new { dh, kh, nv };

            // Filter theo keyword
            if (!string.IsNullOrWhiteSpace(input.Keyword))
            {
                query = query.Where(x =>
                    x.dh.MaDonHang.Contains(input.Keyword) ||
                    x.kh.TenKhachHang.Contains(input.Keyword) ||
                    x.nv.HoTen.Contains(input.Keyword));
            }

            var total = await AsyncExecuter.LongCountAsync(query);

            var list = await AsyncExecuter.ToListAsync(
                query
                .OrderByDescending(x => x.dh.CreationTime)
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount)
            );

            var result = list.Select(x => new DonHangInListDto
            {
                Id = x.dh.Id,
                MaDonHang = x.dh.MaDonHang,
                NgayDatHang = x.dh.NgayDatHang,
                TenKhachHang = x.kh.TenKhachHang,
                NhanVienBanHang = x.nv.HoTen,
                TongTien = x.dh.TongTien
            }).ToList();

            return new PagedResultDto<DonHangInListDto>(total, result);
        }
    }
}
