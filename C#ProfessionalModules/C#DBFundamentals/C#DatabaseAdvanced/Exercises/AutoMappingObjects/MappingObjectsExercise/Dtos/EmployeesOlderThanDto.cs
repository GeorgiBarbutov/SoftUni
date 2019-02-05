using System.ComponentModel;

namespace MappingObjectsExercise.Dtos
{
    public class EmployeesOlderThanDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public string ManagerName { get; set; }
    }
}
