namespace Skeleton.Shared.DTOs;

/// <summary>
/// DTO for retrieving Company.
/// </summary>
/// <param name="Id"></param>
/// <param name="Name"></param>
/// <param name="FullAddress"></param>
public record CompanyForGet(Guid Id, string Name, string FullAddress);

/// <summary>
/// DTO for inserting Company.
/// </summary>
/// <param name="Name"></param>
/// <param name="Address"></param>
/// <param name="Country"></param>
public record CompanyForAdd(string Name, string Address, string Country, IEnumerable<EmployeeForAdd>? Employees);

/// <summary>
/// DTO for updating Company.
/// </summary>
/// <param name="Name"></param>
/// <param name="Address"></param>
/// <param name="Country"></param>
public record CompanyForUpdate(string Name, string Address, string Country);