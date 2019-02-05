using System;
using System.Collections.Generic;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        public Course()
        {
            this.HomeworkSubmissions = new HashSet<Homework>();
            this.StudentsEnrolled = new HashSet<StudentCourse>();
            this.Resources = new HashSet<Resource>();
        }

        public int CourseId { get; private  set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public decimal Price { get; private set; }

        public ICollection<Resource> Resources { get; private set; }

        public ICollection<Homework> HomeworkSubmissions { get; private set; }

        public ICollection<StudentCourse> StudentsEnrolled { get; private set; }
    }
}
