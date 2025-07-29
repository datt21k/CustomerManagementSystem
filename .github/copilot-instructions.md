# AI Agent Instructions for CustomerManagementSystem

This document provides essential context for AI agents working with this codebase.

## Project Overview
- ASP.NET Core 8.0 MVC web application for customer management
- Docker-enabled with Linux as the target OS
- Uses standard ASP.NET Core dependency injection and middleware pipeline

## Key Architecture Components
1. **Web Layer (`/Controllers`, `/Views`)**
   - MVC pattern with controllers in `Controllers/` and views in `Views/`
   - Example: `HomeController.cs` demonstrates controller structure with dependency injection
   - Views follow standard Razor syntax with shared layouts in `Views/Shared/`

2. **Models (`/Models`)**
   - Currently contains `ErrorViewModel.cs` for error handling
   - Add new models in this directory following C# nullable reference type pattern

## Development Workflow
1. **Local Development**
   - Project runs on HTTPS with development certificates
   - Use Visual Studio or `dotnet` CLI commands:
     ```powershell
     dotnet build
     dotnet run
     ```

2. **Docker Support**
   - Docker support is configured for Linux containers
   - Uses `Microsoft.VisualStudio.Azure.Containers.Tools.Targets` for container tooling

## Project Conventions
1. **Code Style**
   - Nullable reference types are enabled project-wide
   - Implicit using statements are enabled
   - Use dependency injection for services and logging

2. **Security**
   - HSTS enabled in production
   - Uses standard exception handling middleware with custom error pages

## Integration Points
1. **Static Files**
   - Served from `wwwroot/` directory
   - Bootstrap and jQuery included by default
   - Custom styles in `wwwroot/css/site.css`

## Common Tasks
- Adding a new view: Create in `Views/{Controller}/` with `.cshtml` extension
- Adding a new controller: Create in `Controllers/` with suffix `Controller`
- Static file changes: Update files in `wwwroot/` directory
