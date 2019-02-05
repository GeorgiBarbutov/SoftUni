using System.Collections.Generic;

namespace MappingObjectsExercise.Dtos
{
    public class ManagerDto
    {
        public ManagerDto()
        {
            this.EmployeeDtos = new HashSet<EmployeeDto>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<EmployeeDto> EmployeeDtos { get; set; }

        public int Count => EmployeeDtos.Count;
    }
}
