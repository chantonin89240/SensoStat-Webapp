namespace SensoStat.Entities.Factory
{
    using Bogus;

    public class ProductFactory
    {
        public static List<Product> GenerateProduct(List<Session> sessions)
        {
            var ProductId = 0;
            var CreateProductFactory = new Faker<Product>()
                .CustomInstantiator(p => new Product(
                    new Bogus.Randomizer().Replace("###"),
                    sessions[p.Random.Number(0, sessions.Count-1)]
                    ));
            //.RuleFor(p => p.CodeProduct, f => f.Random.Int(4));

            var products = CreateProductFactory.Generate(1000);
            return products;
        }
    }
}
