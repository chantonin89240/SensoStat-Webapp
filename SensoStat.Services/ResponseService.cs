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

        public void PostResponse(ResponseRequest response)
        {
            Response laReponse = new Response()
            {
                IdPanelist = response.IdPanelist,
                IdInstruction = response.IdInstruction,
                CommentResponse = response.CommentResponse,
                IdProduct = response.IdProduct,
                DateResponse = DateTime.Now,
            };

            this._responseRepository.Add(laReponse);
        }
    }
}
