using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace School.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssemblies(typeof(DependencyInjection).Assembly);
        });

        services.AddValidatorsFromAssemblies(new[] { typeof(DependencyInjection).Assembly });

        return services;
    }   
}