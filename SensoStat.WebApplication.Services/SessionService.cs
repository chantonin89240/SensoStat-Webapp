﻿namespace SensoStat.WebApplication.Services
{
    using CsvHelper;
    using Microsoft.AspNetCore.Http;
    using Newtonsoft.Json;
    using SensoStat.Entities;
    using SensoStat.WebApplication.Services.Contracts;
    using System.Globalization;

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

        public IEnumerable<Session> GetSessions()
        {
            var sessions = this._clientService.GetDataFromHttpClient("api/Sessions");

            return JsonConvert.DeserializeObject<IEnumerable<Session>>(sessions);

        }

        public void LoadFile(IFormFile file)
        {
            using (var fileStream = file.OpenReadStream())
            using (var reader = new StreamReader(fileStream))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<dynamic>();

                foreach(var line in records)
                {   
                    // Définition à la volée de la valeur de la key
                    var key = (((IDictionary<String, Object>)line).Keys.ToList()[0]).ToString();
                    if(key != null)
                    {
                        // Value de KeyValuePair
                        var text = ((IDictionary<String, Object>)line)[key];                        
                        var panelistPresentation = text.ToString().Split(";");
                        
                        var codePanelist = panelistPresentation[0];
                        // créé un objet panelist

                        var planPresentation = panelistPresentation.Skip(1);
                        // créé des objets produit
                        // créé des objets presentation

                        // envoi de tout les objets
                    }
                };
            }

            
        }
    }
}