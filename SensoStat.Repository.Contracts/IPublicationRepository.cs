﻿namespace SensoStat.Repository.Contracts
{
    using SensoStat.Entities;

    /// <summary>
    /// Interface pour les publications.
    /// </summary>
    public interface IPublicationRepository
    {
        /// <summary>
        /// Ajoute une nouvelle publication.
        /// </summary>
        /// <param name="publication">Publication à ajouter.</param>
        void Add(Publication publication);

        /// <summary>
        /// Supprime une publication.
        /// </summary>
        /// <param name="publication">Publication à supprimer.</param>
        void Delete(Publication publication);

        /// <summary>
        /// Retourne la publication demandée.
        /// </summary>
        /// <param name="id">Id de la publication à trouver.</param>
        /// <returns>La publication ayant l'id demandé si celui-ci est trouvé sinon renvoie null.</returns>
        Publication Find(int idPanelist, int idSession);

        /// <summary>
        /// Retourne toutes les publications.
        /// </summary>
        /// <returns>Une collection contenant toutes les publications.</returns>
        IEnumerable<Publication> FindAll();

        /// <summary>
        /// Met à jour une publication.
        /// </summary>
        /// <param name="publication">Publication à modifier.</param>
        void Update(Publication publication);
    }
}
