using AutoMapper;
using Skeleton.Abstraction;
using Skeleton.Service.Abstraction;

namespace Skeleton.Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly ICompanyService _companyService;
    private readonly IEmployeeService _employeeService;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="companyService"></param>
    /// <param name="employeeService"></param>
    public ServiceManager(ICompanyService companyService, IEmployeeService employeeService)
    {
        _companyService = companyService;
        _employeeService = employeeService;
    }

    public ICompanyService CompanyService => _companyService;
    public IEmployeeService EmployeeService => _employeeService;
}
