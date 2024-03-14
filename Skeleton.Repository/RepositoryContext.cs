using Microsoft.EntityFrameworkCore;
using Skeleton.CQRSCore.Events;
using Skeleton.Entities.Models;
using Skeleton.Repository.Configuration;

namespace Skeleton.Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CompanyConfiguration());
        modelBuilder.ApplyConfiguration(new EmployeeConfiguration());
    }

    public DbSet<Company>? Companies { get; set; }
    public DbSet<Employee>? Employees { get; set; }
    public DbSet<EventModel> Events { get; set; }
}