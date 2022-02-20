using System;
using System.Net.Http;
using System.Threading.Tasks;
using SensoStat.Mobile.Commons;
using SensoStat.Mobile.Helpers.Interface;
using SensoStat.Mobile.Models.Dtos;
using SensoStat.Mobile.Services.Interfaces;

namespace SensoStat.Mobile.Services
{
    public class RequestService : IRequestService
    {
        private readonly IDataTransferHelper _dataTransferHelper;

        public RequestService(IDataTransferHelper dataTransferHelper)
        {
            _dataTransferHelper = dataTransferHelper;
        }

        public async Task<SessionDownDto> GetSession()
        {
            try
            {
                var route = $"{Constants.BaseServerAddress}{Constants.RandomEndpoint}";
                var result = await _dataTransferHelper.SendAsync<SessionDownDto>(route, HttpMethod.Get);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
