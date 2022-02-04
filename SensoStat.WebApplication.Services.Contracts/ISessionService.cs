namespace SensoStat.WebApplication.Services.Contracts
{
    using System.Net;
    using Microsoft.AspNetCore.Http;
    using SensoStat.Entities;
    using SensoStat.WebApplication.ViewModels;

    public interface ISessionService
    {
        HttpResponseMessage GetDataFromHttpClient(string url);

        IEnumerable<SessionViewModel> GetSessions();

        IEnumerable<Session> GetSessionsClose();

        HttpStatusCode LoadFile(IFormFile file);
    }
}