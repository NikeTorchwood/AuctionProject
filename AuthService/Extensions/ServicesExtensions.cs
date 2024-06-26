using AuthService.Api.Mapping;
using AuthService.Api.Settings;
using AutoMapper;
using Infrastructure.EntityFramework;
using Infrastructure.Hasher;
using Infrastructure.JwtBearer;
using Repositories.Abstractions;
using Repositories.Implementations;
using Services.Abstractions;
using Services.Implementations;

namespace AuthService.Api.Extensions
{
    public static class ServicesExtensions
    {
        /// <summary>
        /// Инсталятор сервиса
        /// </summary>
        /// <param name="services">Расширяемая коллекция сервисов</param>
        /// <param name="configuration">Конфигурация буилдера</param>
        /// <returns>Коллекция сервисов с установленными сервисами микросервиса</returns>
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettings = configuration.Get<ApplicationSettings>();
            services.AddSingleton(applicationSettings)
                .AddSingleton((IConfigurationRoot)configuration)
                .InstallServices()
                .ConfigureContext(applicationSettings.ConnectionString)
                .ConfigureJwtBearer(configuration)
                .InstallRepositories();
            
            return services;
        }

        private static IServiceCollection InstallServices(this IServiceCollection services)
        {
            services.AddTransient<IPasswordHasher, PasswordHasher>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IJwtProvider, JwtProvider>()
                .InstallAutomapper(services.BuildServiceProvider().GetService<IPasswordHasher>());
            return services;
        }

        private static IServiceCollection InstallRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }
        private static IServiceCollection InstallAutomapper(this IServiceCollection services, IPasswordHasher passwordHasher)
        {
            var mapperConfiguration = GetMapperConfiguration(passwordHasher);
            services.AddSingleton<IMapper>(new Mapper(mapperConfiguration));
            return services;
        }

        private static MapperConfiguration GetMapperConfiguration(IPasswordHasher passwordHasher)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UsersMappingProfile(passwordHasher));
                cfg.AddProfile<Services.Implementations.Mapping.UsersMappingProfile>();
            });
            configuration.AssertConfigurationIsValid();
            return configuration;
        }
    }
}
