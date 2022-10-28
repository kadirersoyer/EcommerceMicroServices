using CatalogService.Shared.Models.Product;

namespace CatalogService.Shared.Queries
{
    public class GetProductByCategoryQueryResponse
    {
        public List<ProductModel>? ProductModels { get; set; }
    }
}
