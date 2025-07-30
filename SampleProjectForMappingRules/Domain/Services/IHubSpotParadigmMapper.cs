using SampleProjectForMappingRules.Application.Dtos;
using SampleProjectForMappingRules.Domain.Entities;
using SampleProjectForMappingRules.Domain.Enums;

namespace SampleProjectForMappingRules.Domain.Services;

public interface IHubSpotParadigmMapper
{
    void Map<TSrc, TDest>(
        TSrc source,
        TDest destination,
        EntityName entity,
        SyncDirection direction,
        IEnumerable<HubSpotParadigmPropertyMappingRule> rules);
}