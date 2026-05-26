using BookingWorkOrder.Api.Data;
using BookingWorkOrder.Api.Dtos.Appointments;
using BookingWorkOrder.Api.Entities;

namespace BookingWorkOrder.Api.Services;

public class AppointmentService
{
    private readonly ApplicationDbContext _dbContext;

    public AppointmentService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<CreateAppointmentResponseDto> CreateAsync(CreateAppointmentRequestDto request)
    {
        var appointment = new Appointment
        {
            // 临时固定提交人
            UserId = 1,
            AppointmentTime = request.AppointmentTime,
            ServiceType = request.ServiceType,
            Description = request.Description,
            Status = AppointmentStatus.Pending,
            CreatedAtUtc = DateTime.UtcNow
        };

        _dbContext.Appointments.Add(appointment);
        await _dbContext.SaveChangesAsync();

        return new CreateAppointmentResponseDto
        {
            Id = appointment.Id,
            Status = appointment.Status.ToString(),
            Message = "Appointment created successfully."
        };
    }
}
