# RentACar Backend

This is a layered, modular, and scalable backend system for a Car Rental application, built using ASP.NET Core Web API and Entity Framework Core. It follows clean architecture principles, uses dependency injection and aspect-oriented programming (AOP), and provides secure authentication with JWT.

---

## 🚀 Tech Stack

- **Language & Framework:** C# (.NET 7, ASP.NET Core Web API)
- **Database:** SQL Server with Entity Framework Core (Code First)
- **Authentication & Authorization:** JSON Web Tokens (JWT), Role & Claim-based Access Control
- **Dependency Injection:** Autofac for Inversion of Control (IoC)
- **Validation:** FluentValidation for business rule validation
- **Cross-Cutting Concerns:** 
  - Caching
  - Logging
  - Performance Monitoring
  - Transaction Management
- **Error Handling:** Centralized Exception Middleware
- **Architecture Principles:** SOLID, DRY, Clean Code

---

## 🧱 Project Structure

The application is structured into logical layers to enforce separation of concerns:

| Layer           | Description |
|----------------|-------------|
| **Core**        | Contains base interfaces, helpers, utilities, and aspect definitions |
| **Entities**    | Domain models and entity classes |
| **DataAccess**  | EF Core-based repository implementations |
| **Business**    | Business logic and service layer |
| **WebAPI**      | HTTP request handling, controllers, and dependency registration |

---

## ✅ Features

- Full CRUD operations for Cars, Brands, Colors, Customers, Rentals, and more
- Secure JWT-based login & role authorization
- AOP-based handling of caching, validation, logging, and transactions
- Generic Repository pattern & Service-based architecture
- Clean error handling with descriptive messages
- Ready for extension and production deployment

---

## 🔧 Getting Started

### 1. Clone the Repository
```bash
git clone https://github.com/Fateehs/RentACar-Backend.git
cd RentACar-Backend
```
### 2. Configure the Database
Update your appsettings.json with your local SQL Server connection string:
```
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=RentACarDb;Trusted_Connection=True;"
}
```
Then apply migrations: 
```dotnet ef database update```

### 3. Run the Project
Navigate to the WebAPI project and start the application:
```dotnet run```

By default, the API will be available at:
```https://localhost:{port}/api```

Swagger UI (if enabled) will be available at:
```https://localhost:{port}/swagger```


## 📦 Dependency Management
The project uses Autofac as the IoC container and handles service registration via modules. Cross-cutting concerns such as caching, validation, and performance tracking are handled using custom aspects powered by Castle DynamicProxy.

## 🧠 Software Design Principles
SOLID: Ensures high cohesion and low coupling

DRY: Avoids redundant code

Clean Architecture: Focuses on separation of concerns and maintainability

Testability: Designed to be unit-test and integration-test friendly

## 🔮 Future Enhancements (Optional)
Admin dashboard with role management

Swagger authentication support

Docker support for containerization

Unit and integration tests

CI/CD pipeline setup

## 👤 Author

**Fatih Enes Selvi**  
📬 [LinkedIn](https://linkedin.com/in/fatih-enes-selvi-0217681b2)  
🌐 [Personal Website](https://fatihselvi.com)

📄 License
This project is open-source. License to be added.
