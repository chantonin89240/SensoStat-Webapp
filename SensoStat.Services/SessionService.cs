namespace SensoStat.Services
{
    using SensoStat.Entities;
    using SensoStat.Entities.Request;
    using SensoStat.Repository.Contracts;
    using SensoStat.Services.Contracts;

    /// <summary>
    /// .
    /// </summary>
    public class SessionService : ISessionService
    {
        private ISessionRepository _sessionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionService"/> class.
        /// </summary>
        /// <param name="sessionRepository">Repository utilisé.</param>
        public SessionService(ISessionRepository sessionRepository)
        {
            this._sessionRepository = sessionRepository;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <returns>liste des session.</returns>
        public IEnumerable<Session> Get()
        {
            return this._sessionRepository.FindAll();
        }

        public IEnumerable<Session> getByStatut(string statut)
        {
            return this._sessionRepository.FindByStatut(statut);
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="sessionRequest">.</param>
        /// <returns>la session créer.</returns>
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

        /// <summary>
        /// .
        /// </summary>
        /// <param name="id">id de la session.</param>
        /// <returns>la session.</returns>
        public Session Find(int id)
        {
            return this._sessionRepository.Find(id);
        }
    }
}