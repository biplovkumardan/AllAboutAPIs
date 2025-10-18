# WebSocket API Example

This project demonstrates real-time communication using WebSocket with ASP.NET Core SignalR.

## Features

- Bi-directional communication
- Real-time updates
- Connection management
- Client groups
- Broadcasting
- Connection state handling

## Project Structure

```
WebSocketApi/
├── Hubs/
│   └── WeatherHub.cs       # SignalR hub implementation
├── Models/
│   └── Message.cs         # Message models
├── Program.cs             # Application entry point
└── appsettings.json      # Configuration file
```

## Getting Started

1. Navigate to the project directory:
   ```bash
   cd WebSocketApi
   ```

2. Run the project:
   ```bash
   dotnet run
   ```

3. WebSocket server will be available at `ws://localhost:5005`

## SignalR Hub Methods

```csharp
public class WeatherHub : Hub
{
    // Send weather update to all clients
    public async Task BroadcastWeather(WeatherData data)
    {
        await Clients.All.SendAsync("ReceiveWeather", data);
    }

    // Join a specific location group
    public async Task JoinLocation(string location)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, location);
    }

    // Send update to specific location
    public async Task UpdateLocation(string location, WeatherData data)
    {
        await Clients.Group(location).SendAsync("LocationUpdate", data);
    }
}
```

## Client Integration

### JavaScript Client
```javascript
const connection = new signalR.HubConnectionBuilder()
    .withUrl("/weatherHub")
    .build();

connection.on("ReceiveWeather", (data) => {
    console.log("Weather Update:", data);
});

await connection.start();
```

### .NET Client
```csharp
var connection = new HubConnectionBuilder()
    .WithUrl("http://localhost:5005/weatherHub")
    .Build();

connection.On<WeatherData>("ReceiveWeather", (data) =>
{
    Console.WriteLine($"Weather Update: {data.Temperature}°C");
});

await connection.StartAsync();
```

## Features Demonstrated

1. Real-time Updates
   - Weather data broadcasting
   - Location-specific updates
   
2. Connection Management
   - Client groups
   - Connection tracking
   - Reconnection handling

3. Message Types
   - Broadcast to all
   - Group messages
   - Individual client messages

## Learning Resources

1. [SignalR Documentation](https://docs.microsoft.com/en-us/aspnet/core/signalr/introduction)
2. [WebSocket Protocol](https://developer.mozilla.org/en-US/docs/Web/API/WebSockets_API)
3. [Real-time Applications](https://docs.microsoft.com/en-us/aspnet/core/tutorials/signalr)