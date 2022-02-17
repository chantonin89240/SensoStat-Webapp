namespace SensoStat.Services.Contracts
{
    using SensoStat.Entities;
    using SensoStat.Models.HttpRequest;
    using SensoStat.Models.HttpResponse;

    public interface IPresentationService
    {

        IEnumerable<PresentationResponse> FindAllByIdSession(int id);

        bool MultiCreate(List<PresentationRequest> presentations);

        // IEnumerable<PresentationDTO> FindByIdSessionAndIdPanelist(int idSession, int idPanelist);
    }
}
