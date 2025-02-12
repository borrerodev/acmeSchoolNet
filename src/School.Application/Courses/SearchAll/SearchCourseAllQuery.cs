using MediatR;
using School.Domain.Entities.Courses;

namespace School.Application.Courses.SearchAll;

public sealed class SearchCourseAllQuery : IRequest<List<Course>>
{
   
}