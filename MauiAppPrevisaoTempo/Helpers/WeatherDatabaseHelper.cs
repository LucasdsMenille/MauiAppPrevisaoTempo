using SQLite;
using MauiAppPrevisaoTempo.Models;

namespace MauiAppTempoAgora.Helpers
{
    public class WeatherDatabaseHelper
    {
        readonly SQLiteAsyncConnection _connection;

        // Constructor
        public WeatherDatabaseHelper(string path)
        {
            _connection = new SQLiteAsyncConnection(path);
            _connection.CreateTableAsync<WeatherData>().Wait();
        }

        // Create method to save weather data
        public Task<int> SaveWeatherData(WeatherData weatherData)
        {
            return _connection.InsertAsync(weatherData);
        }

        // Get all weather query history
        public Task<List<WeatherData>> GetAllWeatherHistory()
        {
            return _connection.Table<WeatherData>().OrderByDescending(w => w.QueryDate).ToListAsync();
        }

        // Search weather history by city
        public Task<List<WeatherData>> SearchWeatherHistory(string city)
        {
            return _connection.QueryAsync<WeatherData>(
                "SELECT * FROM WeatherData WHERE City LIKE ? ORDER BY QueryDate DESC",
                $"%{city}%"
            );
        }

        // Delete a specific weather query
        public Task<int> DeleteWeatherData(int id)
        {
            return _connection.Table<WeatherData>().DeleteAsync(w => w.Id == id);
        }

        // Clear entire weather history
        public Task<int> ClearWeatherHistory()
        {
            return _connection.DeleteAllAsync<WeatherData>();
        }
    }
}