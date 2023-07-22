using AutoMapper;
using Skeleton.Entities.Models;
using Skeleton.Shared.DTOs;

namespace Skeleton.Mapper;

public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<Company, CompanyForGet>()
            .ForCtorParam("FullAddress",
                opt => opt.MapFrom(x => 
                    string.Join(' ', x.Address, x.Country)));
    }
}