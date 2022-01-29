namespace SensoStat.Services
{
    using Microsoft.AspNetCore.Mvc;
    using SensoStat.Repository.Contracts;
    using SensoStat.Entities;
    using SensoStat.Services.Contracts;

    public class PanelistService : IPanelistService
    {
        public IEnumerable<Panelist> GetPanelists()
        {
            return new List<Panelist>();
        }
        public HttpResponseMessage CreatePanelist()
        {
            return new HttpResponseMessage();
        }
    }
}