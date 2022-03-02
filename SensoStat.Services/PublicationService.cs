using System;
using SensoStat.Entities;
using SensoStat.Models.HttpResponse;
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
                session.Etat = "Publiée";
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
                        Url = $"https://localhost:8080/?hash={hashUrl}",
                        Salt = Convert.ToBase64String(salt),
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

        public List<ExportResponse> ExportUrl(int idSession)
        {
            var exportResponseList = new List<ExportResponse>();

            var publications = this._publicationRepository.FindAll(idSession);
            var listIdPanelist = publications.Select(p => p.IdPaneslist).ToList();
            var panelists = this._panelistRepository.FindAll(listIdPanelist);

            publications.ToList().ForEach(p =>
            {
                var exportResponse = new ExportResponse()
                {
                    URL = p.Url,
                    CodePanelist = panelists.First(pan => pan.Id == p.IdPaneslist).CodePanelist,
                };

                exportResponseList.Add(exportResponse);
            });

            return exportResponseList;
        }
    }
}