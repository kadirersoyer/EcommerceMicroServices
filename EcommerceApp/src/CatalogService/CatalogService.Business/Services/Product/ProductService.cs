using CatalogService.Infrastructure.Repositories;
using CatalogService.Infrastructure.UoW;

namespace CatalogService.Business.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<CatalogService.Infrastructure.Entities.Product> _productRepository;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productRepository = _unitOfWork.GetRepository<CatalogService.Infrastructure.Entities.Product>();
        }
        public async Task<CatalogService.Infrastructure.Entities.Product> AddProductAsync(CatalogService.Infrastructure.Entities.Product product)
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

        public async Task<bool> DeleteAsync(int productId)
        {
            try
            {
                await _productRepository.DeleteById(productId);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBackTransaction();
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<CatalogService.Infrastructure.Entities.Product>> GetAllAsync()
        {
            return await _productRepository.GetAll();
        }

        public async Task<CatalogService.Infrastructure.Entities.Product> GetProductAsync(int productId)
        {
            var entity = await _productRepository.GetById(productId);
            return entity;
        }

        public async Task<List<CatalogService.Infrastructure.Entities.Product>> GetProductsByCategoryNameAsync(string categoryName)
        {
            var entities = await (_productRepository.FindAsync(m => m.Category.Contains(categoryName)));
            return entities;
        }

        public async Task<CatalogService.Infrastructure.Entities.Product> GetProductByNameAsync(string productName)
        {
            var entity = await(_productRepository.FindAsync(m => m.Name.Contains(productName)));
            return entity?.FirstOrDefault() ?? new CatalogService.Infrastructure.Entities.Product();
        }

        public async Task<CatalogService.Infrastructure.Entities.Product> UpdateProductAsync(CatalogService.Infrastructure.Entities.Product product)
        {
            try
            {
                var entity = await _productRepository.Update(product);
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
