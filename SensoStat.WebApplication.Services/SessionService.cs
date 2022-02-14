namespace SensoStat.WebApplication.Services
{
    using CsvHelper;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using SensoStat.WebApplication.Services.Contracts;
    using SensoStat.WebApplication.ViewModels;
    using System.Globalization;
    using System.Net;

    public class SessionService : ISessionService
    {
        private readonly ClientService _clientService;
        public SessionService(ClientService clientService)
        {
            this._clientService = clientService;
        }
        /// <summary>
        /// Connection à une serveur HTTP.
        /// </summary>
        /// <param name="url"></param>
        /// <returns>Réponse du serveur</returns>
        public HttpResponseMessage GetDataFromHttpClient(string url)
        {
            HttpClient httpClient = new HttpClient();
            var response = httpClient.GetAsync(url).Result;
            return response;
        }

        public IEnumerable<SessionViewModel> GetSessions()
        {
            var sessions = this._clientService.GetDataFromHttpClient("api/Sessions");

            var lesSessions = JsonConvert.DeserializeObject<IEnumerable<SessionViewModel>>(sessions);

            return lesSessions.Where(s => s.Etat != "Close").OrderByDescending(s => s.DateUpdate);
        }

        public IEnumerable<SessionViewModel> GetSessionsClose()
        {
            var sessions = this._clientService.GetDataFromHttpClient("api/Sessions");

            var lesSessions = JsonConvert.DeserializeObject<IEnumerable<SessionViewModel>>(sessions);

            return lesSessions.Where(s => s.Etat == "Close").OrderByDescending(s => s.DateUpdate);
        }

        /// <summary>
        /// Méthode de chargement, lecture et enregistrement en base de données de fichier CSV
        /// </summary>
        /// <param name="file"></param>
        /// <param name="idSession"></param>
        /// <returns>Le code du status de la réponse rétourné par l'API</returns>
        public HttpStatusCode LoadFile(IFormFile file, int idSession)
        {
            List<object> listPlanPresentation = new List<object>();

            using (var fileStream = file.OpenReadStream())
            using (var reader = new StreamReader(fileStream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<dynamic>();

                foreach (var line in records)
                {
                    // Définition à la volée de la valeur de la key
                    var key = (((IDictionary<String, Object>)line).Keys.ToList()[0]).ToString();
                    if (key != null)
                    {
                        // Value de KeyValuePair
                        var text = ((IDictionary<String, Object>)line)[key];
                        var panelistPresentation = text.ToString().Split(";");

                        var codePanelist = panelistPresentation[0];

                        var planPresentation = panelistPresentation.Skip(1).ToList();
                        var rank = 1;
                        // créé des objets presentation
                        planPresentation.ForEach(plan =>
                        {
                            var item = new PresentationViewModel
                            {
                                Panelist = new PanelistViewModel { CodePanelist = codePanelist },
                                Product = new ProductViewModel { CodeProduct = plan, IdSession = idSession },
                                Rank = rank,
                                IdSession = idSession
                            };

                            listPlanPresentation.Add(item);

                            rank++;
                        });
                        // envoi de tout les objets
                    }
                };
            }

            var presentations = this._clientService.PostDataFromHttpClient("api/Presentation", listPlanPresentation);
            var lesPresentations = JsonConvert.DeserializeObject<IEnumerable<SessionViewModel>>(presentations);
            var retourn = listPlanPresentation;
            return HttpStatusCode.OK;
        }
    }
}