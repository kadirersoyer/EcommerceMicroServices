using CatalogService.Infrastructure.Repositories;
using CatalogService.Infrastructure.UoW;
using ProductEntity = CatalogService.Infrastructure.Entities.Product;

namespace CatalogService.Business.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<ProductEntity> _productRepository;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productRepository = _unitOfWork.GetRepository<ProductEntity>();
        }
        public async Task<ProductEntity> AddProductAsync(ProductEntity product)
        {
            var entity = await _productRepository.Add(product);
            return entity;
        }
    }
}
