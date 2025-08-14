using AlertsPoc.Contracts.Enums;

namespace AlertsPoc.Domain.Entities;

public class SocAnalyst
{
    public required Guid Id { get; init; }
    public required Level Level { get; init; }
    public required int MaximumCapacity { get; init; }
    public required bool LoggedIn { get; init; }
    public required bool IsAvailable { get; init; }

    public virtual ICollection<Alert> AssignedAlerts { get; init; } = [];
}