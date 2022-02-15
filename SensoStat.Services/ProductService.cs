namespace SensoStat.Services
{
    using System.Collections;
    using SensoStat.Entities;
    using SensoStat.Models.HttpRequest;
    using SensoStat.Repository.Contracts;
    using SensoStat.Services.Contracts;

    /// <summary>
    /// .
    /// </summary>
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductService"/> class.
        /// </summary>
        /// <param name="productRepository">.</param>
        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        /// <inheritdoc/>
        public IEnumerable Get()
        {
            return this._productRepository.FindAll();
        }

        /// <inheritdoc/>
        public Product Find(int id)
        {
            return this._productRepository.Find(id);
        }

        /// <inheritdoc/>
        public Product Create(ProductRequest productRequest)
        {
            var product = new Product()
            {
                CodeProduct = productRequest.CodeProduct,
                IdSession = productRequest.IdSession,
            };

            this._productRepository.Add(product);

            return product;
        }
    }
}
