using SampleProjectForMappingRules.Domain.Entities;
using SampleProjectForMappingRules.Domain.Enums;
using SampleProjectForMappingRules.Domain.Repositories;

namespace SampleProjectForMappingRules.Infrastructure.Repositories;

public class MappingRuleRepository : IMappingRuleRepository
{
    public IReadOnlyList<HubSpotParadigmPropertyMappingRule> GetRules(Guid configId, EntityName entity)
    {
        return new List<HubSpotParadigmPropertyMappingRule>
        {
            new()
            {
                EntityName = entity,
                HubSpotParadigmSyncConfigurationId = configId,
                Id = Guid.Parse("7CECEC31-FFF7-4452-BC65-FD30EB379091"),
                MappingRule = HubSpotParadigmMappingRule.TwoWay,
                PropertyName = "Address"
            },
            new()
            {
                EntityName = entity,
                HubSpotParadigmSyncConfigurationId = configId,
                Id = Guid.Parse("5DD8E1DF-FA27-4888-A34D-ED423035A599"),
                MappingRule = HubSpotParadigmMappingRule.ParadigmToHubSpot,
                PropertyName = "Name"
            },
            new()
            {
                EntityName = entity,
                HubSpotParadigmSyncConfigurationId = configId,
                Id = Guid.Parse("E8B8F539-057F-412E-961E-AD80F36B3C63"),
                MappingRule = HubSpotParadigmMappingRule.NotMap,
                PropertyName = "Phone"
            }
        };
    }
}