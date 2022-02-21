using System;
using SensoStat.Entities;
using SensoStat.Models.HttpRequest;
using SensoStat.Models.HttpResponse;

namespace SensoStat.Services.Contracts
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);

        IEnumerable<User> GetAll();

        User GetById(int id);

        IEnumerable<Role> GetRoles();

        CreateUserResponse CreateUser(CreateUserRequest model);

        byte[] GenerateSalt();

        string HashPasswordWithSalt(string password, byte[] salt);
    }
}

