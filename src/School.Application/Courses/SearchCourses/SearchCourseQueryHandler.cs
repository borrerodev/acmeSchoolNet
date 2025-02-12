namespace School.Application.Courses.SearchCourses;

using MediatR;
using School.Application.Dtos;
using School.Domain.Entities.Courses;

public sealed class SearchCourseQueryHandler : IRequestHandler<SearchCourseQuery, List<CourseDto>>
{
    private readonly ICourseRepository _courseRepository;
    public SearchCourseQueryHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<List<CourseDto>> Handle(SearchCourseQuery request, CancellationToken cancellationToken)
    {
        var courses = await _courseRepository.GetByRange(request.StartDate, request.EndDate, cancellationToken);
        
        return courses.ConvertAll(course => course.ToDto());        
    }
}
