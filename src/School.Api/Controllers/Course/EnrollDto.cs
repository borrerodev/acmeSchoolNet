namespace School.Api.Controllers.Course;

public sealed record EnrollRequest
(
   Guid StudentId,
    Guid CourseId
);