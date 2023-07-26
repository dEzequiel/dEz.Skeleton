namespace Skeleton.Shared.DTOs;

/// <summary>
/// DTO for retrieving employee.
/// </summary>
/// <param name="Id"></param>
/// <param name="Name"></param>
/// <param name="Age"></param>
/// <param name="Position"></param>
/// <param name="CompanyId"></param>
public record EmployeeForGet(Guid Id, string Name, int Age, string? Position, Guid CompanyId);
    
/// <summary>
/// DTO for inserting employee
/// </summary>
/// <param name="Name"></param>
/// <param name="Age"></param>
/// <param name="Position"></param>
/// <param name="CompanyId"></param>
public record EmployeeForAdd(string Name, int Age, string? Position);