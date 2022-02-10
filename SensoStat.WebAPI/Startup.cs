 namespace SensoStat.WebAPI
{
    using System.Text;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using SensoStat.EntitiesContext;
    using SensoStat.Repository;
    using SensoStat.Repository.Contracts;
    using SensoStat.Services;
    using SensoStat.Services.Contracts;
    using SensoStat.WebAPI.Helpers;

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

            // configuration de la configuration relative � l'API dans l'API, fortement typ�e
            services.Configure<JwtSettings>(this.Configuration.GetSection("ApiSettings"));

            // Utilisation de la configuration fortement typ�e dans le Program.cs
            var conf = new JwtSettings();
            this.Configuration.GetSection(nameof(JwtSettings)).Bind(conf);

            // configuration du middleware d'authentification JWT fourni par Microsoft
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = conf.JwtIssuer,
                    ValidateAudience = true,
                    ValidAudience = conf.JwtAudience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(conf.JwtSecret))
                };
            });


            //services.AddDbContext<SensoStatDbContext>(options =>
            //{
            //    options.UseSqlServer(connectionBdd);
            //});

            services.AddDbContext<SensoStatDbContext>(options =>
            {
                options.UseNpgsql(connectionBddPostgresSQL);
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
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

            // Configuration comportement PostgresSql on TimeStamp with timezone
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<SensoStatDbContext>();

                    // context.Database.EnsureDeleted();
                    // context.Database.EnsureCreated();

                    // SeedData.Initialize(services);
                }
                catch (Exception ex)
                {
                    throw ex;
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