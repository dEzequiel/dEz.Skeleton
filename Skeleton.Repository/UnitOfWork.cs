using Skeleton.Abstraction;
using Skeleton.Abstraction.Repository;

namespace Skeleton.Repository;

public class UnitOfWork : IUnitOfWork
{
    private bool _disposedValue;
    private readonly RepositoryContext _repositoryContext;
    private readonly ICompanyRepository _companyRepository;
    private readonly IEmployeeRepository _employeeRepository;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="repositoryContext"></param>
    /// <param name="companyRepository"></param>
    /// <param name="employeeRepository"></param>
    public UnitOfWork(RepositoryContext repositoryContext, ICompanyRepository companyRepository, IEmployeeRepository employeeRepository)
    {
        _repositoryContext = repositoryContext;
        _companyRepository = companyRepository;
        _employeeRepository = employeeRepository;
    }

    public ICompanyRepository CompanyRepository => _companyRepository;
    public IEmployeeRepository EmployeeRepository => _employeeRepository;

    ///<inheritdoc cref="IUnitOfWork"/>
    public async Task SaveAsync()
    {
        await _repositoryContext.SaveChangesAsync();
    }
    
    ///<inheritdoc cref="IDisposable"/>
    public void Dispose()
    {
        Dispose(true);
    }

    private void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _repositoryContext.Dispose();
            }

            _disposedValue = true;
        }
    }
}