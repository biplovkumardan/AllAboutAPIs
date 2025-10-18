# gRPC API Example

This project demonstrates the implementation of a gRPC service using ASP.NET Core.

## Features

- Protocol Buffers (protobuf) for serialization
- HTTP/2 based communication
- Bi-directional streaming
- High performance
- Code generation

## Project Structure

```
GrpcApi/
├── Protos/
│   └── weather.proto        # Protocol buffer definition
├── Services/
│   └── WeatherService.cs   # Service implementation
├── Program.cs              # Application entry point
└── appsettings.json       # Configuration file
```

## Getting Started

1. Navigate to the project directory:
   ```bash
   cd GrpcApi
   ```

2. Run the project:
   ```bash
   dotnet run
   ```

3. The gRPC service will be available at `http://localhost:5002`

## Service Definition

```protobuf
syntax = "proto3";

service WeatherService {
  // Get weather data
  rpc GetWeather (WeatherRequest) returns (WeatherResponse);
  
  // Stream weather updates
  rpc StreamWeather (WeatherRequest) returns (stream WeatherResponse);
}

message WeatherRequest {
  string location = 1;
}

message WeatherResponse {
  float temperature = 1;
  string condition = 2;
  string location = 3;
}
```

## Communication Patterns

1. Unary RPC (Request/Response)
2. Server Streaming RPC
3. Client Streaming RPC
4. Bi-directional Streaming RPC

## Testing

Use [BloomRPC](https://github.com/uw-labs/bloomrpc) or [grpcurl](https://github.com/fullstorydev/grpcurl) for testing:

```bash
grpcurl -d '{"location": "London"}' \
  -plaintext localhost:5002 \
  WeatherService/GetWeather
```

## Learning Resources

1. [Introduction to gRPC](https://grpc.io/docs/what-is-grpc/introduction/)
2. [Protocol Buffers](https://developers.google.com/protocol-buffers)
3. [gRPC in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/grpc/)