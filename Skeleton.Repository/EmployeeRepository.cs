using Skeleton.Abstraction.Repository;
using Skeleton.Entities.Models;

namespace Skeleton.Repository;

public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="repositoryContext"></param>
    public EmployeeRepository(RepositoryContext repositoryContext) 
        : base(repositoryContext)
    {
    }
}