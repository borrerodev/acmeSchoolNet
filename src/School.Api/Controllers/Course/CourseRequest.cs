namespace School.Api.Controllers.Course;

public sealed record CourseRequest
(
    string Name,
    int RegistrationFee,
    DateTime StartDate ,
    DateTime EndDate 
);
