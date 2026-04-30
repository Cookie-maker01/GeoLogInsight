using System.Text.Json;

namespace GeoLogInsight.API.Services;

public class GeoService
{
    private readonly HttpClient _httpClient = new HttpClient();

    private readonly Dictionary<string, (double lat, double lng)> _cache = new();

    public async Task<(double lat, double lng)> GetLocation(string ip)
    {
        if (_cache.ContainsKey(ip))
        {
            return _cache[ip];
        }

        try
        {

            var url = $"http://ip-api.com/json/{ip}";

            var response = await _httpClient.GetStringAsync(url);

            var json = JsonDocument.Parse(response);

            var lat = json.RootElement.GetProperty("lat").GetDouble();
            var lng = json.RootElement.GetProperty("lon").GetDouble();

            var result = (lat, lng);

            _cache[ip] = result;

            return result;
        }
        catch
        {
            return (double.NaN, double.NaN);
        }
    }
}