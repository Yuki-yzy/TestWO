namespace BookingWorkOrder.Api.Entities;

public class WorkOrder
{
    public int Id { get; set; }

    // 来源预约
    public int AppointmentId { get; set; }
    public Appointment? Appointment { get; set; }

    // 分配给的工程师
    public int? AssignedToUserId { get; set; }
    public User? AssignedToUser { get; set; }

    public string Title { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string Priority { get; set; } = "Medium";
    public WorkOrderStatus Status { get; set; } = WorkOrderStatus.Open;
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAtUtc { get; set; }

    public ICollection<WorkOrderLog> Logs { get; set; } = new List<WorkOrderLog>();
}
