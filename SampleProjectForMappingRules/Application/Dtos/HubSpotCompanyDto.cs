using System.Reflection;

namespace SampleProjectForMappingRules.Application.Dtos;

public class HubSpotCompanyDto : IMappingEntityDto
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public PropertyInfo? GetPropertyByName(IMappingEntityDto companyDto, string propertyName)
    {
        switch (propertyName)
        {
            case nameof(CompanyTrackingData.Name):
                return companyDto.GetType().GetProperty(nameof(Name));
            case nameof(CompanyTrackingData.Address):
                return companyDto.GetType().GetProperty(nameof(Address));
            case nameof(CompanyTrackingData.City):
                return companyDto.GetType().GetProperty(nameof(City));
            default:
                return null;
        }
    }
}