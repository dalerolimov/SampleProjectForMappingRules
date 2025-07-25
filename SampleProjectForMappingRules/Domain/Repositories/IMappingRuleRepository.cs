using SampleProjectForMappingRules.Domain.Entities;
using SampleProjectForMappingRules.Domain.Enums;

namespace SampleProjectForMappingRules.Domain.Repositories;

public interface IMappingRuleRepository
{
    IReadOnlyList<HubSpotParadigmPropertyMappingRule> GetRules(Guid configId, EntityName entity);
}