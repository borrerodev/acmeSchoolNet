namespace School.Application.Courses.SearchAll;

using MediatR;
using School.Domain.Entities.Courses;

public sealed class SearchCourseAllQueryHandler : IRequestHandler<SearchCourseAllQuery, List<Course>>
{
    private readonly ICourseRepository _courseRepository;
    public SearchCourseAllQueryHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<List<Course>> Handle(SearchCourseAllQuery request, CancellationToken cancellationToken)
    {
        var courses = await _courseRepository.GetAll(cancellationToken);
        
        return courses;
    }
}
