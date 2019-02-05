using MappingObjectsExercise.Contracts.Controllers;

namespace MappingObjectsExercise.Commands
{
    public class SetAddressCommand : Command
    {
        public SetAddressCommand(IEmployeeController employeeController, 
            IManagerController managerController) : base(employeeController, managerController)
        {
        }

        public override void Execute(string[] parameters)
        {
            int employeeId = int.Parse(parameters[1]);

            string address = parameters[2];

            this.employeeController.SetAddress(employeeId, address);
        }
    }
}
