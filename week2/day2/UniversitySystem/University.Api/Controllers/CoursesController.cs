using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using University.Core.DTOs;
using University.Core.Forms.CourseForm;
using University.Core.Services.CourseService;

namespace University.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseService _service;
        private readonly ILogger<CoursesController> _logger;

        public CoursesController(ICourseService courseService, ILogger<CoursesController> logger)
        {
            _service = courseService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CourseDto>), 200)]
        public ApiResponse GetAll()
        {
            _logger.LogInformation("Incoming request to get all courses");
            return new ApiResponse(_service.GetAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CourseDto), 200)]
        [ProducesResponseType(404)]
        public ApiResponse GetById(int id)
        {
            _logger.LogInformation("Incoming request to get Course with ID: {CourseId}", id);
            var course = _service.GetById(id);
            return new ApiResponse(course);
        }

        [Authorize(Roles = "Teacher")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]

        public ApiResponse Create([FromBody] CreateCourseForm form)
        {
            _logger.LogInformation("Incoming request to create course with Name: {CourseName}", form.Name);
            _service.Create(form);
            return new ApiResponse("Course created successfully");
        }

        [Authorize(Roles = "Teacher")]
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ApiResponse Update(int id, [FromBody] UpdateCourseForm form)
        {
            _logger.LogInformation("Incoming request to update Course with ID: {CourseId}", id);
            _service.Update(id, form);
            return new ApiResponse("Course updated successfully");
        }

        [Authorize(Roles = "Teacher")]
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ApiResponse Delete(int id)
        {
            _logger.LogInformation("Incoming request to delete Course with ID: {CourseId}", id);
            _service.Delete(id);
            return new ApiResponse("Course deleted successfully");
        }
    }
}