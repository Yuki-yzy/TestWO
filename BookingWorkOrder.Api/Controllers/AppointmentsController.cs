using BookingWorkOrder.Api.Dtos.Appointments;
using BookingWorkOrder.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookingWorkOrder.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly AppointmentService _appointmentService;

    public AppointmentsController(AppointmentService appointmentService)
    {
        _appointmentService = appointmentService;
    }

    [HttpPost]
    public async Task<ActionResult<CreateAppointmentResponseDto>> Create(
        [FromBody] CreateAppointmentRequestDto request)
    {
        if (request.AppointmentTime == default)
        {
            return BadRequest("AppointmentTime is required.");
        }

        if (string.IsNullOrWhiteSpace(request.ServiceType))
        {
            return BadRequest("ServiceType is required.");
        }

        var result = await _appointmentService.CreateAsync(request);
        return Ok(result);
    }

    [HttpGet("my")]
    public async Task<ActionResult<List<AppointmentListItemDto>>> GetMyAppointments()
    {
        var result = await _appointmentService.GetMyAppointmentsAsync();
        return Ok(result);
    }
}
