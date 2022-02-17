namespace SensoStat.Repository
{
    using SensoStat.Entities;
    using SensoStat.Repository.Contracts;
    using SensoStat.EntitiesContext;

    public class DbPanelistRepository : IPanelistRepository
    {

        private SensoStatDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SessionRepository"/> class.
        /// </summary>
        /// <param name="context">Context de la base de donnée.</param>
        public DbPanelistRepository(SensoStatDbContext context)
        {
            this._context = context;
        }
        /// <summary>
        /// Ajoute un nouveau paneliste.
        /// </summary>
        /// <param name="panelist">Paneliste à ajouter.</param>
        public Panelist Add(Panelist panelist)
        {
            var existingPanelist = this._context.Panelists.FirstOrDefault(p => p.CodePanelist == panelist.CodePanelist);

            if (existingPanelist == null)
            {
                this._context.Panelists.Add(panelist);
                this._context.SaveChanges();
                return panelist;
            }

            return existingPanelist;
        }

        /// <summary>
        /// Supprime un paneliste.
        /// </summary>
        /// <param name="panelist">Paneliste à supprimer.</param>
        public void Delete(Panelist panelist)
        {

        }

        /// <summary>
        /// Retourne le paneliste demandé.
        /// </summary>
        /// <param name="id">Id du paneliste à trouver.</param>
        /// <returns>>Le paneliste ayant l'id demandé si celui-ci est trouvé sinon renvoie null.</returns>
        public Panelist Find(int id)
        {
            return new Panelist();
        }

        /// <summary>
        /// Retourne tous les panelistes.
        /// </summary>
        /// <returns>Une collection contenant tous les panelistes.</returns>
        public IEnumerable<Panelist> FindAll()
        {
            return new List<Panelist>();
        }

        /// <summary>
        /// Met à jour un paneliste.
        /// </summary>
        /// <param name="panelist">PAneliste à modifier.</param>
        public void Update(Panelist panelist)
        {

        }
    }
}