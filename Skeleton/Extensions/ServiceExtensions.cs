using Skeleton.Abstraction;
using Skeleton.Logger;

namespace Skeleton.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureLoggerManager(this IServiceCollection serviceCollection) =>
            serviceCollection.AddSingleton<ILoggerManager, LoggerManager>();
    }
}
