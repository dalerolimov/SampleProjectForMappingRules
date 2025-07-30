using SampleProjectForMappingRules.Application.Dtos;
using SampleProjectForMappingRules.Application.Mapping;
using SampleProjectForMappingRules.Domain.Enums;
using SampleProjectForMappingRules.Domain.Repositories;
using SampleProjectForMappingRules.Domain.Services;

namespace SampleProjectForMappingRules.Application.Services;

public class SyncService : ISyncService
{
    private readonly IMappingRuleRepository _repository;
    private readonly IHubSpotParadigmMapper _mapper;

    public SyncService(IMappingRuleRepository repository, IHubSpotParadigmMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public void MapCompany(HubSpotCompanyDto hubspot, ParadigmCompanyDto company, Guid configId)
    {
        var rules = _repository.GetRules(Guid.NewGuid(), EntityName.Company);
        _mapper.Map(hubspot, company, EntityName.Company, SyncDirection.ParadigmToHubSpot, rules);
    }
}