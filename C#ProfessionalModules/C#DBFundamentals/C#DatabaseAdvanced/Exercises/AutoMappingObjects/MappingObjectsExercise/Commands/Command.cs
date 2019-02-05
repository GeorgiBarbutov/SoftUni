using MappingObjectsExercise.Contracts.Commands;
using MappingObjectsExercise.Contracts.Controllers;

namespace MappingObjectsExercise.Commands
{
    public abstract class Command : ICommand
    {
        protected IEmployeeController employeeController;
        protected IManagerController managerController;

        public Command(IEmployeeController employeeController, IManagerController managerController)
        {
            this.employeeController = employeeController;
            this.managerController = managerController;
        }

        public abstract void Execute(string[] parameters);
    }
}
