namespace SensoStat.Entities.Factory
{
    using Bogus;

    public class PresentationFactory
    {
        public static Faker<Presentation> GeneratePresentation()
        {
            var CreatePresentationFactory = new Faker<Presentation>()
                .StrictMode(true)
                .RuleFor(p => p.Rank, f => f.Random.Int(5));

            return CreatePresentationFactory;
        }
    }
}
