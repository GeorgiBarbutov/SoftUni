namespace _03BarracksFactory.Core.Commands
{
    using Contracts;
    using System;

    public class Retire : Command
    {
        public Retire(string[] data, IUnitFactory unitFactory, IRepository repository)
            : base(data, unitFactory, repository)
        {
        }

        public override string Execute()
        {
            this.Repository.RemoveUnit(this.Data[1]);
            string output = $"{this.Data[1]} retired!";

            return output;
        }
    }
}
