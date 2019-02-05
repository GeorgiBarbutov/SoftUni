using MappingObjectsExercise.Contracts.Commands;

namespace MappingObjectsExercise.Contracts.Factories
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandType);
    }
}
