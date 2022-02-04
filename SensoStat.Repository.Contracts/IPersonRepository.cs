namespace SensoStat.Repository.Contracts
{
    using SensoStat.Entities;

    /// <summary>
    /// Interface pour les utilsateurs.
    /// </summary>
    public interface IPersonRepository
    {
        /// <summary>
        /// Ajoute une nouveau utilsateur.
        /// </summary>
        /// <param name="person">Utilisateur à ajouter.</param>
        void Add(User person);

        /// <summary>
        /// Supprime un utilisateur.
        /// </summary>
        /// <param name="person">Utilisateur à supprimer.</param>
        void Delete(User person);

        /// <summary>
        /// Retourne l'utilisateur demandée.
        /// </summary>
        /// <param name="id">Id de l'utilisateur à trouver.</param>
        /// <returns>L'utilisateur ayant l'id demandé si celui-ci est trouvé sinon renvoie null.</returns>
        User Find(int id);

        /// <summary>
        /// Retourne toutes les utilisateurs.
        /// </summary>
        /// <returns>Une collection contenant tous les utilisateurs.</returns>
        IEnumerable<User> FindAll();

        /// <summary>
        /// Met à jour un utilisateur.
        /// </summary>
        /// <param name="person">Utilisateur à modifier.</param>
        void Update(User person);
    }
}
