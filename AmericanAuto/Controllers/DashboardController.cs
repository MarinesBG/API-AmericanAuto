using AmericanAuto.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace AmericanAuto.Controllers
{
    [CustomAuthorize]
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(ILogger<DashboardController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
           return BadRequest();
        }
    }
}