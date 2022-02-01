namespace SensoStat.Entities.Factory
{
    using Bogus;

    public class SessionFactory
    {
        public static IEnumerable<Session> GenerateSession(List<User> users)
        {
            var TypeEtat = new[] { "Close", "Deploy", "No Deploy" };
            var SessionId = 0;
            var CreateSessionFactory = new Faker<Session>("fr")
                .CustomInstantiator(f => new Session(
                f.Name.JobTitle(),
                f.PickRandom(TypeEtat),
                f.Date.Recent(),
                f.Date.Recent(),
                f.Date.Future(),
                users[f.Random.Number(0, users.Count-1)]));

            var sessions = CreateSessionFactory.Generate(100);

            //.RuleFor(p => p.Id, f => SessionId++)
            //.RuleFor(p => p.Name, f => f.Name.JobTitle())
            //.RuleFor(p => p.Etat, f => f.PickRandom(TypeEtat))
            //.RuleFor(p => p.DateCreate, f => f.Date.Recent())
            //.RuleFor(p => p.DateUpdate, f => f.Date.Recent())
            //.RuleFor(p => p.DateClose, f => f.Date.Future());
            return sessions;
        }
    }
}
