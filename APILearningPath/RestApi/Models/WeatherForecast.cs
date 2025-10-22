namespace RestApi.Models;

/// <summary>
/// Represents a weather forecast with temperature and conditions
/// </summary>
public class WeatherForecast
{
    /// <summary>
    /// Gets or sets the unique identifier for the forecast
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the date of the weather forecast
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the temperature in Celsius
    /// </summary>
    public int TemperatureC { get; set; }

    /// <summary>
    /// Gets or sets a brief description of the weather conditions
    /// </summary>
    public string? Summary { get; set; }

    /// <summary>
    /// Gets the temperature in Fahrenheit, calculated from Celsius
    /// </summary>
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}