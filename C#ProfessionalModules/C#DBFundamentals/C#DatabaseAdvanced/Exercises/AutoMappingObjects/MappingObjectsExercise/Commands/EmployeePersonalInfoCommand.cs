using MappingObjectsExercise.Contracts.Controllers;
using System;

namespace MappingObjectsExercise.Commands
{
    public class EmployeePersonalInfoCommand : Command
    {
        public EmployeePersonalInfoCommand(IEmployeeController employeeController,
            IManagerController managerController) : base(employeeController, managerController)
        {
        }

        public override void Execute(string[] parameters)
        {
            int employeeId = int.Parse(parameters[1]);

            var employeePersonalInfoDto = this.employeeController.GetEmployeePersonalInfo(employeeId);

            Console.WriteLine($"ID: {employeePersonalInfoDto.Id} - {employeePersonalInfoDto.FirstName} " +
                              $"{employeePersonalInfoDto.LastName} - ${employeePersonalInfoDto.Salary:f2}");

            if (employeePersonalInfoDto.BirthDate == null)
            {
                Console.WriteLine($"Birtday: no info");
            }
            else
            {
                Console.WriteLine($"Birtday: {employeePersonalInfoDto.BirthDate.Value.Day}-" +
                              $"{employeePersonalInfoDto.BirthDate.Value.Month}-" +
                              $"{employeePersonalInfoDto.BirthDate.Value.Year}");
            }

            if (employeePersonalInfoDto.Address == null)
            {
                Console.WriteLine($"Address: no info");
            }
            else
            {
                Console.WriteLine($"Address: {employeePersonalInfoDto.Address}");
            }
        }
    }
}
