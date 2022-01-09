using Bogus;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace WeatherApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly ConverterClient _converterClient;

    public WeatherForecastController(
        ConverterClient converterClient,
        ILogger<WeatherForecastController> logger)
    {
        _converterClient = converterClient;
        _logger = logger;
    }

    [HttpGet("[action]"), ActionName("forecast")]
    public ActionResult<IEnumerable<WeatherForecast>> Get()
    {
        _logger.LogInformation($"Getting Weather Forecast");

        var weathers = new Faker<WeatherForecast>()
            .RuleFor(x => x.Date, x => DateTime.Today.AddDays(-1 * x.UniqueIndex))
            .RuleFor(x => x.Summary, x => x.Address.City())
            .RuleFor(x => x.TemperatureC, x => x.Random.Int(-5, 40))
            .Generate(10);

        foreach (var weather in weathers)
        {
            var request = new RestRequest(new Uri("/api/Temperature/c-to-f", UriKind.Relative), Method.GET);
            request.AddParameter("c", weather.TemperatureC);

            var response = _converterClient.Client.Execute<int>(request);

            weather.TemperatureF = response.Data;
        }

        return Ok(weathers);
    }
}
