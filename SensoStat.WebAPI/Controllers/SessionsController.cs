// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SensoStat.WebAPI.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using SensoStat.Entities.Request;
    using SensoStat.Services;

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
        public IActionResult Get([FromQuery]string? statut)
        {
            if (string.IsNullOrEmpty(statut)) return this.Ok(this._sessionService.Get());
            else return this.Ok(this._sessionService.getByStatut(statut));

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return this.Ok(this._sessionService.Find(id));
        }

        [HttpPost]
        public IActionResult CreateSession([FromBody] SessionRequest session)
        {
            var sessionResponse = this._sessionService.Create(session);
            return this.CreatedAtAction(nameof(SessionsController.GetById), new { id = sessionResponse.Id }, sessionResponse);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSession(int id)
        {
            return this.Ok(this._sessionService.Get());
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSession(int id)
        {
            throw new NotImplementedException();
        }
    }
}
