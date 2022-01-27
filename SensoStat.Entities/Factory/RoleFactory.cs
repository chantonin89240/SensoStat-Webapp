namespace SensoStat.Entities.Factory
{
    using Bogus;

    public class RoleFactory
    {
        public static IEnumerable<Role> GenerateRole()
        {
            List<Role> roles = new List<Role>()
            {
                new Role() { Id = 1, Libelle = "SuperAdmin" },
                new Role() { Id = 1, Libelle = "Admin" },
                new Role() { Id = 1, Libelle = "Stagiaire" },
            };

            return roles;
        }
    }
}
