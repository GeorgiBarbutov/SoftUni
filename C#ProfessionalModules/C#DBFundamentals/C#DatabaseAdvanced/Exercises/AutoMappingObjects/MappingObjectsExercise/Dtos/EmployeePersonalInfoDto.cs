using System;

namespace MappingObjectsExercise.Dtos
{
    public class EmployeePersonalInfoDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal Salary { get; set; }

        public string Address { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
