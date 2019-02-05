namespace P01_StudentSystem.Data.Models
{
    public class StudentCourse
    {
        public int StudentId { get; private set; }
        public Student Student { get; private set; }

        public int CourseId { get; private set; }
        public Course Course { get; private set; }
    }
}
