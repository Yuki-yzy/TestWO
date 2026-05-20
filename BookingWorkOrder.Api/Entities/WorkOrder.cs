namespace BookingWorkOrder.Api.Entities;

public class WorkOrder
{
    public Guid Id { get; set; }
    public Guid? AppointmentId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? EngineerName { get; set; }
    public WorkOrderStatus Status { get; set; } = WorkOrderStatus.Open;
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAtUtc { get; set; }
}
