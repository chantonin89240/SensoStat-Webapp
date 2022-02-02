namespace SensoStat.WebAPI.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using SensoStat.Entities.Request;
    using SensoStat.Services;
    using SensoStat.Services.Contracts;

    [Route("api/[controller]")]
    [ApiController]
    public class PresentationController : ControllerBase
    {
        private IPresentationService _presentationService;

        public PresentationController(IPresentationService presentationService)
        {
            this._presentationService = presentationService;
        }

        //[HttpGet]
        //public IActionResult Get()
        //{
        //    var truc = this._presentationService.Get();
        //    return this.Ok(truc);
        //}

        [HttpGet("{id}")]
        public IActionResult GetByIdSession(int id)
        {
            return this.Ok(this._presentationService.FindByIdSession(id));
        }

        [HttpPost]
        public IActionResult CreatePresentation([FromBody] ProductRequest presentation)
        {
            //var productResponse = this._productService.Create(product);
            //return this.CreatedAtAction(nameof(SessionsController.GetById), new { id => };
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePresentation(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePresentation(int id)
        {
            throw new NotImplementedException();
        }
    }
}
