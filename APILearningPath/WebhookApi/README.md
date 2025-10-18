# Webhook API Example

This project demonstrates the implementation of Webhooks using ASP.NET Core Web API.

## Features

- Webhook registration
- Event notifications
- Payload delivery
- Retry mechanism
- Security validation

## Project Structure

```
WebhookApi/
├── Controllers/
│   └── WebhookController.cs   # Webhook endpoints
├── Models/
│   └── WebhookPayload.cs     # Payload definitions
├── Program.cs                # Application entry point
└── appsettings.json         # Configuration file
```

## Getting Started

1. Navigate to the project directory:
   ```bash
   cd WebhookApi
   ```

2. Run the project:
   ```bash
   dotnet run
   ```

3. Access the API at `http://localhost:5004`

## API Endpoints

- POST `/webhooks/register` - Register a new webhook
- POST `/webhooks/trigger` - Trigger a webhook event
- DELETE `/webhooks/{id}` - Unregister a webhook

## Sample Usage

1. Register a webhook:
```bash
curl -X POST http://localhost:5004/webhooks/register \
  -H "Content-Type: application/json" \
  -d '{
    "url": "https://your-server.com/webhook",
    "events": ["weather.update", "weather.alert"],
    "secret": "your-secret-key"
  }'
```

2. Trigger an event:
```bash
curl -X POST http://localhost:5004/webhooks/trigger \
  -H "Content-Type: application/json" \
  -d '{
    "event": "weather.update",
    "data": {
      "temperature": 25,
      "condition": "Sunny"
    }
  }'
```

## Webhook Payload Format

```json
{
  "id": "evt_123456",
  "event": "weather.update",
  "timestamp": "2025-10-18T10:30:00Z",
  "data": {
    "temperature": 25,
    "condition": "Sunny"
  }
}
```

## Security

- HMAC signature validation
- Secret key authentication
- Rate limiting
- IP whitelisting

## Learning Resources

1. [Webhook Best Practices](https://docs.github.com/en/developers/webhooks-and-events/webhooks/about-webhooks)
2. [Implementing Webhooks](https://zapier.com/engineering/webhook-design/)
3. [Securing Webhooks](https://developers.shopify.com/tutorials/manage-webhooks)