### **Technologies**
- Clean Architecture
- ASP.NET CORE 7.0
- Entity FrameWork Core 7.0
- Mediatr
- AutoMapper
- FluentValidation
  

Database Migrations   
1. Open the `EmployeeManagement.sln` solution file with Visual Studio.

1. Using the Cloud SQL Server IP address, user and password you created preceding, modify your connection string in the `Web.config` file:

   ```XML
    
   "ConnectionStrings": {
        "EmployeeManagementDb": "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=employee_management;Integrated Security=True;Connect Timeout=60;TrustServerCertificate=True"
      } 
   ```
 
1. Set as startup project EmployeeManagement.Api
2. In Visual Studio, open the Package Manager Console from the **View** menu -> **Other Windows** -> **Package Manager Console**. 
   -  Default project Core\Infrastructure  
   -  Enter the following command:

   ```cmd
   PM> update-database
   ```
Domain
This will contain all entities, enums, exceptions, interfaces, types and logic specific to the domain layer.

Application
This layer contains all application logic. It is dependent on the domain layer, but has no dependencies on any other layer or project. This layer defines interfaces that are implemented by outside layers. For example, if the application need to access a notification service, a new interface would be added to application and an implementation would be created within infrastructure.

Infrastructure
This layer contains classes for accessing external resources such as file systems, web services, smtp, and so on. These classes should be based on interfaces defined within the application layer.
