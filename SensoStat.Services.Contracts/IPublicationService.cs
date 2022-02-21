using System;
namespace SensoStat.Services.Contracts
{
    public interface IPublicationService
    {
        bool Publish(int idSession);

        bool DeletePublication(int idsession);
    }
}

