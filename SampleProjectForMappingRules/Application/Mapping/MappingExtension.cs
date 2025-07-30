using System.Reflection;

namespace SampleProjectForMappingRules.Application.Mapping;

public static class MappingExtension
{
    public static PropertyInfo? GetPropertyByName(this Type? type, string propertyName)
    {
        if (type == null || string.IsNullOrEmpty(propertyName))
            return null;

        return type.GetProperties()
            .FirstOrDefault(p => p.Name.Contains(propertyName, StringComparison.OrdinalIgnoreCase));
    }
}