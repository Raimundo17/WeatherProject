namespace WeatherApp.Models
{
    public class GeoPositionResponse
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ElevationResponse Elevation { get; set; }
    }
}
