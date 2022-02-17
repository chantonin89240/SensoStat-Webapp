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

        public IEnumerable<SessionViewModel> GetSessions()
        {
            var sessions = this._clientService.GetDataFromHttpClient("api/Sessions");

            var lesSessions = JsonConvert.DeserializeObject<IEnumerable<SessionViewModel>>(sessions);

            return lesSessions.Where(s => s.Etat != "Close").OrderByDescending(s => s.DateUpdate);
        }

        public SessionViewModel GetSessionById(int id)
        {
            var session = this._clientService.GetDataFromHttpClient($"api/Sessions/{id}");

            var laSession = JsonConvert.DeserializeObject<SessionViewModel>(session);

            laSession.MsgAccueil = laSession.Instructions.First().Libelle;
            laSession.MsgFinal = laSession.Instructions.Last().Libelle;

            laSession.Instructions.Remove(laSession.Instructions.First());
            laSession.Instructions.Remove(laSession.Instructions.Last());
            return laSession;
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
        public bool LoadFile(IFormFile file, int idSession)
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
                                CodePanelist = codePanelist,
                                CodeProduct = plan,
                                Rank = rank,
                                IdSession = idSession
                            };

                            listPlanPresentation.Add(item);

                            rank++;
                        });
                    }
                };
            }

            // envoi de tout les objets
            var presentations = this._clientService.PostDataFromHttpClient("api/Presentation", listPlanPresentation);
            var lesPresentations = JsonConvert.DeserializeObject<bool>(presentations);

            return lesPresentations;
        }

        public List<PresentationViewModel> GetPresentations(int id)
        {
            var presentations = this._clientService.GetDataFromHttpClient($"api/Presentation/{id}");
            var lesPresentations = JsonConvert.DeserializeObject<List<PresentationViewModel>>(presentations);

            return lesPresentations;
        }
    }
}