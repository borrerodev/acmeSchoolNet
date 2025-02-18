using Microsoft.EntityFrameworkCore;
using School.Infrastructure;

namespace School.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static async void ApplyMigrations(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider;
                var loggerFactory = dbContext.GetRequiredService<ILoggerFactory>();

                try
                {
                    var context = dbContext.GetRequiredService<SchoolDbContext>();
                    await context.Database.MigrateAsync();
                }
                catch (Exception ex)
                {
                   var logger = loggerFactory.CreateLogger<Program>(); 
                   logger.LogError(ex, "Error en el proceso de migración");
                }

            }
        }
    }
}