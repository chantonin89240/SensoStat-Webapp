using System;
using SensoStat.Entities;

namespace SensoStat.Repository.Contracts
{
    public interface IUserRepository
    {
        void Add(User User);

        void Delete(User User);

        User FindById(int id);

        User FindByEmail(string email);

        IEnumerable<Role> FindAllRoles();

        IEnumerable<User> FindAll();

        void Update(User User);
    }
}