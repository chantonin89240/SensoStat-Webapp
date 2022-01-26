namespace SensoStat.Repository.Contracts
{
    using SensoStat.Entities;

    /// <summary>
    /// Interface pour les produits.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Ajoute un nouveau produit.
        /// </summary>
        /// <param name="product">Produit à ajouter.</param>
        void Add(Product product);

        /// <summary>
        /// Supprime un produit.
        /// </summary>
        /// <param name="product">Produit à supprimer.</param>
        void Delete(Product product);

        /// <summary>
        /// Retourne le produit demandé.
        /// </summary>
        /// <param name="id">Id du produit à trouver.</param>
        /// <returns>Le produit ayant l'id demandé si celui-ci est trouvé sinon renvoie null.</returns>
        Product Find(int id);

        /// <summary>
        /// Retourne tous les produits.
        /// </summary>
        /// <returns>Une collection contenant tous les produits.</returns>
        IEnumerable<Product> FindAll();

        /// <summary>
        /// Met à jour un produit.
        /// </summary>
        /// <param name="product">Produit à modifier.</param>
        void Update(Product product);
    }
}
