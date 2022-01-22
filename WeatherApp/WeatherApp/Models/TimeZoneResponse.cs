namespace WeatherApp.Models
{
    public class TimeZoneResponse
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double GmtOffset { get; set; }
        public bool IsDaylightSaving { get; set; }
        public object NextOffsetChange { get; set; }
    }
}
