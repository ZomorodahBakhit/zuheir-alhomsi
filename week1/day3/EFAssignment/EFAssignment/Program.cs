using EFAssignment;
using EFAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;

Console.WriteLine("Hello , World!");
using var db = new UniversityDbContext();

// Insert Data (via C# code) Data for all the interns into the user table with Role ‘Student’ ,Two teachers (Sami, Feryal)

var interns = new List<User>
{
    new User { UserName = "Zuhair Alhomsi", FirstName = "Zuhair", LastName = "Alhomsi", EmailAddress = "zuheiralhomsi73@gmail.com", PhoneNumber = "+963 992 042 713", Role = "Student" },
    new User { UserName = "Ayman durra", FirstName = "Ayman", LastName = "durra", EmailAddress = "aymndurra099@gmail.com", PhoneNumber = "+963 999 042 713", Role = "Student" },
    new User { UserName = "Motaz Al Masri", FirstName = "Motaz", LastName = "AL Masri", EmailAddress = "motazalmasri@gmail.com", PhoneNumber = "+963 999 942 713", Role = "Student" },
    new User { UserName = "Fawzy Sukkar", FirstName = "Fawzy", LastName = "Sukkar", EmailAddress = "fawzysukkar2005@gmail.com", PhoneNumber = "+963 999 992 713", Role = "Student" },
    new User { UserName = "Mehyar Khuder", FirstName = "Mehyar", LastName = "Khuder", EmailAddress = "mehyarkuder11@gmail.com", PhoneNumber = "+963 999 999 813", Role = "Student" },
    new User { UserName = "Nawar Al Tibi", FirstName = "Nawar", LastName = "Altibi", EmailAddress = "nawaraltibi46@gmail.com", PhoneNumber = "+963 999 999 913", Role = "Student" },
    new User { UserName = "Ahmed Khaled", FirstName = "Ahmed", LastName = "Khaled", EmailAddress = "eng.ahmadkhaled21@gmail.com", PhoneNumber = "+963 999 999 993", Role = "Student" },
    new User { UserName = "moaaz zakaria", FirstName = "Moaaz", LastName = "Zakaria", EmailAddress = "mouazzakaria0@gmail.com", PhoneNumber = "+963 999 999 999", Role = "Student" },
    new User { UserName = "Aya Jazba", FirstName = "Aya", LastName = "jazba", EmailAddress = "ayajazba2005@gmail.com", PhoneNumber = "+963 999 999 317", Role = "Student" },
    new User { UserName = "Masa Hammoud", FirstName = "Masa", LastName = "Hammoud", EmailAddress = "masahammoud05@gmail.com", PhoneNumber = "+963 999 999 137", Role = "Student" },
    new User { UserName = "Hiba Jazba", FirstName = "Hiba", LastName = "Jazba", EmailAddress = "hibajazba7@gmail.com", PhoneNumber = "+963 999 999 711", Role = "Student" },
    new User { UserName = "yehyam", FirstName = "Yehya", LastName = "Yam", EmailAddress = "yehyam6611@gmail.com", PhoneNumber = "+963 999 999 731", Role = "Student" },

};

var teacher = new List<User>
{
    new User {UserName = "Sami Hijazi", FirstName = "Sami", LastName = "Hijazi",EmailAddress = "sami.hijazi@gmail.com",PhoneNumber = "+963 999 999 791",Role = "Teacher"},
    new User {UserName = "Feryal tulaimat" , FirstName = "Feryal", LastName = "tulaimat",EmailAddress = "feryal.tulaimat@gmail.com",PhoneNumber = "+963 999 999 739",Role = "Teacher"},
};

//db.Users.AddRange(interns);
//db.Users.AddRange(teacher);
//try { db.SaveChanges(); } catch(Exception e) { Console.WriteLine(e); }

// At least 5 courses assigned to that teacher (SQL, C#, Entity Framework, Web API and React)s

var courses = new List<Course>
{
    new Course { CourseName = "SQL", TeacherId = 13, StartDate = new DateTime(2026, 6, 22, 9, 0, 0), EndDate = new DateTime(2026, 6, 22, 9, 10, 0) },
    new Course { CourseName = "C#", TeacherId = 13, StartDate = new DateTime(2026, 6, 22, 9, 0, 0), EndDate = new DateTime(2026, 6, 22, 9, 20, 0) },
    new Course { CourseName = "Entity FrameWork", TeacherId = 13, StartDate = new DateTime(2026, 6, 22, 9, 0, 0), EndDate = new DateTime(2026, 6, 22, 9, 20, 0) },
    new Course { CourseName = "Web API", TeacherId = 14, StartDate = new DateTime(2026, 6, 22, 9, 0, 0), EndDate = new DateTime(2026, 6, 22, 9, 20, 0) },
    new Course { CourseName = "React Courses", TeacherId = 14, StartDate = new DateTime(2026, 6, 22, 9, 0, 0), EndDate = new DateTime(2026, 6, 22, 9, 30, 0) }
};

