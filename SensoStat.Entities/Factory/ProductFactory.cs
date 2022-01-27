namespace SensoStat.Entities.Factory
{
    using Bogus;

    public class ProductFactory
    {
        public static Faker<Product> GenerateProduct()
        {
            var ProductId = 0;
            var CreateProductFactory = new Faker<Product>()
                .StrictMode(true)
                .RuleFor(p => p.Id, f => ProductId++)
                .RuleFor(p => p.CodeProduct, f => f.Random.Int(4));

            return CreateProductFactory;
        }
    }
}
