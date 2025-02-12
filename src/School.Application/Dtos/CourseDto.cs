using School.Domain.Entities.Course;

namespace School.Application.Dtos;

public static class CourseMapper 
{
    public static CourseDto ToDto(this Course course)
    {
        return new CourseDto
        (
            Id: course.Id,
            Name: course.Name!,
            RegistrationFee: course.RegistrationFee,
            StartDate: course.StartDate,
            EndDate: course.EndDate
        );
    }
}
public sealed record CourseDto
(
    Guid Id,
    string Name,
    int RegistrationFee,
    DateTime StartDate,
    DateTime EndDate
);
