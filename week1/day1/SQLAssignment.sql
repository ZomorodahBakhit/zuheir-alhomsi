CREATE TABLE Users(
	UserId INT PRIMARY KEY,
	UserName VARCHAR(64) NOT NULL,
	FirstName VARCHAR(64) NOT NULL,
	LastName VARCHAR(64) NOT NULL,
	EmailAddress VARCHAR(128) NOT NULL,
	PhoneNumber VARCHAR(16) NOT NULL,
	Role VARCHAR(32) NOT NULL
);

CREATE TABLE Courses(
	CourseId INT PRIMARY KEY,
	CourseName VARCHAR(100) NOT NULL,
	TeacherId INT NULL,
	StartDate DateTime NOT NULL,
	EndDate DateTime NOT NULL,
	SyllabusId INT NULL
);

CREATE TABLE Assignments (
	AssignmentId INT PRIMARY KEY,
	CourseId INT NOT NULL,
	AssignmentTitle VARCHAR(128) NOT NULL,
	Description TEXT NULL,
	Weight float NOT NULL,
	MaxGrade INT NOT NULL,
	DueDate DATE NOT NULL
);

CREATE TABLE Comments(
	CommentId INT PRIMARY KEY,
	AssignmentId INT NOT NULL,
	CreatedByUserId  INT NOT NULL,
	CreatedDate DateTime NOT NULL,
	CommentContent TEXT NULL
);

CREATE TABLE Grades (
	GradeId INT PRIMARY KEY,
	AssignmentId INT NOT NULL,
	StudentId INT NOT NULL,
	Grade INT NULL
);

CREATE TABLE Syllabus (SyllabusId INT PRIMARY KEY, Description TEXT NULL);

ALTER TABLE Users
ADD UNIQUE (EmailAddress);

/*INSERT INTO Users(UserId , UserName , FirstName, LastName , EmailAddress , PhoneNumber , Role)
VALUES()*/

/*Write SQL statements to INSERT data for all the interns into the user table with Role ‘Student’*/
CREATE PROCEDURE AddUsers
	@UserId INT,
	@UserName VARCHAR(64),
	@FirstName VARCHAR(64),
	@LastName VARCHAR(64),
	@EmailAddress VARCHAR(128),
	@PhoneNumber VARCHAR(16),
	@Role VARCHAR(32) = 'Student'

AS BEGIN
	INSERT INTO Users(UserId , UserName , FirstName, LastName , EmailAddress , PhoneNumber , Role)
	VALUES(@UserId , @UserName , @FirstName , @LastName , @EmailAddress , @PhoneNumber , @Role)
END;

EXEC AddUsers 
	1, 'Zuhair Alhomsi', 'Zuhair', 'Alhomsi' , 'zuheiralhomsi73@gmail.com', '+963 992 042 713' 

EXEC AddUsers 
	2,'Ayman durra','Ayman', 'durra', 'aymndurra099@gmail.com', '+963 999 042 713'

EXEC AddUsers
	3,'Motaz Al Masri','Motaz', 'AL Masri', 'motazalmasri@gmail.com', '+963 999 942 713'

EXEC AddUsers
	4,'Fawzy Sukkar','Fawzy', 'Sukkar', 'fawzysukkar2005@gmail.com', '+963 999 992 713'

EXEC AddUsers 
	5,'Mehyar Khuder','Mehyar', 'Khuder', 'mehyarkuder11@gmail.com', '+963 999 999 813'

EXEC AddUsers
	6,'Nawar Al Tibi','Nawar', 'Altibi', 'nawaraltibi46@gmail.com', '+963 999 999 913'

EXEC AddUsers 
	7,'Ahmed Khaled','Ahmed', 'Khaled', 'eng.ahmadkhaled21@gmail.com', '+963 999 999 993'

EXEC AddUsers 
	8,'moaaz zakaria','Moaaz', 'Zakaria', 'mouazzakaria0@gmail.com', '+963 999 999 999'

EXEC AddUsers 
	9,'Aya Jazba','Aya', 'jazba', 'ayajazba2005@gmail.com', '+963 999 999 317'

EXEC AddUsers 
	10,'Masa Hammoud','Masa', 'Hammoud', 'masahammoud05@gmail.com', '+963 999 999 137'

EXEC AddUsers 
	11,'Hiba Jazba','Hiba', 'Jazba', 'hibajazba7@gmail.com', '+963 999 999 711'

EXEC AddUsers
	12,'yehyam','Yehya', 'Yam', 'yehyam6611@gmail.com', '+963 999 999 731'


/*Write SQL statements to INSERT data for Sami, Feryal into the user table with Role ‘Teacher’*/

