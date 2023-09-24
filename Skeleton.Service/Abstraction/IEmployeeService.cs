using Skeleton.Shared.DTOs;

namespace Skeleton.Service.Abstraction;

/// <summary>
/// Service interface for employee-related operations.
/// </summary>
public interface IEmployeeService : IServiceBase
{
    /// <summary>
    /// Get all employees by company ID asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, returning an enumerable collection of
    /// <see cref="EmployeeForGet"/>.</returns>
    Task<IEnumerable<EmployeeForGet>> GetAllAsync(Guid companyId, bool trackChanges);

    /// <summary>
    /// Gets employee by its ID asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the employee.</param>
    /// <param name="companyId">The unique identifier of the company.</param>
    /// <returns>A task representing the asynchronous operation, returning the <see cref="EmployeeForGet"/>
    /// object or null if not found.</returns>
    Task<EmployeeForGet> GetByIdAsync(Guid id, Guid companyId, bool trackChanges);

    /// <summary>
    /// Add new employee asynchronously.
    /// </summary>
    /// <param name="employeeForAdd"></param>
    /// <param name="companyId"></param>
    /// <returns>A task representing the asynchronous operation, returning the <see cref="EmployeeForGet"/>
    /// object.</returns>
    Task<EmployeeForGet> AddAsync(Guid companyId, EmployeeForAdd employeeForAdd, bool trackChanges);
}