namespace SensoStat.WebApplication.Services.Contracts
{
    using Microsoft.AspNetCore.Http;
    using SensoStat.Entities;

    public interface ISessionService
    {
        void LoadFile(IFormFile file);
        IEnumerable<Session> GetSessions();
    }
}