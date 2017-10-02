using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nutrimeal.Data;
using Nutrimeal.Models;
using Nutrimeal.Services;
using Nutrimeal.Domain.Contracts.Manager;
using Nutrimeal.Business;
using Nutrimeal.Domain.Contracts.Repository;
using Nutrimeal.Repository.ef;
using Nutrimeal.Repository.Ef.Context;
using Nutrimeal.Repository;
using Nutrimeal.Configuration;
using Microsoft.AspNetCore.Identity;

namespace Nutrimeal
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();

                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<RepositoryContext>(options =>
    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDbContext<Nutrimeal.Repository.Ef.Context.RepositoryContext>(options =>
            //{
            //    options.UseSqlServer(Configuration.GetConnectionString("Db"));
            //});

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<RepositoryContext>()
    .AddDefaultTokenProviders();

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();


            services.AddTransient<IObjetivosManager, ObjetivosManager>();
            services.AddTransient<IObjetivosRepository, ObjetivosRepository>();

            services.AddTransient<IMedidasManager, MedidasManager>();
            services.AddTransient<IMedidasRepository, MedidasRepository>();

            services.AddTransient<IPerfilAlimentarManager, PerfilAlimentarManager>();
            services.AddTransient<IPerfilAlimentarRepository, PerfilAlimentarRepository>();

            services.AddTransient<IRefeicaoManager, RefeicaoManager>();
            services.AddTransient<IRefeicaoRepository, RefeicaoRepository>();

            services.AddTransient<IAlimentoManager, AlimentoManager>();
            services.AddTransient<IAlimentoRepository, AlimentoRepository>();

            services.AddTransient<IQuantidadeAlimentarManager, QuantidadeAlimentarManager>();
            services.AddTransient<IQuantidadeAlimentarRepository, QuantidadeAlimentarRepository>();

            services.AddTransient<IPerfilFisicoManager, PerfilFisicoManager>();
            services.AddTransient<IPerfilFisicoRepository, PerfilFisicoRepository>();

            services.AddTransient<IExercicioManager, ExercicioManager>();
            services.AddTransient<IExercicioRepository, ExercicioRepository>();

            services.AddTransient<IMetaExercicioManager, MetaExercicioManager>();
            services.AddTransient<IMetaExercicioRepository, MetaExercicioRepository>();

            services.AddTransient<IAtributoManager, AtributoManager>();
            services.AddTransient<IAtributoRepository, AtributoRepository>();

            services.AddTransient<IExercicioAtributoManager, ExercicioAtributoManager>();
            services.AddTransient<IExercicioAtributoRepository, ExercicioAtributoRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            new UserRolesSeed(app.ApplicationServices.GetService<RoleManager<IdentityRole>>()).Seed();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
