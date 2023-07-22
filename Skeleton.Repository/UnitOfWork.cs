using Skeleton.Abstraction;
using Skeleton.Abstraction.Repository;

namespace Skeleton.Repository;

public class UnitOfWork : IUnitOfWork
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<ICompanyRepository> _companyRepository;
    private readonly Lazy<IEmployeeRepository> _employeeRepository;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="repositoryContext"></param>
    /// <param name="companyRepository"></param>
    /// <param name="employeeRepository"></param>
    public UnitOfWork(RepositoryContext repositoryContext, Lazy<ICompanyRepository> companyRepository, Lazy<IEmployeeRepository> employeeRepository)
    {
        _repositoryContext = repositoryContext;
        _companyRepository = new Lazy<ICompanyRepository>(() => new
            CompanyRepository(repositoryContext));
        _employeeRepository = new Lazy<IEmployeeRepository>(() => new
            EmployeeRepository(repositoryContext));
    }

    public ICompanyRepository CompanyRepository => _companyRepository.Value;
    public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;

    ///<inheritdoc cref="IUnitOfWork"/>
    public async void Save() => await _repositoryContext.SaveChangesAsync();
}