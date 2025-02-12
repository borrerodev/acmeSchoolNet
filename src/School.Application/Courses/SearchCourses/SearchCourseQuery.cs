using MediatR;
using School.Application.Dtos;

namespace School.Application.Courses.SearchCourses;

public sealed class SearchCourseQuery : IRequest<List<CourseDto>>
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
