using Skeleton.Entities.Models;

namespace Skeleton.Abstraction.Repository;

/// <summary>
/// Repository interface for employee-related operations.
/// </summary>
public interface IEmployeeRepository
{
    /// <summary>
    /// Asynchronously retrieves all employees.
    /// </summary>
    /// <param name="companyId">The unique identifier of the company to retrieve employees.</param>
    /// <returns>A task representing the asynchronous operation, returning an enumerable collection of
    /// <see cref="Employee"/>.</returns>
    Task<IEnumerable<Employee>> GetAllAsync(Guid companyId);

    /// <summary>
    /// Asynchronously retrieves a employee by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the employee to retrieve.</param>
    /// <param name="companyId">The unique identifier of the company related to employee.</param>
    /// <returns>
    /// A task representing the asynchronous operation, returning the <see cref="Employee"/> object
    /// with the specified ID, or null if the company is not found.
    /// </returns>
    Task<Employee?> GetAsync(Guid id, Guid companyId);
}