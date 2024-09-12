using System.Reflection;
using FlintSoft.CRM.Api.Errors;
using FlintSoft.CRM.Api.Filters;
using FlintSoft.CRM.Api.Middleware;
using FlintSoft.CRM.Application;
using FlintSoft.CRM.Infrastructure;
using FlintSoft.Endpoints;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());
// builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
builder.Services.AddControllers();
builder.Services.AddSingleton<ProblemDetailsFactory, CustomProblemsDetailsFactory>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error");

//app.UseMiddleware<ErrorHandlingMiddleware>();

// app.UseHttpsRedirection();

// app.MapEndpoints(app);
app.MapControllers();

app.Run();