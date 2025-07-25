using Microsoft.EntityFrameworkCore;
using SampleProjectForMappingRules.Domain.Entities;

namespace SampleProjectForMappingRules.Infrastructure.Db;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<HubSpotParadigmPropertyMappingRule> MappingRules => Set<HubSpotParadigmPropertyMappingRule>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HubSpotParadigmPropertyMappingRule>(e =>
        {
            e.HasKey(x => x.Id);

            e.Property(x => x.PropertyName)
                .IsRequired()
                .HasMaxLength(256);

            e.Property(x => x.EntityName)
                .HasConversion<int>()
                .IsRequired();

            e.Property(x => x.MappingRule)
                .HasConversion<int>()
                .IsRequired();

            e.HasIndex(x => new
            {
                x.HubSpotParadigmSyncConfigurationId,
                x.EntityName,
                x.PropertyName
            }).IsUnique();

            e.HasIndex(x => x.HubSpotParadigmSyncConfigurationId);
            e.HasIndex(x => x.EntityName);
        });
    }
}