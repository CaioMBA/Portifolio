using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PortifolioCore.Auxiliary;
using PortifolioCore.Auxiliary.Mappings;
using PortifolioCore.Entities.Models.GeneralSettingsModels;
using PortifolioInfrastructure.Data.APIs;
using PortifolioInfrastructure.Data.DataBases;

namespace PortifolioInfrastructure.DependencyInjection
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
            //serviceCollection.AddScoped<IUserService, UserService>();
        }

        public static void ConfigureDependenciesRepository(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ApiDefaultAccess>();
            serviceCollection.AddTransient<DataBaseDefaultAccess>();
        }

        public static void ConfigureDependenciesExtras(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<Utils>();
        }
    }
}
