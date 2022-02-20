namespace SensoStat.WebAPI.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using SensoStat.Models.HttpRequest;
    using SensoStat.Services;

    [Route("api/[controller]")]
    [ApiController]
    public class PwaController : ControllerBase
    {
        private readonly SessionService _sessionService;

        public PwaController(SessionService sessionService)
        {
            this._sessionService = sessionService;
        }

        [HttpGet]
        public IActionResult GetById(int idSession, int idPanelist)
        {
            return this.Ok(this._sessionService.FindSession(idSession, idPanelist));
        }

        [HttpPost]
        public bool PostResponse(ResponseRequest responseResquest)
        {
            return true;
        }
    }
}