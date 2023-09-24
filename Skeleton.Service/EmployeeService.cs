using AutoMapper;
using Skeleton.Abstraction;
using Skeleton.Entities.Exceptions;
using Skeleton.Entities.Models;
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

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="unitOfWork"></param>
    /// <param name="logger"></param>
    /// <param name="mapper"></param>
    public EmployeeService(IUnitOfWork unitOfWork, ILoggerManager logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    ///<inheritdoc cref="IEmployeeService"/>
    public async Task<IEnumerable<EmployeeForGet>> GetAllAsync(Guid companyId, bool trackChanges)
    {
        _logger.LogInfo($"EmployeeService --> GetAllAsync --> Start");

        var company = await _unitOfWork.CompanyRepository.GetAsync(companyId, trackChanges);

        if (company is null)
            throw new CompanyNotFoundException(companyId);

        var employees = await _unitOfWork.EmployeeRepository.GetAllAsync(companyId);

        var result = _mapper.Map<IEnumerable<EmployeeForGet>>(employees);

        _logger.LogInfo($"EmployeeService --> GetAllAsync --> End");

        return result;
    }

    ///<inheritdoc cref="IEmployeeService"/>
    public async Task<EmployeeForGet> GetByIdAsync(Guid id, Guid companyId, bool trackChanges)
    {
        _logger.LogInfo($"EmployeeService --> GetByIdAsync(CompanyId({companyId} - EmployeeId({id}))) --> Start");

        var company = await _unitOfWork.CompanyRepository.GetAsync(companyId, trackChanges);

        if (company is null)
            throw new CompanyNotFoundException(companyId);

        var employee = await _unitOfWork.EmployeeRepository.GetAsync(id, companyId);

        if (employee is null)
            throw new EmployeeNotFoundException(id);

        var result = _mapper.Map<EmployeeForGet>(employee);

        _logger.LogInfo($"EmployeeService --> GetByIdAsync(CompanyId({companyId} - EmployeeId({id}))) --> End");

        return result;
    }

    ///<inheritdoc cref="IEmployeeService"/>
    public async Task<EmployeeForGet> AddAsync(Guid companyId, EmployeeForAdd employeeForAdd, bool trackChanges)
    {
        _logger.LogInfo($"EmployeeService --> AddAsync --> Start");

        var company = await _unitOfWork.CompanyRepository.GetAsync(companyId, trackChanges);

        if (company is null)
            throw new CompanyNotFoundException(companyId);

        var employeeEntity = _mapper.Map<Employee>(employeeForAdd);

        _unitOfWork.EmployeeRepository.Add(companyId, employeeEntity);
        await _unitOfWork.SaveAsync();

        var employeeToReturn = _mapper.Map<EmployeeForGet>(employeeEntity);

        _logger.LogInfo($"EmployeeService --> AddAsync --> End");

        return employeeToReturn;
    }

    ///<inheritdoc cref="IDisposable"/>
    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}