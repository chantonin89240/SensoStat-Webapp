namespace SensoStat.WebApplication.Services.Contracts
{
    using System.Net;
    using Microsoft.AspNetCore.Http;
    using SensoStat.WebApplication.ViewModels;

    public interface ISessionService
    {
        IEnumerable<SessionViewModel> GetSessions();

        SessionViewModel GetSessionById(int id);

        IEnumerable<SessionViewModel> GetSessionsClose();

        HttpStatusCode LoadFile(IFormFile file, int idSession);
    }
}