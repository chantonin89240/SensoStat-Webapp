namespace SensoStat.WebApplication.Services.Contracts
{
    using System.Net;
    using Microsoft.AspNetCore.Http;
    using SensoStat.Entities;

    public interface ISessionService
    {
        HttpResponseMessage GetDataFromHttpClient(string url);

        IEnumerable<Session> GetSessions();

        HttpStatusCode LoadFile(IFormFile file);
    }
}