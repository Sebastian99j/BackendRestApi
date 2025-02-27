using Microsoft.AspNetCore.Mvc;

namespace BackendRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        public CommonController() { }

        [HttpGet("healthcheck")]
        public async Task<IActionResult> HealthCheck()
        {
            return Ok("health");
        }
    }
}
