namespace SensoStat.WebAPI
{
    using Microsoft.EntityFrameworkCore;
    using SensoStat.EntitiesContext;
    using SensoStat.Repository;
    using SensoStat.Repository.Contracts;
    using SensoStat.Services;
    using SensoStat.Services.Contracts;

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            string connectionBdd = this.Configuration.GetConnectionString("SensoStatDbContext");
            string connectionBddPostgresSQL = this.Configuration.GetConnectionString("SensoStatDbContextPostgresSql");

            // try
            // {
            //     services.AddDbContext<SensoStatDbContext>(options =>
            //     {
            //         options.UseSqlServer(connectionBdd);
            //     });
            // }
            // catch
            // {
                services.AddDbContext<SensoStatDbContext>(options =>
                {
                    options.UseNpgsql(connectionBddPostgresSQL);
                });
            // }


            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<IPanelistRepository, DbPanelistRepository>();
            services.AddScoped<IPanelistService, PanelistService>();
            // services.AddScoped<SessionService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<SensoStatDbContext>();

                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();

                    SeedData.Initialize(services);

                }
                catch (Exception ex)
                {
                }
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}