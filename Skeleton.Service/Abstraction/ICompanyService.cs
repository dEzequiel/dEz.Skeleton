using Skeleton.Entities.Models;

namespace Skeleton.Service.Abstraction;

public interface ICompanyService
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="trackChanges"></param>
    /// <returns></returns>
    Task<IEnumerable<Company>> GetAllAsync();
}