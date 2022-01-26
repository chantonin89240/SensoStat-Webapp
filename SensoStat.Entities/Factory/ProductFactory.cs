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
                .RuleFor(p => p.CodeProduct, f => f.Random.Int(4))
                .RuleFor(p => p.Session, SessionFactory.GenerateSession().Generate())
                .RuleFor(p => p.Responses, ResponseFactory.GenerateResponse().Generate(10))
                .RuleFor(p => p.Presentations, PresentationFactory.GeneratePresentation().Generate(8));

            return CreateProductFactory;
        }
    }
}
