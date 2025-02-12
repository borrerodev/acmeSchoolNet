using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using School.Domain.Abstractions;
using School.Domain.Entities.Course;
using School.Domain.Entities.Student;
using School.Infrastructure.Repositories;

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

            options.UseSqlite(
                configuration.GetConnectionString("SqliteSchoolConnection")                
            ).UseSnakeCaseNamingConvention();
        });
        
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<SchoolDbContext>());
        services.AddScoped<ICourseRepository, CourseRepository>();
        services.AddScoped<IStudentRepository, StudentRepository>();
        
        return services;
    }
}
