using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using University.Core.DTOs;
using University.Core.Exceptions;
using University.Core.Forms.CourseForm;
using University.Core.Validation;
using University.Data.Entities;
using University.Data.Repositories.CourseRepository;

namespace University.Core.Services.CourseService;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _repository;
    private readonly ILogger<CourseService> _logger;

    public CourseService(ICourseRepository repository, ILogger<CourseService> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public List<CourseDto> GetAll()
    {
        return _repository.GetAll()
            .Select(c => new CourseDto
            {
                Id = c.Id,
                Name = c.Name,
                TeacherId = c.TeacherId,
                StartDate = c.StartDate,
                EndDate = c.EndDate,
                SyllabusId = c.SyllabusId
            }).ToList();
    }

    public CourseDto? GetById(int id)
    {
        var course = _repository.GetById(id);
        if (course == null)
        {
            _logger.LogError("Course with ID {CourseId} was not found", id);
            throw new NotFoundException("Course Not Found");
        }

        return new CourseDto
        {
            Id = course.Id,
            Name = course.Name,
            TeacherId = course.TeacherId,
            StartDate = course.StartDate,
            EndDate = course.EndDate,
            SyllabusId = course.SyllabusId
        };
    }

    public void Create(CreateCourseForm form)
    {
        var validation = FormValidator.Validate(form);

        if (!validation.IsValid)
        {
            _logger.LogWarning("Validation failed for CreateCourse payload. Errors: {@ValidationErrors}", validation.Errors);
            throw new BusinessException("The Course Form is invalid");
        }

        var course = new Course
        {
            Name = form.Name,
            TeacherId = form.TeacherId,
            StartDate = form.StartDate,
            EndDate = form.EndDate,
            SyllabusId = form.SyllabusId
        };
        _repository.Add(course);
    }

    public void Update(int id, UpdateCourseForm form)
    {
        var course = _repository.GetById(id);
        if (course == null)
        {
            _logger.LogError("Course with ID {CourseId} was not found for update", id);
            throw new NotFoundException("Course Not Found");
        }

        var validation = FormValidator.Validate(form);

        if (!validation.IsValid)
        {
            _logger.LogWarning("Validation failed for UpdateCourse payload. Errors: {@ValidationErrors}", validation.Errors);
            throw new BusinessException("The Course Form is invalid");
        }

        course.Name = form.Name;
        course.TeacherId = form.TeacherId;
        course.StartDate = form.StartDate;
        course.EndDate = form.EndDate;
        course.SyllabusId = form.SyllabusId;

        _repository.Update(course);
    }

    public void Delete(int id)
    {
        var course = _repository.GetById(id);
        if (course == null)
        {
            _logger.LogError("Course with ID {CourseId} was not found for deletion", id);
            throw new NotFoundException("Course Not Found");
        }

        _repository.Delete(id);
    }
}