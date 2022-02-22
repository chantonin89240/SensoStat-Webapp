using System;
using SensoStat.Models.HttpResponse;

namespace SensoStat.Services.Contracts
{
    public interface IPublicationService
    {
        bool Publish(int idSession);

        bool DeletePublication(int idsession);

        List<ExportResponse> ExportUrl(int idSession);
    }
}

