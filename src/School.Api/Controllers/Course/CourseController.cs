using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.Courses.CreateCourse;
using School.Application.Courses.SearchAll;
using School.Application.Courses.SearchCourses;

namespace School.Api.Controllers.Course
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ISender _sender;
        public CourseController(ISender sender)
        {
            _sender = sender;
        }

        //http://localhost:5000/api/Course/all
        [HttpGet("all")]
        public async Task<IActionResult> GetCourses()
        {
            var courses = await _sender.Send(new SearchCourseAllQuery());
            return Ok(courses);
        }

        //http://localhost:5000/api/Course/startDate=2021-01-01&endDate=2021-12-31
       [HttpGet]
        public async Task<IActionResult> GetByRangeDate([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            var query = new SearchCourseQuery()
            {
                StartDate = startDate,
                EndDate = endDate
            };
            var courses = await _sender.Send(query);
            return Ok(courses);
        }
        

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CourseRequest request)
        {
            var command = new CreateCourseCommand(request.Name, request.RegistrationFee, request.StartDate, request.EndDate);
            var courseId = await _sender.Send(command);
            return Ok(courseId);
        }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> EnrollStudent(int id, [FromBody] CourseDto courseDto)
        // {
        //     var course = await _courseService.UpdateCourseAsync(id, courseDto);
        //     return Ok(course);
        // }

    }
}
