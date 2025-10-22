using System.ServiceModel;
using System.Runtime.Serialization;

namespace SoapApi.Services;

[ServiceContract(Namespace = "http://tempuri.org/")]
public interface IWeatherService
{
    [OperationContract]
    WeatherData GetWeather(string city);

    [OperationContract]
    List<WeatherData> GetWeatherForecast(string city, int days);

    [OperationContract]
    bool UpdateWeather(string city, WeatherData weatherData);
}

[DataContract]
public class WeatherData
{
    [DataMember]
    public string City { get; set; } = string.Empty;

    [DataMember]
    public DateTime Date { get; set; }

    [DataMember]
    public double Temperature { get; set; }

    [DataMember]
    public string Condition { get; set; } = string.Empty;

    [DataMember]
    public double Humidity { get; set; }
}