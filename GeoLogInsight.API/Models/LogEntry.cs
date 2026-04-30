public class LogEntry
{
    public required string Ip {  get; set; }
    public required string Endpoint { get; set; }

    public int StatusCode { get; set; }
    public int ResponseTime { get; set; }

    public double Lat {  get; set; }

    public double Lng { get; set; }
}