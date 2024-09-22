using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PortifolioCore.Auxiliary;
using PortifolioCore.Auxiliary.Mappings;
using PortifolioCore.Entities.Models.GeneralSettingsModels;
using PortifolioCore.Interfaces;
using PortifolioInfrastructure.Data.APIs;
using PortifolioInfrastructure.Data.DataBases;
using PortifolioInfrastructure.Data.DataBases.SqlServer;
using PortifolioServices.MainServices;

namespace PortifolioInjections
{
    public class InjectionConfiguration
    {
        public static void ConfigureDependencies(IServiceCollection serviceCollection, AppSettingsModel appConfig)
        {
            serviceCollection.AddSingleton(appConfig);
            ConfigureAutoMapper(serviceCollection);
            ConfigureDependenciesService(serviceCollection);
            ConfigureDependenciesRepository(serviceCollection);
            ConfigureDependenciesExtras(serviceCollection);
        }

        public static void ConfigureAutoMapper(IServiceCollection serviceCollection)
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ModelToDto());
                cfg.AddProfile(new DtoToModel());
            });
            IMapper mapper = config.CreateMapper();
            serviceCollection.AddSingleton(mapper);
        }

        public static void ConfigureDependenciesService(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IHomeService, HomeService>();
            serviceCollection.AddScoped<IAboutServices, AboutService>();
            serviceCollection.AddScoped<IServicesService, ServicesService>();
            serviceCollection.AddScoped<IPortfolioService, PortfolioService>();
            serviceCollection.AddScoped<IContactService, ContactService>();
        }

        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ApiDefaultAccess>();
            serviceCollection.AddTransient<DataBaseDefaultAccess>();
            serviceCollection.AddTransient<AboutRepository>();
            serviceCollection.AddTransient<ServicesRepository>();
            serviceCollection.AddTransient<PortfolioRepository>();
            serviceCollection.AddTransient<ContactRepository>();
        }

        public static void ConfigureDependenciesExtras(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<Utils>();
        }
    }
}
