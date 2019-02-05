using MappingObjectsExercise.Contracts.Controllers;
using System;

namespace MappingObjectsExercise.Commands
{
    public class ManagerInfoCommand : Command
    {
        public ManagerInfoCommand(IEmployeeController employeeController, 
            IManagerController managerController) : base(employeeController, managerController)
        {
        }

        public override void Execute(string[] parameters)
        {
            int employeeId = int.Parse(parameters[1]);

            var managerDto = this.managerController.GetManagerInfo(employeeId);

            Console.WriteLine($"{managerDto.FirstName} {managerDto.LastName} | Employees: {managerDto.Count}");

            foreach (var employee in managerDto.EmployeeDtos)
            {
                Console.WriteLine($"    - {employee.FirstName} {employee.LastName} - ${employee.Salary:f2}");
            }
        }
    }
}
