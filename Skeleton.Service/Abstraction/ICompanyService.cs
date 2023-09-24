using Skeleton.Entities.Models;
using Skeleton.Shared.DTOs;
using Skeleton.Shared.RequestFeatures;

namespace Skeleton.Service.Abstraction;

/// <summary>
/// Service interface for company-related operations.
/// </summary>
public interface ICompanyService : IServiceBase
{
    /// <summary>
    /// Gets all companies asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, returning an enumerable collection of
    /// <see cref="CompanyForGet"/>.</returns>
    Task<(IEnumerable<CompanyForGet> companies, PagedListMetaData metaData)> GetAllAsync(CompanyParameters parameters, bool trackChanges);

    /// <summary>
    /// Gets all companies asynchronously by its ID.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, returning an enumerable collection of
    /// <see cref="CompanyForGet"/>.</returns>
    Task<IEnumerable<CompanyForGet>> GetAllByIdAsync(IEnumerable<Guid> ids, bool trackChanges);

    /// <summary>
    /// Gets a company by its ID asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the company.</param>
    /// <returns>A task representing the asynchronous operation, returning the <see cref="CompanyForGet"/>
    /// object or null if not found.</returns>
    Task<CompanyForGet> GetByIdAsync(Guid id, bool trackChanges);

    /// <summary>
    /// Add new company asynchronously.
    /// </summary>
    /// <param name="companyForAdd"></param>
    /// <returns>A task representing the asynchronous operation, returning the <see cref="CompanyForGet"/>
    /// object.</returns>
    Task<CompanyForGet> AddAsync(CompanyForAdd companyForAdd);

    /// <summary>
    /// Add new companies asynchronously.
    /// </summary>
    /// <param name="companiesForAdd"></param>
    /// <returns>A task representing the asynchronous operation, returning an enumerable collection of
    /// <see cref="CompanyForGet" with ids./></returns>
    Task<(IEnumerable<CompanyForGet> companies, string companiesId)> AddCollectionAsync(IEnumerable<CompanyForAdd> companiesForAdd);

    /// <summary>
    /// Delete company asynchronously.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>A trask representing the asynchronous operation.</returns>
    Task DeleteAsync(Guid id, bool trackChanges);

    /// <summary>
    /// Update company asynchronously.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="companyForUpdate"></param>
    /// <param name="trackChanges"></param>
    /// <returns>A trask representing the asynchronous operation.</returns>
    Task UpdateAsync(Guid id, CompanyForUpdate companyForUpdate, bool trackChanges);

    /// <summary>
    /// Partially update company asynchronously.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="trackChanges"></param>
    /// <returns>A task representing the asynchronous operation, returning company for patch and company entity.</returns>
    Task<(CompanyForUpdate companyToPatch, Company company)> GetForPatchAsync(Guid id, bool trackChanges);

    /// <summary>
    /// Save changes for patch.
    /// </summary>
    /// <param name="companyToPatch"></param>
    /// <param name="company"></param>
    Task SaveChangesForPatch(CompanyForUpdate companyToPatch, Company company);
}

