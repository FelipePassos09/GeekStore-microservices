using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Repository;
using Microsoft.AspNetCore.Mvc;


namespace GeekShopping.ProductApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository ?? throw new
                ArgumentNullException(nameof(repository));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var product = await _repository.FindById(id);

            if(product == null) { return NotFound(); }

            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var products = await _repository.FindAll();
            
            if (products == null) { return NotFound(); }
            
            return Ok(products);

        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> CreateProduct(ProductVO vo)
        {
            if(vo == null) { return BadRequest(); }
            var product = await _repository.Create(vo);
            return Ok(product);
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<ProductVO>> UpdateProduct(ProductVO product, long id)
        {
            if (product == null || id != product.Id) return BadRequest();
            
            try {
                var prod = await _repository.Update(product);
                return Ok(prod);
            }
            catch
            {
                return Problem();
            }

        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult> DeleteProduct(long id)
        {
            //

            var status = await _repository.Delete(id);
            
            if (!status) return BadRequest();

            return Ok(status);
        }
    }
}
