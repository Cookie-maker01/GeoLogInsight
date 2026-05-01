using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using GeoLogInsight.API.Services;
using GeoLogInsight.API.Hubs;


[ApiController]
[Route("api/logs")]
public class LogsController : ControllerBase
{
    private readonly GeoService _geoService;
    private readonly IHubContext<LogHub> _hubContext;

    public LogsController(IHubContext<LogHub> hubContext, GeoService geoService)
    {
        _hubContext = hubContext;
        _geoService = geoService;
    }

    [HttpGet]
    public async Task<IActionResult> GetLogs()
    {
        var logs = new List<LogEntry>
        {
            new LogEntry
            {
                Ip = "8.8.8.8",
                Endpoint = "/api/orders",
                StatusCode = 500,
                ResponseTime = 320
            },
            new LogEntry
            {
                Ip = "1.1.1.1",
                Endpoint = "/api/users",
                StatusCode = 200,
                ResponseTime = 120
            }
        };

        foreach (var log in logs)
        {
            var (lat, lng) = await _geoService.GetLocation(log.Ip);
            log.Lat = lat;
            log.Lng = lng;

            await _hubContext.Clients.All.SendAsync("ReceiveLog", log);
        }

        return Ok(logs);
    }
}