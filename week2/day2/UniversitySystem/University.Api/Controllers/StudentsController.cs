using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using University.Core.DTOs;
using University.Core.Forms.StudentForm;
using University.Core.Services.StudentService;

namespace University.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;
        private readonly ILogger<StudentsController> _logger;

        public StudentsController(IStudentService studentService, ILogger<StudentsController> logger)
        {
            _service = studentService;
            _logger = logger;
        }

        [Authorize(Roles = "Teacher")]
        [HttpGet]
        [ProducesResponseType(typeof(List<StudentDto>), 200)]
        public ApiResponse GetAll()
        {
            _logger.LogInformation("Incoming request to get all students");
            return new ApiResponse(_service.GetAll());
        }

        [Authorize(Roles = "Teacher")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(StudentDto), 200)]
        [ProducesResponseType(404)]
        public ApiResponse GetById(int id)
        {
            _logger.LogInformation("Incoming request received for Student ID: {StudentId}", id);
            var student = _service.GetById(id);
            return new ApiResponse(student);
        }

        [Authorize(Roles = "Teacher")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public ApiResponse Create([FromBody] CreateStudentForm form)
        {
            _logger.LogInformation("Incoming request to create student with Email: {Email}", form.Email);
            _service.Create(form);
            return new ApiResponse("Student created successfully");
        }

        [Authorize(Roles = "Teacher")]
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ApiResponse Update(int id, [FromBody] UpdateStudentForm form)
        {
            _logger.LogInformation("Incoming request to update Student with ID: {StudentId}", id);
            _service.Update(id, form);
            return new ApiResponse("Student updated successfully");
        }

        [Authorize(Roles = "Teacher")]
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ApiResponse Delete(int id)
        {
            _logger.LogInformation("Incoming request to delete Student with ID: {StudentId}", id);
            _service.Delete(id);
            return new ApiResponse("Student deleted successfully");
        }
    }
}