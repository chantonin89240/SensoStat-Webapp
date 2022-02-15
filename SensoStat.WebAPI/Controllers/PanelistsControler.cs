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

        [HttpPost]
        public IActionResult CreatePanelist(Panelist panelist)
        {
            var newPanelist = this._panelistService.CreatePanelist(panelist);
            return this.CreatedAtAction(nameof(PanelistsController.CreatePanelist), new { id = newPanelist.Id }, newPanelist);
        }
    }
}