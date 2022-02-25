namespace SensoStat.WebAPI.Controllers
{
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
        public bool PostResponse(ResponseRequest responseResquest)
        {
            return true;
        }
    }
}