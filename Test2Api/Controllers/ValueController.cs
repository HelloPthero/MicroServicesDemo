using Microsoft.AspNetCore.Mvc;

namespace Test2Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValueController : ControllerBase
    {
        private readonly ILogger<ValueController> _logger;

        public ValueController(ILogger<ValueController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            var ip = HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            var port = Request.HttpContext.Connection.RemotePort;
            return $"Test2 {port}";
        }
    }
}