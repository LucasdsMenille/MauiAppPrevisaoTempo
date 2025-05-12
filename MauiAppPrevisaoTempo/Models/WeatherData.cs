
using SQLite;
using System;

namespace MauiAppPrevisaoTempo.Models
{
    public class WeatherData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string City { get; set; }
        public double Temperature { get; set; }
        public string Description { get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }
        public DateTime QueryDate { get; set; }

        // Additional validation or custom logic can be added here
        public string GetFormattedDescription()
        {
            return $"{City} - {Temperature}°C, {Description}";
        }
    }
}
