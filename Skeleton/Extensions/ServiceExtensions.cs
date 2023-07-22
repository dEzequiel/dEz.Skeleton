using Skeleton.Abstraction;
using Skeleton.Logger;
using Skeleton.Repository;
using Skeleton.Service;

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
        public static void ConfigureUnitOfWork(this IServiceCollection serviceCollection) =>
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

        /// <summary>
        /// DI for service manager.
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void ConfigureServiceManager(this IServiceCollection serviceCollection) =>
            serviceCollection.AddScoped<IServiceManager, ServiceManager>();
    }
}
