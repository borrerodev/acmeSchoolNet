using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace School.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services, 
        IConfiguration configuration)
    {
        services.AddDbContext<SchoolDbContext>(options => {
            options.LogTo(Console.WriteLine, new [] 
            {
                DbLoggerCategory.Database.Command.Name
            }, LogLevel.Information).EnableSensitiveDataLogging();

            options.UseSqlite(configuration.GetConnectionString("SqliteSchoolConnection"));
        });
        
        return services;
    }
}
