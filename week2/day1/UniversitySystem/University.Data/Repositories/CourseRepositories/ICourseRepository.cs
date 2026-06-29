using System;
using System.Collections.Generic;
using System.Text;
using University.Data.Entities;

namespace University.Data.Repositories.CourseRepository;

public interface ICourseRepository
{
    List<Course> GetAll();
    Course? GetById(int id);
    void Add(Course course);
    void Update(Course course);
    void Delete(int id);
}

