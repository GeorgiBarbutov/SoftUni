using P01_StudentSystem.Data.Models.Enums;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        public int ResourceId { get; private set; }

        public string Name { get; private set; }

        public string Url { get; private set; }

        public ResourceType ResourceType { get; private set; }

        public int CourseId { get; private set; }
        public Course Course { get; private set; }
    }
}
