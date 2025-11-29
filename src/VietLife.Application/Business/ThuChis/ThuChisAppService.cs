using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VietLife.Business.ThuChisList.ThuChis;
using VietLife.Catalog.NhanViens;
using VietLife.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Uow;

namespace VietLife.Business.ThuChis
{
    public class ThuChisAppService :
        CrudAppService<ThuChi, ThuChiDto, Guid,
        PagedResultRequestDto, CreateUpdateThuChiDto, CreateUpdateThuChiDto>,
        IThuChisAppService
    {
        private readonly IRepository<ThuChi, Guid> _repository;
        private readonly IRepository<LoaiThuChi, Guid> _loaiThuChiRepo;
        private readonly IRepository<TaiKhoanKeToan, Guid> _taiKhoanRepo;
        private readonly IRepository<NhanVien, Guid> _nhanVienRepo;

        public ThuChisAppService(
            IRepository<ThuChi, Guid> repository,
            IRepository<LoaiThuChi, Guid> loaiThuChiRepo,
            IRepository<TaiKhoanKeToan, Guid> taiKhoanRepo,
            IRepository<NhanVien, Guid> nhanVienRepo)
            : base(repository)
        {
            _repository = repository;
            _loaiThuChiRepo = loaiThuChiRepo;
            _taiKhoanRepo = taiKhoanRepo;
            _nhanVienRepo = nhanVienRepo;

            GetPolicyName = VietLifePermissions.ThuChi.View;
            GetListPolicyName = VietLifePermissions.ThuChi.View;
            CreatePolicyName = VietLifePermissions.ThuChi.Create;
            UpdatePolicyName = VietLifePermissions.ThuChi.Update;
            DeletePolicyName = VietLifePermissions.ThuChi.Delete;
        }

        [Authorize(VietLifePermissions.ThuChi.Delete)]
        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        [Authorize(VietLifePermissions.ThuChi.View)]
        public async Task<List<ThuChiInListDto>> GetListAllAsync()
        {
            var query = await BuildJoinedQuery();
            return await AsyncExecuter.ToListAsync(query);
        }

        [Authorize(VietLifePermissions.ThuChi.View)]
        public async Task<PagedResultDto<ThuChiInListDto>> GetListFilterAsync(BaseListFilterDto input)
        {
            var query = await BuildJoinedQuery();

            // Keyword filter
            if (!string.IsNullOrWhiteSpace(input.Keyword))
            {
                query = query.Where(x =>
                    x.MaPhieu.Contains(input.Keyword) ||
                    x.DienGiai.Contains(input.Keyword)
                );
            }

            var total = await AsyncExecuter.LongCountAsync(query);

            var data = await AsyncExecuter.ToListAsync(
                query.Skip(input.SkipCount).Take(input.MaxResultCount)
            );

            return new PagedResultDto<ThuChiInListDto>(total, data);
        }

        // Build query có join đầy đủ
        private async Task<IQueryable<ThuChiInListDto>> BuildJoinedQuery()
        {
            var thuChiQuery = await _repository.GetQueryableAsync();
            var loaiQuery = await _loaiThuChiRepo.GetQueryableAsync();
            var tkQuery = await _taiKhoanRepo.GetQueryableAsync();
            var nvQuery = await _nhanVienRepo.GetQueryableAsync();

            var query = from tc in thuChiQuery
                        join loai in loaiQuery on tc.LoaiThuChiId equals loai.Id into loaiGroup
                        from loai in loaiGroup.DefaultIfEmpty()

                        join tkNo in tkQuery on tc.TaiKhoanNoId equals tkNo.Id into tkNoGroup
                        from tkNo in tkNoGroup.DefaultIfEmpty()

                        join tkCo in tkQuery on tc.TaiKhoanCoId equals tkCo.Id into tkCoGroup
                        from tkCo in tkCoGroup.DefaultIfEmpty()

                        join nv in nvQuery on tc.NguoiDuyetId equals nv.Id into nvGroup
                        from nv in nvGroup.DefaultIfEmpty()

                        select new ThuChiInListDto
                        {
                            Id = tc.Id,
                            MaPhieu = tc.MaPhieu,
                            NgayGiaoDich = tc.NgayGiaoDich,
                            NgayHachToan = tc.NgayHachToan,
                            DienGiai = tc.DienGiai,
                            SoTien = tc.SoTien,
                            Status = tc.Status,
                            PhuongThucThanhToan = tc.PhuongThucThanhToan,
                            LoaiThuChiId = tc.LoaiThuChiId,
                            TenLoaiThuChi = loai.Ten,
                            
                            TaiKhoanNoId = tc.TaiKhoanNoId,
                            TenTaiKhoanNo = tkNo.TenTaiKhoan,

                            TaiKhoanCoId = tc.TaiKhoanCoId,
                            TenTaiKhoanCo = tkCo.TenTaiKhoan,

                            NguoiDuyetId = tc.NguoiDuyetId,
                            TenNguoiDuyet = nv.HoTen
                        };

            return query;
        }
    }
}
