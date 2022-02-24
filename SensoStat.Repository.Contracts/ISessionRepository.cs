namespace SensoStat.Repository.Contracts
{
    using SensoStat.Entities;

    /// <summary>
    /// Interface pour une campagne.
    /// </summary>
    public interface ISessionRepository
    {
        /// <summary>
        /// Ajoute une nouvelle campagne.
        /// </summary>
        /// <param name="session">Campagne à ajouter.</param>
        void Add(Session session);

        /// <summary>
        /// Supprime une campagne.
        /// </summary>
        /// <param name="session">Campagne à supprimer.</param>
        void Delete(int id);

        /// <summary>
        /// Retourne la campagne demandée.
        /// </summary>
        /// <param name="id">Id de la campagne à trouver.</param>
        /// <returns>La campagne ayant l'id demandé si celui-ci est trouvé sinon renvoie null.</returns>
        Session Find(int id);

        /// <summary>
        /// Retourne toutes les campagnes.
        /// </summary>
        /// <returns>Une collection contenant toutes les campagnes.</returns>
        IEnumerable<Session> FindAll();

        /// <summary>
        /// .
        /// </summary>
        /// <param name="statut">toto.</param>
        /// <returns>.</returns>
        IEnumerable<Session> FindByStatut(string statut);

        /// <summary>
        /// Met à jour une campagne.
        /// </summary>
        /// <param name="session">Campagne à modifier.</param>
        void Update(Session session);
    }
}