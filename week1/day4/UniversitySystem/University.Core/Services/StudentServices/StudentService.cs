using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using University.Core.DTOs;
using University.Core.Exceptions;
using University.Core.Forms.StudentForm;
using University.Core.Validation;
using University.Data.Entities;
using University.Data.Repositories.StudentRepositories.StudentRepositories;

namespace University.Core.Services.StudentService;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _repository;
    private readonly ILogger<StudentService> _logger;

    public StudentService(IStudentRepository repository , ILogger<StudentService> logger)
    {
        _repository = repository;
        _logger = logger;
    }
    public List<StudentDto> GetAll()
    {
        return _repository.GetAll().Select(s => new StudentDto { Id = s.Id, Name = s.Name , Email = s.Email }).ToList();
    }

    public StudentDto? GetById(int id)
    {
        var student = _repository.GetById(id);
        if (student == null) throw new NotFoundException("Student Not Found");
        return new StudentDto
        {
            Id = student.Id,
            Name = student.Name,
            Email = student.Email,
        };
    }
    public void Create(CreateStudentForm form)
    {
        var validation = FormValidator.Validate(form);

        if (!validation.IsValid)
        {
            _logger.LogWarning("Validation failed for CreateStudent payload. Errors: {@ValidationErrors}", validation.Errors);
            throw new BusinessException("The Student Form is invalid");
        }

        var student = new Student
        {
            Name = form.Name,
            Email = form.Email
        };
        _repository.Add(student);
    }

    public void Update(int id, UpdateStudentForm form)
    {
        var student = _repository.GetById(id);
        if (student == null) throw new NotFoundException("Student Not Found");

        if (!FormValidator.Validate(form).IsValid)
        {
            throw new BusinessException("The Student Form is invalid");
        }

        bool emailFound = _repository.GetAll()
            .Any(s => s.Id != id && s.Email.Equals(form.Email, StringComparison.OrdinalIgnoreCase));

        if (emailFound) throw new BusinessException("A student email already exists");
       

        student.Name = form.Name;
        student.Email = form.Email;
        _repository.Update(student);
    }

    public void Delete(int id)
    {
        var student = _repository.GetById(id);
        if (student == null) throw new NotFoundException("Student Not Found");
        _repository.Delete(id);
    }
}
