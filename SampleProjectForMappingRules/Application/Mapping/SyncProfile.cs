using AutoMapper;
using SampleProjectForMappingRules.Application.Dtos;

namespace SampleProjectForMappingRules.Application.Mapping;

public class SyncProfile : Profile
{
    public SyncProfile()
    {
        CreateMap<HubSpotCompanyDto, ParadigmCompanyDto>()
            .ConvertUsing<RuleBasedConverter<HubSpotCompanyDto, ParadigmCompanyDto>>();
    }
}