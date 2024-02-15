using Microsoft.AspNetCore.SignalR;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net.NetworkInformation;
using WebApplication2.Services.Interfaces;
using WebApplication2.Services;
using WebApplication2.Repository.Interfaces;
using WebApplication2.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Add the Services and Repositories here
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<CustomerService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

//Data Source = APINP - ELPTOH9CG\SQLEXPRESS; Initial Catalog = chubb; User ID = tap2023; Password = ***********; Encrypt = False
