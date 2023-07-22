using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Skeleton.Abstraction;

namespace Skeleton.Repository;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected RepositoryContext RepositoryContext;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="repositoryContext"></param>
    protected RepositoryBase(RepositoryContext repositoryContext)
        => RepositoryContext = repositoryContext;

    ///<inheritdoc cref="IRepositoryBase{T}"/>
    public IQueryable<T> FindAll(bool trackChanges) =>
        !trackChanges ?
            RepositoryContext.Set<T>()
                .AsNoTracking() :
            RepositoryContext.Set<T>();

    ///<inheritdoc cref="IRepositoryBase{T}"/>
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
        bool trackChanges) =>
        !trackChanges ?
            RepositoryContext.Set<T>()
                .Where(expression)
                .AsNoTracking() :
            RepositoryContext.Set<T>()
                .Where(expression);
    
    ///<inheritdoc cref="IRepositoryBase{T}"/>
    public void Create(T entity)
    {
        RepositoryContext.Set<T>().Add(entity);
    }

    ///<inheritdoc cref="IRepositoryBase{T}"/>
    public void Update(T entity)
    {
        RepositoryContext.Set<T>().Update(entity);
    }

    ///<inheritdoc cref="IRepositoryBase{T}"/>
    public void Delete(T entity)
    {
        RepositoryContext.Set<T>().Remove(entity);
    }
}