using Microsoft.AspNetCore.Mvc;
using Skeleton.Abstraction;

namespace Skeleton.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private ILoggerManager _logger;

    public WeatherForecastController(ILoggerManager logger)
    {
        _logger = logger;
    }

    [HttpGet("GetLogMessages")]
    public IEnumerable<string> GetLogMessages()
    {
        throw new Exception("Exception");
        _logger.LogInfo("Here is info message from our values controller.");
        _logger.LogDebug("Here is debug message from our values controller.");
        _logger.LogWarn("Here is warn message from our values controller.");
        _logger.LogError("Here is an error message from our values controller.");
        return new string[] { "value1", "value2" };
    }
}