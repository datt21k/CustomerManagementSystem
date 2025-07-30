# AI Agent Instructions for CustomerManagementSystem

This guide enables AI agents to be immediately productive in this codebase.

## Project Overview
- ASP.NET Core 8.0 MVC web application for customer management
- Docker-enabled (Linux containers)
- PostgreSQL database with Entity Framework Core
- Uses standard ASP.NET Core dependency injection and middleware pipeline

## Architecture & Major Components

### Data Flow
1. HTTP Request → Controller → Service → Repository → Database
2. Database → Repository → Service → ViewModel → View → HTTP Response

### Components
- **Web Layer**: Controllers in `Controllers/` handle HTTP requests and use services via DI
  - Example: `CustomerController.cs` for customer CRUD operations
- **Services Layer**: Business logic in `Services/`
  - Example: `CustomerService.cs` implements validation and business rules
- **Data Layer**: 
  - `Data/ApplicationDbContext.cs`: EF Core context with PostgreSQL
  - `Repositories/`: Data access patterns (e.g., `CustomerRepository.cs`)
  - Unique constraints: Customer email must be unique
- **Models & ViewModels**:
  - Domain models in `Models/` (e.g., `Customer.cs`)
  - View-specific models in `ViewModels/` (e.g., `CustomerViewModel.cs`)
  - All use C# nullable reference types

## Developer Workflow
1. **Database Setup**:
   ```powershell
   # Configure connection in appsettings.json:
   "DefaultConnection": "Host=localhost;Database=CustomerManagementSystem;Username=postgres;Password=postgres"
   # Run initial migration script:
   psql -U postgres -d CustomerManagementSystem -f Scripts/001_InitialSchema.sql
   ```

2. **Build & Run**:
   ```powershell
   dotnet build
   dotnet run
   ```

3. **Docker**:
   ```powershell
   docker build -t customermgmt .
   docker run -p 8080:80 customermgmt
   ```

## Project-Specific Patterns
- **Repository Pattern**: All data access through repositories (`ICustomerRepository`)
- **Service Layer**: Business logic isolated in services, injected into controllers
- **View Reuse**: Common form elements in shared partials (e.g., `_CustomerForm.cshtml`)
- **Error Handling**: 
  - Application errors use `ErrorViewModel` and `Error.cshtml`
  - Data validation in services with custom exceptions
- **Database**: 
  - PostgreSQL with unique constraints on email
  - Migration scripts in `Scripts/` folder

## Integration Points
- **Database**: PostgreSQL connection configured in `appsettings.json`
- **Static Assets**: Bootstrap/jQuery from `wwwroot/lib/`, custom styles in `wwwroot/css/site.css`
- **View Components**: Shared components in `Views/Shared/`
- **API Integration**: Controllers support both view and JSON responses

## Common Tasks
- **Add New Feature**:
  1. Add model in `Models/`
  2. Create repository interface and implementation
  3. Add service with business logic
  4. Create controller with DI
  5. Add views in `Views/{Controller}/`
- **Database Changes**: 
  1. Add migration script in `Scripts/`
  2. Update model and DbContext
  3. Update repository implementation
