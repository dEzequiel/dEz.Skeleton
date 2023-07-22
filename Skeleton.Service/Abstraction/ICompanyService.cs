using Skeleton.Entities.Models;
using Skeleton.Shared.DTOs;

namespace Skeleton.Service.Abstraction;

public interface ICompanyService
{
    /// <summary>
    /// Get all Companies.
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<CompanyForGet>> GetAllAsync();

    /// <summary>
    /// Get Company by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<CompanyForGet> GetByIdAsync(Guid id);
}