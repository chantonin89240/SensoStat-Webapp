namespace SensoStat.WebApplication
{
    using SensoStat.WebApplication.Filters;
    using SensoStat.WebApplication.Services;
    using SensoStat.WebApplication.Services.Contracts;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            // services.AddControllersWithViews(option =>
            // {
            //     option.Filters.Add(typeof(LoggerActionFilter));
            // });

            services.AddRazorPages()
                .AddRazorRuntimeCompilation();

            var apiAdress = Configuration.GetSection("Api").Value;

            services.AddHttpClient<ClientService>(e =>
            {
                e.BaseAddress = new Uri(apiAdress);
            });

            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<IUserService, UserService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error404");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
     }
}
