using AutoMapper;
using Skeleton.Abstraction;
using Skeleton.Entities.Exceptions;
using Skeleton.Service.Abstraction;
using Skeleton.Shared.DTOs;

namespace Skeleton.Service;

/// <summary>
/// Service implementation for employee-related operations.
/// </summary>
public sealed class EmployeeService : IEmployeeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;
    private readonly ICompanyService _companyService;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="unitOfWork"></param>
    /// <param name="logger"></param>
    /// <param name="mapper"></param>
    /// <param name="companyService"></param>
    public EmployeeService(IUnitOfWork unitOfWork, ILoggerManager logger, IMapper mapper, ICompanyService companyService)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
        _companyService = companyService;
    }

    ///<inheritdoc cref="IEmployeeService"/>
    public async Task<IEnumerable<EmployeeForGet>> GetAllAsync(Guid companyId)
    {
        _logger.LogInfo($"EmployeeService --> GetAllAsync --> Start");

        var company = await _companyService.GetByIdAsync(companyId);
        
        var employees = await _unitOfWork.EmployeeRepository.GetAllAsync(companyId);

        var result = _mapper.Map<IEnumerable<EmployeeForGet>>(employees);
        
        _logger.LogInfo($"EmployeeService --> GetAllAsync --> End");

        return result;
    }

    ///<inheritdoc cref="IEmployeeService"/>
    public async Task<EmployeeForGet> GetByIdAsync(Guid id, Guid companyId)
    {
        _logger.LogInfo($"EmployeeService --> GetByIdAsync(CompanyId({companyId} - EmployeeId({id}))) --> Start");

        var company = await _companyService.GetByIdAsync(companyId);

        var employee = await _unitOfWork.EmployeeRepository.GetAsync(id, companyId);

        if (employee is null)
            throw new EmployeeNotFoundException(id);
        
        var result = _mapper.Map<EmployeeForGet>(employee);
        
        _logger.LogInfo($"EmployeeService --> GetByIdAsync(CompanyId({companyId} - EmployeeId({id}))) --> End");

        return result;    }
}