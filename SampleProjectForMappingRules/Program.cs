using SampleProjectForMappingRules.Application.Dtos;
using SampleProjectForMappingRules.Application.Mapping;
using SampleProjectForMappingRules.Application.Services;
using SampleProjectForMappingRules.Domain.Repositories;
using SampleProjectForMappingRules.Domain.Services;
using SampleProjectForMappingRules.Infrastructure.Db;
using SampleProjectForMappingRules.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IMappingRuleRepository, MappingRuleRepository>();
builder.Services.AddAutoMapper(typeof(SyncProfile).Assembly);
builder.Services.AddScoped<ISyncService, SyncService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapGet("/", (ISyncService syncService) =>
    {
        return syncService.MapCompany(new HubSpotCompanyDto
        {
            Address = "1234",
            Name = "Abdu",
            Phone = "1234567890"
        }, Guid.Empty);
    })
    .WithName("test");

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}