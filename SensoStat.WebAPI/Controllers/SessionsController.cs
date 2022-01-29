using Microsoft.AspNetCore.Mvc;
using SensoStat.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SensoStat.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private SessionService _sessionService;

        public SessionsController(SessionService sessionService)
        {
            this._sessionService = sessionService;
        }

        // GET: api/<SessionController>
        [HttpGet]
        public IActionResult GetSessions()
        {
            return this._sessionService.GetSessions();
        }

        [HttpPost]
        public IActionResult CreateSession()
        {
            return this._sessionService.CreateSession();
        }
    }
}
