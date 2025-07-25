using SampleProjectForMappingRules.Application.Dtos;
using SampleProjectForMappingRules.Domain.Enums;

namespace SampleProjectForMappingRules.Domain.Services;

public interface IHubSpotParadigmMapper
{
    TDest Map<TSrc, TDest>(TSrc source, EntityName entity, SyncDirection direction, Guid configId)
        where TDest : new();
}