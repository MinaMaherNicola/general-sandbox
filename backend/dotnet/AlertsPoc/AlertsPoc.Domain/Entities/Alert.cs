using AlertsPoc.Contracts.Enums;

namespace AlertsPoc.Domain.Entities;

public class Alert
{
    public required Guid Id { get; init; }
    public required AlertStatus Status { get; init; }
    public required AlertSeverity Severity { get; init; }
    public required Level Level { get; init; }
    public required decimal ConfidenceLevel { get; init; }
    public Guid? AssigneeId { get; init; }

    public virtual SocAnalyst? Assignee { get; init; } = null;
}