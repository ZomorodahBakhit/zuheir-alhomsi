using System;
using System.Collections.Generic;
using System.Text;
using University.Core.DTOs;
using University.Core.Forms.StudentForm;
using University.Data.Entities;

namespace University.Core.Services.StudentService;

public interface IStudentService
{
    List<StudentDto> GetAll();
    StudentDto? GetById(int id);
    void Create(CreateStudentForm form);
    void Update(int id, UpdateStudentForm form);
    void Delete(int id);
}
