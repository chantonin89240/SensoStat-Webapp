﻿namespace SensoStat.Repository
{
    using System;
    using SensoStat.Entities;
    using SensoStat.EntitiesContext;
    using SensoStat.Repository.Contracts;

    public class PublicationRepository : IPublicationRepository
    {
        private SensoStatDbContext _context;

        public PublicationRepository(SensoStatDbContext context)
        {
            this._context = context;
        }

        public void Add(Publication publication)
        {
            throw new NotImplementedException();
        }

        public void AddRange(List<Publication> publications)
        {
            this._context.Publications.AddRange(publications);
            this._context.SaveChanges();
        }

        public void Delete(int idSession)
        {
            var publications = this._context.Publications.Where(p => p.IdSession == idSession);

            this._context.Publications.RemoveRange(publications);
            this._context.SaveChanges();
        }

        public Publication? Find(int idPanelist, int idSession)
        {
            return this._context.Publications.FirstOrDefault(pub => pub.IdPaneslist == idPanelist && pub.IdSession == idSession);
        }

        public Publication? Find(string hash)
        {
            var urlCompare = $"https://localhost:8080/?hash={hash}";
            return this._context.Publications.FirstOrDefault(pub => pub.Url == urlCompare);
        }

        public IEnumerable<Publication> FindAll(int idSession)
        {
            return this._context.Publications.Where(p => p.IdSession == idSession);
        }

        public void Update(Publication publication)
        {
            throw new NotImplementedException();
        }
    }
}