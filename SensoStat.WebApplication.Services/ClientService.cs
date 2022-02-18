namespace SensoStat.WebApplication.Services
{
    using Newtonsoft.Json;
    using System.Net.Http.Headers;
    using System.Text;

    public class ClientService
    {
        private readonly HttpClient _httpClient;

        public static string tokenApi;

        public ClientService(HttpClient client)
        {
            this._httpClient = client;
            this._httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenApi);
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

        public HttpResponseMessage PostDataFromHttpClient(string url, object content)
        {
            var json = JsonConvert.SerializeObject(content);
            var stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            //call http
            var reponseHttp = _httpClient.PostAsync(url, stringContent).Result;
            return reponseHttp;
            //lire le resultat => json
            //string jsonResult = reponseHttp.Content.ReadAsStringAsync().Result;

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

        /// <summary>
        /// Execute une requete Http de type Get Post Put ou Delete suivant le 1er argument "method"
        /// </summary>
        /// <param name="method"></param>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <returns>Le body de la réponse http au format string</returns>
        public string RequestHttp(string method, string url, object? content)
        {
            var reponseHttp = new HttpResponseMessage();

            if (method == "Post" || method == "Put")
            {
                var json = JsonConvert.SerializeObject(content);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                switch (method)
                {
                    case "Post":
                        reponseHttp = _httpClient.PostAsync(url, stringContent).Result;
                        break;
                    case "Put":
                        reponseHttp = _httpClient.PutAsync(url, stringContent).Result;
                        break;
                    default:
                        break;
                }
            }

            switch (method)
            {
                case "Get":
                    reponseHttp = _httpClient.GetAsync(url).Result;
                    break;
                case "Delete":
                    reponseHttp = _httpClient.DeleteAsync(url).Result;
                    break;
                default:
                    break;
            }

            var jsonResult = reponseHttp.Content.ReadAsStringAsync().Result;

            return jsonResult;
        }
    }
}
