namespace Skeleton.Entities.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a company with a specified ID is not found.
/// This exception is used to indicate that a requested company does not exist in the system.
/// </summary>
public sealed class CompanyNotFoundException : NotFoundException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CompanyNotFoundException"/> class
    /// with the provided company ID that was not found.
    /// </summary>
    /// <param name="companyId">The ID of the company that was not found.</param>
    public CompanyNotFoundException(Guid companyId) 
        : base($"Company with ID: {companyId} not found.") {}
}
