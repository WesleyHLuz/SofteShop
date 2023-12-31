﻿using GeekShopping.ProductApi.Data.ValueObjects;
using GeekShopping.ProductApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.ProductApi.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _repository;

        public ProductController(IProductRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerator<ProductVO>>> FindAll()
        {
            var product = await _repository.FindAll();
            if (product == null) return NotFound();

            return Ok(product);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> FindById(long id)
        {
            var products = await _repository.FindById(id);
            if (products == null) return NotFound();

            return Ok(products);
        }
        
        [HttpPost]
        public async Task<ActionResult<ProductVO>> Create([FromBody]ProductVO vo)
        {
            if (vo == null) return BadRequest();
            var product = await _repository.Create(vo);


            return Ok(product);
        } 
        
        [HttpPut]
        public async Task<ActionResult<ProductVO>> Update([FromBody] ProductVO vo)
        {
            if (vo == null) return BadRequest();
            var product = await _repository.Create(vo);


            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var status = await _repository.Delete(id);
            if (!status) return BadRequest(); 
            return Ok(status);


        }
       
    }
}
