namespace Swaggerator.Shared;

public class Service
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public string HealthCheckUrl { get; set; } = string.Empty;
    public bool AuthRequired { get; set; }
    public string AuthType { get; set; } = string.Empty;
    public List<string> Tags { get; set; } = new();
}
