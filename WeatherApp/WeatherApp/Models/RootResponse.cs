using System;

namespace WeatherApp.Models
{
    public class RootResponse
    {
        public string Key { get; set; }
        public string LocalizedName { get; set; }
        public string EnglishName { get; set; }
        public CountryResponse Country { get; set; }
        public TimeZoneResponse TimeZone { get; set; }
        public GeoPositionResponse GeoPosition { get; set; }
        public DateTime LocalObservationDateTime { get; set; }
        public int EpochTime { get; set; }
        public string WeatherText { get; set; }
        public int WeatherIcon { get; set; }
        public bool HasPrecipitation { get; set; }
        public string PrecipitationType { get; set; }
        public bool IsDayTime { get; set; }
        public TemperatureResponse Temperature { get; set; }
        public string MobileLink { get; set; }
        public string Link { get; set; }
        public LocalSourceResponse LocalSource { get; set; }
        public string Image { get; set; }
    }
}
