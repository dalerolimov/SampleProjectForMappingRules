using SampleProjectForMappingRules.Application.Dtos;
using SampleProjectForMappingRules.Domain.Enums;
using SampleProjectForMappingRules.Domain.Repositories;
using SampleProjectForMappingRules.Domain.Services;

namespace SampleProjectForMappingRules.Application.Mapping;

public class HubSpotParadigmMapper : IHubSpotParadigmMapper
{
    private readonly IMappingRuleRepository _repo;

    public HubSpotParadigmMapper(IMappingRuleRepository repo)
    {
        _repo = repo;
    }

    public TDest Map<TSrc, TDest>(
        TSrc source, 
        TDest destination,
        EntityName entity, 
        SyncDirection direction, 
        Guid configId) 
        where TDest : new()
    {
        var rules = _repo.GetRules(configId, entity);

        foreach (var rule in rules)
        {
            if (!IsAllowed(rule.MappingRule, direction))
                continue;

            var srcProp = typeof(TSrc).GetPropertyByName(rule.PropertyName);
            var dstProp = typeof(TDest).GetPropertyByName(rule.PropertyName);

            if (srcProp == null || dstProp == null || !dstProp.CanWrite)
                throw new ArgumentException("Property not found or not writable: " + rule.PropertyName);

            var value = srcProp.GetValue(source);
            dstProp.SetValue(destination, value);
        }

        return destination;
    }

    private static bool IsAllowed(HubSpotParadigmMappingRule rule, SyncDirection dir) =>
        rule switch
        {
            HubSpotParadigmMappingRule.TwoWay => true,
            HubSpotParadigmMappingRule.HubSpotToParadigm => dir == SyncDirection.HubSpotToParadigm,
            HubSpotParadigmMappingRule.ParadigmToHubSpot => dir == SyncDirection.ParadigmToHubSpot,
            _ => false
        };
}