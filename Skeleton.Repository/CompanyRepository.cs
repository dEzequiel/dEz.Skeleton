﻿using Microsoft.EntityFrameworkCore;
using Skeleton.Abstraction.Repository;
using Skeleton.Entities.Models;
using Skeleton.Shared.RequestFeatures;

namespace Skeleton.Repository;

public sealed class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="repositoryContext"></param>
    public CompanyRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    ///<inheritdoc cref="ICompanyRepository"/>
    public async Task<PagedList<Company>> GetAllAsync(CompanyParameters parameters, bool trackChanges)
    {
        var companies = await FindAll(trackChanges).ToListAsync();
        return PagedList<Company>.ToPagedList(companies, parameters.PageNumber, parameters.PageSize);
    }

    ///<inheritdoc cref="ICompanyRepository"/>
    public async Task<IEnumerable<Company>> GetAllByIdAsync(IEnumerable<Guid> ids, bool trackChanges) =>
        await FindByCondition(c => ids.Contains(c.Id), trackChanges).ToListAsync();

    ///<inheritdoc cref="ICompanyRepository"/>
    public async Task<Company?> GetAsync(Guid id, bool trackChanges) =>
        await FindByCondition(c => c.Id.Equals(id), trackChanges)
            .SingleOrDefaultAsync();

    ///<inheritdoc cref="ICompanyRepository"/>
    public void AddAsync(Company company) =>
        Create(company);

    ///<inheritdoc cref="ICompanyRepository"/>
    public void DeleteAsync(Company company) =>
        Delete(company);
}