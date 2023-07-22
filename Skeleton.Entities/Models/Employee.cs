namespace Skeleton.Entities.Models;

/// <summary>
/// Employee business entity.
/// </summary>
public class Employee
{
    /// <summary>
    /// Employee Identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Employee name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Employee age.
    /// </summary>
    public int Age { get; set; }

    /// <summary>
    /// Employee position.
    /// </summary>
    public string? Position { get; set; }

    /// <summary>
    /// Attached company identifier.
    /// </summary>
    public Guid CompanyId { get; set; }

    /// <summary>
    /// Company attached to Employee.
    /// </summary>
    public Company Company { get; set; } = null!;
}