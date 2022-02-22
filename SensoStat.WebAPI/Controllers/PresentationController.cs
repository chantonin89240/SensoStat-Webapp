namespace SensoStat.WebAPI.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using SensoStat.Models.HttpRequest;
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
            return this.Ok(this._presentationService.FindAllByIdSession(id));
        }

        [HttpGet("{idSession}/{idPanlelist}")]
        public IActionResult GetByIdSessionAndIdPanelist(int idSession, int idPanlelist)
        {
            var presentations = this._presentationService.FindByIdSessionAndIdPanelist(idSession, idPanlelist);

            if (presentations == null)
            {
                return this.NotFound();
            }

            return this.Ok(presentations);
        }

        [HttpPost]
        public bool CreatePresentation([FromBody] List<PresentationRequest> presentations)
        {
            return this._presentationService.MultiCreate(presentations);
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
