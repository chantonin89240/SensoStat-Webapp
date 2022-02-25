// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SensoStat.WebAPI.Controllers
{
    using System;
    using Microsoft.AspNetCore.Mvc;
    using SensoStat.Models.HttpRequest;
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
            if (string.IsNullOrEmpty(statut)) return this.Ok(this._sessionService.GetAll());
            else return this.Ok(this._sessionService.getByStatut(statut));

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return this.Ok(this._sessionService.Find(id));
        }

        [HttpPost]
        [Route("create")]
        public IActionResult CreateSession([FromBody] SessionRequest session)
        {
            var sessionResponse = this._sessionService.Create(session);
            return this.CreatedAtAction(nameof(SessionsController.CreateSession), new { id = sessionResponse.Id }, sessionResponse);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateSession([FromBody] SessionRequest session)
        {
            var sessionResponse = this._sessionService.Update(session);
            return this.CreatedAtAction(nameof(SessionsController.UpdateSession), new { id = sessionResponse.Id }, sessionResponse);
        }

        [HttpPut("close/{id}")]
        public IActionResult UpdateSessionState(int id)
        {
            var sessionResponse = this._sessionService.UpdateState(id);
            return this.CreatedAtAction(nameof(SessionsController.UpdateSessionState), new { id = id });
        }

        [HttpDelete("{id}")]
        public bool DeleteSession(int id)
        {
            return this._sessionService.DeleteSession(id);
        }
    }
}
