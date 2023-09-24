using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skeleton.Abstraction;
using Skeleton.Entities.Models;
using Skeleton.Service.Abstraction;
using Skeleton.Shared.DTOs;

namespace Skeleton.Presentation.Controllers;

[Route("api/company")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly IServiceManager _service;
    private readonly ILoggerManager _logger;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="service"></param>
    /// <param name="logger"></param>
    public CompanyController(IServiceManager service, ILoggerManager logger)
    {
        _service = service;
        _logger = logger;
    }

    /// <summary>
    /// Get all companies.
    /// </summary>
    /// <returns>Collection of companies.</returns>
    [HttpGet, ProducesResponseType(typeof(IEnumerable<Company>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCompanies()
    {
        _logger.LogInfo($"CompanyController --> GetCompanies --> Start");
        var companies = await _service.CompanyService.GetAllAsync(trackChanges: false);
        _logger.LogInfo($"CompanyController --> GetCompanies --> End");
        return Ok(companies);
    }

    /// <summary>
    /// Get company by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Company with the same passed id.</returns>
    [HttpGet("{id:guid}", Name = "GetCompany")]
    [ProducesResponseType(typeof(CompanyForGet), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCompany(Guid id)
    {
        _logger.LogInfo($"CompanyController --> GetCompany({id}) --> Start");
        var company = await _service.CompanyService.GetByIdAsync(id, trackChanges: false);
        _logger.LogInfo($"CompanyController --> GetCompany({id}) --> End");
        return Ok(company);
    }

    /// <summary>
    /// Get companies by ids.
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>Collection of comapnies with the passed ids.</returns>
    [HttpGet("collection/({ids})", Name = "GetCompanyCollection")]
    [ProducesResponseType(typeof(IEnumerable<CompanyForGet>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetCompaniesById(IEnumerable<Guid> ids)
    {
        _logger.LogInfo($"CompanyController --> GetCompanies --> Start");
        var companies = await _service.CompanyService.GetAllByIdAsync(ids, trackChanges: false);
        _logger.LogInfo($"CompanyController --> GetCompanies --> End");
        return Ok(companies);
    }

    /// <summary>
    /// Create a new company.
    /// </summary>
    /// <param name="company"></param>
    /// <returns>Company.</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> AddAsync([FromBody] CompanyForAdd company)
    {
        _logger.LogInfo($"CompanyController --> AddAsync --> Start");
        var createdCompany = await _service.CompanyService.AddAsync(company);
        _logger.LogInfo($"CompanyController --> AddAsync --> End");
        return CreatedAtRoute("GetCompany", new
        {
            id = createdCompany.Id
        }, createdCompany);
    }

    /// <summary>
    /// Delete company by id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content.</returns>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        _logger.LogInfo($"CompanyController --> DeleteAsync({id}) --> Start");
        await _service.CompanyService.DeleteAsync(id, trackChanges: false);
        _logger.LogInfo($"CompanyController --> DeleteAsync({id}) --> End");
        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] CompanyForUpdate company)
    {
        _logger.LogInfo($"CompanyController --> UpdateAsync({id}) --> Start");
        await _service.CompanyService.UpdateAsync(id, company, trackChanges: true);
        _logger.LogInfo($"CompanyController --> UpdateAsync({id}) --> End");
        return NoContent();
    }
}