using MappingObjectsExercise.Contracts.Commands;
using MappingObjectsExercise.Contracts.Factories;
using System;
using System.Linq;
using System.Reflection;

namespace MappingObjectsExercise.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private IServiceProvider serviceProvider;

        public CommandFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public ICommand CreateCommand(string commandType)
        {
            Type type = Assembly.GetExecutingAssembly().GetType("MappingObjectsExercise.Commands." + commandType);

            var parameterTypes = type.GetConstructors().First()
                                                       .GetParameters()
                                                       .Select(p => p.ParameterType)
                                                       .ToArray();

            var typesToInject = new object[parameterTypes.Length];
            for (int i = 0; i < parameterTypes.Length; i++)
            {
                typesToInject[i] = this.serviceProvider.GetService(parameterTypes[i]);
            }

            var command = (ICommand)Activator.CreateInstance(type, typesToInject);

            return command;
        }
    }
}
