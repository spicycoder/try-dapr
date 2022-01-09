using Microsoft.AspNetCore.Mvc;

namespace ConversionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperatureController : ControllerBase
    {
        private readonly ILogger<TemperatureController> _logger;

        public TemperatureController(ILogger<TemperatureController> logger)
        {
            _logger = logger;
        }

        [HttpGet("[action]"), ActionName("c-to-f")]
        public ActionResult<int> ConvertCToF(int c)
        {
            var f = 32 + (int)(c / 0.5556);
            _logger.LogInformation("Converting {celcius}c to {farenheit}f", c, f);
            return Ok(f);
        }
    }
}
