namespace _03BarracksFactory.Core
{
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            Type type = Type.GetType($"_03BarracksFactory.Core.Commands.{commandName[0].ToString().ToUpper() + commandName.Substring(1)}");

            FieldInfo[] fieldsToInject = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(x => x.CustomAttributes.Any(y => y.AttributeType.Name == "InjectAttribute")).ToArray();

            object[] argsToInject = fieldsToInject.Select(x => serviceProvider.GetService(x.FieldType)).ToArray();

            IExecutable command = (IExecutable)Activator.CreateInstance(type, new object[] { data }.Concat(argsToInject).ToArray());

            return command;
        }
    }
}
