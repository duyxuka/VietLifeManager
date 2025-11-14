using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using VietLife.Business.SanPhamsList.SanPhams;
using VietLife.Permissions;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain.Repositories;

namespace VietLife.Business.SanPhams
{
    public class SanPhamsAppService :
        CrudAppService<SanPham, SanPhamDto, Guid, PagedResultRequestDto, CreateUpdateSanPhamDto, CreateUpdateSanPhamDto>,
        ISanPhamsAppService
    {
        private readonly SanPhamManager _productManager;
        private readonly IBlobContainer<AnhSanPhamContainer> _fileContainer;
        private readonly MaSanPhamGenerator _productCodeGenerator;
        private readonly IRepository<NhomSanPham, Guid> _nhomSanPhamRepository;
        private readonly IRepository<DonViTinh, Guid> _donViTinhRepository;

        public SanPhamsAppService(
            IRepository<SanPham, Guid> repository,
            SanPhamManager productManager,
            MaSanPhamGenerator productCodeGenerator,
            IBlobContainer<AnhSanPhamContainer> fileContainer,
            IRepository<NhomSanPham, Guid> nhomSanPhamRepository,
            IRepository<DonViTinh, Guid> donViTinhRepository)
            : base(repository)
        {
            _productManager = productManager;
            _productCodeGenerator = productCodeGenerator;
            _fileContainer = fileContainer;
            _nhomSanPhamRepository = nhomSanPhamRepository;
            _donViTinhRepository = donViTinhRepository;
        }

        public override async Task<SanPhamDto> CreateAsync(CreateUpdateSanPhamDto input)
        {
            var product = await _productManager.CreateAsync(
                input.Ten,
                input.Ma,
                input.Model,
                input.HoatDong,
                input.MoTa,
                input.Anh,
                input.GiaBan,
                input.DonViTinhId,
                input.NhomSanPhamId
            );

            if (!string.IsNullOrEmpty(input.AnhContent))
            {
                await SaveThumbnailImageAsync(input.AnhName, input.AnhContent);
                product.Anh = input.AnhName;
            }

            var created = await Repository.InsertAsync(product);
            return ObjectMapper.Map<SanPham, SanPhamDto>(created);
        }

        public override async Task<SanPhamDto> UpdateAsync(Guid id, CreateUpdateSanPhamDto input)
        {
            var product = await Repository.GetAsync(id);
            if (product == null)
                throw new BusinessException(VietLifeDomainErrorCodes.ProductIsNotExists);

            product.Ten = input.Ten;
            product.Ma = input.Ma;
            product.Model = input.Model;
            product.HoatDong = input.HoatDong;
            product.MoTa = input.MoTa;
            product.GiaBan = input.GiaBan;
            product.DonViTinhId = input.DonViTinhId;
            product.NhomSanPhamId = input.NhomSanPhamId;

            if (!string.IsNullOrEmpty(input.AnhContent))
            {
                await SaveThumbnailImageAsync(input.AnhName, input.AnhContent);
                product.Anh = input.AnhName;
            }

            await Repository.UpdateAsync(product);
            return ObjectMapper.Map<SanPham, SanPhamDto>(product);
        }

        public async Task DeleteMultipleAsync(IEnumerable<Guid> ids)
        {
            await Repository.DeleteManyAsync(ids);
            await UnitOfWorkManager.Current.SaveChangesAsync();
        }

        public async Task<List<SanPhamInListDto>> GetListAllAsync()
        {
            var queryable = await Repository.GetQueryableAsync();
            var list = await AsyncExecuter.ToListAsync(queryable.Where(x => x.HoatDong));
            return ObjectMapper.Map<List<SanPham>, List<SanPhamInListDto>>(list);
        }

        public async Task<PagedResultDto<SanPhamInListDto>> GetListFilterAsync(SanPhamListFilterDto input)
        {
            var query = from sp in await Repository.GetQueryableAsync()
                        join nhom in await _nhomSanPhamRepository.GetQueryableAsync()
                            on sp.NhomSanPhamId equals nhom.Id
                        join dv in await _donViTinhRepository.GetQueryableAsync()
                            on sp.DonViTinhId equals dv.Id
                        select new { sp, NhomTen = nhom.TenNhom, DonViTen = dv.TenDonVi };

            if (!string.IsNullOrWhiteSpace(input.Keyword))
            {
                query = query.Where(x => x.sp.Ten.Contains(input.Keyword) || x.sp.Ma.Contains(input.Keyword));
            }

            var totalCount = await AsyncExecuter.LongCountAsync(query);

            var items = await AsyncExecuter.ToListAsync(
                query.OrderByDescending(x => x.sp.CreationTime)
                     .Skip(input.SkipCount)
                     .Take(input.MaxResultCount)
            );

            var result = items.Select(x =>
            {
                var dto = ObjectMapper.Map<SanPham, SanPhamInListDto>(x.sp);
                dto.NhomSanPhamTen = x.NhomTen;
                dto.DonViTinhTen = x.DonViTen;
                return dto;
            }).ToList();

            return new PagedResultDto<SanPhamInListDto>(totalCount, result);
        }

        private async Task SaveThumbnailImageAsync(string fileName, string base64)
        {
            Regex regex = new Regex(@"^[\w/\:.-]+;base64,");
            base64 = regex.Replace(base64, string.Empty);
            byte[] bytes = Convert.FromBase64String(base64);
            await _fileContainer.SaveAsync(fileName, bytes, overrideExisting: true);
        }

        public async Task<string> GetThumbnailImageAsync(string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
                return null;

            var fileBytes = await _fileContainer.GetAllBytesOrNullAsync(fileName);
            if (fileBytes == null) return null;

            return Convert.ToBase64String(fileBytes);
        }
        public async Task<string> GetSuggestNewCodeAsync()
        {
            return await _productCodeGenerator.GenerateAsync();
        }

    }
}
