using System.ComponentModel;
using School.Domain.Entities.Course;
using School.Domain.Entities.Student;
using School.Infrastructure;

namespace School.Api.Extensions
{
    public static class DataSeed
    {
        public static async Task SeedSchoolCourse(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var service = scope.ServiceProvider;
                var loggerFactory = service.GetRequiredService<ILoggerFactory>();

                try
                {
                    var context = service.GetRequiredService<SchoolDbContext>();  

                    if(!context.Set<Course>().Any())
                    {
                        var courseMath = Course.Create("Mathematics", 1000, DateTime.Now,DateTime.Now);
                        var courseEnglish = Course.Create("English", 1000, DateTime.Now,DateTime.Now);                                                                    
                        context.AddRange(new List<Course> { courseEnglish, courseMath });

                        await context.SaveChangesAsync();
                    }  

                    if(!context.Set<Student>().Any())
                    {
                        var student1 = Student.Create("John Doe", 19);
                        var student2 = Student.Create("Jane Doe", 20);
                        context.AddRange(new List<Student> { student1, student2 });
                         
                        await context.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<SchoolDbContext>();
                    logger.LogError(ex, ex.Message);
                }
            }
        }       
    }
}   