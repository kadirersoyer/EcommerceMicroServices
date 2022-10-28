using MediatR;

namespace CatalogService.Shared.Queries
{
    public class GetProductByCategoryQueryRequest : IRequest<GenericResponse<GetProductByCategoryQueryResponse>>
    {
        public string? Category { get; set; }
    }
}
