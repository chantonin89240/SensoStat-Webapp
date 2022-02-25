namespace SensoStat.Repository
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using SensoStat.Entities;
    using SensoStat.EntitiesContext;
    using SensoStat.Models.HttpResponse;
    using SensoStat.Repository.Contracts;

    public class PwaRepository : IPwaRepository
    {
        private SensoStatDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PwaRepository"/> class.
        /// </summary>
        /// <param name="context">Context de la base de donnée.</param>
        public PwaRepository(SensoStatDbContext context)
        {
            this._context = context;
        }

        public PwaSessionResponse getPwaResponse(string hash)
        {
            var urlCompare = $"http://localhost:8080/{hash}";
            var session = this._context.Publications.Where(p => p.Url == urlCompare)?.Select(p => new PwaSessionResponse()
            {
                Id = p.IdSession,
                Instructions = p.Session.Instructions.Select(d => new InstructionResponse()
                {
                    Id = d.Id,
                    Chronology = d.Chronology,
                    IsQuestion = d.IsQuestion,
                    Libelle = d.Libelle,
                }).OrderBy(a => a.Chronology).ToList(),
                MsgAccueil = p.Session.MsgAccueil,
                MsgFinal = p.Session.MsgFinal,
                Name = p.Session.Name,
                IdPanelist = p.IdPaneslist,
                Presentations = p.Panelist.Presentations.Select(e => new PwaPresentationResponse()
                {
                    IdProduct = e.IdProduct,
                    CodeProduit = e.Product.CodeProduct,
                    Rank = e.Rank,
                }).OrderBy(a => a.Rank).ToList(),
            }).FirstOrDefault();

            return session;
        }
    }
}
