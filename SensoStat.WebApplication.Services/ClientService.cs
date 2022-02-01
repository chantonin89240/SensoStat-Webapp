namespace SensoStat.WebApplication.Services
{
    using Newtonsoft.Json;
    using System.Text;
    public class ClientService
    {
        private readonly HttpClient _httpClient;

        public ClientService(HttpClient client)
        {
            this._httpClient = client;
        }

        public string GetDataFromHttpClient(string url)
        {
            //call http
            var reponseHttp = _httpClient.GetAsync(url).Result;
            //lire le resultat => json
            string jsonResult = reponseHttp.Content.ReadAsStringAsync().Result;
            //ajout des tests de communications
            return jsonResult;
        }

        public string PostDataFromHttpClient(string url, object content)
        {
            var json = JsonConvert.SerializeObject(content);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            //call http
            var reponseHttp = _httpClient.PostAsync(url, stringContent).Result;
            //lire le resultat => json
            string jsonResult = reponseHttp.Content.ReadAsStringAsync().Result;
            return jsonResult;
        }

        public string PutDataFromHttpClient(string url, object content)
        {
            var json = JsonConvert.SerializeObject(content);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            //call http
            var reponseHttp = _httpClient.PutAsync(url, stringContent).Result;
            //lire le resultat => json
            string jsonResult = reponseHttp.Content.ReadAsStringAsync().Result;
            //ajout des tests de communications
            return jsonResult;
        }

        public string DeleteDataFromHttpClient(string url)
        {
            //call http
            var reponseHttp = _httpClient.DeleteAsync(url).Result;
            //lire le resultat => json
            string jsonResult = reponseHttp.Content.ReadAsStringAsync().Result;
            //ajout des tests de communications
            return jsonResult;
        }
    }
}
