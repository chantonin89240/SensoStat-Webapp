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
        public void Delete(int id)
        {
            var session = this._context.Sessions.First(s => s.Id == id);
            this._context.Sessions.Remove(session);
            this._context.SaveChanges();
        }

        /// <inheritdoc/>
        public Session Find(int id)
        {
            return this._context.Sessions.FirstOrDefault(session => session.Id == id);
        }

        /// <inheritdoc/>
        public IEnumerable<Session> FindAll()
        {
            return this._context.Sessions;
        }

        public IEnumerable<Session> FindByStatut(string statut)
        {
            return this._context.Sessions.Where(session => session.Etat.ToLower() == statut.ToLower());
        }

        /// <inheritdoc/>
        public void Update(Session session)
        {
            this._context.Update(session);
            this._context.SaveChanges();
        }

        public void UpdateSate(int id)
        {
            var session = this._context.Sessions.First(s => s.Id == id);
            session.Etat = "Cloturée";
            this._context.Update(session);
            this._context.SaveChanges();
        }
    }
}
