using Microsoft.AspNetCore.Mvc;

namespace OcelotDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsulHealthController : ControllerBase
    {
        private readonly ILogger<ValueController> _logger;

        public ConsulHealthController(ILogger<ValueController> logger)
        {
            _logger = logger;
        }

        [HttpGet] 
        public string Get()
        {
            return "1";
        }
    }
}