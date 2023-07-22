using Skeleton.Abstraction.Repository;
using Skeleton.Entities.Models;

namespace Skeleton.Repository;

public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="repositoryContext"></param>
    public CompanyRepository(RepositoryContext repositoryContext) 
        : base(repositoryContext)
    {
    }
}