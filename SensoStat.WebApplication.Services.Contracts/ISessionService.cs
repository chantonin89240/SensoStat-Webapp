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

        SessionViewModel CreateSession(SessionViewModel session);

        bool LoadFile(IFormFile file, int idSession);

        List<PresentationViewModel> GetPresentations(int id);

        SessionViewModel UpdateSession(SessionViewModel session);

        SessionViewModel MessagesToInstructions(SessionViewModel session);

        bool DeleteSession(int id);

        bool Publish(int idSession);
    }
}