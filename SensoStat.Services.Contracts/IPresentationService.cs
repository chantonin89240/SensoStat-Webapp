namespace SensoStat.Services.Contracts
{
    using SensoStat.Models.HttpRequest;
    using SensoStat.Models.HttpResponse;

    public interface IPresentationService
    {

        IEnumerable<PresentationResponse> FindAllByIdSession(int id);

        bool MultiCreate(List<PresentationRequest> presentations);
    }
}
