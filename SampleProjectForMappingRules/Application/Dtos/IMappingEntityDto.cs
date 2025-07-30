
using System.Reflection;

namespace SampleProjectForMappingRules.Application.Dtos;

public interface IMappingEntityDto
{
    PropertyInfo? GetPropertyByName(IMappingEntityDto dto, string propertyName);
}