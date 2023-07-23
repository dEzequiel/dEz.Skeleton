namespace Skeleton.Entities.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a employee with a specified ID is not found.
/// This exception is used to indicate that a requested employee does not exist in the system.
/// </summary>
public sealed class EmployeeNotFoundException : NotFoundException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EmployeeNotFoundException"/> class
    /// with the provided employee ID that was not found.
    /// </summary>
    /// <param name="employeeId">The ID of the employee that was not found.</param>
    public EmployeeNotFoundException(Guid employeeId) 
        : base($"Employee with ID: {employeeId} not found.")
    {
    }
}