using System;
using SensoStat.Mobile.Helpers.Interface;
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


    }
}
