# REST API Example

This project demonstrates the implementation of a REST API using ASP.NET Core Web API.

## Features

- CRUD operations (Create, Read, Update, Delete)
- Standard HTTP methods usage
- JSON response format
- Stateless communication
- Resource-based routing

## Project Structure

```
RestApi/
├── Controllers/
│   └── WeatherForecastController.cs    # Example controller
├── Models/
│   └── WeatherForecast.cs             # Data model
├── Program.cs                         # Application entry point
└── appsettings.json                  # Configuration file
```

## Getting Started

1. Navigate to the project directory:
   ```bash
   cd RestApi
   ```

2. Run the project:
   ```bash
   dotnet run
   ```

3. Access the API at `http://localhost:5000`

## API Endpoints

- GET `/weatherforecast` - Get weather forecast data
- POST `/weatherforecast` - Create new weather forecast
- PUT `/weatherforecast/{id}` - Update existing forecast
- DELETE `/weatherforecast/{id}` - Delete a forecast

## Testing

Use Postman or curl to test the API endpoints:

```bash
# Get weather forecast
curl http://localhost:5000/weatherforecast

# Create new forecast
curl -X POST http://localhost:5000/weatherforecast \
  -H "Content-Type: application/json" \
  -d '{"date":"2025-10-18","temperatureC":20,"summary":"Warm"}'
```

## Learning Resources

1. [REST API Best Practices](https://docs.microsoft.com/en-us/azure/architecture/best-practices/api-design)
2. [ASP.NET Core Web API Tutorial](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api)
3. [HTTP Methods for RESTful Services](https://www.restapitutorial.com/lessons/httpmethods.html)