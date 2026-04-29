public class LogEntry
{
    public string Ip {  get; set; }
    public string Endpoint { get; set; }
    public int StatusCode { get; set; }
    public int ResponseTime { get; set; }

    public double Lat {  get; set; }

    public double Lng { get; set; }
}