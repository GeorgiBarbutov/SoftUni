using MappingObjectsExercise.Contracts.Controllers;
using System;

namespace MappingObjectsExercise.Commands
{
    public class ListEmployeesOlderThanCommand : Command
    {
        public ListEmployeesOlderThanCommand(IEmployeeController employeeController, 
            IManagerController managerController) : base(employeeController, managerController)
        {
        }

        public override void Execute(string[] parameters)
        {
            int age = int.Parse(parameters[1]);

            var employees = this.employeeController.ListEmployeesOlderThan(age);

            foreach (var employee in employees)
            {
                if (employee.ManagerName == null)
                {
                    Console.WriteLine($"{employee.FirstName} {employee.LastName} - ${employee.Salary:f2} - " +
                    $"Manager: [no manager]");
                }
                else
                {
                    Console.WriteLine($"{employee.FirstName} {employee.LastName} - ${employee.Salary:f2} - " +
                        $"Manager: {employee.ManagerName}");
                }
            }
        }
    }
}
