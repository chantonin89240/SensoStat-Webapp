namespace SensoStat.WebApplication.Services
{
    using System;
    using Newtonsoft.Json;
    using SensoStat.WebApplication.Services.Contracts;
    using SensoStat.WebApplication.ViewModels;

    public class UserService : IUserService
    {
        private readonly ClientService _clientService;

        public UserService(ClientService clientService)
        {
            this._clientService = clientService;
        }

        public IEnumerable<RoleViewModel> GetRoles()
        {
            var roles = this._clientService.GetDataFromHttpClient("api/Roles");
            var lesRoles = JsonConvert.DeserializeObject<IEnumerable<RoleViewModel>>(roles);
            return lesRoles;
        }

        public UserViewModel CreateUser(UserViewModel model)
        {
            var user = this._clientService.PostDataFromHttpClient("api/User", model);
            var newUser = JsonConvert.DeserializeObject<UserViewModel>(user);
            return newUser;
        }
    }
}

