namespace Skeleton.Entities.Exceptions;

public sealed class CompanyNotFoundException : NotFoundException
{
    public CompanyNotFoundException(Guid companyId) 
        : base($"Company with ID: {companyId} not found.") {}
}