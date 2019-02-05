namespace _03BarracksFactory.Core
{
    using Contracts;
    using System;

    class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Type type = Type.GetType($"_03BarracksFactory.Core.Commands.{commandName[0].ToString().ToUpper() + commandName.Substring(1)}");
            IExecutable command = (IExecutable)Activator.CreateInstance(type, new object[] { data, this.unitFactory, this.repository });

            return command;
        }
    }
}
