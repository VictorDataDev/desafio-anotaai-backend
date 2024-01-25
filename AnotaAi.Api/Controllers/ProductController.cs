using AnotaAi.Application.IServices;
using AnotaAi.Core.Domain.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AnotaAi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public async Task<ActionResult> Post(ProductDTO request)
        {
            var product = _productService.Add(request);

            return Ok(product);
        }
    }
}
