namespace BookingWorkOrder.Api.Dtos.Appointments;

public class CreateAppointmentRequestDto
{
    public DateTime AppointmentTime { get; set; }
    public string ServiceType { get; set; } = null!;
    public string? Description { get; set; }
}
