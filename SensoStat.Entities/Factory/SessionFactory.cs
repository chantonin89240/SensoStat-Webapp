namespace SensoStat.Entities.Factory
{
    using Bogus;

    public class SessionFactory
    {
        public static Faker<Session> GenerateSession()
        {
            var TypeEtat = new[] { "Close", "Deploy", "No Deploy" };
            var SessionId = 0;
            var CreateSessionFactory = new Faker<Session>()
                .StrictMode(true)
                .RuleFor(p => p.Id, f => SessionId++)
                .RuleFor(p => p.Name, f => f.Name.JobTitle())
                .RuleFor(p => p.Etat, f => f.PickRandom(TypeEtat))
                .RuleFor(p => p.DateCreate, f => f.Date.Recent())
                .RuleFor(p => p.DateUpdate, f => f.Date.Recent())
                .RuleFor(p => p.DateClose, f => f.Date.Future());

            return CreateSessionFactory;
        }
    }
}
