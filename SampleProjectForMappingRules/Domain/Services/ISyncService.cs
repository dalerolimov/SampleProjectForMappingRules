using SampleProjectForMappingRules.Application.Dtos;

namespace SampleProjectForMappingRules.Domain.Services;

public interface ISyncService
{
    ParadigmCompanyDto MapCompany(HubSpotCompanyDto hubspot, Guid configId);
}