using FlintSoft.CRM.Application.Common.Interfaces.Authentication;
using FlintSoft.CRM.Application.Common.Interfaces.Services;
using FlintSoft.CRM.Infrastructure.Authentication;
using FlintSoft.CRM.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlintSoft.CRM.Infrastructure;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) {

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        
        return services;
    }
}