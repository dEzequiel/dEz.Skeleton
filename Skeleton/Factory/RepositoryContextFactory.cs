using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Skeleton.Repository;

namespace Skeleton.Factory;

public class RepositoryContextFactory : IDesignTimeDbContextFactory<RepositoryContext>
{
    private const string APP_SETTINGS = "appsettings.json";

    public RepositoryContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile(APP_SETTINGS)
            .Build();

        var builder = new DbContextOptionsBuilder<RepositoryContext>()
            .UseSqlServer(configuration.GetConnectionString("sqlConnection"));

        return new RepositoryContext(builder.Options);
    }
}