using MappingObjectsExercise.Contracts;
using MappingObjectsExercise.Contracts.Commands;
using MappingObjectsExercise.Contracts.Factories;
using MappingObjectsExercise.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MappingObjectsExercise
{
    public class Engine : IEngine
    {
        private IServiceProvider serviceProvider;

        public Engine(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public void Run()
        {
            var commandFactory = this.serviceProvider.GetService<ICommandFactory>();

            var initializer = this.serviceProvider.GetService<IInitializeDatabaseService>();
            initializer.InitializeDatabase();

            while(true)
            {
                string[] commandInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string commandType = commandInput[0] + "Command";

                if(commandInput[0] == "Exit")
                {
                    break;
                }

                ICommand command = commandFactory.CreateCommand(commandType);

                command.Execute(commandInput);
            }
        }
    }
}
