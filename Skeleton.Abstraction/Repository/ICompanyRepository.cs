using Skeleton.Entities.Models;

namespace Skeleton.Abstraction.Repository;

public interface ICompanyRepository
{
    /// <summary>
    /// Get all Companies.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Company>> GetAllAsync();
}