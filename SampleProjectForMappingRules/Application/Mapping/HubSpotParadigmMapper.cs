using System.Reflection;
using SampleProjectForMappingRules.Application.Dtos;
using SampleProjectForMappingRules.Domain.Entities;
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

    public void Map<TSrc, TDest>(
        TSrc source,
        TDest destination,
        EntityName entity,
        SyncDirection direction,
        IEnumerable<HubSpotParadigmPropertyMappingRule> rules)
    {
        foreach (var rule in rules)
        {
            if (!IsAllowed(rule.MappingRule, direction))
                continue;

            PropertyInfo? srcProp = null;
            PropertyInfo? dstProp = null;
            if (source is IMappingEntityDto srcDto)
                srcProp = srcDto.GetPropertyByName(srcDto, rule.PropertyName);
            if (destination is IMappingEntityDto destDto)
                dstProp = destDto.GetPropertyByName(destDto, rule.PropertyName);

            if (srcProp == null || dstProp == null || !dstProp.CanWrite)
                throw new ArgumentException("Property not found or not writable: " + rule.PropertyName);

            var value = srcProp.GetValue(source);
            dstProp.SetValue(destination, value);
        }
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