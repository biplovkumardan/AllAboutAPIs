using RestApi.Models;

namespace RestApi.Services;

/// <summary>
/// Defines the contract for weather forecast operations
/// </summary>
public interface IWeatherForecastService
{
    /// <summary>
    /// Retrieves all weather forecasts
    /// </summary>
    /// <returns>A collection of weather forecasts</returns>
    IEnumerable<WeatherForecast> GetAll();

    /// <summary>
    /// Retrieves a specific weather forecast by its identifier
    /// </summary>
    /// <param name="id">The unique identifier of the forecast</param>
    /// <returns>The weather forecast if found; otherwise, null</returns>
    WeatherForecast? GetById(int id);

    /// <summary>
    /// Creates a new weather forecast
    /// </summary>
    /// <param name="forecast">The weather forecast to create</param>
    /// <returns>The created weather forecast with assigned Id</returns>
    WeatherForecast Create(WeatherForecast forecast);

    /// <summary>
    /// Updates an existing weather forecast
    /// </summary>
    /// <param name="id">The unique identifier of the forecast to update</param>
    /// <param name="forecast">The updated forecast information</param>
    /// <returns>The updated forecast if found; otherwise, null</returns>
    WeatherForecast? Update(int id, WeatherForecast forecast);

    /// <summary>
    /// Deletes a specific weather forecast
    /// </summary>
    /// <param name="id">The unique identifier of the forecast to delete</param>
    /// <returns>True if the forecast was deleted; otherwise, false</returns>
    bool Delete(int id);
}