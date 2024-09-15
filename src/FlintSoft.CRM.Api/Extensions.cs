using FlintSoft.CRM.Api.Common.Errors;
using FlintSoft.CRM.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace FlintSoft.CRM.Api;

public static class Extensions
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, CustomProblemsDetailsFactory>();

        services.AddMappings();

        return services;
    }
}
