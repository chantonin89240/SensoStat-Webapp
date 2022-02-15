namespace SensoStat.Services.Contracts
{
    using SensoStat.Entities;
    using SensoStat.Models.HttpRequest;

    public interface ISessionService
    {
        IEnumerable<Session> GetAll();

        IEnumerable<Session> getByStatut(string statut);

        Session Create(SessionRequest sessionRequest);

        Session Find(int id);
    }
}