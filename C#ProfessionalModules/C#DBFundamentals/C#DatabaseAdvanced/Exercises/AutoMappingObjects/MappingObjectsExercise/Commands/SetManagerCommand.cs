using MappingObjectsExercise.Contracts.Controllers;

namespace MappingObjectsExercise.Commands
{
    public class SetManagerCommand : Command
    {
        public SetManagerCommand(IEmployeeController employeeController,
            IManagerController managerController) : base(employeeController, managerController)
        {
        }

        public override void Execute(string[] parameters)
        {
            int employeeId = int.Parse(parameters[1]);
            int managerId = int.Parse(parameters[2]);

            this.managerController.SetManager(employeeId, managerId);
        }
    }
}
