### **Technologies**
- Clean Architecture
- ASP.NET CORE 7.0
- Entity FrameWork Core 7.0
- Mediatr
- AutoMapper
- FluentValidation

Database Migrations
To use dotnet-ef for your migrations first ensure that "UseInMemoryDatabase" is disabled, as described within previous section. Then, add the following flags to your command (values assume you are executing from repository root)

- project Core/Infrastructure (optional if in this folder)
- startup-project Presentation/EmployeeManagment.API
- output-dir /Infrastructure/Persistence/Migrations
For example, to add a new migration from the root folder:

dotnet ef migrations add "SampleMigration" --project Core\Infrastructure --startup-project Presentation\EmployeeManagement.APi --output-dir Persistence\Migrations

Domain
This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

Application
This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

Infrastructure
This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.
