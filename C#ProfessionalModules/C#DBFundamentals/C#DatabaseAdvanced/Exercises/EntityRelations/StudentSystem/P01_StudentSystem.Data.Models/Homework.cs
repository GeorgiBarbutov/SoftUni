using P01_StudentSystem.Data.Models.Enums;
using System;

namespace P01_StudentSystem.Data.Models
{
    public class Homework
    {
        public int HomeworkId { get; private set; }

        public string Content { get; private set; }

        public ContentType ContentType { get; private set; }

        public DateTime SubmissionTime { get; private set; }

        public int StudentId { get; private set; }
        public Student Student { get; private set; }

        public int CourseId { get; private set; }
        public Course Course { get; private set; }
    }
}
