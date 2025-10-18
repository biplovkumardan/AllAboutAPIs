# GraphQL API Example

This project demonstrates the implementation of a GraphQL API using Hot Chocolate with ASP.NET Core.

## Features

- Schema-first development
- Flexible queries
- Real-time subscriptions
- GraphQL Playground
- Resolvers and DataLoaders

## Project Structure

```
GraphQLApi/
├── Schema/
│   └── WeatherSchema.cs    # GraphQL schema definition
├── Models/
│   └── Weather.cs         # Data models
├── Program.cs             # Application entry point
└── appsettings.json      # Configuration file
```

## Getting Started

1. Navigate to the project directory:
   ```bash
   cd GraphQLApi
   ```

2. Run the project:
   ```bash
   dotnet run
   ```

3. Access GraphQL Playground at `http://localhost:5003/graphql`

## Schema Definition

```graphql
type Query {
  weather(location: String!): Weather
  forecast(location: String!, days: Int!): [Weather!]!
}

type Mutation {
  updateWeather(input: WeatherInput!): Weather
}

type Subscription {
  onWeatherUpdate(location: String!): Weather
}

type Weather {
  id: ID!
  location: String!
  temperature: Float!
  condition: String!
  timestamp: DateTime!
}

input WeatherInput {
  location: String!
  temperature: Float!
  condition: String!
}
```

## Sample Queries

```graphql
# Get weather for a location
query {
  weather(location: "London") {
    temperature
    condition
    timestamp
  }
}

# Update weather data
mutation {
  updateWeather(input: {
    location: "London"
    temperature: 20.5
    condition: "Sunny"
  }) {
    id
    temperature
  }
}

# Subscribe to weather updates
subscription {
  onWeatherUpdate(location: "London") {
    temperature
    condition
    timestamp
  }
}
```

## Learning Resources

1. [GraphQL Official Documentation](https://graphql.org/learn/)
2. [Hot Chocolate Documentation](https://chillicream.com/docs/hotchocolate)
3. [GraphQL vs REST](https://www.howtographql.com/basics/1-graphql-is-the-better-rest/)