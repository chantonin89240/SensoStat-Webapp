namespace SensoStat.Services.Contracts
{
    using SensoStat.Entities;
    using SensoStat.Entities.Request;

    public interface ISessionService
    {
        IEnumerable<Session> Get();

        IEnumerable<Session> getByStatut(string statut);

        Session Create(SessionRequest sessionRequest);

        Session Find(int id);
    }
}