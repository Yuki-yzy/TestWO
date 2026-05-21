namespace BookingWorkOrder.Api.Entities;

public class Appointment
{
    public int Id { get; set; }

    // 提交人
    public int UserId { get; set; }
    public User? User { get; set; }

    public DateTime AppointmentTime { get; set; }
    public string ServiceType { get; set; } = string.Empty;
    public string? Description { get; set; }

    public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;

    // 审核相关
    public int? ReviewedByUserId { get; set; }
    public User? ReviewedByUser { get; set; }
    public string? ReviewNote { get; set; }

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

    // 可选关联的工单
    public WorkOrder? WorkOrder { get; set; }
}
