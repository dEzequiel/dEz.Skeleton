using Microsoft.EntityFrameworkCore;
using Skeleton.Abstraction;
using Skeleton.Abstraction.Repository;
using Skeleton.Logger;
using Skeleton.Repository;
using Skeleton.Service;
using Skeleton.Service.Abstraction;

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

            serviceCollection.AddLazyScoped<ICompanyRepository>();
            serviceCollection.AddLazyScoped<IEmployeeRepository>();
        }
        
        private static void AddLazyScoped<T>(this IServiceCollection services) where T : class =>
            services.AddScoped<Lazy<T>>(sp => new Lazy<T>(() => sp.GetService<T>()));

        /// <summary>
        /// DI for service manager.
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void ConfigureServiceManager(this IServiceCollection serviceCollection) =>
            serviceCollection.AddScoped<IServiceManager, ServiceManager>();


        public static void ConfigureDbContext(this IServiceCollection serviceCollection,
            IConfiguration configuration) =>
            serviceCollection.AddDbContext<RepositoryContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("sqlConnectionString")));
    }
    
}
