namespace SensoStat.Repository
{
    using Microsoft.EntityFrameworkCore;
    using SensoStat.Entities;
    using SensoStat.EntitiesContext;
    using SensoStat.Repository.Contracts;

    /// <summary>
    /// . 
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private SensoStatDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="context">Context de la base de donnée.</param>
        public ProductRepository(SensoStatDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Ajoute un produit.
        /// </summary>
        /// <param name="product">le produit à ajouter.</param>
        public Product Add(Product product)
        {
            var existingProduct = this._context.Products.FirstOrDefault(p => p.CodeProduct == product.CodeProduct && p.IdSession == product.IdSession);
            if (existingProduct == null)
            {
                this._context.Products.Add(product);
                this._context.SaveChanges();
                return product;
            }

            return existingProduct;
        }

        /// <summary>
        /// Supprime un produit.
        /// </summary>
        /// <param name="product">le produit à supprimer.</param>
        public void Delete(Product product)
        {
            this._context.Products.Remove(product);
            this._context.SaveChanges();
        }

        /// <summary>
        /// Retourne le produit en fonction de sont id.
        /// </summary>
        /// <param name="id">id du produit que l'on veux retourner.</param>
        /// <returns>.</returns>
        public Product Find(int id)
        {
            return this._context.Products.FirstOrDefault(p => p.Id == id);
        }

        /// <summary>
        /// Retourne une liste des produits.
        /// </summary>
        /// <returns>.</returns>
        public IEnumerable<Product> FindAll()
        {
            return this._context.Products.Include(p => p.Presentations);
        }

        /// <summary>
        /// Modifie le produit passé en paramètre.
        /// </summary>
        /// <param name="product">le produit modifier.</param>
        public void Update(Product product)
        {
            this._context.Update(product);
            this._context.SaveChanges();
        }
    }
}