EXEC AddUsers 
	13,'Sami Hijazi','Sami', 'Hijazi', 'sami.hijazi@gmail.com', '+963 999 999 791', 'Teacher'

EXEC AddUsers 
	14,'Feryal tulaimat','Feryal', 'tulaimat', 'feryal.tulaimat@gmail.com', '+963 999 999 739' , 'Teacher'

/*Write SQL statements to INSERT data for SQL, C#, Entity Framework, Web API and React Courses.*/
ALTER TABLE Courses
ADD CONSTRAINT FK_Syllabus_Courses
FOREIGN KEY (SyllabusId) 
REFERENCES Syllabus(SyllabusId)

CREATE PROCEDURE AddCourses
	@CourseId INT,
	@CourseName VARCHAR(100),
	@TeacherId INT,
	@StartDate DateTime,
	@EndDate DateTime,
	@SyllabusId INT

AS BEGIN
	INSERT INTO Courses(CourseId , CourseName , TeacherId, StartDate , EndDate , SyllabusId)
	VALUES(@CourseId , @CourseName , @TeacherId, @StartDate , @EndDate , @SyllabusId)
END;

EXEC AddCourses 1 , 'SQL' , 13 ,  '2026-06-22 09:00:00' , '2026-06-22 09:10:00' , NULL
EXEC AddCourses 2 , 'C#' , 13 ,  '2026-06-22 09:00:00' , '2026-06-22 09:20:00' , NULL
EXEC AddCourses 3 , 'Entity FrameWork' , 13 ,  '2026-06-22 09:00:00' , '2026-06-22 09:20:00' , NULL
EXEC AddCourses 4 , 'Web API' , 14 ,  '2026-06-22 09:00:00' , '2026-06-22 09:20:00' , NULL
EXEC AddCourses 5 , 'React Courses' , 14 ,  '2026-06-22 09:00:00' , '2026-06-22 09:30:00' , NULL

/*Write SQL Statements to INSERT at least 5 Assignments for each Course with random due dates (past & future).*/
ALTER TABLE Assignments
ADD CONSTRAINT FK_Assignments_Courses
FOREIGN KEY (CourseId) 
REFERENCES Courses(CourseId)

CREATE PROCEDURE AddAssignments
	@AssignmentId INT,
	@CourseId INT,
	@AssignmentTitle VARCHAR(128),
	@Description TEXT,
	@Weight float,
	@MaxGrade INT,
	@DueDate DATE

AS BEGIN
	INSERT INTO Assignments(AssignmentId  , CourseId , AssignmentTitle, Description , Weight , MaxGrade ,DueDate)
	VALUES(@AssignmentId  , @CourseId , @AssignmentTitle, @Description , @Weight , @MaxGrade ,@DueDate)
END;

EXEC AddAssignments 1 , 1 , 'Database' , 'Introduction to Database' , 20 , 100 , '2026-06-26'
EXEC AddAssignments 2 , 1 , 'CRUD' , 'Essential DDL' , 20 , 100 , '2026-06-27'
EXEC AddAssignments 3 , 1 , 'KEYS' , 'PK , FK , UK' , 20 , 100 , '2026-06-28'
EXEC AddAssignments 4 , 1 , 'Relations' , 'One to Many , Many to Many' , 20 , 100 , '2026-06-29'
EXEC AddAssignments 5 , 1 , 'Procedure' , 'Functions in SQL' , 20 , 100 , '2026-06-30'


EXEC AddAssignments 6 , 2 , 'Variables' , 'Introduction to C#' , 20 , 100 , '2026-07-01'
EXEC AddAssignments 7 , 2 , 'Statment' , 'For , if , switch' , 20 , 100 , '2026-07-02'
EXEC AddAssignments 8 , 2 , 'Functions' , 'Functions in C#' , 20 , 100 , '2026-07-03'
EXEC AddAssignments 9 , 2 , 'Classes' , 'One to Many , Many to Many' , 20 , 100 , '2026-07-04'
EXEC AddAssignments 10 , 2 , 'OOP' , 'Inheritence , Encapsulation , Abstractions , Polymorphism , Interface' , 20 , 100 , '2026-07-05'

