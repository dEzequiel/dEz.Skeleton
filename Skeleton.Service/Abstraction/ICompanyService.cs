using Skeleton.Entities.Models;
using Skeleton.Shared.DTOs;

namespace Skeleton.Service.Abstraction;

/// <summary>
/// Service interface for company-related operations.
/// </summary>
public interface ICompanyService
{
    /// <summary>
    /// Gets all companies asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, returning an enumerable collection of
    /// <see cref="CompanyForGet"/>.</returns>
    Task<IEnumerable<CompanyForGet>> GetAllAsync();

    /// <summary>
    /// Gets a company by its ID asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the company.</param>
    /// <returns>A task representing the asynchronous operation, returning the <see cref="CompanyForGet"/>
    /// object or null if not found.</returns>
    Task<CompanyForGet> GetByIdAsync(Guid id);

    /// <summary>
    /// Add new company asynchronously.
    /// </summary>
    /// <param name="companyForAdd"></param>
    /// <returns>A task representing the asynchronous operation, returning the <see cref="CompanyForGet"/>
    /// object.</returns>
    Task<CompanyForGet> AddAsync(CompanyForAdd companyForAdd);
}

