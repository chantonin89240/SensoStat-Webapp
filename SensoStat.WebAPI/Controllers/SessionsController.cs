// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SensoStat.WebAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SensoStat.Entities.Request;
    using SensoStat.Services;
    using System;

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
            return this._sessionService.Get();
        }

        [HttpGet]
        public IActionResult GetById(int idSession)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult CreateSession([FromBody] SessionRequest session)
        {
            var sessionResponse = this._sessionService.Create(session);
            return CreatedAtAction(nameof(SessionsController.GetById), new { id = sessionResponse.Id }, sessionResponse);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSession(int id)
        {
            return this._sessionService.Get();
        }
    }
}
