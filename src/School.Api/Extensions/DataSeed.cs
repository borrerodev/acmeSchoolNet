using System.ComponentModel;
using School.Domain.Entities.Courses;
using School.Domain.Entities.Enrollments;
using School.Domain.Entities.Students;
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
                        var student2 = Student.Create("Jorge Armando", 20);
                        context.AddRange(new List<Student> { student1, student2 });
                         
                        await context.SaveChangesAsync();
                    }

                    if(!context.Set<Enrollment>().Any())
                    {
                        var student1 = context.Set<Student>().FirstOrDefault(x => x.Name == "John Doe");
                        var student2 = context.Set<Student>().FirstOrDefault(x => x.Name == "Jorge Armando");

                        var course1 = context.Set<Course>
                        ().FirstOrDefault(x => x.Name == "Mathematics");
                        var course2 = context.Set<Course>().FirstOrDefault(x => x.Name == "English");

                        var enrollment1 = Enrollment.Create(student1.Id, course1.Id);
                        Student.AssignCourse(student1, course1);

                        var enrollment2 = Enrollment.Create(student2.Id, course2.Id);
                        Student.AssignCourse(student2, course2);

                        context.AddRange(new List<Enrollment> { enrollment1, enrollment2 });

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