//db.Courses.AddRange(courses);
//try { db.SaveChanges(); } catch (Exception e) { Console.WriteLine(e); }

// At least 5 assignments per course with random due dates (past & future).

var assignments = new List<Assignment>
{
    new Assignment { CourseId = 1, AssignmentTitle = "Database", Description = "Introduction to Database", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026, 6, 26) },
    new Assignment { CourseId = 1, AssignmentTitle = "CRUD", Description = "Essential DDL", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026, 6, 27) },
    new Assignment { CourseId = 1, AssignmentTitle = "KEYS", Description = "PK , FK , UK", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026, 6, 28) },
    new Assignment { CourseId = 1, AssignmentTitle = "Relations", Description = "One to Many , Many to Many", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026, 6, 29) },
    new Assignment { CourseId = 1, AssignmentTitle = "Procedure", Description = "Functions in SQL", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026, 6, 30) },

    new Assignment { CourseId = 2, AssignmentTitle = "Variables", Description = "Introduction to C#", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026, 7, 1) },
    new Assignment { CourseId = 2, AssignmentTitle = "Statment", Description = "For , if , switch", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026, 7, 2) },
    new Assignment { CourseId = 2, AssignmentTitle = "Functions", Description = "Functions in C#", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026, 7, 3) },
    new Assignment { CourseId = 2, AssignmentTitle = "Classes", Description = "One to Many , Many to Many", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026, 7, 4) },
    new Assignment { CourseId = 2, AssignmentTitle = "OOP", Description = "Inheritence , Encapsulation , Abstractions , Polymorphism , Interface", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026, 7, 5) },

    new Assignment { CourseId = 3, AssignmentTitle = "Data-First Synchronization", Description = "Reverse Engineering and Query Optimization", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026, 7, 6) },
    new Assignment { CourseId = 3, AssignmentTitle = "Domain-Driven Design", Description = "Building an E-Commerce Backend with Code-First Migrations", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026, 7, 7) },
    new Assignment { CourseId = 3, AssignmentTitle = "Advanced Querying", Description = "Implementing Efficient Eager, Lazy, and Explicit Loading", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026, 7, 8) },
    new Assignment { CourseId = 3, AssignmentTitle = "Architectural Separation", Description = "Implementing the Repository Pattern with DbContext", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026, 7, 9) },
    new Assignment { CourseId = 3, AssignmentTitle = "Enterprise Performance Tuning", Description = "Tracking Management and Global Query Filtering", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026, 7, 10) },

    new Assignment { CourseId = 4, AssignmentTitle = "RestAPI", Description = "Introduction to RestAPI", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026, 7, 11) },
    new Assignment { CourseId = 4, AssignmentTitle = "Post", Description = "Sends data to the server", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026, 7, 12) },
    new Assignment { CourseId = 4, AssignmentTitle = "GET", Description = "Requesting data from the server", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026, 7, 13) },
    new Assignment { CourseId = 4, AssignmentTitle = "Patch", Description = "Edit data on DB", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026, 7, 14) },
    new Assignment { CourseId = 4, AssignmentTitle = "Delete", Description = "instruct a server to remove a specific resource", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026, 7, 15) },

    new Assignment { CourseId = 5, AssignmentTitle = "Components", Description = "Reusable code", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026, 7, 16) },
    new Assignment { CourseId = 5, AssignmentTitle = "Props", Description = "Data from parent", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026, 7, 17) },
    new Assignment { CourseId = 5, AssignmentTitle = "Drilling", Description = "When the props data drilling in the tree Parent-Child", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026, 7, 18) },
    new Assignment { CourseId = 5, AssignmentTitle = "State", Description = "store and manage dynamic data that influences their behavior and appearance", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026, 7, 19) },
    new Assignment { CourseId = 5, AssignmentTitle = "Hooks", Description = "JavaScript function provided by the React library", Weight = 20, MaxGrade = 100, DueDate = new DateOnly(2026, 7, 20) }
};

//db.Assignments.AddRange(assignments);
//try { db.SaveChanges(); } catch (Exception e) { Console.WriteLine(e); }

// At least 10 comments for random assignments

