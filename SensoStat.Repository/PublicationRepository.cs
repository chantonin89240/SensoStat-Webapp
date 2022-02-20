namespace SensoStat.Repository
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

        public void Delete(Publication publication)
        {
            throw new NotImplementedException();
        }

        public Publication? Find(int idPanelist, int idSession)
        {
            return this._context.Publications.FirstOrDefault(pub => pub.IdPaneslist == idPanelist && pub.IdSession == idSession);
        }

        public IEnumerable<Publication> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Publication publication)
        {
            throw new NotImplementedException();
        }
    }
}