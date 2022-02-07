namespace SensoStat.Services.Contracts
{
    using SensoStat.Entities;

    public interface IPresentationService
    {
        IEnumerable<Presentation> Get();

        IEnumerable<Presentation> FindByIdSession(int id);

        List<Presentation> MultiCreate(List<Presentation> presentations);
    }
}
