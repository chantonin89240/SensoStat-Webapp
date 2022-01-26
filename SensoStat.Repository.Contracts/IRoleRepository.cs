namespace SensoStat.Repository.Contracts
{

    using SensoStat.Entities;

    /// <summary>
    /// Interface pour les rôles.
    /// </summary>
    public interface IRoleRepository
    {
        /// <summary>
        /// Ajoute une nouveau rôle.
        /// </summary>
        /// <param name="role">Rôle à ajouter.</param>
        void Add(Role role);

        /// <summary>
        /// Supprime un rôle.
        /// </summary>
        /// <param name="role">Rôle à supprimer.</param>
        void Delete(Role role);

        /// <summary>
        /// Retourne le rôle demandée.
        /// </summary>
        /// <param name="id">Id du rôle à trouver.</param>
        /// <returns>Le rôle ayant l'id demandé si celui-ci est trouvé sinon renvoie null.</returns>
        Role Find(int id);

        /// <summary>
        /// Retourne toutes les rôles.
        /// </summary>
        /// <returns>Une collection contenant tous les rôles.</returns>
        IEnumerable<Role> FindAll();

        /// <summary>
        /// Met à jour un rôle.
        /// </summary>
        /// <param name="role">Rôle à modifier.</param>
        void Update(Role role);
    }
}
