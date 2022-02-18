namespace SensoStat.Repository.Contracts
{
    using SensoStat.Entities;

    /// <summary>
    /// Interface pour les présentations.
    /// </summary>
    public interface IPresentationRepository
    {
        /// <summary>
        /// Ajoute une nouvelle présentation.
        /// </summary>
        /// <param name="presentation">Présenetation à ajouter.</param>
        void Add(Presentation presentation);

        /// <summary>
        /// Ajoute une liste de présentations.
        /// </summary>
        /// <param name="presentation">Présenetation à ajouter.</param>
        void AddRange(List<Presentation> presentations);

        /// <summary>
        /// Supprime une présentation.
        /// </summary>
        /// <param name="presentation">Présentation à supprimer.</param>
        void Delete(Presentation presentation);

        /// <summary>
        /// Supprime une liste de présentations.
        /// </summary>
        /// <param name="presentations"></param>
        void DeleteRange(List<Presentation> presentations);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="id"></param>
        /// <returns>une collection contenant les présentations de la session passé en paramétre.</returns>
        IEnumerable<Presentation> FindByIdSession(int id);

        /// <summary>
        /// Retourne toutes les présentations de la session et du panaliste.
        /// </summary>
        /// <param name="idSession">Id de la Session.</param>
        /// <param name="idPanelist">Id du paneliste.</param>
        /// <returns>Une collection contenant les présentations de la session et du panaliste passé en paramètre.</returns>
        //IEnumerable<PresentationDTO> FindByIdSessionAndIdPanelist(int idSession, int idPanelist);

        /// <summary>
        /// Retourne toutes les présentations.
        /// </summary>
        /// <returns>Une collection contenant toutes les présentations.</returns>
        IEnumerable<Presentation> FindAll();

        /// <summary>
        /// Met à jour une présentation.
        /// </summary>
        /// <param name="presentation">Présentation à modifier.</param>
        void Update(Presentation presentation);
    }
}
