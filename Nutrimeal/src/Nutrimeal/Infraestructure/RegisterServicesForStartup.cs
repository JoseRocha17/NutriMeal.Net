using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Nutrimeal.Business;
using Nutrimeal.Domain.Contracts.Manager;
using Nutrimeal.Domain.Contracts.Repository;
using Nutrimeal.Repository.ef;
//using Swashbuckle.AspNetCore.Swagger;

namespace Nutrimeal.Web.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    public class RegisterServicesForStartup
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="connectionString"></param>
        public static void RegisterServices(IServiceCollection services, string connectionString)
        {

            //services.AddMvcCore().AddJsonOptions(opt =>
            //{
            //    var resolver = opt.SerializerSettings.ContractResolver;
            //    if (resolver == null) return;
            //    var res = resolver as DefaultContractResolver;
            //    if (res != null) res.NamingStrategy = null;  // <<!-- this removes the camelcasing
            //});

            services.AddMvcCore().AddApiExplorer();

            //Repository.Dapper.Context.RepositoryContext.Instance.ConnectionString = connectionString;

            services.AddTransient<IObjetivosManager, ObjetivosManager>();
            services.AddTransient<IObjetivosRepository, ObjetivosRepository>();

            //services.AddTransient<ICandidateDocumentManager, CandidateDocumentManager>();
            //services.AddTransient<ICandidateDocumentRepository, CandidateDocumentsRepository>();

            //services.AddTransient<ICandidateStatusManager, CandidateStatusManager>();
            //services.AddTransient<ICandidateStatusRepository, CandidateStatusRepository>();

            //services.AddTransient<IRecruiterManager, RecruiterManager>();
            //services.AddTransient<IRecruiterRepository, RecruiterRepository>();

            //services.AddTransient<ISoftSkillsManager, SoftSkillsManager>();
            //services.AddTransient<ISoftSkillsRepository, SoftSkillsRepository>();

            //services.AddTransient<ITechnicalSkillsManager, TechnicalSkillsManager>();
            //services.AddTransient<ITechnicalSkillsRepository, TechnicalSkillsRepository>();

            //services.AddTransient<IEvaluationTechnicalSkillsManager, EvaluationTechnicalSkillsManager>();
            //services.AddTransient<IEvaluationTechnicalSkillsRepository, EvaluationTechnicalSkillsRepository>();

            //services.AddTransient<IEvaluationSoftSkillsManager, EvaluationSoftSkillsManager>();
            //services.AddTransient<IEvaluationSoftSkillsRepository, EvaluationSoftSkillsRepository>();

            //services.AddTransient<IEvaluationSoftSkillsPontuationManager, EvaluationSoftSkillsPontuationManager>();
            //services.AddTransient<IEvaluationSoftSkillsPontuationRepository, EvaluationSoftSkillsPontuationRepository>();

            //services.AddTransient<IEvaluationTechnicalSkillsPontuationManager, EvaluationTechnicalSkillsPontuationManager>();
            //services.AddTransient<IEvaluationTechnicalSkillsPontuationRepository, EvaluationTechnicalSkillsPontuationRepository>();


            //services.AddTransient<IEvaluationSoftSkillsPontuationManager, EvaluationSoftSkillsPontuationManager>();
            //services.AddTransient<IEvaluationSoftSkillsPontuationRepository, EvaluationSoftSkillsPontuationRepository>();

            //services.AddTransient<IMessageRepository, MessageRepository>();

            //services.AddTransient<IDeviceManager, DeviceManager>();
            //services.AddTransient<IDeviceRepository, DeviceRepository>();

            ////As this is not a dbcontext we must add this
            //Repository.Json.Context.RepositoryContext.Instance.ConnectionString =
            //    Path.Combine(Directory.GetCurrentDirectory(), "files");
            //services.AddTransient<IAppRepository, Repository.Json.AppRepository>();
            //services.AddTransient<IQuickAccessMenuRepository, Repository.Json.QuickAccessMenu>();
            //services.AddTransient<IBrandRepository, Repository.Json.BrandRepository>();



            //services.AddTransient<IAppManager, AppManager>();
            //services.AddTransient<IVehiclesManager, VehiclesManager>();
            //services.AddTransient<ICampaignManager, CampaignManager>();
            //services.AddTransient<ICampaignRepository, CampaignRepository>();

            //services.AddTransient<IContactManager, ContactManager>();

            //services.AddTransient<ICustomerManager, CustomerManager>();
            //services.AddTransient<IVehiclesRepository, VehiclesRepository>();

            //services.AddScoped<TokenValidationAsyncResourceFilter>();
            //services.AddScoped<CurrentUserAsyncResourceFilter>();
            //services.AddScoped<CurrentJwtUserEmailAsyncResourceFilter>();

  



            //services.ConfigureSwaggerGen(options =>
            //{
            //    //options.(new Info
            //    //{
            //    //    Version = "v1",
            //    //    Title = "Salvador Caetano App Services Platform",
            //    //    Description = "",
            //    //    TermsOfService = "None",
            //    //    Contact = new Contact() { Name = "Cristovão Morgado", Email = "cristovao.morgado@itsector.pt", Url = "www.itsector.com" }
            //    //});



            //    // var xmlPath = System.IO.Path.Combine(PlatformServices.Default.Application.ApplicationBasePath, "sc.Services.xml");
            //    // options.IncludeXmlComments(xmlPath);
            //});

        }


    }
}
