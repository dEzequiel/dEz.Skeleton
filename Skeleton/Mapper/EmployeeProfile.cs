using AutoMapper;
using Skeleton.Entities.Models;
using Skeleton.Shared.DTOs;

namespace Skeleton.Mapper;

/// <summary>
/// AutoMapper profile for employee-related mappings.
/// </summary>
public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeForGet>();
        CreateMap<EmployeeForAdd, Employee>();
    }
}