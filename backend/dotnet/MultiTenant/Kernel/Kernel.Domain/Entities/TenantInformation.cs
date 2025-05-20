namespace Kernel.Domain.Entities;

public sealed class TenantInformation
{
    public required Guid Id { get; init; }
    public required string Name { get; set; }
}