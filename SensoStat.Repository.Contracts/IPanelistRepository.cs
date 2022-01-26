namespace SensoStat.Repository.Contracts
{
    using SensoStat.Entities;

    /// <summary>
    /// Interface pour un paneliste.
    /// </summary>
    public interface IPanelistRepository
    {
        /// <summary>
        /// Ajoute un nouveau paneliste.
        /// </summary>
        /// <param name="panelist">Paneliste à ajouter.</param>
        void Add(Panelist panelist);

        /// <summary>
        /// Supprime un paneliste.
        /// </summary>
        /// <param name="panelist">Paneliste à supprimer.</param>
        void Delete(Panelist panelist);

        /// <summary>
        /// Retourne le paneliste demandé.
        /// </summary>
        /// <param name="id">Id du paneliste à trouver.</param>
        /// <returns>>Le paneliste ayant l'id demandé si celui-ci est trouvé sinon renvoie null.</returns>
        Panelist Find(int id);

        /// <summary>
        /// Retourne tous les panelistes.
        /// </summary>
        /// <returns>Une collection contenant tous les panelistes.</returns>
        IEnumerable<Panelist> FindAll();

        /// <summary>
        /// Met à jour un paneliste.
        /// </summary>
        /// <param name="panelist">PAneliste à modifier.</param>
        void Update(Panelist panelist);
    }
}
