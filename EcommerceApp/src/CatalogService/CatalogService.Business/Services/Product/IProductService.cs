namespace CatalogService.Business.Services.Product
{
    public interface IProductService
    {
        /// <summary>
        ///  Add Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<CatalogService.Infrastructure.Entities.Product> AddProductAsync(CatalogService.Infrastructure.Entities.Product product);
    }
}
