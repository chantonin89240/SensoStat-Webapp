namespace SensoStat.Entities.Factory
{
    using Bogus;

    public static class PersonFactory
    {
        public static IEnumerable<User> GeneratePerson(List<Role> roles) 
        {
            var PersonId = 0;
            var CreatePersonFactory = new Faker<User>()
                .CustomInstantiator(f => new User(
                    PersonId++,
                    roles[f.Random.Number(0, 2)],
                    f.Name.LastName(),
                    f.Name.FirstName(),
                    f.Internet.Email(),
                    f.Name.FullName(),
                    f.Random.String(10)));

            //.RuleFor(p => p.Id, f => PersonId++)
            //.RuleFor(p => p.Role, roles[p.Random.Number(1, 2)])
            //.RuleFor(p => p.LastName, f => f.Name.LastName())
            //.RuleFor(p => p.FirstName, f => f.Name.FirstName())
            //.RuleFor(p => p.Mail, f => f.Internet.Email())
            //.RuleFor(p => p.Login, f => f.Name.FullName())
            //.RuleFor(p => p.Password, f => f.Random.String(10));

            var users = CreatePersonFactory.Generate(10);
            return users;
        }
    }
}
