namespace SensoStat.Services
{
    using SensoStat.Entities;
    using SensoStat.Repository.Contracts;
    using SensoStat.Services.Contracts;

    /// <summary>
    /// .
    /// </summary>
    public class PresentationService : IPresentationService
    {
        private IPresentationRepository _presentationRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="PresentationService"/> class.
        /// </summary>
        /// <param name="presentationRepository">.</param>
        public PresentationService(IPresentationRepository presentationRepository)
        {
            this._presentationRepository = presentationRepository;
        }

        /// <summary>
        /// .
        /// </summary>
        /// <returns>liste des presentations.</returns>
        public IEnumerable<Presentation> Get()
        {
            return this._presentationRepository.FindAll();
        }

        /// <summary>
        /// .
        /// </summary>
        /// <param name="id">id de la session.</param>
        /// <returns>liste des présentation en fonction de la session.</returns>
        public IEnumerable<Presentation> FindByIdSession(int id)
        {
            return this._presentationRepository.FindByIdSession(id);
        }

        public List<Presentation> MultiCreate(List<Presentation> presentations)
        {
            this._presentationRepository.AddRange(presentations);

            return presentations;
        }

        public IEnumerable<PresentationDTO> FindByIdSessionAndIdPanelist(int idSession, int idPanelist)
        {
            return this._presentationRepository.FindByIdSessionAndIdPanelist(idSession, idPanelist);
        }
    }
}
