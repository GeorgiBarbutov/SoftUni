using System;
using System.Collections.Generic;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        public Student()
        {
            this.HomeworkSubmissions = new HashSet<Homework>();
            this.CourseEnrollments = new HashSet<StudentCourse>();
        }

        public int StudentId { get; private set; }

        public string Name { get; private set; }

        public string PhoneNumber { get; private set; }

        public DateTime RegisteredOn { get; private set; }

        public DateTime? Birthday { get; private set; }

        public ICollection<Homework> HomeworkSubmissions { get; private set; }

        public ICollection<StudentCourse> CourseEnrollments { get; private set; }
    }
}
