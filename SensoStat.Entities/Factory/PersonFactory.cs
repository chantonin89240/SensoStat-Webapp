namespace SensoStat.Entities.Factory
{
    using Bogus;

    public class PersonFactory
    {
        public static Faker<Entities.Person> GeneratePerson()
        {
            var PersonId = 0;
            var CreatePersonFactory = new Faker<Entities.Person>()
                .StrictMode(true)
                .RuleFor(p => p.Id, f => PersonId++)
                .RuleFor(p => p.Role, f => RoleFactory.GenerateRole().Generate())
                .RuleFor(p => p.LastName, f => f.Name.LastName())
                .RuleFor(p => p.FirstName, f => f.Name.FirstName())
                .RuleFor(p => p.Mail, f => f.Internet.Email())
                .RuleFor(p => p.Login, f => f.Name.FullName())
                .RuleFor(p => p.Password, f => f.Random.String(10));

            return CreatePersonFactory;
        }
    }
}