var comments = new List<Comment>
{
    new Comment { AssignmentId = 1, CreatedByUserId = 1, CreatedDate = new DateTime(2026, 8, 11), CommentContent = "First Comment" },
    new Comment { AssignmentId = 4, CreatedByUserId = 4, CreatedDate = new DateTime(2026, 8, 12), CommentContent = "Second Comment" },
    new Comment { AssignmentId = 7, CreatedByUserId = 5, CreatedDate = new DateTime(2026, 8, 24), CommentContent = "Third Comment" },
    new Comment { AssignmentId = 8, CreatedByUserId = 3, CreatedDate = new DateTime(2026, 8, 22), CommentContent = "Fourth Comment" },
    new Comment { AssignmentId = 11, CreatedByUserId = 2, CreatedDate = new DateTime(2026, 8, 17), CommentContent = "Fifth Comment" },
    new Comment { AssignmentId = 13, CreatedByUserId = 9, CreatedDate = new DateTime(2026, 8, 27), CommentContent = "Sixth Comment" },
    new Comment { AssignmentId = 15, CreatedByUserId = 2, CreatedDate = new DateTime(2026, 8, 21), CommentContent = "Seventh Comment" },
    new Comment { AssignmentId = 16, CreatedByUserId = 11, CreatedDate = new DateTime(2026, 8, 13), CommentContent = "Eigth Comment" },
    new Comment { AssignmentId = 23, CreatedByUserId = 6, CreatedDate = new DateTime(2026, 8, 17), CommentContent = "Ninth Comment" },
    new Comment { AssignmentId = 25, CreatedByUserId = 1, CreatedDate = new DateTime(2026, 8, 19), CommentContent = "Last Comment" }
};

//db.Comments.AddRange(comments);
//try { db.SaveChanges(); } catch (Exception e) { Console.WriteLine(e); }

// A grade for each student per assignment

var allStudents = db.Users.Where(u => u.Role == "Student").ToList();
var allAssignments = db.Assignments.ToList();

var random = new Random();
var Grades = new List<Grade>();

foreach (var student in allStudents)
{
    foreach (var assignment in allAssignments)
    {
        var newGrade = new Grade
        {
            StudentId = student.UserId,
            AssignmentId = assignment.AssignmentId,
            GradeVal = random.Next(0, assignment.MaxGrade + 1)
        };

        Grades.Add(newGrade);
    }
}
//db.Grades.AddRange(Grades);
//try { db.SaveChanges(); } catch (Exception e) { Console.WriteLine(e); }

// A syllabus for each course

var syllabus = new List<Syllabus>();

for (int i = 1; i <= 5; i++) syllabus.Add(new Syllabus {CourseId = i, Description = $"Syllabus for Course {i}" });

//db.Syllabus.AddRange(syllabus);
//try { db.SaveChanges(); } catch (Exception e) { Console.WriteLine(e); }

using var context = new UniversityDbContext();

// List all courses

var course = context.Courses;
foreach (var x in course) Console.WriteLine($"{x.CourseId} , Name: {x.CourseName}");

// Show all assignments for a specific course

var assign = context.Assignments.Where(a => a.CourseId == 1).ToList();
foreach (var x in assign) Console.WriteLine($"{x.AssignmentTitle}");


// List all students

var st = context.Users.Where(u => u.Role == "Student");
foreach(var x in st) Console.WriteLine($"{x.UserName}");

// Show all comments for a given assignment

var cm = context.Comments.Where(c => c.AssignmentId == 1);
foreach (var x in cm) Console.WriteLine($"{x.CommentContent}");

// how all grades for a student

var gr = context.Grade.Where(g => g.StudentId == 1);
foreach (var x in gr) Console.WriteLine($"{x.GradeVal}");

//  List each assignment with its course and the teacher’s full name

var asd = context.Assignments.Include(a => a.Course).ThenInclude(c => c.Teacher).ToList();
foreach (var x in asd) Console.WriteLine($"{x.AssignmentTitle} , {(x.Course.Teacher != null ? x.Course.Teacher.UserName : "Unknown")}");

// Query to show average grade per course

var avgGrades = context.Grade.Include(g => g.Assignment).ThenInclude(a => a.Course).GroupBy(g => g.Assignment.Course.CourseName).Select(group => new
    {
        CourseName = group.Key,
        Avg = group.Average(g => g.GradeVal)
    }).ToList();

foreach (var x in avgGrades) Console.WriteLine($"{x.CourseName} , Avg: {x.Avg}");

// Create a method to return letter grades (A, B, C, etc.) based on the student’s performance

Console.WriteLine(Functions.CalculateGradeInCourse(1 , 1 , context));

// Create a method to calculate GPA for a student

Console.WriteLine(Functions.CalculateGPA(1, context));

// Update a student’s role to “Teacher”

context.Users.Where(u => u.UserId == 1).ExecuteUpdate(s => s.SetProperty(u => u.Role, "Teacher"));

// Delete a specific comment
context.Comments.Where(c => c.CommentId == 1).ExecuteDelete();