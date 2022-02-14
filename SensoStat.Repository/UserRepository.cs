namespace SensoStat.Repository
{
    using System;
    using System.Collections.Generic;
    using SensoStat.Entities;
    using SensoStat.EntitiesContext;
    using SensoStat.Repository.Contracts;

    public class UserRepository : IUserRepository
    {
        private SensoStatDbContext _context;

        public UserRepository(SensoStatDbContext context)
        {
            this._context = context;
        }

        /// <inheritdoc/>
        public void Add(User User)
        {
            User.Login = "test";
            this._context.Users.Add(User);
            this._context.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(User User)
        {
            this._context.Users.Remove(User);
            this._context.SaveChanges();
        }

        /// <inheritdoc/>
        public User FindById(int id)
        {
            return this._context.Users?.FirstOrDefault(User => User.Id == id);
        }

        /// <inheritdoc/>
        public User FindByEmail(string email)
        {
            return this._context.Users.SingleOrDefault(x => x.Email == email);
        }

        /// <inheritdoc/>
        public IEnumerable<User> FindAll()
        {
            return this._context.Users;
        }

        public IEnumerable<Role> FindAllRoles()
        {
            return this._context.Roles;
        }

        /// <inheritdoc/>
        public void Update(User User)
        {
            this._context.Update(User);
            this._context.SaveChanges();
        }
    }
}