EXEC AddAssignments 11 , 3 , 'Data-First Synchronization' , 'Reverse Engineering and Query Optimization' , 20 , 100 , '2026-07-06'
EXEC AddAssignments 12 , 3 , 'Domain-Driven Design' , 'Building an E-Commerce Backend with Code-First Migrations' , 20 , 100, '2026-07-07'
EXEC AddAssignments 13 , 3 , 'Advanced Querying' , 'Implementing Efficient Eager, Lazy, and Explicit Loading' , 20 , 100 , '2026-07-08'
EXEC AddAssignments 14 , 3 , 'Architectural Separation' , 'Implementing the Repository Pattern with DbContext' , 20 , 100 , '2026-07-09'
EXEC AddAssignments 15 , 3 , 'Enterprise Performance Tuning' , 'Tracking Management and Global Query Filtering' , 20 , 100 , '2026-07-10'

EXEC AddAssignments 16 , 4 , 'RestAPI' , 'Introduction to RestAPI' , 20 , 100 , '2026-07-11'
EXEC AddAssignments 17 , 4 , 'Post' , 'Sends data to the server' , 20 ,100 , '2026-07-12'
EXEC AddAssignments 18 , 4 , 'GET' , 'Requesting data from the server' , 20 , 100 , '2026-07-13'
EXEC AddAssignments 19 , 4 , 'Patch' , 'Edit data on DB' , 20 , 100 , '2026-07-14'
EXEC AddAssignments 20 , 4 , 'Delete' , 'instruct a server to remove a specific resource' , 20 , 100 , '2026-07-15'

EXEC AddAssignments 21 , 5 , 'Components' , 'Reusable code' , 20 , 100 , '2026-07-16'
EXEC AddAssignments 22 , 5 , 'Props' , 'Data from parent' , 20 , 100 , '2026-07-17'
EXEC AddAssignments 23 , 5 , 'Drilling' , 'When the props data drilling in the tree Parent-Child' , 20 , 100 , '2026-07-18'
EXEC AddAssignments 24 , 5 , 'State' , 'store and manage dynamic data that influences their behavior and appearance' , 20 , 100 , '2026-07-19'
EXEC AddAssignments 25 , 5 , 'Hooks' , 'JavaScript function provided by the React library' , 20 , 100 , '2026-07-20'

/*Write SQL Statements to INSERT at least 10 comments for random assignments.*/
ALTER TABLE Comments
ADD CONSTRAINT FK_Comments_Assignments
FOREIGN KEY (AssignmentId) 
REFERENCES Assignments(AssignmentId)

ALTER TABLE Comments
ADD CONSTRAINT FK_Comments_Users
FOREIGN KEY (CreatedByUserId) 
REFERENCES Users(UserId)

CREATE PROCEDURE AddComments
	@CommentId INT,
	@AssignmentId INT,
	@CreatedByUserId  INT,
	@CreatedDate DateTime,
	@CommentContent TEXT

AS BEGIN
	INSERT INTO Comments(CommentId , AssignmentId , CreatedByUserId , CreatedDate , CommentContent)
	VALUES(@CommentId , @AssignmentId , @CreatedByUserId , @CreatedDate , @CommentContent)
END;

EXEC AddComments 1 , 1 , 1 , '2026-08-11' , 'First Comment'
EXEC AddComments 2 , 4 , 4 , '2026-08-12' , 'Second Comment'
EXEC AddComments 3 , 7 , 5 , '2026-08-24' , 'Third Comment'
EXEC AddComments 4 , 8 , 3 , '2026-08-22' , 'Fourth Comment'
EXEC AddComments 5 , 11 , 2 , '2026-08-17' , 'Fifth Comment'
EXEC AddComments 6 , 13 , 9 , '2026-08-27' , 'Sixth Comment'
EXEC AddComments 7 , 15 , 2 , '2026-08-21' , 'Seventh Comment'
EXEC AddComments 8 , 16 , 11 , '2026-08-13' , 'Eigth Comment'
EXEC AddComments 9 , 23 , 6 , '2026-08-17' , 'Ninth Comment'
EXEC AddComments 10 , 25 , 1 , '2026-08-19' , 'Last Comment'

/*Write SQL Statement to INSERT random grades for all students for every assignment.*/
ALTER TABLE Grades
ADD CONSTRAINT FK_Grades_Assignments
FOREIGN KEY (AssignmentId) 
REFERENCES Assignments(AssignmentId)

ALTER TABLE Grades
ADD CONSTRAINT FK_Grades_Users
FOREIGN KEY (StudentId) 
REFERENCES Users(UserId)

INSERT INTO Grades (GradeId, AssignmentId, StudentId, Grade)
SELECT
    ROW_NUMBER() OVER (
		ORDER BY A.AssignmentId, U.UserId),
    A.AssignmentId,
    U.UserId,
    ABS(CHECKSUM(NEWID())) % 101
FROM Assignments A
CROSS JOIN Users U
WHERE U.Role = 'Student';


/*Write SQL Statement to INSERT Syllabus for each Course.*/

