using Microsoft.EntityFrameworkCore;
using Skeleton.Abstraction.Repository;
using Skeleton.Entities.Models;

namespace Skeleton.Repository;

public sealed class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="repositoryContext"></param>
    public CompanyRepository(RepositoryContext repositoryContext) 
        : base(repositoryContext)
    {
    }

    ///<inheritdoc cref="ICompanyRepository"/>
    public async Task<IEnumerable<Company>> GetAllAsync() =>
        await FindAll(false).ToListAsync();

    ///<inheritdoc cref="ICompanyRepository"/>
    public async Task<Company?> GetAsync(Guid id) =>
        await FindByCondition(c => c.Id.Equals(id), false)
            .SingleOrDefaultAsync();

    ///<inheritdoc cref="ICompanyRepository"/>
    public void Add(Company company) =>
        Create(company);
}