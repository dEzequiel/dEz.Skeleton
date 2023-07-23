using Microsoft.EntityFrameworkCore;
using Skeleton.Abstraction.Repository;
using Skeleton.Entities.Models;

namespace Skeleton.Repository;

/// <summary>
/// Repository implementation for employee-related operations.
/// </summary>
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

    ///<inheritdoc cref="IEmployeeRepository"/>
    public async Task<IEnumerable<Employee>> GetAllAsync(Guid companyId) =>
        await FindAll(false).Where(e => e.CompanyId.Equals(companyId)).ToListAsync();

    ///<inheritdoc cref="IEmployeeRepository"/>
    public async Task<Employee?> GetAsync(Guid id, Guid companyId) =>
        await FindByCondition(e => (e.Id.Equals(id) && e.CompanyId.Equals(companyId)), false)
            .SingleOrDefaultAsync();
}