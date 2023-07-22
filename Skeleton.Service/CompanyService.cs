using AutoMapper;
using Skeleton.Abstraction;
using Skeleton.Entities.Exceptions;
using Skeleton.Entities.Models;
using Skeleton.Service.Abstraction;
using Skeleton.Shared.DTOs;

namespace Skeleton.Service;

public sealed class CompanyService : ICompanyService
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
    public CompanyService(IUnitOfWork unitOfWork, ILoggerManager logger, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
        _mapper = mapper;
    }

    ///<inheritdoc cref="ICompanyService"/>
    public async Task<IEnumerable<CompanyForGet>> GetAllAsync()
    {
        _logger.LogInfo($"CompanyService --> GetAllAsync --> Start");

        var companies = await _unitOfWork.CompanyRepository.GetAllAsync();

        var result = _mapper.Map<IEnumerable<CompanyForGet>>(companies);

        _logger.LogInfo($"CompanyService --> GetAllAsync --> End");

        return result;
    }

    ///<inheritdoc cref="ICompanyService"/>
    public async Task<CompanyForGet> GetByIdAsync(Guid id)
    {
        _logger.LogInfo($"CompanyService --> GetByIdAsync({id}) --> Start");

        var company = await _unitOfWork.CompanyRepository.GetAsync(id);

        if (company is null)
            throw new CompanyNotFoundException(id);

        var result = _mapper.Map<CompanyForGet>(company);

        _logger.LogInfo($"CompanyService --> GetByIdAsync({id}) --> End");

        return result;
    }
}