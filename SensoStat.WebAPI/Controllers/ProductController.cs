namespace SensoStat.WebAPI.Controllers
{
    using System;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using SensoStat.Models.HttpRequest;
    using SensoStat.Services;

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : Controller
    {
        private ProductService _productService;

        public ProductController(ProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet]
        public IActionResult Get(int idSession)
        {
            return this.Ok(this._productService.Get(idSession));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductRequest product)
        {
            var productResponse = this._productService.Create(product);
            return this.CreatedAtAction(nameof(SessionsController.GetById), new { id = productResponse.Id }, productResponse);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
