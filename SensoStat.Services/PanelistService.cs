namespace SensoStat.Services
{
    using Microsoft.AspNetCore.Mvc;
    using SensoStat.Repository.Contracts;
    using SensoStat.Entities;
    using SensoStat.Services.Contracts;

    public class PanelistService : IPanelistService
    {
        public readonly IPanelistRepository _panelistRepository;

        public PanelistService(IPanelistRepository repository)
        {
            this._panelistRepository = repository;
        }

        public IEnumerable<Panelist> GetPanelists()
        {
            return new List<Panelist>();
        }

        public Panelist CreatePanelist(Panelist panelist)
        {
            var newPanelist = this._panelistRepository.Add(panelist);
            return newPanelist;
        }
    }
}