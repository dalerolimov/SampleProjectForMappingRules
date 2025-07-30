namespace SampleProjectForMappingRules.Application.Dtos;

public record CompanyTrackingData
{
    public required string Name { get; set; }

    public required string Address { get; set; }

    public required string City { get; set; }

    public required string State { get; set; }

    public required string Zip { get; set; }

    public required string Type { get; set; }

    public required string OwnerName { get; set; }
}