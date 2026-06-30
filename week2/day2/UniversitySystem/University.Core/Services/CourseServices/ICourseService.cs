using System;
using System.Collections.Generic;
using System.Text;
using University.Core.DTOs;
using University.Core.Forms.CourseForm;
using University.Core.Forms.StudentForm;

namespace University.Core.Services.CourseService;

public interface ICourseService
{
    List<CourseDto> GetAll();
    CourseDto? GetById(int id);
    void Create(CreateCourseForm form);
    void Update(int id, UpdateCourseForm form);
    void Delete(int id);
}
