using System;
using FlintSoft.CRM.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FlintSoft.CRM.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services) {
        
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}
