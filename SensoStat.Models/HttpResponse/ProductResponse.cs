namespace SensoStat.Models.HttpResponse
{
    using SensoStat.Entities;

    public class ProductResponse
    {
        public int Id { get; set; }

        public string? CodeProduct { get; set; }

        public ProductResponse(Product product)
        {
            this.Id = product.Id;
            this.CodeProduct = product.CodeProduct;
        }
    }
}
