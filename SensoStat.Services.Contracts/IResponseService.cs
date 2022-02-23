namespace SensoStat.Services.Contracts
{
    using SensoStat.Models.HttpRequest;

    public interface IResponseService
    {
        void PostResponse(ResponseRequest responseRequest);
    }
}
