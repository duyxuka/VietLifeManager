using System;
using System.Threading.Tasks;
using System.Xml.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace VietLife.Business.SanPhams
{
    public class SanPhamManager : DomainService
    {
        private readonly IRepository<SanPham, Guid> _productRepository;

        public SanPhamManager(IRepository<SanPham, Guid> productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<SanPham> CreateAsync(
            string ten,
            string ma,
            string model,
            bool hoatDong,
            string moTa,
            string anh,
            decimal giaBan)
        {
            // Kiểm tra trùng tên
            if (await _productRepository.AnyAsync(x => x.Ten == ten))
                throw new UserFriendlyException(
                    "Tên sản phẩm đã tồn tại.",
                    VietLifeDomainErrorCodes.ProductNameAlreadyExists
                );

            // Kiểm tra trùng mã
            if (await _productRepository.AnyAsync(x => x.Ma == ma))
                throw new UserFriendlyException(
                    "Mã sản phẩm đã tồn tại.",
                    VietLifeDomainErrorCodes.ProductCodeAlreadyExists
                );

            return new SanPham(
                Guid.NewGuid(),
                ten,
                ma,
                model,
                hoatDong,
                moTa,
                anh,
                giaBan
            );
        }
    }
}