using Skeleton.Abstraction.Repository;

namespace Skeleton.Abstraction;

public interface IUnitOfWork : IDisposable
{
    ICompanyRepository CompanyRepository { get; }
    IEmployeeRepository EmployeeRepository { get; }
    
    /// <summary>
    /// Commit changes to database.
    /// </summary>
    Task SaveAsync();
}