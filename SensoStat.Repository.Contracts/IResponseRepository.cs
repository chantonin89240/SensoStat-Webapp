namespace SensoStat.Repository.Contracts
{
    using SensoStat.Entities;

    /// <summary>
    /// Interface pour les réponses.
    /// </summary>
    public interface IResponseRepository
    {
        /// <summary>
        /// Ajoute une nouvelle réponse.
        /// </summary>
        /// <param name="response">Réponse à ajouter.</param>
        void Add(Response response);

        /// <summary>
        /// Supprime une réponse.
        /// </summary>
        /// <param name="response">Réponse à supprimer.</param>
        void Delete(Response response);

        /// <summary>
        /// Retourne la réponse demandée.
        /// </summary>
        /// <param name="id">Id de la réponse à trouver.</param>
        /// <returns>La réponse ayant l'id demandé si celui-ci est trouvé sinon renvoie null.</returns>
        Response Find(int id);

        /// <summary>
        /// Retourne toutes les réponse.
        /// </summary>
        /// <returns>Une collection contenant toutes les réponses.</returns>
        IEnumerable<Response> FindAll();

        /// <summary>
        /// Met à jour une réponse.
        /// </summary>
        /// <param name="response">Réponse à modifier.</param>
        void Update(Response response);
    }
}
