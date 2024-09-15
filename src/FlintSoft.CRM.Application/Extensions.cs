using Microsoft.Extensions.DependencyInjection;

namespace FlintSoft.CRM.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblyContaining(typeof(Extensions)));

        return services;
    }
}
