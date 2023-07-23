﻿using AutoMapper;
using Skeleton.Abstraction;
using Skeleton.Service.Abstraction;

namespace Skeleton.Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<ICompanyService> _companyService;
    private readonly Lazy<IEmployeeService> _employeeService;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="unitOfWork"></param>
    /// <param name="logger"></param>
    public ServiceManager(IUnitOfWork unitOfWork, ILoggerManager logger, IMapper mapper)
    {
        _companyService = new Lazy<ICompanyService>(() => new CompanyService(unitOfWork, logger, mapper));
        _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(unitOfWork, logger, mapper, _companyService.Value));
    }

    public ICompanyService CompanyService => _companyService.Value;
    public IEmployeeService EmployeeService => _employeeService.Value;
}