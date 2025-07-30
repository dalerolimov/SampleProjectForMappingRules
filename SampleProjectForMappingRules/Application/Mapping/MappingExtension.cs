using System.Reflection;
using SampleProjectForMappingRules.Application.Dtos;

namespace SampleProjectForMappingRules.Application.Mapping;

public static class MappingExtension
{
    public static PropertyInfo? GetPropertyByName(this ParadigmCompanyDto companyDto, string propertyName)
    {
        switch (propertyName)
        {
            case nameof(CompanyTrackingData.Name):
                return companyDto.GetType().GetProperty(nameof(ParadigmCompanyDto.StrCompanyName));
            case nameof(CompanyTrackingData.Address):
                return companyDto.GetType().GetProperty(nameof(ParadigmCompanyDto.Address));
            case nameof(CompanyTrackingData.City):
                return companyDto.GetType().GetProperty(nameof(ParadigmCompanyDto.City));
            default:
                return null;
        }
    }
    
    public static PropertyInfo? GetPropertyByName(this HubSpotCompanyDto companyDto, string propertyName)
    {
        switch (propertyName)
        {
            case nameof(CompanyTrackingData.Name):
                return companyDto.GetType().GetProperty(nameof(HubSpotCompanyDto.Name));
            case nameof(CompanyTrackingData.Address):
                return companyDto.GetType().GetProperty(nameof(HubSpotCompanyDto.Address));
            case nameof(CompanyTrackingData.City):
                return companyDto.GetType().GetProperty(nameof(HubSpotCompanyDto.City));
            default:
                return null;
        }
    }
}