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

        public SanPhamsAppService(
            IRepository<SanPham, Guid> repository,
            SanPhamManager productManager,
            MaSanPhamGenerator productCodeGenerator,
            IBlobContainer<AnhSanPhamContainer> fileContainer)
            : base(repository)
        {
            _productManager = productManager;
            _productCodeGenerator = productCodeGenerator;
            _fileContainer = fileContainer;
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
                input.GiaBan
            );

            if (!string.IsNullOrEmpty(input.AnhContent))
            {
                await SaveThumbnailImageAsync(input.AnhName, input.AnhContent);
                product.Anh = input.AnhName;
            }

            var created = await Repository.InsertAsync(product, autoSave: true);
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

            if (!string.IsNullOrEmpty(input.AnhContent))
            {
                await SaveThumbnailImageAsync(input.AnhName, input.AnhContent);
                product.Anh = input.AnhName;
            }

            await Repository.UpdateAsync(product, autoSave: true);
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
            var query = await Repository.GetQueryableAsync();
            query = query.WhereIf(!string.IsNullOrWhiteSpace(input.Keyword),
                x => x.Ten.Contains(input.Keyword) || x.Ma.Contains(input.Keyword));

            var total = await AsyncExecuter.LongCountAsync(query);
            var items = await AsyncExecuter.ToListAsync(
                query.OrderByDescending(x => x.CreationTime)
                     .Skip(input.SkipCount)
                     .Take(input.MaxResultCount)
            );

            return new PagedResultDto<SanPhamInListDto>(
                total,
                ObjectMapper.Map<List<SanPham>, List<SanPhamInListDto>>(items)
            );
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
