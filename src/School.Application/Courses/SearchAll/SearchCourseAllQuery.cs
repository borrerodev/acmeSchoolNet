using MediatR;
using School.Domain.Entities.Course;

namespace School.Application.Courses.SearchAll;

public sealed class SearchCourseAllQuery : IRequest<List<Course>>
{
   
}