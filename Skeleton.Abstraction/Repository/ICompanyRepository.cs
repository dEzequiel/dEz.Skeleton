using Skeleton.Entities.Models;

namespace Skeleton.Abstraction.Repository;

/// <summary>
/// Repository interface for company-related operations.
/// </summary>
public interface ICompanyRepository
{
    /// <summary>
    /// Asynchronously retrieves all companies.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, returning an enumerable collection of
    /// <see cref="Company"/>.</returns>
    Task<IEnumerable<Company>> GetAllAsync();
    
    /// <summary>
    /// Asynchronously retrieves all companies by its ID.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, returning an enumerable collection of
    /// <see cref="Company"/>.</returns>
    Task<IEnumerable<Company>> GetAllByIdAsync(IEnumerable<Guid> ids);

    /// <summary>
    /// Asynchronously retrieves a company by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the company to retrieve.</param>
    /// <returns>
    /// A task representing the asynchronous operation, returning the <see cref="Company"/> object
    /// with the specified ID, or null if the company is not found.
    /// </returns>
    Task<Company?> GetAsync(Guid id);

    /// <summary>
    /// Create company.
    /// </summary>
    /// <param name="company">Company object to be created.</param>
    void Add(Company company);
}