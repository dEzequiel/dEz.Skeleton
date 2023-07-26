using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Skeleton.Service.Abstraction;
using Skeleton.Shared.DTOs;

namespace Skeleton.Presentation.Controllers;

[Route("api/company/{companyId}/employee")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IServiceManager _service;

    public EmployeeController(IServiceManager service) => _service = service;
    
    [HttpGet("{id:guid}", Name = "GetEmployeeForCompany")] 
    [ProducesResponseType(typeof(EmployeeForGet), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetEmployee(Guid id, Guid companyId)
    {
        var company = await _service.EmployeeService.GetByIdAsync(id, companyId);
        return Ok(company);
    }
    
    [HttpGet] 
    [ProducesResponseType(typeof(IEnumerable<EmployeeForGet>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllEmployees(Guid companyId)
    {
        var company = await _service.EmployeeService.GetAllAsync(companyId);
        return Ok(company);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> AddAsync(Guid companyId, [FromBody] EmployeeForAdd employee)
    {
        var createdEmployee = await _service.EmployeeService.AddAsync(companyId, employee);
        
        return CreatedAtRoute("GetEmployeeForCompany", new
        {
            companyId, id = createdEmployee.Id, 
        }, createdEmployee);
    }

}