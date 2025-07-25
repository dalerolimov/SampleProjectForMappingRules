using AutoMapper;
using SampleProjectForMappingRules.Domain.Enums;
using SampleProjectForMappingRules.Domain.Repositories;

namespace SampleProjectForMappingRules.Application.Mapping;

public enum SyncDirection { HubSpotToParadigm, ParadigmToHubSpot }

public class RuleBasedConverter<TSrc, TDest> : ITypeConverter<TSrc, TDest>
    where TDest : new()
{
    private readonly IMappingRuleRepository _repo;

    public RuleBasedConverter(IMappingRuleRepository repo) => _repo = repo;

    public TDest Convert(TSrc source, TDest destination, ResolutionContext context)
    {
        destination ??= new TDest();

        var entity    = (EntityName)context.Items["entity"];
        var direction = (SyncDirection)context.Items["direction"];
        var configId  = (Guid)context.Items["configId"];

        var rules = _repo.GetRules(configId, entity);

        foreach (var rule in rules)
        {
            if (!IsAllowed(rule.MappingRule, direction))
                continue;

            var srcProp = typeof(TSrc).GetProperty(rule.PropertyName);
            var dstProp = typeof(TDest).GetProperty(rule.PropertyName);

            if (srcProp != null && dstProp != null && dstProp.CanWrite)
            {
                var value = srcProp.GetValue(source);
                dstProp.SetValue(destination, value);
            }
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
