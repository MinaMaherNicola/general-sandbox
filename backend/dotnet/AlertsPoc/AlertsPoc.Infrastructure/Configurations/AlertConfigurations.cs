using AlertsPoc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AlertsPoc.Infrastructure.Configurations;

public class AlertConfigurations : IEntityTypeConfiguration<Alert>
{
    public void Configure(EntityTypeBuilder<Alert> builder)
    {
        builder.ToTable("Alerts");
        builder.HasKey(a => a.Id);
        
        builder.Property(a => a.Status)
            .HasConversion<int>()
            .IsRequired();

        builder.Property(a => a.Severity)
            .HasConversion<int>()
            .IsRequired();
        
        builder.Property(a => a.Level)
            .HasConversion<int>()
            .IsRequired();
        
        builder.Property(a => a.ConfidenceLevel)
            .HasColumnType("decimal(5,2)")
            .IsRequired();
        
        builder.Property(a => a.AssigneeId)
            .IsRequired(false);

        builder.HasOne(a => a.Assignee)
            .WithMany(s => s.AssignedAlerts)
            .HasForeignKey(a => a.AssigneeId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}