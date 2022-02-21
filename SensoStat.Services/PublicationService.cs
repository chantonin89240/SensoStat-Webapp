using System;
using SensoStat.Entities;
using SensoStat.Repository.Contracts;
using SensoStat.Services.Contracts;

namespace SensoStat.Services
{
    public class PublicationService : IPublicationService
    {
        private readonly IPublicationRepository _publicationRepository;
        private readonly IPresentationRepository _presentationtRepository;
        private readonly IPanelistRepository _panelistRepository;
        private readonly ISessionRepository _sessionRepository;
        private readonly IUserService _userService;

        public PublicationService(IPublicationRepository publicationRepository, IPresentationRepository presentationtRepository, IPanelistRepository panelistRepository, ISessionRepository sessionRepository, IUserService userService)
        {
            this._publicationRepository = publicationRepository;
            this._presentationtRepository = presentationtRepository;
            this._panelistRepository = panelistRepository;
            this._sessionRepository = sessionRepository;
            this._userService = userService;
        }

        public bool Publish(int idSession)
        {
            List<Publication> publications = new List<Publication>();

            try
            {
                // Maj état de publication
                var session = this._sessionRepository.Find(idSession);
                session.Etat = "Deploy";
                this._sessionRepository.Update(session);

                // Création publication
                var idPanelistInPresentations = this._presentationtRepository.FindByIdSession(idSession).Select(p => p.IdPanelist).Distinct().ToList();
                var panelists = this._panelistRepository.FindAll(idPanelistInPresentations);

                panelists.ToList().ForEach(p =>
                {
                    var salt = this._userService.GenerateSalt();
                    var hashUrl = this._userService.HashPasswordWithSalt($"{idSession}-{p.CodePanelist}", salt);

                    publications.Add(new Publication()
                    {
                        IdSession = idSession,
                        IdPaneslist = p.Id,
                        DateStart = DateTime.Now,
                        Url = $"http://localhost:8080/{hashUrl}",
                    });
                });

                this._publicationRepository.AddRange(publications);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeletePublication(int idsession)
        {
            return true;
        }
    }
}