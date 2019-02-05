namespace _03BarracksFactory.Core.Commands
{
    using System;
    using Contracts;

    public class Fight : Command
    {
        public Fight(string[] data, IUnitFactory unitFactory, IRepository repository)
            : base(data, unitFactory, repository)
        {
        }

        public override string Execute()
        {
            Environment.Exit(0);

            return "";
        }
    }
}
