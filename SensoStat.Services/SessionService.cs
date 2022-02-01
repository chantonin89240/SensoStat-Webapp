namespace SensoStat.Services
{
    using Microsoft.AspNetCore.Mvc;
    using SensoStat.Entities;
    using SensoStat.Entities.Request;
    using SensoStat.Repository.Contracts;

    public class SessionService
    {
        private ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository)
        {
            this._sessionRepository = sessionRepository;
        }

        public IEnumerable<Session> Get()
        {
            return this._sessionRepository.FindAll();
        }

        public Session Create(SessionRequest sessionRequest)
        {
            var session = new Session()
            {
                Name = sessionRequest.Name,
                Etat = sessionRequest.Etat,
                DateCreate = DateTime.Now,
                IdPerson = sessionRequest.IdPerson,
            };

            session.DateUpdate = session.DateCreate;

            this._sessionRepository.Add(session);
            return session;
        }
    }
}