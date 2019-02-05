namespace Travel.Core.Commands
{
    using Travel.Core.Contracts;

    public abstract class Command : ICommand
    {
        public abstract void ExecuteCommand();
    }
}
