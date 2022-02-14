namespace SensoStat.Services.Contracts
{
    using SensoStat.Entities;
    public interface IPanelistService
    {
        IEnumerable<Panelist> GetPanelists();

        Panelist CreatePanelist(Panelist panelist);
    }
}