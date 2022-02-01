namespace SensoStat.Repository
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using SensoStat.Entities;
    using SensoStat.EntitiesContext;
    using SensoStat.Repository.Contracts;

    public class SessionRepository : ISessionRepository
    {
        private SensoStatDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionRepository"/> class.
        /// </summary>
        /// <param name="context">Context de la base de donnée.</param>
        public SessionRepository(SensoStatDbContext context)
        {
            this._context = context;
        }

        /// <inheritdoc/>
        public void Add(Session session)
        {
            this._context.Sessions.Add(session);
            this._context.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(Session session)
        {
            this._context.Sessions.Remove(session);
            this._context.SaveChanges();
        }

        /// <inheritdoc/>
        public Session Find(int id)
        {
            return this._context.Sessions.Include(s => s.Products).Include(i => i.Instructions).FirstOrDefault(session => session.Id == id);
        }

        /// <inheritdoc/>
        public IEnumerable<Session> FindAll()
        {
            return this._context.Sessions.Include(s => s.Products).Include(i => i.Instructions);
        }

        /// <inheritdoc/>
        public void Update(Session session)
        {
            this._context.Update(session);
            this._context.SaveChanges();
        }
    }
}
