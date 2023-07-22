using Skeleton.Abstraction;
using Skeleton.Abstraction.Service;

namespace Skeleton.Service;

public sealed class EmployeeService : IEmployeeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILoggerManager _logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="unitOfWork"></param>
    /// <param name="logger"></param>
    public EmployeeService(IUnitOfWork unitOfWork, ILoggerManager logger)
    {
        _unitOfWork = unitOfWork;
        _logger = logger;
    }
}