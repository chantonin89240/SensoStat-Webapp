namespace SensoStat.WebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SensoStat.Services.Contracts;
    using SensoStat.Entities;

    [Route("api/[controller]")]
    [ApiController]
    public class PanelistsController : ControllerBase
    {
        private readonly IPanelistService _panelistService;

        public PanelistsController(IPanelistService service)
        {
            this._panelistService = service;
        }

        // GET: api/<SessionController>
        [HttpGet]
        public IEnumerable<Panelist> GetPanelists()
        {
            return this._panelistService.GetPanelists();
        }

        [HttpPost]
        public HttpResponseMessage CreatePanelist()
        {
            return this._panelistService.CreatePanelist();
        }
    }
}