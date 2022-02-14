namespace SensoStat.WebApplication.Services.Contracts
{
    using System.Net;
    using Microsoft.AspNetCore.Http;
    using SensoStat.WebApplication.ViewModels;

    public interface ISessionService
    {
        HttpResponseMessage GetDataFromHttpClient(string url);

        IEnumerable<SessionViewModel> GetSessions();

        IEnumerable<SessionViewModel> GetSessionsClose();

        HttpStatusCode LoadFile(IFormFile file, int idSession);
    }
}