using CatalogService.Shared;
using CatalogService.Shared.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Api.Controllers
{
    [Route("api/v1")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]", Name = "AddProduct")]
        public async Task<GenericResponse<SaveProductCommandResponse>> AddProduct([FromBody] SaveProductCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost("[action]", Name = "UpdateProduct")]
        public async Task<GenericResponse<UpdateProductCommandResponse>> UpdateProduct([FromBody] UpdateProductCommandRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
