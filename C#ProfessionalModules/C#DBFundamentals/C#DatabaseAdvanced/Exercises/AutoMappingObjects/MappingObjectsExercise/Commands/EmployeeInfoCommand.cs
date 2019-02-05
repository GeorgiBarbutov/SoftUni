using MappingObjectsExercise.Contracts.Controllers;
using System;

namespace MappingObjectsExercise.Commands
{
    public class EmployeeInfoCommand : Command
    {
        public EmployeeInfoCommand(IEmployeeController employeeController,
            IManagerController managerController) : base(employeeController, managerController)
        {
        }

        public override void Execute(string[] parameters)
        {
            int employeeId = int.Parse(parameters[1]);

            var employeeDto = this.employeeController.GetEmployeeInfo(employeeId);

            Console.WriteLine($"ID: {employeeDto.Id} - {employeeDto.FirstName}" +
                                 $" {employeeDto.LastName} - ${employeeDto.Salary:f2}");
        }
    }
}
