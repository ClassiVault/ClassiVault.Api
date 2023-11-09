using Microsoft.AspNetCore.Mvc;

namespace ClassiVault.Api.Controllers
{
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet("/healthy")]
        public IActionResult Healthy()
        {
            return Ok("Healthy");
        }
    }
}
