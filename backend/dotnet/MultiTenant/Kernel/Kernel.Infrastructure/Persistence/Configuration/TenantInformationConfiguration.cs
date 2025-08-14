using Kernel.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kernel.Infrastructure.Persistence.Configuration;

public sealed class TenantInformationConfiguration : IEntityTypeConfiguration<TenantInformation>
{
    public void Configure(EntityTypeBuilder<TenantInformation> builder)
    {
        builder.HasKey(t => t.Id);
        
        builder.Property(t => t.ConnectionString)
            .HasMaxLength(400)
            .IsRequired();

        builder.Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(100);
    }
}