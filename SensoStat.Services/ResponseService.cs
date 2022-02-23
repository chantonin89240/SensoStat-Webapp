namespace SensoStat.Services
{
    using SensoStat.Entities;
    using SensoStat.Models.HttpRequest;
    using SensoStat.Repository.Contracts;
    using SensoStat.Services.Contracts;

    public class ResponseService : IResponseService
    {
        private readonly IResponseRepository _responseRepository;

        public ResponseService(IResponseRepository responseRepository)
        {
            this._responseRepository = responseRepository;
        }

        public void PostResponse(ResponseRequest responseRequest)
        {
            Response response = new Response()
            {
                IdPanelist = responseRequest.IdPanelist,
                IdInstruction = responseRequest.IdInstruction,
                CommentResponse = responseRequest.CommentResponse,
                IdProduct = responseRequest.IdProduct,
                DateResponse = DateTime.Now,
            };

            this._responseRepository.Add(response);
        }
    }
}
