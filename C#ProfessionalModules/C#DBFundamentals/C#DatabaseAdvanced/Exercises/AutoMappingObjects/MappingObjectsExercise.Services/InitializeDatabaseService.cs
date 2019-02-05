using MappingObjectsExercise.Data;
using MappingObjectsExercise.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;

namespace MappingObjectsExercise.Services
{
    public class InitializeDatabaseService : IInitializeDatabaseService
    {
        private MappingObjectsExerciseContext context;

        public InitializeDatabaseService(MappingObjectsExerciseContext context)
        {
            this.context = context;
        }

        public void InitializeDatabase()
        {
            this.context.Database.Migrate();
        }
    }
}
