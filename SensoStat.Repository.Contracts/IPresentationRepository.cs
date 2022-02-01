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
        /// Supprime une présentation.
        /// </summary>
        /// <param name="presentation">Présentation à supprimer.</param>
        void Delete(Presentation presentation);

        /// <summary>
        /// .
        /// </summary>
        /// <param name="id"></param>
        /// <returns>.</returns>
        IEnumerable<Presentation> FindByIdSession(int id);

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
