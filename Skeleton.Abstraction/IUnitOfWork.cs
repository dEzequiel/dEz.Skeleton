namespace Skeleton.Abstraction;

public interface IUnitOfWork
{
    /// <summary>
    /// Commit changes to database.
    /// </summary>
    void Save();
}