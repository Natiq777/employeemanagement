using EmployeeManagement.Api.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterService(builder.Configuration);

var app = builder.Build();

app.ConfigureSwagger();

app.MapControllers();

app.Run();