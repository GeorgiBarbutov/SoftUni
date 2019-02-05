using MappingObjectsExercise.Contracts.Controllers;
using System;

namespace MappingObjectsExercise.Commands
{
    public class SetBirthdayCommand : Command
    {
        public SetBirthdayCommand(IEmployeeController employeeController, 
            IManagerController managerController) : base(employeeController, managerController)
        {
        }

        public override void Execute(string[] parameters)
        {
            int employeeId = int.Parse(parameters[1]);
            DateTime date = new DateTime(int.Parse(parameters[2].Split("-")[2]), int.Parse(parameters[2].Split("-")[1]), int.Parse(parameters[2].Split("-")[0]));

            this.employeeController.SetBirthday(employeeId, date);
        }
    }
}
