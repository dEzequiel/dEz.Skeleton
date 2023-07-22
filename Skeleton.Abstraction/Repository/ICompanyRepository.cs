using Skeleton.Entities.Models;

namespace Skeleton.Abstraction.Repository;

public interface ICompanyRepository
{
    /// <summary>
    /// Get all Companies.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<Company>> GetAllAsync();

    /// <summary>
    /// Get Company by Id.
    /// </summary>
    /// <param name="id">Company identifier.</param>
    /// <returns></returns>
    Task<Company?> GetAsync(Guid id);
}