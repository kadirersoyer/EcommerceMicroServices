using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {

        }
        //[HttpGet("{catalog}",Name = "GetAllProducts")]
        [HttpGet("[action]/{catalog}", Name = "GetAllProducts")]
        public async Task<IActionResult> GetProducts(string catalog)
        {
            return Ok();
        }

    }
}
