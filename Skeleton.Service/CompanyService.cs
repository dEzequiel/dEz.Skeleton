using Skeleton.Abstraction;
using Skeleton.Entities.Models;
using Skeleton.Service.Abstraction;

namespace Skeleton.Service;

public sealed class CompanyService : ICompanyService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILoggerManager _logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="unitOfWork"></param>
    /// <param name="logger"></param>
    public CompanyService(IUnitOfWork unitOfWork, ILoggerManager logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
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