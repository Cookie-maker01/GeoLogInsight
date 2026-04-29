using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/logs")]
public class LogsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetLogs()
    {
        var logs = new List<LogEntry>
        {
            new LogEntry
            {
                Ip = "8.8.8.8",
                Endpoint = "/api/orders",
                StatusCode = 500,
                ResponseTime = 320,
                Lat = -36.8485,
                Lng = 174.7633 // Auckland
            }
        };

        return Ok(logs);
    }
}