namespace Forum.App.Factories
{
	using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    public class CommandFactory : ICommandFactory
	{
        private IServiceProvider serviceProvider;

        public CommandFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

		public ICommand CreateCommand(string commandName)
		{
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name == commandName + "Command");

            if(commandType == null)
            {
                throw new ArgumentException($"Command {commandName} not found!");
            }
            if(!typeof(ICommand).IsAssignableFrom(commandType))
            {
                throw new ArgumentException($"Command {commandName} is not a command!");
            }

            ParameterInfo[] parameters = commandType.GetConstructors().FirstOrDefault().GetParameters();
            object[] parametersToPass = new object[parameters.Length];

            for (int i = 0; i < parametersToPass.Length; i++)
            {
                parametersToPass[i] = this.serviceProvider.GetService(parameters[i].ParameterType);
            }

            ICommand command = (ICommand)Activator.CreateInstance(commandType, parametersToPass);

            return command;
		}
	}
}
