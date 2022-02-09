namespace SensoStat.WebApplication.Services.Contracts
{
    using System;
    using SensoStat.WebApplication.ViewModels;

    public interface IUserService
    {
        IEnumerable<RoleViewModel> GetRoles();

        UserViewModel CreateUser(UserViewModel model);
    }
}

