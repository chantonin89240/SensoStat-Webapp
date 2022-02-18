namespace SensoStat.Services
{
    using SensoStat.Entities;
    using SensoStat.Models.HttpRequest;
    using SensoStat.Models.HttpResponse;
    using SensoStat.Repository.Contracts;
    using SensoStat.Services.Contracts;

    /// <summary>
    /// .
    /// </summary>
    public class SessionService : ISessionService
    {
        private ISessionRepository _sessionRepository;
        private IInstructionRepository _instructionRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionService"/> class.
        /// </summary>
        /// <param name="sessionRepository">Repository utilisé.</param>
        public SessionService(ISessionRepository sessionRepository, IInstructionRepository instructionRepository)
        {
            this._sessionRepository = sessionRepository;
            this._instructionRepository = instructionRepository;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <returns>liste des session.</returns>
        public IEnumerable<Session> GetAll()
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
                MsgAccueil = sessionRequest.MsgAccueil,
                MsgFinal = sessionRequest.MsgFinal,
            };

            session.DateUpdate = session.DateCreate;

            foreach (var item in sessionRequest.Instructions)
            {
                session.Instructions.Add(new Instruction()
                {
                    Libelle = item.Libelle,
                    Chronology = item.Chronology,
                    IsQuestion = item.IsQuestion,
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
            var session = this._sessionRepository.Find(id);
            session.Instructions = this._instructionRepository.FindAll(id).ToList();
            return session;
        }

        public SessionResponse Update(SessionRequest sessionRequest)
        {
            this._instructionRepository.DeleteAllByIdSession(sessionRequest.Id);

            var session = new Session()
            {
                Id = sessionRequest.Id,
                Name = sessionRequest.Name,
                MsgAccueil = sessionRequest.MsgAccueil,
                MsgFinal = sessionRequest.MsgFinal,
                Etat = sessionRequest.Etat,
                DateCreate = DateTime.Now,
                IdPerson = sessionRequest.IdPerson,
            };

            session.DateUpdate = session.DateCreate;

            foreach (var item in sessionRequest.Instructions)
            {
                session.Instructions.Add(new Instruction()
                {
                    Libelle = item.Libelle,
                    Chronology = item.Chronology,
                    IsQuestion = item.IsQuestion,
                });
            }

            this._sessionRepository.Update(session);

            return new SessionResponse(session);
        }

        public bool DeleteSession(int id)
        {
            try
            {
                this._sessionRepository.Delete(id);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}