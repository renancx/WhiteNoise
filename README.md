**White Noise**
.NET Core Web Application with DDD, Identity and MVC

**Description**
Web application built on .NET Core following Domain-Driven Design (DDD). Includes ASP.NET Core Identity for authentication and authorization, MVC for presentation, and clean architecture principles.

**Technologies & Packages**

* .NET Core 3.1
* ASP.NET Core MVC
* ASP.NET Core Identity
* MediatR
* AutoMapper
* FluentValidation
* Entity Framework Core
* Microsoft.Extensions.DependencyInjection (IoC)

**Architecture**

```
src/  
├── Domain/           # Entities, Enums, Extensions, Interfaces  
├── Application/      # DTOs, ViewModels, Application Services, Interfaces  
├── Infrastructure/   # DbContext, Repository Implementations, Identity Stores  
└── Presentation/     # ASP.NET Core MVC: Controllers, Views, TagHelpers, ViewComponents  
```

**Prerequisites**

* .NET SDK 3.1 or later
* SQL Server (or other EF Core provider)

**Folder Structure**

* **Domain**: Domain models, value objects, domain interfaces
* **Application**: Business logic, DTOs, mapping profiles
* **Infrastructure**: Persistence, repository implementations, external services
* **Presentation**: MVC controllers, views, UI components, validation
