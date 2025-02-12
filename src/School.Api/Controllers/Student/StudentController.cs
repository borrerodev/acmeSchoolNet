using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.Students.CreateStudent;

namespace School.Api.Controllers.Student
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ISender _sender;
        public StudentController(ISender sender)
        {
            _sender = sender;
        }
    
        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] StudentRequest request)
        {
            var command = new CreateStudentCommand(request.Name, request.Age);
            var studentId = await _sender.Send(command);
            return Ok(studentId);
        }     

    }
}
