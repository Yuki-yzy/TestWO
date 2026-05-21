namespace BookingWorkOrder.Api.Entities;

public class WorkOrderLog
{
    public int Id { get; set; }

    public int WorkOrderId { get; set; }
    public WorkOrder? WorkOrder { get; set; }

    public string Action { get; set; } = string.Empty;
    public string? Note { get; set; }

    public int OperatorUserId { get; set; }
    public User? OperatorUser { get; set; }

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
}
