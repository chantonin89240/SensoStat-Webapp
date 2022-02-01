namespace SensoStat.Entities.Factory
{
    using Bogus;

    public class PublicationFactory
    {
        public static List<Publication> GeneratePublication(List<Session> sessions)
        {
            List<Publication> publications = new List<Publication>();

            sessions.ForEach(session =>
            {
                var CreatePanelistFactory = new Faker<Panelist>("fr")
                .CustomInstantiator(f => new Panelist(
                   new Bogus.Randomizer().Replace("?##")));

                var CreatePublicationFactory = new Faker<Publication>()
               .CustomInstantiator(p => new Publication(
                   session,
                   CreatePanelistFactory.Generate(),
                   p.Internet.Url(),
                   p.Date.Recent(),
                   p.Date.Future()
                   ));

                publications.AddRange(CreatePublicationFactory.Generate(50));
            });
                //.StrictMode(true)
                //.RuleFor(p => p.Url, f => f.Internet.Url())
                //.RuleFor(p => p.DateStart, f => f.Date.Recent())
                //.RuleFor(p => p.DateEnd, f => f.Date.Future());

            return publications;
        }
    }
}
