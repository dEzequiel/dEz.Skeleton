using Skeleton.Entities.Models;
using Skeleton.Shared.DTOs;

namespace Skeleton.Service.Abstraction;

public interface ICompanyService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="trackChanges"></param>
    /// <returns></returns>
    Task<IEnumerable<CompanyForGet>> GetAllAsync();
}