# API Learning Path

This solution contains example implementations of different types of APIs using C# and ASP.NET Core. Each project demonstrates a specific type of API with practical examples and documentation.

## Projects Overview

### 1. REST API
- Location: `./RestApi/`
- Description: Demonstrates REST API principles using ASP.NET Core Web API
- Features:
  - CRUD operations
  - HTTP methods (GET, POST, PUT, DELETE)
  - JSON response format
  - Stateless communication

### 2. SOAP API
- Location: `./SoapApi/`
- Description: Shows SOAP API implementation using WCF
- Features:
  - XML-based messaging
  - WSDL contract
  - Enterprise-grade features

### 3. gRPC API
- Location: `./GrpcApi/`
- Description: High-performance RPC framework implementation
- Features:
  - Protocol Buffers
  - Streaming support
  - HTTP/2 based communication

### 4. GraphQL API
- Location: `./GraphQLApi/`
- Description: GraphQL implementation using Hot Chocolate
- Features:
  - Schema definition
  - Queries and mutations
  - Real-time subscriptions

### 5. Webhook API
- Location: `./WebhookApi/`
- Description: Webhook implementation for event-driven architecture
- Features:
  - Event registration
  - Payload delivery
  - Event handling

### 6. WebSocket API
- Location: `./WebSocketApi/`
- Description: Real-time bidirectional communication using SignalR
- Features:
  - Real-time messaging
  - Connection management
  - Groups and broadcasting

### 7. WebRTC API
- Location: `./WebRTCApi/`
- Description: Peer-to-peer communication implementation
- Features:
  - Signaling server
  - Video/Audio streaming
  - Data channels

## Getting Started

1. Clone the repository
2. Open the solution in Visual Studio Code
3. Install dependencies for each project:
   ```bash
   dotnet restore
   ```
4. Build the solution:
   ```bash
   dotnet build
   ```
5. Run any project:
   ```bash
   cd ProjectName
   dotnet run
   ```

## Learning Path

1. Start with REST API as it's the most common and straightforward
2. Move to SOAP API to understand enterprise-grade features
3. Explore GraphQL for flexible data querying
4. Learn WebSocket for real-time features
5. Study gRPC for high-performance microservices
6. Implement Webhooks for event-driven scenarios
7. Finally, dive into WebRTC for peer-to-peer communication

## Requirements

- .NET SDK 7.0 or later
- Visual Studio Code
- Postman or similar API testing tool

## Additional Resources

Each project contains its own README with detailed documentation and examples.