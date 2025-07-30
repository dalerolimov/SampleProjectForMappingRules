using SampleProjectForMappingRules.Application.Dtos;

namespace SampleProjectForMappingRules.Domain.Services;

public interface ISyncService
{
    void MapCompany(HubSpotCompanyDto hubspot, ParadigmCompanyDto company, Guid configId);
}