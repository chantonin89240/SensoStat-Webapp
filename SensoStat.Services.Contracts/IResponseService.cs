using SensoStat.Models.HttpRequest;

namespace SensoStat.Services.Contracts
{
    public interface IResponseService
    {
        void PostResponse(ResponseRequest response);
    }
}
