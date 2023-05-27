using Microsoft.AspNetCore.Mvc;

namespace Test2Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly ILogger<ValueController> _logger; 

        public HealthController(ILogger<ValueController> logger) 
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
