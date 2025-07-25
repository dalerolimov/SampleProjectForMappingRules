using SampleProjectForMappingRules.Application.Dtos;
using SampleProjectForMappingRules.Application.Mapping;
using SampleProjectForMappingRules.Domain.Enums;
using SampleProjectForMappingRules.Domain.Services;

namespace SampleProjectForMappingRules.Application.Services;

public class SyncService : ISyncService
{
    private readonly IHubSpotParadigmMapper _mapper;

    public SyncService(IHubSpotParadigmMapper mapper)
    {
        _mapper = mapper;
    }
    
    public ParadigmCompanyDto MapCompany(HubSpotCompanyDto hubspot, Guid configId)
    {
        return _mapper.Map<HubSpotCompanyDto, ParadigmCompanyDto>(
            hubspot,
            EntityName.Company,
            SyncDirection.HubSpotToParadigm,
            configId);
    }
}