using Microsoft.AspNetCore.Mvc;
using Shopping.API.Data;
using Shopping.API.Models;

namespace Shopping.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController 
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            this._logger = logger;
        }

        [HttpGet]
        [Route("Get")]
        public IEnumerable<Product> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new Product
            {
                Name = "test"

            }).ToArray();
        }

        [HttpGet]
        [Route("GetData")]
        public IEnumerable<Product> GetData()
        {
            return ProductContext.Products;
        }

    }
}
