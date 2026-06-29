using University.Data.Entities;
using University.Data.Repositories.StudentRepositories.StudentRepositories;

namespace University.Data.Repositories.StudentRepositories;

public class StudentRepository : IStudentRepository
{
    private readonly UniversityDbContext _context;
    public StudentRepository(UniversityDbContext context)
    {
        _context = context;
    }

    public List<Student> GetAll()
    {
        return _context.Students.ToList();
    }

    public Student? GetById(int id)
    {
        return _context.Students.Find(id);
    }

    public void Add(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
    }

    public void Update(Student student)
    {
        _context.Students.Update(student);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var student = _context.Students.Find(id);
        if (student != null)
        {
            _context.Students.Remove(student);
            _context.SaveChanges();
        }
    }
}