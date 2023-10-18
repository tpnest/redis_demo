using Microsoft.AspNetCore.Mvc;
using redis_demo_api.Share;
using redis_demo_api.Share.Exceptions;

namespace redis_demo_api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    private readonly IHttpContextAccessor _httpContextAccessor;
    public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public HttpResult Get()
    {
        var session = _httpContextAccessor.HttpContext.Session.GetString("session");

        _logger.LogInformation(session);

        var list =  Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

        var total = list.Length;

        //throw new BusinessException("测试测试");
        return ResultTool.Success(list,total);
    }
}