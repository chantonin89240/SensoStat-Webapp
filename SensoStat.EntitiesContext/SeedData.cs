namespace SensoStat.EntitiesContext
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;

    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SensoStatDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SensoStatDbContext>>()))
            {
                
            }
        }
    }
}
