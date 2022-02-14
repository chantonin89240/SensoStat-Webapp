using System;
using SensoStat.Entities;
using SensoStat.Entities.HttpRequest;
using SensoStat.Entities.HttpResponse;

namespace SensoStat.Services.Contracts
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);

        IEnumerable<User> GetAll();

        User GetById(int id);

        IEnumerable<Role> GetRoles();

        CreateUserResponse CreateUser(CreateUserRequest model);

    }
}

