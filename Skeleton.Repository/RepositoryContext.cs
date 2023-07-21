using Microsoft.EntityFrameworkCore;
using Skeleton.Entities.Models;

namespace Skeleton.Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Company>? Companies { get; set; }
    public DbSet<Employee>? Employees { get; set; }
}