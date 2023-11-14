﻿using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Repository;
using GeekShopping.ProductApi.Utils;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> FindById(long id)
        {
            var product = await _repository.FindById(id);

            if(product == null) { return NotFound(); }

            return Ok(product);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAll()
        {
            var products = await _repository.FindAll();
            
            if (products == null) { return NotFound(); }
            
            return Ok(products);

        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProductVO>> CreateProduct([FromBody] ProductVO vo)
        {
            if(vo == null) { return BadRequest(); }
            var product = await _repository.Create(vo);
            return Ok(product);
        }

        [HttpPut("{id:long}")]
        [Authorize]
        public async Task<ActionResult<ProductVO>> UpdateProduct([FromBody] ProductVO product, long id)
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
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult> DeleteProduct(long id)
        {
            //

            var status = await _repository.Delete(id);
            
            if (!status) return BadRequest();

            return Ok(status);
        }
    }
}
