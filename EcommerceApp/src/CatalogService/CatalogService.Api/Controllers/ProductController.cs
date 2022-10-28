using CatalogService.Shared;
using CatalogService.Shared.Commands;
using CatalogService.Shared.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        [ProducesResponseType(typeof(GenericResponse<SaveProductCommandResponse>), (int)HttpStatusCode.Created)]
        public async Task<GenericResponse<SaveProductCommandResponse>> AddProduct([FromBody] SaveProductCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost("[action]", Name = "UpdateProduct")]
        [ProducesResponseType(typeof(GenericResponse<UpdateProductCommandResponse>),(int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<GenericResponse<UpdateProductCommandResponse>>> UpdateProduct([FromBody] UpdateProductCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpGet("[action]", Name = "GetProductByCategory")]
        [ProducesResponseType(typeof(GenericResponse<GetProductByCategoryQueryResponse>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<ActionResult<GenericResponse<GetProductByCategoryQueryResponse>>> GetProductByCategory([FromQuery] GetProductByCategoryQueryRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}

