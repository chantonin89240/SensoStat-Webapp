namespace SensoStat.WebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SensoStat.Models.HttpRequest;
    using SensoStat.Services.Contracts;

    [Route("api/[controller]")]
    [ApiController]
    public class PwaController : ControllerBase
    {
        private readonly ISessionService _sessionService;
        private readonly IResponseService _responseService;

        public PwaController(ISessionService sessionService, IResponseService responseService)
        {
            this._sessionService = sessionService;
            this._responseService = responseService;
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
        public IActionResult PostResponse(ResponseRequest response)
        {
            this._responseService.PostResponse(response);
            return this.CreatedAtAction(nameof(PwaController), response);
        }
    }
}