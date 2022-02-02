namespace SensoStat.WebAPI.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using SensoStat.Entities.Request;
    using SensoStat.Services;

    [Route("api/[controller]")]
    [ApiController]
    public class PresentationController : Controller
    {
        private PresentationService _presentationService;

        public PresentationController(PresentationService presentationService)
        {
            this._presentationService = presentationService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return this.Ok(this._presentationService.Find(id));
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductRequest product)
        {
            //var productResponse = this._productService.Create(product);
            //return this.CreatedAtAction(nameof(SessionsController.GetById), new { id => };
            throw new NotImplementedException();
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
