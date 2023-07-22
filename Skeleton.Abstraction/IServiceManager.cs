using Skeleton.Abstraction.Service;

namespace Skeleton.Abstraction;

public interface IServiceManager
{
    ICompanyService CompanyService { get; }
    IEmployeeService EmployeeService { get; }
}