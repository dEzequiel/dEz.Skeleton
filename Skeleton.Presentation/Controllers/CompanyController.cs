﻿using System.Collections;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skeleton.Entities.Models;
using Skeleton.Service.Abstraction;
using Skeleton.Shared.DTOs;

namespace Skeleton.Presentation.Controllers;

[Route("api/company")]
[ApiController]
public class CompanyController : ControllerBase
{
    private readonly IServiceManager _service;

    public CompanyController(IServiceManager service) => _service = service;

    [HttpGet, ProducesResponseType(typeof(IEnumerable<Company>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCompanies()
    {
        var companies = await _service.CompanyService.GetAllAsync();
        return Ok(companies);
    }
    
    [HttpGet("{id:guid}", Name = "GetCompany")] 
    [ProducesResponseType(typeof(CompanyForGet), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCompany(Guid id)
    {
        var company = await _service.CompanyService.GetByIdAsync(id);
        return Ok(company);
    }

    [HttpGet("collection/({ids})", Name = "GetCompanyCollection")]
    [ProducesResponseType(typeof(IEnumerable<CompanyForGet>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetCompaniesById(IEnumerable<Guid> ids)
    {
        var companies = await _service.CompanyService.GetAllByIdAsync(ids);
        return Ok(companies);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> AddAsync([FromBody] CompanyForAdd company)
    {
        var createdCompany = await _service.CompanyService.AddAsync(company);
        
        return CreatedAtRoute("GetCompany", new
        {
            id = createdCompany.Id
        }, createdCompany);
    }
}