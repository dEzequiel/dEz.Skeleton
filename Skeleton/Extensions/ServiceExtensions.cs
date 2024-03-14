using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skeleton.Abstraction;
using Skeleton.Abstraction.Repository;
using Skeleton.CQRSCore.Infrastructure;
using Skeleton.Entities.Aggregates;
using Skeleton.Logger;
using Skeleton.Presentation.Commands.Company;
using Skeleton.Presentation.Dispatchers;
using Skeleton.Presentation.Handlers;
using Skeleton.Repository;
using Skeleton.Service;
using Skeleton.Service.Abstraction;
using System.Reflection;

namespace Skeleton.Extensions
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// DI for loggin.
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void ConfigureLoggerManager(this IServiceCollection serviceCollection) =>
            serviceCollection.AddSingleton<ILoggerManager, LoggerManager>();

        /// <summary>
        /// DI for unit of work.
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void ConfigureUnitOfWork(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
            serviceCollection.AddScoped<ICompanyRepository, CompanyRepository>();
            serviceCollection.AddScoped<IEmployeeRepository, EmployeeRepository>();
            serviceCollection.AddScoped<IEventStoreRepository, EventStoreRepository>();
        }

        /// <summary>
        /// DI for service manager.
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void ConfigureServiceManager(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IServiceManager, ServiceManager>();

            var serviceAssembly = Assembly.GetAssembly(typeof(IServiceBase));

            IEnumerable<Type> appServices =
                serviceAssembly.GetTypes().Where(x => x.GetInterface(nameof(IServiceBase)) != null && !x.IsAbstract
                    && !x.IsInterface);

            // Para cada tipo (será una clase)...
            foreach (Type r in appServices)
            {
                // Cogemos todas sus interfaces que no son ni IServiceBase ni IDisposable...y nos quedamos con la primera (o null).
                Type i = r.GetInterfaces().FirstOrDefault(x => x != typeof(IServiceBase) && x != typeof(IDisposable));
                // ...y sólo añadimos la clase al IOC (como Transient) si tiene alguna interfaz propia: usamos esa interfaz para registrarlo !!!
                if (i != null)
                    serviceCollection.TryAddScoped(i, r);
            }
        }

        /// <summary>
        /// Configuration for database context.
        /// </summary>
        /// <param name="serviceCollection"></param>
        /// <param name="configuration"></param>
        public static void ConfigureDbContext(this IServiceCollection serviceCollection,
            IConfiguration configuration) =>
            serviceCollection.AddDbContext<RepositoryContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("sqlConnectionString")));


        /// <summary>
        /// DI for event sourcing.
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void ConfigureEventSourcingHandlers(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IEventSourcingHandler<CompanyAggregate>, CompanyEventSourcingHandler>();
        }

        /// <summary>
        /// DI for command handlers.
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void ConfigureCommandHandlers(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICompanyCommandHandler, CompanyCommandHandler>();

            var companyCommandHandler = serviceCollection.BuildServiceProvider().GetRequiredService<ICompanyCommandHandler>();
            var commandDispatcher = new CommandDispatcher();
            
            commandDispatcher.RegisterHandler<AddCompanyCommand>(companyCommandHandler.HandleAsync);
            commandDispatcher.RegisterHandler<DeleteCompanyCommand>(companyCommandHandler.HandleAsync);
            commandDispatcher.RegisterHandler<UpdateCompanyCommand>(companyCommandHandler.HandleAsync);

            serviceCollection.AddSingleton<ICommandDispatcher>(commandDispatcher);
        }


        /// <summary>
        /// Configuration for IIS integration.
        /// </summary>
        /// <param name="services"></param>
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .WithExposedHeaders("X-Pagination"));
            });
    }
}
