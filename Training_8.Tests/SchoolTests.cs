using Epam.Training_8;
using NUnit.Framework;
using System;
using System.Linq;

namespace Training_8.Tests
{
    public class SchoolTests
    {
        School school;

        [SetUp]
        public void Setup()
        {
            school = new School();
        }

        [Test]
        public void Verify_Max_Number_Of_Students_On_Course()
        {
            Course course = new Course();

            int id = School.MinStudentId;
            for (int i = 0; i < Course.MaxStudentCount; ++i, ++id)
            {
                course.AddStudent(new Student 
                { 
                    Id = id, 
                    FirstName = "test", 
                    LastName = "test" 
                });
            }

            var student = new Student
            {
                Id = id,
                FirstName = "test",
                LastName = "test"
            };

            Assert.Throws<ArgumentException>(() => course.AddStudent(student));
            Assert.AreEqual(Course.MaxStudentCount, course.GetAllStudents().Count());
        }

        [Test]
        public void Can_Add_Student_With_Nonunique_Id()
        {
            Student firstStudent = new Student
            {
                Id = School.MinStudentId,
                FirstName = "test",
                LastName = "test"
            };

            Student secondStudent = new Student
            {
                Id = School.MinStudentId,
                FirstName = "test2",
                LastName = "test2"
            };

            Student thirdStudent = new Student
            {
                Id = School.MinStudentId + 1,
                FirstName = "test",
                LastName = "test"
            };

            school.AddStudent(firstStudent);
            school.AddStudent(thirdStudent);

            Assert.Throws<ArgumentException>(() => school.AddStudent(secondStudent));
            Assert.AreEqual(0, school.GetAllStudents().GroupBy(s => s.Id).Where(g => g.Count() > 1).Count());
        }

        [Test]
        public void Can_Student_Name_Be_Empty()
        {
            Student student = new Student
            {
                Id = School.MaxStudentId,
                FirstName = "",
                LastName = ""
            };

            Assert.Throws<ArgumentException>(() => school.AddStudent(student));
        }
    }
}