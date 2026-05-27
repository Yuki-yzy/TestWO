using BookingWorkOrder.Api.Data;
using BookingWorkOrder.Api.Dtos.Appointments;
using BookingWorkOrder.Api.Entities;
using Microsoft.EntityFrameworkCore;

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

    public async Task<List<AppointmentListItemDto>> GetMyAppointmentsAsync()
    {
        var userId = 1;

        return await _dbContext.Appointments
            .Where(x => x.UserId == userId)
            .OrderByDescending(x => x.CreatedAtUtc)
            .Select(x => new AppointmentListItemDto
            {
                Id = x.Id,
                AppointmentTime = x.AppointmentTime,
                ServiceType = x.ServiceType,
                Description = x.Description,
                Status = x.Status.ToString(),
                CreatedAt = x.CreatedAtUtc
            })
            .ToListAsync();
    }
}
