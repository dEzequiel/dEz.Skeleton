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
    public async Task<IEnumerable<CompanyForGet>> GetAllByIdAsync(IEnumerable<Guid> ids)
    {
        _logger.LogInfo($"CompanyService --> GetAllByIdAsync --> Start");

        if (!ids.Any())
            throw new IdParametersBadRequestException();

        var companies = await _unitOfWork.CompanyRepository.GetAllByIdAsync(ids);

        if (companies.Count() != ids.Count())
            throw new CollectionByIdsBadRequestException();

        var result = _mapper.Map<IEnumerable<CompanyForGet>>(companies);

        _logger.LogInfo($"CompanyService --> GetAllByIdAsync --> End");

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

    ///<inheritdoc cref="ICompanyService"/>
    public async Task<CompanyForGet> AddAsync(CompanyForAdd companyForAdd)
    {
        _logger.LogInfo($"CompanyService --> AddAsync --> Start");

        var companyEntity = _mapper.Map<Company>(companyForAdd);

        _unitOfWork.CompanyRepository.AddAsync(companyEntity);
        await _unitOfWork.SaveAsync();

        var companyToReturn = _mapper.Map<CompanyForGet>(companyEntity);

        _logger.LogInfo($"CompanyService --> AddAsync --> End");

        return companyToReturn;
    }

    ///<inheritdoc cref="ICompanyService"/>
    public async Task DeleteAsync(Guid id)
    {
        _logger.LogInfo($"CompanyService --> DeleteAsync({id}) --> Start");

        var company = await _unitOfWork.CompanyRepository.GetAsync(id);

        if (company is null)
            throw new CompanyNotFoundException(id);

        _unitOfWork.CompanyRepository.DeleteAsync(company);
        await _unitOfWork.SaveAsync();

        _logger.LogInfo($"CompanyService --> DeleteAsync({id}) --> End");
    }

    ///<inheritdoc cref="IDisposable"/>
    public void Dispose()
    {
        _unitOfWork.Dispose();
    }
}