### **Technologies**
- Clean Architecture
- ASP.NET CORE 7.0
- Entity FrameWork Core 7.0
- Mediatr
- AutoMapper
- FluentValidation
  

### **Database Migrations**
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
 ### **Note**
 All
 http://localhost:5229/api/v1/employee   
 Filter 
 http://localhost:5229/api/v1/employee?qname=emin
  - qname -  name variable in the response data
 
