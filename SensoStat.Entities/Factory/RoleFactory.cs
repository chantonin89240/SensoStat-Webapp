namespace SensoStat.Entities.Factory
{
    using Bogus;

    public class RoleFactory
    {
        public static Faker<Role> GenerateRole()
        {
            var TypeRole = new[] { "SuperAdmin", "Admin", "Stagiaire" };
            var RoleId = 0;
            var CreateRoleFactory = new Faker<Role>()
                .StrictMode(true)
                .RuleFor(r => r.Id, f => RoleId++)
                .RuleFor(r => r.Libelle, f => f.PickRandom(TypeRole))
                .RuleFor(r => r.Persons, PersonFactory.GeneratePerson().Generate(6));

            return CreateRoleFactory;
        }
    }
}
