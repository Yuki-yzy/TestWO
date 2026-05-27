namespace BookingWorkOrder.Api.Dtos.Appointments;

public class AppointmentListItemDto
{
    public int Id { get; set; }
    public DateTime AppointmentTime { get; set; }
    public string ServiceType { get; set; } = null!;
    public string? Description { get; set; }
    public string Status { get; set; } = null!;
    public DateTime CreatedAt { get; set; }
}
