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

            return laSession;
        }

        public IEnumerable<SessionViewModel> GetSessionsClose()
        {
            var sessions = this._clientService.GetDataFromHttpClient("api/Sessions");

            var lesSessions = JsonConvert.DeserializeObject<IEnumerable<SessionViewModel>>(sessions);

            return lesSessions.Where(s => s.Etat == "Close").OrderByDescending(s => s.DateUpdate);
        }

        public SessionViewModel CreateSession(SessionViewModel session)
        {
            this._clientService.PostDataFromHttpClient("api/Sessions", session);
            return session;
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
            var lesPresentations = JsonConvert.DeserializeObject<bool>(presentations.Content.ReadAsStringAsync().Result);

            return lesPresentations;
        }

        public List<PresentationViewModel> GetPresentations(int id)
        {
            var presentations = this._clientService.GetDataFromHttpClient($"api/Presentation/{id}");
            var lesPresentations = JsonConvert.DeserializeObject<List<PresentationViewModel>>(presentations);

            return lesPresentations;
        }

        public SessionViewModel UpdateSession(SessionViewModel session)
        {
            this._clientService.PutDataFromHttpClient($"api/Sessions/{session.Id}", session);

            return session;
        }

        /// <summary>
        /// Méthode de gestion de la liste d'instruction de la séance à la création et à l'édition
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        public SessionViewModel MessagesToInstructions(SessionViewModel session)
        {
            if (session.Messages != null)
            {
                foreach (var item in session.Messages.Select((value, index) => new { value, index }))
                {
                    int isQuestion = 0;
                    if (session.Types[item.index] == "Question")
                    {
                        isQuestion = 1;
                    }

                    session.Instructions.Add(new InstructionItemViewModel() { Chronology = item.index + 1, Libelle = item.value, IsQuestion = isQuestion });
                }
            }

            return session;
        }

        public bool DeleteSession(int id)
        {
            var request = this._clientService.DeleteDataFromHttpClient($"api/Sessions/{id}");
            return JsonConvert.DeserializeObject<bool>(request);
        } 
    }
}