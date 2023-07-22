using AutoMapper;
using Skeleton.Abstraction;
using Skeleton.Entities.Models;
using Skeleton.Service.Abstraction;

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
    public async Task<IEnumerable<Company>> GetAllAsync()
    {
        _logger.LogInfo($"CompanyService --> GetAllAsync --> Start");

        var companies = await _unitOfWork.CompanyRepository.GetAllAsync();

        _logger.LogInfo($"CompanyService --> GetAllAsync --> End");

        return companies;
    }
}