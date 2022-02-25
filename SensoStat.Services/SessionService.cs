﻿namespace SensoStat.Services
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
        private readonly ISessionRepository _sessionRepository;
        private readonly IInstructionRepository _instructionRepository;
        private readonly IProductRepository _productRepository;
        private readonly IPresentationRepository _presentationtRepository;
        private readonly IPublicationRepository _publicationtRepository;
        private readonly IPanelistRepository _panelistRepository;
        private readonly IPwaRepository _pwaRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionService"/> class.
        /// </summary>
        /// <param name="sessionRepository">Repository utilisé.</param>
        public SessionService(ISessionRepository sessionRepository, IInstructionRepository instructionRepository, IProductRepository productRepository, IPresentationRepository presentationtRepository, IPublicationRepository publicationtRepository, IPanelistRepository panelistRepository, IPwaRepository pwaRepository)
        {
            this._sessionRepository = sessionRepository;
            this._instructionRepository = instructionRepository;
            this._productRepository = productRepository;
            this._presentationtRepository = presentationtRepository;
            this._publicationtRepository = publicationtRepository;
            this._panelistRepository = panelistRepository;
            this._pwaRepository = pwaRepository;
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

        public bool UpdateState(int id)
        {
            this._sessionRepository.UpdateSate(id);
            return true;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="sessionRequest">.</param>
        /// <returns>la session créer.</returns>
        public SessionResponse Create(SessionRequest sessionRequest)
         {
            var session = new Session()
            {
                Name = sessionRequest.Name,
                Etat = sessionRequest.Etat,
                DateCreate = sessionRequest.DateCreate,
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
            return new SessionResponse(session);
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="id">id de la session.</param>
        /// <returns>la session.</returns>
        public SessionResponse Find(int id)
        {
            var session = this._sessionRepository.Find(id);
            session.Instructions = this._instructionRepository.FindAll(id).ToList();
            var test = new SessionResponse(session);
            return new SessionResponse(session);
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
                DateCreate = sessionRequest.DateCreate,
                IdPerson = sessionRequest.IdPerson,
            };

            session.DateUpdate = DateTime.Now;

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

        public PwaSessionResponse FindSession(int idSession, int idPanelist)
        {
            var session = this._sessionRepository.Find(idSession);
            session.Instructions = this._instructionRepository.FindAll(idSession).ToList();
            session.Products = this._productRepository.FindAll(idSession).ToList();

            var pwaSession = new PwaSessionResponse(session); 
            var publication = this._publicationtRepository.Find(idPanelist, idSession);
            if (publication != null)
            {
              //  pwaSession.Publication = new PublicationResponse(publication);
            }

            var presentations = this._presentationtRepository.FindByIdSessionAndIdPanelistVincent(idSession, idPanelist).ToList();
            presentations.ForEach(p => pwaSession.Presentations.Add(new PwaPresentationResponse(p)));

            return pwaSession;
        }

        public PwaSessionResponse FindSessionWithHash(string hash)
        {
            return this._pwaRepository.getPwaResponse(hash);

        }
    }
}