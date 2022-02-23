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
        private readonly ResponseService _responseService;

        public PwaController(SessionService sessionService, ResponseService responseService)
        {
            this._sessionService = sessionService;
            this._responseService = responseService;
        }

        [HttpGet]
        public IActionResult GetById(int idSession, int idPanelist)
        {
            return this.Ok(this._sessionService.FindSession(idSession, idPanelist));
        }

        [HttpPost]
        public IActionResult PostResponse(ResponseRequest responseResquest)
        {
            this._responseService.PostResponse(responseResquest);

            return this.CreatedAtAction(nameof(PwaController), responseResquest);
        }
    }
}