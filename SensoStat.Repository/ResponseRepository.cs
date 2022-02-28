namespace SensoStat.Repository
{
    using SensoStat.Entities;
    using SensoStat.EntitiesContext;
    using SensoStat.Repository.Contracts;

    public class ResponseRepository : IResponseRepository
    {
        private SensoStatDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResponseRepository"/> class.
        /// </summary>
        /// <param name="context">Context de la base de donnée.</param>
        public ResponseRepository(SensoStatDbContext context)
        {
            this._context = context;
        }

        /// <inheritdoc/>
        public void Add(Response response)
        {
            this._context.Responses.Add(response);
            this._context.SaveChanges();
        }

        public void Delete(Response response)
        {
            throw new NotImplementedException();
        }

        public Response Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Response> FindAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Response response)
        {
            throw new NotImplementedException();
        }
    }
}
