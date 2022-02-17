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

        bool LoadFile(IFormFile file, int idSession);

        List<PresentationViewModel> GetPresentations(int id);
    }
}