
# TomBay

## Overview

This project is a .NET Core 8 WebAPI application designed to provide RESTful services for the TomBay example application. The API supports basic CRUD operations and includes SwaggerUI for easy testing and documentation.

## Project Structure

The project follows part of a typical .NET Core WebAPI structure with controllers, services, models, and a mock data store. Below is an overview of the key directories and files:

```
- TomBayAPI
  - Controllers
  - Models
  - Services
  - Data
  - Program.cs
  - Startup.cs
- TomBayTests
```

### Controllers

Controllers handle HTTP requests and return HTTP responses. They act as intermediaries between the client and the business logic.

### Models

Models represent the data structure of your application.

### Services

Services contain the business logic of your application and interact with the data access layer.

### Data

Data layer is responsible for database access and contains the database context.

### Program.cs

Entry point of the application that configures services, middleware, and the HTTP request pipeline.

### Tests

Unit tests for the application, ensuring the correctness of the code.
.

## Getting Started

### Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Visual Studio Code](https://code.visualstudio.com/) or [Visual Studio](https://visualstudio.microsoft.com/)

### Installation

1. Clone the repository:

   ```bash
   git clone https://github.com/your-username/your-repo-name.git
   cd your-repo-name
   ```

2. Restore the .NET packages:

   ```bash
   dotnet restore
   ```

### Running the Application

1. Run the application:

   ```bash
   dotnet run --project TomBayAPI
   ```

2. Open your browser and navigate to `https://localhost:5001/swagger` to access Swagger UI and interact with the API.

### Running the Tests

1. Run the tests:

   ```bash
   dotnet test
   ```

## Contributing

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Commit your changes (`git commit -am 'Add new feature'`).
4. Push to the branch (`git push origin feature-branch`).
5. Create a new Pull Request.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
