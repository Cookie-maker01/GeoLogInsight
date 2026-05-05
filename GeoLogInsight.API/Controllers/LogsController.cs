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
        var random = new Random();

        var ips = new[] { "8.8.8.8", "1.1.1.1", "13.75.0.1", "172.217.0.0" };
        var endpoints = new[] { "/api/orders", "/api/users", "/api/products" };

        var logs = new List<LogEntry>();

        for (int i =0; i < random.Next(1, 4); i++)
        {
            logs.Add(new LogEntry
            {
                Ip = ips[random.Next(ips.Length)],
                Endpoint = endpoints[random.Next(endpoints.Length)],
                StatusCode = random.Next(0, 2) == 0 ? 200 : 500,
                ResponseTime = random.Next(50, 500)
            });
        }

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