using RestApi.Models;

namespace RestApi.Services;

/// <summary>
/// Provides implementation for weather forecast operations
/// </summary>
public class WeatherForecastService : IWeatherForecastService
{
    /// <summary>
    /// In-memory collection of weather forecasts
    /// </summary>
    private readonly List<WeatherForecast> _forecasts;

    /// <summary>
    /// Counter for generating unique IDs
    /// </summary>
    private int _nextId = 1;

    /// <summary>
    /// Predefined weather condition summaries
    /// </summary>
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    /// <summary>
    /// Initializes a new instance of the WeatherForecastService
    /// Creates initial sample data
    /// </summary>
    public WeatherForecastService()
    {
        _forecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Id = index,
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToList();
        _nextId = _forecasts.Count + 1;
    }

    /// <inheritdoc/>
    public IEnumerable<WeatherForecast> GetAll()
    {
        return _forecasts;
    }

    /// <inheritdoc/>
    public WeatherForecast? GetById(int id)
    {
        return _forecasts.FirstOrDefault(f => f.Id == id);
    }

    /// <inheritdoc/>
    public WeatherForecast Create(WeatherForecast forecast)
    {
        forecast.Id = _nextId++;
        _forecasts.Add(forecast);
        return forecast;
    }

    /// <inheritdoc/>
    public WeatherForecast? Update(int id, WeatherForecast forecast)
    {
        var existing = _forecasts.FirstOrDefault(f => f.Id == id);
        if (existing == null) return null;

        existing.Date = forecast.Date;
        existing.TemperatureC = forecast.TemperatureC;
        existing.Summary = forecast.Summary;

        return existing;
    }

    /// <inheritdoc/>
    public bool Delete(int id)
    {
        var forecast = _forecasts.FirstOrDefault(f => f.Id == id);
        if (forecast == null) return false;

        _forecasts.Remove(forecast);
        return true;
    }
}