using CatalogService.Business.Services.Product;
using CatalogService.Shared.Commands;
using CatalogService.Shared.Models.Product;
using Mapster;
using MediatR;
using Product = CatalogService.Infrastructure.Entities.Product;
namespace CatalogService.Shared.Handlers
{
    public class SaveProductCommandHandler : IRequestHandler<SaveProductCommandRequest, GenericResponse<SaveProductCommandResponse>>
    {
        private readonly IProductService _productService;

        public SaveProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<GenericResponse<SaveProductCommandResponse>> Handle(SaveProductCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GenericResponse<SaveProductCommandResponse>();
            response.Value = new SaveProductCommandResponse();

            var mappedEntity = request.Adapt<Product>();
            var addedEntity = await _productService.AddProductAsync(mappedEntity);

            response.Value.ProductModel = addedEntity.Adapt<ProductModel>();
            response.Message = "Success";
            return response;
        }
    }
}
