namespace SensoStat.Services
{
    using Microsoft.AspNetCore.Mvc;
    using SensoStat.Entities;
    using SensoStat.Entities.Request;
    using SensoStat.Repository.Contracts;

    public class ProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public IActionResult Get()
        {
            return new OkObjectResult(this._productRepository.FindAll());
        }
    }
}
