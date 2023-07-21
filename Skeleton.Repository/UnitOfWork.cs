using Skeleton.Abstraction;

namespace Skeleton.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly RepositoryContext _repositoryContext;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="repositoryContext"></param>
    public UnitOfWork(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
    }

    public async void Save() => await _repositoryContext.SaveChangesAsync();
}