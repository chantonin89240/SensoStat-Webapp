namespace SensoStat.WebApplication.Services.Contracts
{
    using Microsoft.AspNetCore.Http;
    public interface ISessionService
    {
        void LoadFile(IFormFile file);
    }
}