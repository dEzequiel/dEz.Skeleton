using System.Linq.Expressions;

namespace Skeleton.Abstraction;

public interface IRepositoryBase<T>
{
    ///<summary>
    /// Retrieves all instances of type T. 
    /// 'trackChanges' toggles change tracking.
    /// </summary>
    IQueryable<T> FindAll(bool trackChanges);

    ///<summary>
    /// Retrieves instances of type T matching a condition. 
    /// 'trackChanges' toggles change tracking.
    /// </summary>
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);

    ///<summary>
    /// Creates a new instance of type T.
    /// </summary>
    void Create(T entity);

    ///<summary>
    /// Updates an existing instance of type T.
    /// </summary>
    void Update(T entity);

    ///<summary>
    /// Deletes an existing instance of type T.
    /// </summary>
    void Delete(T entity);

}