using SampleProjectForMappingRules.Domain.Enums;

namespace SampleProjectForMappingRules.Domain.Entities;

public class HubSpotParadigmPropertyMappingRule
{
    public Guid Id { get; set; }
    public Guid HubSpotParadigmSyncConfigurationId { get; set; }
    public EntityName EntityName { get; set; }
    public string PropertyName { get; set; }
    public HubSpotParadigmMappingRule MappingRule { get; set; }
}