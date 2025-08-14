using AlertsPoc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlertsPoc.Infrastructure.Configurations;

public class SocAnalystConfiguration : IEntityTypeConfiguration<SocAnalyst>
{
    public void Configure(EntityTypeBuilder<SocAnalyst> builder)
    {
        builder.ToTable("SocAnalysts");
        builder.HasKey(s => s.Id);
        
        builder.Property(s => s.Level)
            .HasConversion<int>()
            .IsRequired();
        
        builder.Property(s => s.MaximumCapacity)
            .IsRequired();

        builder.Property(s => s.LoggedIn)
            .IsRequired();

        builder.Property(s => s.IsAvailable)
            .IsRequired();
        
        builder.HasMany(s => s.AssignedAlerts)
            .WithOne(a => a.Assignee)
            .HasForeignKey(a => a.AssigneeId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}