namespace SensoStat.Entities.Factory
{
    using Bogus;

    public class RoleFactory
    {
        public static IEnumerable<Role> GenerateRole()
        {
            List<Role> roles = new List<Role>()
            {
                new Role() { Libelle = "SuperAdmin" },
                new Role() { Libelle = "Admin" },
                new Role() { Libelle = "Stagiaire" },
            };

            return roles;
        }
    }
}
