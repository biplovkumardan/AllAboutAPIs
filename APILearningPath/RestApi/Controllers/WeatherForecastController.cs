using Microsoft.AspNetCore.Mvc;
using RestApi.Models;
using RestApi.Services;

namespace RestApi.Controllers;

/// <summary>
/// Controller for managing weather forecasts
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastService _service;

    /// <summary>
    /// Initializes a new instance of the WeatherForecastController
    /// </summary>
    /// <param name="service">The weather forecast service</param>
    public WeatherForecastController(IWeatherForecastService service)
    {
        _service = service;
    }

    /// <summary>
    /// Retrieves all weather forecasts
    /// </summary>
    /// <returns>A collection of all weather forecasts</returns>
    /// <response code="200">Returns the list of weather forecasts</response>
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<WeatherForecast>), StatusCodes.Status200OK)]
    public IActionResult GetAll()
    {
        return Ok(_service.GetAll());
    }

    /// <summary>
    /// Retrieves a specific weather forecast by id
    /// </summary>
    /// <param name="id">The id of the weather forecast to retrieve</param>
    /// <returns>The weather forecast</returns>
    /// <response code="200">Returns the requested weather forecast</response>
    /// <response code="404">If the weather forecast is not found</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(WeatherForecast), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetById(int id)
    {
        var forecast = _service.GetById(id);
        if (forecast == null)
            return NotFound();

        return Ok(forecast);
    }

    /// <summary>
    /// Creates a new weather forecast
    /// </summary>
    /// <param name="forecast">The weather forecast to create</param>
    /// <returns>The created weather forecast</returns>
    /// <response code="201">Returns the newly created weather forecast</response>
    /// <response code="400">If the weather forecast is invalid</response>
    [HttpPost]
    [ProducesResponseType(typeof(WeatherForecast), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Create(WeatherForecast forecast)
    {
        var created = _service.Create(forecast);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    /// <summary>
    /// Updates an existing weather forecast
    /// </summary>
    /// <param name="id">The id of the weather forecast to update</param>
    /// <param name="forecast">The updated weather forecast data</param>
    /// <returns>The updated weather forecast</returns>
    /// <response code="200">Returns the updated weather forecast</response>
    /// <response code="404">If the weather forecast is not found</response>
    /// <response code="400">If the weather forecast is invalid</response>
    [HttpPut("{id}")]
    [ProducesResponseType(typeof(WeatherForecast), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Update(int id, WeatherForecast forecast)
    {
        var updated = _service.Update(id, forecast);
        if (updated == null)
            return NotFound();

        return Ok(updated);
    }

    /// <summary>
    /// Deletes a specific weather forecast
    /// </summary>
    /// <param name="id">The id of the weather forecast to delete</param>
    /// <returns>No content</returns>
    /// <response code="204">If the weather forecast was successfully deleted</response>
    /// <response code="404">If the weather forecast is not found</response>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult Delete(int id)
    {
        var result = _service.Delete(id);
        if (!result)
            return NotFound();

        return NoContent();
    }
}