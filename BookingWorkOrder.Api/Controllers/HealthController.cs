using Microsoft.AspNetCore.Mvc;

namespace BookingWorkOrder.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { status = "ok", service = "BookingWorkOrder.Api" });
    }
}
