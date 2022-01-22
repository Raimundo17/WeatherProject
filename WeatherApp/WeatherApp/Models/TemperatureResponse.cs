namespace WeatherApp.Models
{
    public class TemperatureResponse
    {
        public MetricResponse Metric { get; set; }
        public ImperialResponse Imperial { get; set; }
    }
}
