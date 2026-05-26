namespace BookingWorkOrder.Api.Dtos.Appointments;

public class CreateAppointmentResponseDto
{
    public int Id { get; set; }
    public string Status { get; set; } = null!;
    public string Message { get; set; } = null!;
}
