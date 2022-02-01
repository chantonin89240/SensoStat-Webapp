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

            foreach (var item in sessionRequest.Products)
            {
                session.Products.Add(new Product()
                {
                    CodeProduct = item.CodeProduct,
                });
            }

            foreach (var item in sessionRequest.Instructions)
            {
                session.Instructions.Add(new Instruction()
                {
                    Libelle = item.Libelle,
                    Chronology = item.Chronology,
                });
            }

            this._sessionRepository.Add(session);
            return session;
        }

        public Session Find(int idSession)
        {
            Session session = this._sessionRepository.Find(idSession);
            return session;
        }
    }
}