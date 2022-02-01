namespace SensoStat.EntitiesContext
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using SensoStat.Entities;
    using SensoStat.Entities.Factory;

    public class SeedData
    {
        public static List<Role> roles;
        public static List<User> users;
        public static List<Panelist> panelists;
        public static void Initialize(IServiceProvider serviceProvider)
        {
            
            using (var context = new SensoStatDbContext(serviceProvider.GetRequiredService<DbContextOptions<SensoStatDbContext>>()))
            {
                roles = RoleFactory.GenerateRole().ToList();
                context.Roles.AddRange(roles);
                context.SaveChanges();

                users = UserCreator();
                context.Users.AddRange(users);
                context.SaveChanges();

                panelists = PanelistCreator();
                context.Panelists.AddRange(panelists);
                context.SaveChanges();
            }
        }

        public static List<User> UserCreator()
        {
            return PersonFactory.GeneratePerson(roles).ToList();
        }

        public static List<Session> SessionCreator()
        {
            return SessionFactory.GenerateSession(users).ToList();
        }

        public static List<Panelist> PanelistCreator()
        {
            return PanelistFactory.GeneratePanelist();
        }
    }
}
