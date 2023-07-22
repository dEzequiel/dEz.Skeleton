using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skeleton.Entities.Models;
using Skeleton.Service.Abstraction;

namespace Skeleton.Presentation.Controllers;

[Route("api/company")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly IServiceManager _service;

    public CompanyController(IServiceManager service) => _service = service;

    [HttpGet, ProducesResponseType(typeof(IEnumerable<Company>), StatusCodes.Status200OK)]
    public IActionResult GetCompanies()
    {
        try
        {
            var companies = _service.CompanyService.GetAllAsync();

            return Ok(companies);
        }
        catch
        {
            return StatusCode(500, "Internal server error");
        }
    }
}