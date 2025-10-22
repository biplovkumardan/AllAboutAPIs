using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace SoapApi.Services;

public class WeatherService : IWeatherService
{
    private static readonly Dictionary<string, WeatherData> _weatherCache = new(StringComparer.OrdinalIgnoreCase);
    private static readonly string[] _conditions = new[]
    {
        "Sunny", "Partly Cloudy", "Cloudy", "Rain", "Thunderstorm", "Snow"
    };
    private readonly ILogger<WeatherService> _logger;

    public WeatherService(ILogger<WeatherService> logger)
    {
        _logger = logger;
        InitializeSampleData();
    }

    public WeatherData GetWeather(string city)
    {
        ArgumentException.ThrowIfNullOrEmpty(city);
        _logger.LogInformation("Getting weather for city: {City}", city);

        if (_weatherCache.TryGetValue(city, out var weather))
        {
            if (DateTime.Now.Subtract(weather.Date).TotalMinutes < 30)
            {
                _logger.LogDebug("Returning cached weather data for {City}", city);
                return weather;
            }
            _weatherCache.Remove(city);
        }

        var newWeather = GenerateRandomWeather(city);
        _weatherCache[city] = newWeather;
        
        _logger.LogInformation("Generated new weather data for {City}", city);
        return newWeather;
    }

    public List<WeatherData> GetWeatherForecast(string city, int days)
    {
        ArgumentException.ThrowIfNullOrEmpty(city);
        if (days <= 0 || days > 14)
        {
            throw new ArgumentException("Forecast days must be between 1 and 14", nameof(days));
        }

        _logger.LogInformation("Getting {Days} day forecast for {City}", days, city);

        var currentWeather = GetWeather(city);
        var forecast = new List<WeatherData>
        {
            currentWeather
        };

        var baseTemp = currentWeather.Temperature;
        var baseCondition = currentWeather.Condition;

        for (int i = 1; i < days; i++)
        {
            forecast.Add(new WeatherData
            {
                City = city,
                Date = DateTime.Now.AddDays(i),
                Temperature = baseTemp + Random.Shared.Next(-5, 6),
                Condition = GetNextDayCondition(baseCondition),
                Humidity = Random.Shared.Next(40, 90)
            });
        }

        return forecast;
    }

    public bool UpdateWeather(string city, WeatherData weatherData)
    {
        ArgumentException.ThrowIfNullOrEmpty(city);
        ArgumentNullException.ThrowIfNull(weatherData);

        try
        {
            weatherData.City = city;
            weatherData.Date = DateTime.Now;
            _weatherCache[city] = weatherData;
            _logger.LogInformation("Updated weather data for {City}", city);
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating weather for {City}", city);
            return false;
        }
    }

    private WeatherData GenerateRandomWeather(string city)
    {
        return new WeatherData
        {
            City = city,
            Date = DateTime.Now,
            Temperature = Random.Shared.Next(0, 35),
            Condition = _conditions[Random.Shared.Next(_conditions.Length)],
            Humidity = Random.Shared.Next(40, 90)
        };
    }

    private string GetNextDayCondition(string currentCondition)
    {
        // 60% chance to keep similar weather
        return Random.Shared.NextDouble() < 0.6
            ? currentCondition
            : _conditions[Random.Shared.Next(_conditions.Length)];
    }

    private void InitializeSampleData()
    {
        if (!_weatherCache.Any())
        {
            var london = new WeatherData
            {
                City = "London",
                Date = DateTime.Now,
                Temperature = 18.5,
                Condition = "Cloudy",
                Humidity = 72
            };
            _weatherCache["London"] = london;
            _logger.LogInformation("Sample weather data initialized for London");
        }
    }
}