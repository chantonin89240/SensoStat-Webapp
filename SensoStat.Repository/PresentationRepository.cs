namespace SensoStat.Repository
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using SensoStat.Entities;
    using SensoStat.EntitiesContext;
    using SensoStat.Repository.Contracts;

    public class PresentationRepository : IPresentationRepository
    {
        private SensoStatDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PresentationRepository"/> class.
        /// </summary>
        /// <param name="context">Context de la base de donnée.</param>
        public PresentationRepository(SensoStatDbContext context)
        {
            this._context = context;
        }

        /// <inheritdoc/>
        public void Add(Presentation presentation)
        {
            this._context.Presentations.Add(presentation);
            this._context.SaveChanges();
        }

        /// <inheritdoc/>
        public void AddRange(List<Presentation> presentations)
        {
            this._context.Presentations.AddRange(presentations);
            this._context.SaveChanges();
        }

        /// <inheritdoc/>
        public void Delete(Presentation presentation)
        {
            this._context.Presentations.Remove(presentation);
            this._context.SaveChanges();
        }

        /// <inheritdoc/>
        public void DeleteRange(List<Presentation> presentations)
        {
            this._context.Presentations.RemoveRange(presentations);
            this._context.SaveChanges();
        }

        /// <inheritdoc/>
        public IEnumerable<Presentation> FindAll()
        {
            return this._context.Presentations;
        }

        /// <inheritdoc/>
        public IEnumerable<Presentation> FindByIdSession(int id)
        {
            var result = this._context.Presentations.Include(p => p.Product).Include(p => p.Panelist).Where(presentation => presentation.Product.IdSession == id);
            return this._context.Presentations.Where(presentation => presentation.Product.IdSession == id);
        }

        /// <inheritdoc/>
        /*public IEnumerable<PresentationDTO> FindByIdSessionAndIdPanelist(int idSession, int idPanelist)
        {
            return this._context.Presentations.Where(p => p.Product.IdSession == idSession && p.IdPanelist == idPanelist).Select(p => new PresentationDTO
            {
                IdPanelist = idPanelist,
                IdSession = idSession,
                CodeProduit = p.Product.CodeProduct,
                IdProduit = p.IdProduct,
                Rank = p.Rank,
            }).OrderBy(p => p.Rank);
        }*/

        /// <inheritdoc/>
        public void Update(Presentation presentation)
        {
            this._context.Update(presentation);
            this._context.SaveChanges();
        }
    }
}
