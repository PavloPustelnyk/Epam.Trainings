using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epam.Training_8
{
    public class School
    {
        public const int MaxStudentId = 99999;
        public const int MinStudentId = 10000;

        private List<Student> Students { get; set; } = new List<Student>();
        private List<Course> Courses { get; set; } = new List<Course>();

        public void AddCourse(Course course)
        {
            if(Courses.Where(c => c.CourseName == course.CourseName).Count() > 0)
            {
                throw new ArgumentException($"Course with name '{course.CourseName}' already exist.");
            }
            else if (string.IsNullOrEmpty(course.CourseName))
            {
                throw new ArgumentException($"Course name cannot be empty.");
            }
            else
            {
                Courses.Add(course);
            }
        }

        public void RegisterStudentOnCourse(int studentId, string courseName)
        {
            var course = Courses.Where(c => c.CourseName == courseName);
            var student = Students.Where(s => s.Id == studentId);

            if (student.Count() == 0)
            {
                throw new ArgumentException($"Student with id '{studentId}' does not exist.");
            }
            else if (course.Count() == 0)
            {
                throw new ArgumentException($"Course with name '{courseName}' does not exist.");
            }
            else if (course.First().GetAllStudents().Where(s => s.Id == studentId).Count() > 0)
            {
                throw new ArgumentException($"Student with id '{studentId}' is " +
                    $"already registered on course '{courseName}'.");
            }
            else
            {
                course.First().AddStudent(student.First());
            }
        }

        public void UnregisterStudentFromCourse(int studentId, string courseName)
        {
            var course = Courses.Where(c => c.CourseName == courseName);
            var student = Students.Where(s => s.Id == studentId);

            if (student.Count() == 0)
            {
                throw new ArgumentException($"Student with id '{studentId}' does not exist.");
            }
            else if (course.Count() == 0)
            {
                throw new ArgumentException($"Course with name '{courseName}' does not exist.");
            }
            else if (course.First().GetAllStudents().Where(s => s.Id == studentId).Count() > 0)
            {
                throw new ArgumentException($"Student with id '{studentId}' is " +
                    $"already registered on course '{courseName}'.");
            }
            else
            {
                course.First().DeleteStudent(student.First().Id);
            }
        }

        public void AddStudent(Student student)
        {
            if (VerifyStudent(student))
            {
                Students.Add(student);
            }
            else
            {
                throw new ArgumentException($"Wrong student parameters.");
            }
        }

        private bool VerifyStudent(Student student)
        {
            if (string.IsNullOrEmpty(student.FirstName) || string.IsNullOrEmpty(student.LastName) ||
                student.Id < MinStudentId || student.Id > MaxStudentId)
            {
                return false;
            }
            else if (Students.Where(s => s.Id == student.Id).Count() > 0)
            {
                return false;
            }

            return true;
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return Students;
        }

        public Student GetStudent(int id)
        {
            return Students.Where(s => s.Id == id).FirstOrDefault();
        }
    }
}
