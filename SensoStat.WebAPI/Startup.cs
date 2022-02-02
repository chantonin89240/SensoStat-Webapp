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
            services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen();

            string connectionBdd = this.Configuration.GetConnectionString("SensoStatDbContext");
            string connectionBddPostgresSQL = this.Configuration.GetConnectionString("SensoStatDbContextPostgresSql");

            services.AddDbContext<SensoStatDbContext>(options =>
            {
                options.UseSqlServer(connectionBdd);
            });

            //services.AddDbContext<SensoStatDbContext>(options =>
            //{
            //    options.UseNpgsql(connectionBddPostgresSQL);
            //});

            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPresentationRepository, PresentationRepository>();
            services.AddScoped<IPresentationService, PresentationService>();
            services.AddScoped<IPanelistRepository, DbPanelistRepository>();
            services.AddScoped<IPanelistService, PanelistService>();
            services.AddScoped<SessionService>();
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

                    //context.Database.EnsureDeleted();
                    //context.Database.EnsureCreated();

                    //SeedData.Initialize(services);

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