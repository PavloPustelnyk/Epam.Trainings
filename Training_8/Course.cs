using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epam.Training_8
{
    public class Course
    {
        public const int MaxStudentCount = 30;
        public const int MaxStudentId = 99999;
        public const int MinStudentId = 10000;

        public string CourseName { get; set; }

        private List<Student> Students { get; set; } = new List<Student>();

        public void AddStudent(Student student)
        {
            if (!VerifyStudent(student))
            {
                throw new ArgumentException($"Wrong student parameters.");
            }
            else if (Students.Count >= MaxStudentCount)
            {
                throw new ArgumentException("Course is full.");
            }
            else
            {
                Students.Add(student);
            }
        }

        public void DeleteStudent(int studentId)
        {
            Students.RemoveAll(s => s.Id == studentId);
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
