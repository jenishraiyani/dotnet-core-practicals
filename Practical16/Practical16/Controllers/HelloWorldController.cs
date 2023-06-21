using Microsoft.AspNetCore.Mvc;

namespace Practical16.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class HelloWorldController : Controller
    {
        private readonly ILogger<HelloWorldController> _logger;

        public HelloWorldController(ILogger<HelloWorldController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult GetMessage()
        {
            _logger.LogInformation("HelloWorldController - GetMessage method called");
            return Ok("Hello World!!!");
        }
    }
}
