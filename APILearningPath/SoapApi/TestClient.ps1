$url = "http://localhost:5163/WeatherService.asmx"

function Invoke-SoapRequest {
    param(
        [string]$action,
        [string]$body
    )
    
    $headers = @{
        "Content-Type" = "text/xml; charset=utf-8"
        "SOAPAction" = "http://tempuri.org/$action"
    }

    try {
        $response = Invoke-WebRequest -Uri $url -Method Post -Body $body -Headers $headers
        Write-Host "Response Status Code: $($response.StatusCode)"
        Write-Host "Response Body:"
        Write-Host $response.Content
        Write-Host
    }
    catch {
        Write-Host "Error occurred: $_"
        Write-Host "Status Code: $($_.Exception.Response.StatusCode.value__)"
        Write-Host "Status Description: $($_.Exception.Response.StatusDescription)"
        Write-Host
    }
}

# Test 1: Get weather for London
Write-Host "Test 1: GetWeather for London"
$body = @"
<?xml version="1.0" encoding="utf-8"?>
<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <GetWeather xmlns="http://tempuri.org/">
      <city>London</city>
    </GetWeather>
  </soap:Body>
</soap:Envelope>
"@
Invoke-SoapRequest -action "GetWeather" -body $body

# Test 2: Get weather forecast for London (3 days)
Write-Host "Test 2: GetWeatherForecast for London (3 days)"
$body = @"
<?xml version="1.0" encoding="utf-8"?>
<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <GetWeatherForecast xmlns="http://tempuri.org/">
      <city>London</city>
      <days>3</days>
    </GetWeatherForecast>
  </soap:Body>
</soap:Envelope>
"@
Invoke-SoapRequest -action "GetWeatherForecast" -body $body

# Test 3: Update weather for London
Write-Host "Test 3: UpdateWeather for London"
$body = @"
<?xml version="1.0" encoding="utf-8"?>
<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <UpdateWeather xmlns="http://tempuri.org/">
      <city>London</city>
      <weatherData>
        <City>London</City>
        <Date>$([DateTime]::Now.ToString('o'))</Date>
        <Temperature>25.5</Temperature>
        <Condition>Sunny</Condition>
        <Humidity>65</Humidity>
      </weatherData>
    </UpdateWeather>
  </soap:Body>
</soap:Envelope>
"@
Invoke-SoapRequest -action "UpdateWeather" -body $body

# Test 4: Get weather for London again to verify update
Write-Host "Test 4: GetWeather for London (after update)"
$body = @"
<?xml version="1.0" encoding="utf-8"?>
<soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/">
  <soap:Body>
    <GetWeather xmlns="http://tempuri.org/">
      <city>London</city>
    </GetWeather>
  </soap:Body>
</soap:Envelope>
"@
Invoke-SoapRequest -action "GetWeather" -body $body