using System.Reflection;

namespace SampleProjectForMappingRules.Application.Dtos;

public class ParadigmCompanyDto : IMappingEntityDto
{
    public string StrCompanyName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }

    public PropertyInfo? GetPropertyByName(IMappingEntityDto dto, string propertyName)
    {
        switch (propertyName)
        {
            case nameof(CompanyTrackingData.Name):
                return dto.GetType().GetProperty(nameof(StrCompanyName));
            case nameof(CompanyTrackingData.Address):
                return dto.GetType().GetProperty(nameof(Address));
            case nameof(CompanyTrackingData.City):
                return dto.GetType().GetProperty(nameof(City));
            default:
                return null;
        }
    }
}