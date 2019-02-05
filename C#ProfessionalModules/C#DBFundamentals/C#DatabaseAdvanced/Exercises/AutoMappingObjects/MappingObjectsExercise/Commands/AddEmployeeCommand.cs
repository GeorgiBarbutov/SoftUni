using MappingObjectsExercise.Contracts.Controllers;
using MappingObjectsExercise.Dtos;

namespace MappingObjectsExercise.Commands
{
    public class AddEmployeeCommand : Command
    {
        public AddEmployeeCommand(IEmployeeController employeeController,
            IManagerController managerController) : base(employeeController, managerController)
        {
        }

        public override void Execute(string[] parameters)
        {
            string firstName = parameters[1];
            string lastName = parameters[2];
            decimal salary = decimal.Parse(parameters[3]);

            EmployeeDto employeeDto = new EmployeeDto()
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            this.employeeController.AddEmployee(employeeDto);
        }
    }
}
