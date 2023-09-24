using AutoMapper;
using Skeleton.Abstraction;
using Skeleton.Entities.Exceptions;
using Skeleton.Entities.Exceptions.Company;
using Skeleton.Entities.Models;
using Skeleton.Service.Abstraction;
using Skeleton.Shared.DTOs;
using Skeleton.Shared.RequestFeatures;

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
    public async Task<(IEnumerable<CompanyForGet> companies, PagedListMetaData metaData)> GetAllAsync(CompanyParameters parameters, bool trackChanges)
    {
        _logger.LogInfo($"CompanyService --> GetAllAsync --> Start");

        var companies = await _unitOfWork.CompanyRepository.GetAllAsync(parameters, trackChanges);

        var result = _mapper.Map<IEnumerable<CompanyForGet>>(companies);

        _logger.LogInfo($"CompanyService --> GetAllAsync --> End");

        return (companies: result, metaData: companies.MetaData);
    }

    ///<inheritdoc cref="ICompanyService"/>
    public async Task<IEnumerable<CompanyForGet>> GetAllByIdAsync(IEnumerable<Guid> ids, bool trackChanges)
    {
        _logger.LogInfo($"CompanyService --> GetAllByIdAsync --> Start");

        if (!ids.Any())
            throw new IdParametersBadRequestException();

        var companies = await _unitOfWork.CompanyRepository.GetAllByIdAsync(ids, trackChanges);

        if (companies.Count() != ids.Count())
            throw new CollectionByIdsBadRequestException();

        var result = _mapper.Map<IEnumerable<CompanyForGet>>(companies);

        _logger.LogInfo($"CompanyService --> GetAllByIdAsync --> End");

        return result;
    }

    ///<inheritdoc cref="ICompanyService"/>
    public async Task<CompanyForGet> GetByIdAsync(Guid id, bool trackChanges)
    {
        _logger.LogInfo($"CompanyService --> GetByIdAsync({id}) --> Start");

        var company = await _unitOfWork.CompanyRepository.GetAsync(id, trackChanges);

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
    public async Task<(IEnumerable<CompanyForGet> companies, string companiesId)> AddCollectionAsync(IEnumerable<CompanyForAdd> companiesForAdd)
    {
        _logger.LogInfo($"CompanyService --> AddCollectionAsync --> Start");

        if (companiesForAdd is null)
            throw new CompanyCollectionBadRequestException();

        var companyEntities = _mapper.Map<IEnumerable<Company>>(companiesForAdd);
        foreach (var companyEntity in companyEntities)
            _unitOfWork.CompanyRepository.AddAsync(companyEntity);

        await _unitOfWork.SaveAsync();

        var companyCollectionToReturn = _mapper.Map<IEnumerable<CompanyForGet>>(companyEntities);
        var ids = string.Join(",", companyCollectionToReturn.Select(c => c.Id));

        _logger.LogInfo($"CompanyService --> AddCollectionAsync --> End");

        return (companies: companyCollectionToReturn, companiesId: ids);
    }

    ///<inheritdoc cref="ICompanyService"/>
    public async Task DeleteAsync(Guid id, bool trackChanges)
    {
        _logger.LogInfo($"CompanyService --> DeleteAsync({id}) --> Start");

        var company = await _unitOfWork.CompanyRepository.GetAsync(id, trackChanges);

        if (company is null)
            throw new CompanyNotFoundException(id);

        _unitOfWork.CompanyRepository.DeleteAsync(company);
        await _unitOfWork.SaveAsync();

        _logger.LogInfo($"CompanyService --> DeleteAsync({id}) --> End");
    }

    ///<inheritdoc cref="ICompanyService"/>
    public async Task UpdateAsync(Guid id, CompanyForUpdate companyForUpdate, bool trackChanges)
    {
        _logger.LogInfo($"CompanyService --> UpdateAsync({id}) --> Start");

        var company = await _unitOfWork.CompanyRepository.GetAsync(id, trackChanges);

        if (company is null)
            throw new CompanyNotFoundException(id);

        _mapper.Map(companyForUpdate, company);
        await _unitOfWork.SaveAsync();

        _logger.LogInfo($"CompanyService --> UpdateAsync({id}) --> End");
    }

    ///<inheritdoc cref="ICompanyService"/>
    public async Task<(CompanyForUpdate companyToPatch, Company company)> GetForPatchAsync(Guid id, bool trackChanges)
    {
        _logger.LogInfo($"CompanyService --> GetForPatchAsync({id}) --> Start");

        var company = await _unitOfWork.CompanyRepository.GetAsync(id, trackChanges);
        if (company is null)
            throw new CompanyNotFoundException(id);

        var companyToPatch = _mapper.Map<CompanyForUpdate>(company);

        _logger.LogInfo($"CompanyService --> GetForPatchAsync({id}) --> End");

        return (companyToPatch, company);
    }

    ///<inheritdoc cref="ICompanyService"/>
    public async Task SaveChangesForPatch(CompanyForUpdate companyToPatch, Company company)
    {
        _logger.LogInfo($"CompanyService --> SaveChangesForPatch --> Start");

        _mapper.Map(companyToPatch, company);

        _logger.LogInfo($"CompanyService --> SaveChangesForPatch --> End");

        await _unitOfWork.SaveAsync();
    }

    ///<inheritdoc cref="IDisposable"/>
    public void Dispose()
    {
        _unitOfWork.Dispose();
    }

}