using System;
using System.Collections.Generic;
using System.Text;

namespace MappingObjectsExercise.Contracts.Commands
{
    public interface ICommand
    {
        void Execute(string[] parameters);
    }
}
