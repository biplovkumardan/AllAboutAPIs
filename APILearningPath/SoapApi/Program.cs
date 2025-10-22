using SoapApi.Services;
using SoapCore;
using Microsoft.AspNetCore.Builder;
using System.ServiceModel;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add comprehensive logging
builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
    logging.AddDebug();
});

// Add SOAP service with proper configuration
builder.Services.AddSingleton<IWeatherService, WeatherService>();
builder.Services.AddSoapCore();
builder.Services.AddMvc();

var app = builder.Build();

// Configure SOAP endpoint with extended options
((IEndpointRouteBuilder)app).UseSoapEndpoint<IWeatherService>("/WeatherService.asmx", new SoapEncoderOptions
{
    WriteEncoding = Encoding.UTF8,
    ReaderQuotas = new System.Xml.XmlDictionaryReaderQuotas
    {
        MaxDepth = 32,
        MaxStringContentLength = 8192,
        MaxArrayLength = 16384,
        MaxBytesPerRead = 4096,
        MaxNameTableCharCount = 16384
    }
}, SoapSerializer.XmlSerializer);

// Add basic health check endpoint
app.MapGet("/health", () => Results.Ok("Service is healthy"));

app.Run();
