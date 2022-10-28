using CatalogService.Business.Services.Product;
using CatalogService.Shared.Helpers;
using CatalogService.Shared.Models.Product;
using CatalogService.Shared.Queries;
using MediatR;
using System.Collections.Generic;

namespace CatalogService.Shared.Handlers
{
    public class GetProductByCategoryQueryHandler : IRequestHandler<GetProductByCategoryQueryRequest, GenericResponse<GetProductByCategoryQueryResponse>>
    {
        private readonly IProductService _productService;

        public GetProductByCategoryQueryHandler(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        ///  Business logics are here
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GenericResponse<GetProductByCategoryQueryResponse>> Handle(GetProductByCategoryQueryRequest request, CancellationToken cancellationToken)
        {
            var response = new GenericResponse<GetProductByCategoryQueryResponse>();
            response.Value = new GetProductByCategoryQueryResponse();

            var validator = await ValidatorHelper.ValidateAsync(request);

            if (!validator.IsValid) { response.Message = validator.Errors.FirstOrDefault()?.ErrorMessage; response.IsSuccess = false; return response; }

            var queries = await _productService.GetProductsByCategoryNameAsync(request.Category);

            response.Value.ProductModels = await MapperHelper.MapTo<List<CatalogService.Infrastructure.Entities.Product>,
                List<ProductModel>>(queries);

            response.IsSuccess = true;
            response.Message = "Sucess";

            return response;
        }
    }
}
