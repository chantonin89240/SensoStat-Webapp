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

        [HttpGet("{idSession, idPanelist}")]
        public IActionResult GetById(int idSession, int idPanelist)
        {
            return this.Ok(this._sessionService.FindSession(idSession, idPanelist));
        }

        [HttpGet]
        public IActionResult GetByHash(string hash)
        {
            var session = this._sessionService.FindSessionWithHash(hash);

            if (session != null)
            {
                return this.Ok(session);
            }
            else
            {
                return this.NotFound();
            }
        }

        [HttpPost]
        public IActionResult PostResponse(ResponseRequest responseResquest)
        {
            this._responseService.PostResponse(responseResquest);

            return this.CreatedAtAction(nameof(PwaController), responseResquest);
        }
    }
}