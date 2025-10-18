# SOAP API Example

This project demonstrates the implementation of a SOAP API using ASP.NET Core and ServiceStack.

## Features

- XML-based messaging
- WSDL contract
- Strong typing
- Enterprise-grade features
- Reliable messaging

## Project Structure

```
SoapApi/
├── Services/
│   └── WeatherService.cs     # SOAP service implementation
├── Models/
│   └── WeatherData.cs       # Data contracts
├── Program.cs               # Application entry point
└── appsettings.json        # Configuration file
```

## Getting Started

1. Navigate to the project directory:
   ```bash
   cd SoapApi
   ```

2. Run the project:
   ```bash
   dotnet run
   ```

3. Access the WSDL at `http://localhost:5001/weather.asmx?wsdl`

## Service Operations

- `GetWeather` - Get current weather data
- `UpdateWeather` - Update weather information
- `SubscribeToAlerts` - Subscribe to weather alerts
- `GetHistoricalData` - Retrieve historical weather data

## Testing

Use SoapUI or similar tools to test the SOAP endpoints:

1. Create a new SOAP project in SoapUI
2. Import the WSDL from `http://localhost:5001/weather.asmx?wsdl`
3. Generate sample requests
4. Execute the requests

## Sample Request

```xml
<soap:Envelope xmlns:soap="http://www.w3.org/2003/05/soap-envelope">
  <soap:Header/>
  <soap:Body>
    <GetWeather xmlns="http://tempuri.org/">
      <city>London</city>
    </GetWeather>
  </soap:Body>
</soap:Envelope>
```

## Learning Resources

1. [SOAP Protocol Specification](https://www.w3.org/TR/soap/)
2. [WS-* Standards](https://www.w3.org/2002/ws/)
3. [ServiceStack Documentation](https://docs.servicestack.net/)