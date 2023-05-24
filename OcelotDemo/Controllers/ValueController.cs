using Microsoft.AspNetCore.Mvc;

namespace OcelotDemo.Controllers
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
            return "Ocelot";
        }
    }
}