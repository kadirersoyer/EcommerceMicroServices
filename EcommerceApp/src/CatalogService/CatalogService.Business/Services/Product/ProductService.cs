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
            try
            {
                var entity = await _productRepository.Add(product);
                await _unitOfWork.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBackTransaction();
                throw new Exception(ex.Message);
            }
        }
    }
}