INSERT INTO Syllabus(
	SyllabusId, 
	Description
)
SELECT CourseId,
CONCAT('Syllabus for ', CourseName)
FROM Courses;

UPDATE Courses SET SyllabusId = CourseId;

/*Write a SELECT query to list all courses.*/

SELECT * FROM Courses

/*Write a SELECT query to find all assignments for a specific course.*/

SELECT AssignmentTitle , CourseName
FROM Assignments a
JOIN Courses c ON (a.CourseId = c.CourseId) AND (a.CourseId = 5)

/*Write a SELECT query to find all students (users with the role 'Student').*/

SELECT *
FROM Users
WHERE Role = 'Student'

/*Write an UPDATE statement to change a student's role*/

UPDATE Users
SET Role = 'Intern'
WHERE UserId = 1

/*Write a DELETE statement to remove a specific comment.*/
DELETE Comments
Where CommentId = 1

/*Write a query to list all students along with their grades for a specific course.*/
SELECT UserName ,a.CourseId , a.AssignmentId, Grade
FROM Users u
JOIN Grades g ON u.UserId = g.StudentId
JOIN Assignments a ON g.AssignmentId = a.AssignmentId
WHERE Role = 'Student' AND a.CourseId = 1

/*Write a query to calculate the average grade for each course.*/
SELECT CourseName ,AVG(Grade) AS average_grade
FROM Courses c
JOIN Assignments a ON c.CourseId = a.CourseId
JOIN Grades g ON g.AssignmentId = a.AssignmentId  
GROUP BY CourseName

/*Write a query to list all courses with their respective syllabuses*/
SELECT  CourseId , CourseName , c.SyllabusId , Description
FROM Courses c
JOIN Syllabus s ON s.SyllabusId = c.SyllabusId

/*Write a query to find all comments for a specific course.*/
SELECT c.CourseName ,CommentContent
FROM Comments cm
JOIN Assignments a ON cm.AssignmentId = a.AssignmentId
JOIN Courses c ON c.CourseId = a.CourseId
WHERE c.CourseId = 2

/*Create a stored procedure to add a new student.*/
 -- I did it when I added Users in line 54 review it

/*Create a stored procedure to add a new Assignment. Make sure the course assignments weights don’t go above 100.*/

 /* I did it when I added Users in line 144 but I should add
 SELECT @TotalWeight = SUM(Weight)
 IF (@TotalWeight + @Weight) > 100
    BEGIN
        PRINT 'Course assignment weights cannot exceed 100.';
        RETURN;
 */

/*Calculate function to calculate the Student Grade in a Course. Return ‘A', 'B’, etc…*/
CREATE FUNCTION CalculateGradeInCourse(
	@StudentId INT,
	@CourseId INT
)
RETURNS VARCHAR(1) 
AS BEGIN
	DECLARE @final_grade FLOAT;
	DECLARE @Letter VARCHAR(1);

	SELECT @final_grade = SUM((g.Grade / 100.0)* a.Weight)
	FROM Users u
	JOIN Grades g ON g.StudentId = u.UserId
	JOIN Assignments a ON a.AssignmentId = g.AssignmentId
	JOIN Courses c ON c.CourseId = a.CourseId
	WHERE Role = 'Student' AND u.UserId = @StudentId AND c.CourseId = @CourseId
	GROUP BY UserId

	IF(@final_grade >= 90) SET @Letter = 'A'
	ELSE IF(@final_grade >= 75) SET @Letter = 'B'
	ELSE IF(@final_grade >= 60) SET @Letter = 'C'
	ELSE IF(@final_grade >= 50) SET @Letter = 'D'
	ELSE SET @Letter = 'F'

	RETURN @Letter
	
END; 

--SELECT dbo.CalculateGradeInCourse(2 , 3) AS FinalGrade;

/*Create a function to calculate the GPA of a student.*/

CREATE FUNCTION CalculateGPA(
	@StudentId INT
)
RETURNS FLOAT
AS BEGIN
	DECLARE @GPA FLOAT;

	SELECT  @GPA = SUM((g.Grade / 100.0)* a.Weight) / COUNT(DISTINCT c.CourseId)
	FROM Users u
	JOIN Grades g ON g.StudentId = u.UserId
	JOIN Assignments a ON a.AssignmentId = g.AssignmentId
	JOIN Courses c ON c.CourseId = a.CourseId
	WHERE Role = 'Student' AND u.UserId = @StudentId
	GROUP BY UserId

	RETURN (@GPA / 25.0)
	
END; 

--SELECT dbo.CalculateGPA(7) AS GPA;