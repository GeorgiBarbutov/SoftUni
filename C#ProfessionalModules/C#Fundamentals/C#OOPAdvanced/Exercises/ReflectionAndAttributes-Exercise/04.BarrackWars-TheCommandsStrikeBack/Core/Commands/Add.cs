namespace _03BarracksFactory.Core.Commands
{
    using Contracts;

    public class Add : Command
    {
        public Add(string[] data, IUnitFactory unitFactory, IRepository repository)
            : base(data, unitFactory, repository)
        {
        }

        public override string Execute()
        {
            string unitType = this.Data[1];
            IUnit unitToAdd = this.UnitFactory.CreateUnit(unitType);
            this.Repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
