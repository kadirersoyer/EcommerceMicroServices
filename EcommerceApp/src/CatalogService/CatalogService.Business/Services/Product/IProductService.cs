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


        /// <summary>
        ///  Update Product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        Task<CatalogService.Infrastructure.Entities.Product> UpdateProductAsync(CatalogService.Infrastructure.Entities.Product product);

        /// <summary>
        ///  Get All Async
        /// </summary>
        /// <returns></returns>
        Task<List<CatalogService.Infrastructure.Entities.Product>> GetAllAsync();

        /// <summary>
        ///  Get product by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<CatalogService.Infrastructure.Entities.Product> GetProductAsync(int productId);

        /// <summary>
        ///  Get product by name
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        Task<CatalogService.Infrastructure.Entities.Product> GetProductByNameAsync(string productName);


        /// <summary>
        ///  Get product by name
        /// </summary>
        /// <param name="productName"></param>
        /// <returns></returns>
        Task<List<CatalogService.Infrastructure.Entities.Product>> GetProductsByCategoryNameAsync(string productName);


        /// <summary>
        ///  Delete product by id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int productId);

    }
}
