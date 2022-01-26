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
                .RuleFor(p => p.DateClose, f => f.Date.Future())
                .RuleFor(p => p.Person, PersonFactory.GeneratePerson().Generate())
                .RuleFor(p => p.Products, ProductFactory.GenerateProduct().Generate(3))
                .RuleFor(p => p.Instructions, InstructionFactory.GenerateInstruction().Generate(8))
                .RuleFor(p => p.Publications, PublicationFactory.GeneratePublication().Generate(30));

            return CreateSessionFactory;
        }
    }
}
