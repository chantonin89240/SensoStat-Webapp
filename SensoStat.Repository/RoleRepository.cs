namespace SensoStat.Repository
{
    using System.Collections.Generic;
    using SensoStat.Entities;
    using SensoStat.EntitiesContext;
    using SensoStat.Repository.Contracts;

    public class RoleRepository : IRoleRepository
    {
        private SensoStatDbContext _context;

        public RoleRepository(SensoStatDbContext context)
        {
            this._context = context;
        }

        public void Add(Role role)
        {
            throw new NotImplementedException();
        }

        public void Delete(Role role)
        {
            throw new NotImplementedException();
        }

        public Role FindById(int id)
        {
            return this._context.Roles.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Role> FindAll()
        {
            return this._context.Roles;
        }

        public void Update(Role role)
        {
            throw new NotImplementedException();
        }
    }
}
