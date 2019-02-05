using AutoMapper;
using MappingObjectsExercise.Contracts;
using MappingObjectsExercise.Contracts.Controllers;
using MappingObjectsExercise.Contracts.Factories;
using MappingObjectsExercise.Controllers;
using MappingObjectsExercise.Data;
using MappingObjectsExercise.Factories;
using MappingObjectsExercise.Services;
using MappingObjectsExercise.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace MappingObjectsExercise
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var services = ConfigureServices();

            IEngine engine = new Engine(services);

            engine.Run();
        }

        private static ServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddDbContext<MappingObjectsExerciseContext>();
            serviceCollection.AddTransient<IInitializeDatabaseService, InitializeDatabaseService>();
            serviceCollection.AddTransient<ICommandFactory, CommandFactory>();
            serviceCollection.AddTransient<IEmployeeController, EmployeeController>();
            serviceCollection.AddTransient<IManagerController, ManagerController>();
            serviceCollection.AddAutoMapper(conf => conf.AddProfile<MapperProfile>());

            return serviceCollection.BuildServiceProvider();
        }
    }
}
