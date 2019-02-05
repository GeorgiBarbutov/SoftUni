namespace _03BarracksFactory.Core.Commands
{
    using Contracts;

    public class Report : Command
    {
        public Report(string[] data, IUnitFactory unitFactory, IRepository repository) 
            : base(data, unitFactory, repository)
        {
        }

        public override string Execute()
        {
            string output = this.Repository.Statistics;
            return output;
        }
    }
}
