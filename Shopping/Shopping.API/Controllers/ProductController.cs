using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Shopping.API.Data;
using Shopping.API.Models;

namespace Shopping.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController 
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProductContext _context;

        public ProductController(ILogger<ProductController> logger, ProductContext context)
        {
            this._logger = logger;
            _context = context;
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
        public async Task<IEnumerable<Product>> GetData()
        {
            //return ProductContext.ProductsList;
            return await _context.Products.Find(p => true).ToListAsync();
        }

    }
}
