namespace SensoStat.Services
{
    using Microsoft.AspNetCore.Mvc;
    using SensoStat.Repository.Contracts;

    public class SessionService
    {
        private ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository)
        {
            this._sessionRepository = sessionRepository;
        }

        public IActionResult GetSessions()
        {
            return new OkObjectResult(this._sessionRepository.FindAll());
        }

        public IActionResult CreateSession()
        {
            return new OkObjectResult("");
        }
    }
}