using Skeleton.Entities.Models;
using Skeleton.Shared.RequestFeatures;

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
    Task<PagedList<Company>> GetAllAsync(CompanyParameters parameters, bool trackChanges);

    /// <summary>
    /// Asynchronously retrieves all companies by its ID.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, returning an enumerable collection of
    /// <see cref="Company"/>.</returns>
    Task<IEnumerable<Company>> GetAllByIdAsync(IEnumerable<Guid> ids, bool trackChanges);

    /// <summary>
    /// Asynchronously retrieves a company by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the company to retrieve.</param>
    /// <returns>
    /// A task representing the asynchronous operation, returning the <see cref="Company"/> object
    /// with the specified ID, or null if the company is not found.
    /// </returns>
    Task<Company?> GetAsync(Guid id, bool trackChanges);

    /// <summary>
    /// Create company.
    /// </summary>
    /// <param name="company">Company object to be created.</param>
    void AddAsync(Company company);

    /// <summary>
    /// Delete company.
    /// </summary>
    void DeleteAsync(Company company);
}