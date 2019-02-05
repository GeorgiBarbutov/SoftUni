namespace _03BarracksFactory.Core.Commands
{
    using Contracts;

    public class Report : Command
    {
        [Inject]
        private IRepository repository;

        public Report(string[] data, IRepository repository) 
            : base(data)
        {
            this.repository = repository;
        }

        public override string Execute()
        {
            string output = this.repository.Statistics;
            return output;
        }
    }
}
