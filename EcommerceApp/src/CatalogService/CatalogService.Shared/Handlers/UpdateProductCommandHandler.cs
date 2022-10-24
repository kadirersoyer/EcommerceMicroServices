using CatalogService.Business.Services.Product;
using CatalogService.Infrastructure.Entities;
using CatalogService.Shared.Commands;
using CatalogService.Shared.Helpers;
using CatalogService.Shared.Models.Product;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogService.Shared.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, GenericResponse<UpdateProductCommandResponse>>
    {
        private readonly IProductService _productService;

        public UpdateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<GenericResponse<UpdateProductCommandResponse>> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var response = new GenericResponse<UpdateProductCommandResponse>();
            response.Value = new UpdateProductCommandResponse();

            var isValidate = await ValidatorHelper.ValidateAsync(request);

            if (!isValidate.IsValid) { response.ValidationResult = isValidate; return response; }

            var mappedEntity = await MapperHelper.MapTo<UpdateProductCommandRequest, Product>(request);
            mappedEntity.UpdatedDate = DateTime.Now;

            var updatedEntity = await _productService.UpdateProductAsync(mappedEntity);
            if (updatedEntity != null)
            {
                response.Message = "Success";
                response.Value.ProductModel = await MapperHelper.MapTo<Product, ProductModel>(updatedEntity);
            }
            return response;
        }
    }
}
