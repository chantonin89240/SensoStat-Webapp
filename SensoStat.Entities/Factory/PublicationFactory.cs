namespace SensoStat.Entities.Factory
{
    using Bogus;

    public class PublicationFactory
    {
        public static Faker<Publication> GeneratePublication()
        {
            var CreatePublicationFactory = new Faker<Publication>()
                .StrictMode(true)
                .RuleFor(p => p.Url, f => f.Internet.Url())
                .RuleFor(p => p.DateStart, f => f.Date.Recent())
                .RuleFor(p => p.DateEnd, f => f.Date.Future());

            return CreatePublicationFactory;
        }
    }
}
