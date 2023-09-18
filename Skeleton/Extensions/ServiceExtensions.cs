using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Skeleton.Abstraction;
using Skeleton.Abstraction.Repository;
using Skeleton.Logger;
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
        }

        private static void AddLazyScoped<T>(this IServiceCollection services) where T : class =>
            services.AddScoped<Lazy<T>>(sp => new Lazy<T>(() => sp.GetService<T>()));

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


        public static void ConfigureDbContext(this IServiceCollection serviceCollection,
            IConfiguration configuration) =>
            serviceCollection.AddDbContext<RepositoryContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("sqlConnectionString")));
    }

}
