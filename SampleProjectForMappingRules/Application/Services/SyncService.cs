using AutoMapper;
using SampleProjectForMappingRules.Application.Dtos;
using SampleProjectForMappingRules.Application.Mapping;
using SampleProjectForMappingRules.Domain.Enums;
using SampleProjectForMappingRules.Domain.Services;

namespace SampleProjectForMappingRules.Application.Services;

public class SyncService : ISyncService
{
    private readonly IMapper _mapper;

    public SyncService(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public ParadigmCompanyDto MapCompany(HubSpotCompanyDto hubspot, Guid configId)
    {
        return _mapper.Map<ParadigmCompanyDto>(hubspot, opt =>
        {
            opt.Items["entity"] = EntityName.Company;
            opt.Items["direction"] = SyncDirection.HubSpotToParadigm;
            opt.Items["configId"] = configId;
        });
    }
}