using CatalogService.Business.Services.Product;
using CatalogService.Shared.Commands;
using CatalogService.Shared.Helpers;
using CatalogService.Shared.Models.Product;
using Mapster;
using MediatR;
using Product = CatalogService.Infrastructure.Entities.Product;
namespace CatalogService.Shared.Handlers
{
    public class SaveProductCommandHandler : IRequestHandler<SaveProductCommandRequest, GenericResponse<SaveProductCommandResponse>>
    {
        private readonly IProductService _productService;
        private readonly IMediator _mediator;

        public SaveProductCommandHandler(IProductService productService,IMediator mediator)
        {
            _productService = productService;
            _mediator = mediator;
        }

        public async Task<GenericResponse<SaveProductCommandResponse>> Handle(SaveProductCommandRequest request, CancellationToken cancellationToken)
        {

            var response = new GenericResponse<SaveProductCommandResponse>();
            response.Value = new SaveProductCommandResponse();
            
            var isValidate = await ValidatorHelper.ValidateAsync(request);

            if (!isValidate.IsValid) { response.Value.ValidationResult = isValidate; return response; };

            var mappedEntity = await MapperHelper.MapTo<SaveProductCommandRequest, Product>(request);

            mappedEntity.CreatedDate = DateTime.Now;
            mappedEntity.UpdatedDate = DateTime.Now;

            var addedEntity = await _productService.AddProductAsync(mappedEntity);

            response.Value.ProductModel = addedEntity.Adapt<ProductModel>();
            response.Message = "Success";
            return response;
        }
    }
}
