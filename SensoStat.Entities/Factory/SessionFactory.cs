namespace SensoStat.Entities.Factory
{
    using Bogus;

    public class SessionFactory
    {
        private static int nombreSeance = 100;

        /// <summary>
        /// Générateur de fausses séances
        /// </summary>
        /// <param name="users"></param>
        /// <returns></returns>
        public static IEnumerable<Session> GenerateSession(List<User> users)
        {
            var TypeEtat = new[] { "Close", "Deploy", "No Deploy" };
            var SessionId = 0;
            var CreateSessionFactory = new Faker<Session>("fr")
                .CustomInstantiator(f => new Session(
                f.Name.JobTitle(),
                f.Lorem.Paragraph(),
                f.Lorem.Paragraph(),
                f.PickRandom(TypeEtat),
                f.Date.Recent(),
                f.Date.Recent(),
                f.Date.Future(),
                users[f.Random.Number(0, users.Count - 1)]));

            var sessions = CreateSessionFactory.Generate(nombreSeance);

            return sessions;
        }
    }
}
